<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl" exclude-result-prefixes="xd"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xmlns:wqx="http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/"
    xmlns:wml11="http://www.cuahsi.org/waterML/1.1/"
    xmlns:wml10="http://www.cuahsi.org/waterML/1.0/" xmlns:gml="http://www.opengis.net/gml/3.2"
    xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:om="http://www.opengis.net/om/2.0"
    xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:sa="http://www.opengis.net/sampling/2.0"
    xmlns:sams="http://www.opengis.net/samplingSpatial/2.0" 
    
    version="1.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Oct 20, 2011</xd:p>
            <xd:p><xd:b>Author:</xd:b> valentin</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
    <!-- 
        xmlns:wqxo="http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/"
        xsi:schemaLocation="http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/ http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/index.xsd"
        
        Logic:
        Pass in expected variable names
        exact match?
        for each /WQX/Organization
        Get the org info
              OrganizationDescription/OrganizationIdentifier
              OrganizationDescription/OrganizationFormalName
              for each distinct ( Activity/MonitoringLocation/MonitoringLocationIdentifier)
               site information
                 MonitoringLocation/MonitoringLocationIdentifier
                ActivityDescription
                ActivityDescription/ActivityStartDate
                ActivityDescription/ActivityStartTime  
                (validate it as a time: ^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$ 
                 ActivityDescription/ActivityMediaName
                 For each characteristic in Result 
                    (Activity/MonitoringLocation/MonitoringLocationIdentifier[distinct site]/../../Result/ResultDescription/CharacteristicName 
                 variableName =ResultDescription/CharacteristicName
                 does it match the expected (or perhaps use an xpath)
                 comments= ResultDescription/ResultCommentText
                 methodCode=ResultAnalyticalMethod/MethodIdentifier
                 methodName=ResultAnalyticalMethod/MethodIdentifierContext
                 methodDescription=ResultLabInformation/ResultLaboratoryCommentCode
                 labName=ResultLabInformation/ResultLaboratoryCommentCode
                 detectionQuantitationLimit=ResultLabInformation/ResultDetectionQuantitationLimit
             ResultDescription/ResultMeasure
                 value = measure.SelectSingleNode("ResultMeasureValue").InnerText.Trim();
                 unitCode = measure.SelectSingleNode("MeasureUnitCode").InnerText.Trim();
                 qualifierCode = measure.SelectSingleNode("MeasureQualifierCode").InnerText.Trim();
                 if (String.IsNullOrEmpty(value))
                 {
                 value = "-9999";
        }
    -->
    
    <!-- TODO 
        Proceedure
        Org to Metadata Element
        Dupliate code in result... xsl:choose... reduce
        Improve result
        option FOI as link to xslt transform of Station
        TimeZone conversion, more of them
     -->
    <xsl:include href="wqxSiteResultToWml1_1_siteInfoType.xsl"/>
    <xsl:include href="WqxToWaterML1_1_Variable.xsl"/>
    <xsl:variable name="siteUrl">http://qwwebservices.usgs.gov/Station/search?siteid=</xsl:variable>
    <xsl:variable name="resultUrl">http://qwwebservices.usgs.gov/Result/search?siteid=</xsl:variable>
    <xsl:variable name="currentDateTime">2099-10-19T00:00:00Z</xsl:variable>
    <xsl:variable name="vocabulary">UknownWQXVocab</xsl:variable>
    <xsl:variable name="network">UnknownWQX</xsl:variable>
    <!-- what did you call this with -->
    <xsl:variable name="site">2099-10-19T00:00:00Z</xsl:variable>
    <xsl:variable name="variable">2099-10-19T00:00:00Z</xsl:variable>
    <xsl:variable name="startDate">2099-10-19T00:00:00Z</xsl:variable>
    <xsl:variable name="endDate">2099-10-19T00:00:00Z</xsl:variable>
    
    <xsl:variable name="debug">false</xsl:variable>
    <!-- otehr query params: characteristicName, pCode, startDateLo, startDateHi, sampleMedia
    -->
    <xsl:namespace-alias stylesheet-prefix="#default" result-prefix="wqx"/>

    <xsl:output method="xml" indent="yes"/>
    <!-- old wqx from epa <xsl:key name="siteid" match="wqx:Activity"
       use="wqx:MonitoringLocation/wqx:MonitoringLocationIdentifier"/>
   -->
    <!-- wqx from nwisepa -->
    <xsl:key name="siteid" match="wqx:Activity"
        use="wqx:ActivityDescription/wqx:MonitoringLocationIdentifier"/>
    <xsl:key name="charName" match="wqx:Activity/wqx:Result/wqx:ResultDescription/wqx:CharacteristicName"
        use="text()"/>
    <xsl:key name="measureUnitsCode" match="wqx:Activity/wqx:Result/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode"
        use="text()"/>
    
    <xsl:template match="//wqx:WQX">
        <wml11:timeSeriesResponse  xmlns:gml="http://www.opengis.net/gml/3.2"
            xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:om="http://www.opengis.net/om/2.0"
            xmlns:xlink="http://www.w3.org/1999/xlink"
            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
            xmlns:wml11="http://www.cuahsi.org/waterML/1.1/"
            xmlns:wqx="http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/"
          >
    
            <wml11:queryInfo>
                <wml11:creationTime><xsl:value-of select="$currentDateTime"/></wml11:creationTime>
                <wml11:criteria MethodCalled="GetValues">
                    <wml11:parameter name="site" > <xsl:attribute name="value"><xsl:value-of select="$site"/></xsl:attribute></wml11:parameter>
                   
                    <wml11:parameter name="variable"><xsl:attribute name="value"><xsl:value-of select="$variable"/></xsl:attribute></wml11:parameter>
                    
                    <xsl:if test="$startDate != ''">
                        <wml11:parameter name="startDate" >  <xsl:attribute name="value"><xsl:value-of select="$startDate"/></xsl:attribute></wml11:parameter>
                      
                    </xsl:if>
                    <xsl:if test="$endDate != ''">
                        <wml11:parameter name="endDate">    <xsl:attribute name="value"><xsl:value-of select="$endDate"/></xsl:attribute></wml11:parameter>
                    
                    </xsl:if>
                </wml11:criteria>
            </wml11:queryInfo>
            
            

            <xsl:apply-templates/>
        </wml11:timeSeriesResponse>
    </xsl:template>
    
    
    <xsl:template match="wqx:Organization"> 
        <xsl:variable name="characteristicNames" select="wqx:Activity/wqx:Result/wqx:ResultDescription/wqx:CharacteristicName[generate-id(.) =
        generate-id(key('charName',.)[1])]">
            </xsl:variable>
            <xsl:variable name="unitCodeNames" select="wqx:Activity/wqx:Result/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode[generate-id(.) =
                generate-id(key('measureUnitsCode',.)[1])]">
        </xsl:variable>
        <xsl:for-each
            select="wqx:Activity[generate-id(.) =
                generate-id(key('siteid', wqx:ActivityDescription/wqx:MonitoringLocationIdentifier)[1])]">
            <xsl:comment>site Number = <xsl:value-of
                    select="./wqx:ActivityDescription/wqx:MonitoringLocationIdentifier"
                /></xsl:comment>
             <xsl:call-template name="renderResultsForSite">
                <xsl:with-param name="thisSite" select="./wqx:ActivityDescription/wqx:MonitoringLocationIdentifier/text()"/>
                <xsl:with-param name="Activities" select="."/>
                 <xsl:with-param name="characteristics" select="$characteristicNames"></xsl:with-param>
                 <xsl:with-param name="units" select="$unitCodeNames"></xsl:with-param>
                </xsl:call-template>
        </xsl:for-each>

    </xsl:template>
    
<xsl:template name="renderResultsForSite">
    <xsl:param name="thisSite" ></xsl:param>
    <xsl:param name="Activities" ></xsl:param>
    <xsl:param name="characteristics"></xsl:param>
    <xsl:param name="units"></xsl:param>
    <xsl:variable name="resultsBysSite"
        select="$Activities/../wqx:Activity/wqx:ActivityDescription/wqx:MonitoringLocationIdentifier[text() = $thisSite]/../../wqx:Result"/>
    <xsl:if test="$debug=true">
    <xsl:comment>result count for site  = <xsl:value-of select="count($resultsBysSite)"/></xsl:comment>
   </xsl:if>
 <xsl:for-each
        select="$characteristics">
     <xsl:if test="$debug=true">    <xsl:comment>$characteristics loop = <xsl:value-of select="."/></xsl:comment>
         </xsl:if>
        <xsl:variable name="char" select="."/>
        <xsl:call-template name="renderResultByCharacteristic">
            <xsl:with-param name="CharacteristicName" select="$char" /> 
            <xsl:with-param name="resultsByCharacteristic" 
select="$resultsBysSite/wqx:ResultDescription/wqx:CharacteristicName[text() = current()]/../.."></xsl:with-param>
            <xsl:with-param name="siteId" select="$thisSite"></xsl:with-param>
            <xsl:with-param name="units" select="$units" />
        </xsl:call-template>
    </xsl:for-each>
</xsl:template>
    
    <xsl:template name="renderResultByCharacteristicUnits">
        <xsl:param name="CharacteristicName" /> 
        <xsl:param name="resultsByCharacteristic" 
            ></xsl:param>
        <xsl:param name="siteId" ></xsl:param>
        <xsl:param name="units" ></xsl:param>
        <xsl:for-each select="$units">
            <xsl:if test="$debug=true">    <xsl:comment>$units loop = <xsl:value-of select="."/></xsl:comment>
            </xsl:if>
            <xsl:variable name="unit" select="."/>
            <xsl:call-template name="renderResultByCharacteristic">
                <xsl:with-param name="CharacteristicName" select="$CharacteristicName" /> 
                <xsl:with-param name="resultsByCharacteristic" 
                    select="$resultsByCharacteristic/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode[text() = current()]/../../.."></xsl:with-param>
                <xsl:with-param name="siteId" select="$siteId"></xsl:with-param>
                <xsl:with-param name="units" select="$unit" />
            </xsl:call-template>
        </xsl:for-each>
    </xsl:template>
    
    <xsl:template name="renderResultByCharacteristic">
        <xsl:param name="resultsByCharacteristic"></xsl:param>
        <xsl:param name="CharacteristicName"></xsl:param>
        <xsl:param name="siteId"></xsl:param>
        <xsl:if test="$debug=true">
            <xsl:comment>charascteristic = <xsl:value-of select="."/></xsl:comment>
  <!--      <xsl:variable name="resultsByCharacteristic"
            select="$resultsBysSite/wqx:ResultDescription/wqx:CharacteristicName[text() = .]/../.."/>
      -->  <xsl:comment> variable result count= <xsl:value-of select="count($resultsByCharacteristic)"
        /></xsl:comment>
            </xsl:if>
        <!--      <xsl:for-each
            select="wqx:Activity/wqx:Result[generate-id(.) =
            generate-id(key('charName', wqx:ResultDescription/wqx:CharacteristicName))]"> 
            <xsl:variable name="resultsByCharacteristic" 
            select="../../wqx:Activity/wqx:Result/wqx:ResultDescription/wqx:CharacteristicName[text() = .]/../.."/>
        -->
        <xsl:if test="count($resultsByCharacteristic) >0"  >
        <wml11:timeSeries>
            <xsl:attribute name="name">aSeries</xsl:attribute>
            <xsl:call-template name="siteInfoTypeFromUrl">
              
                    <xsl:with-param name="sitesurl" select="$siteUrl"></xsl:with-param>
                    <xsl:with-param name="siteId" select="$siteId"></xsl:with-param>
                
            </xsl:call-template>
            
            <!--  <variable>
                <variableCode vocabulary="UNDEFINEDVocab" default="true" variableID="14">USU14</variableCode>
                <variableName>Temperature</variableName>
                <valueType>Field Observation</valueType>
                <dataType>Average</dataType>
                <generalCategory>Climate</generalCategory>
                <sampleMedium>Air</sampleMedium>
                <unit>
                <unitName>degree celcius</unitName>
                <unitType>Temperature</unitType>
                <unitAbbreviation>degC</unitAbbreviation>
                <unitCode>96</unitCode>
                </unit>
                <noDataValue>-9999</noDataValue>
                <timeScale isRegular="true">
                <unit>
                <unitName>hour</unitName>
                <unitType>Time</unitType>
                <unitAbbreviation>hr</unitAbbreviation>
                <unitCode>103</unitCode>
                </unit>
                <timeSupport>1</timeSupport>
                </timeScale>
                <speciation>Not Applicable</speciation>
                </variable>
            -->
            <xsl:call-template name="ResultToVariable">
                <xsl:with-param name="aResult" select="$resultsByCharacteristic[1]"></xsl:with-param>
                <xsl:with-param name="vocabulary"><xsl:value-of select="$vocabulary"/></xsl:with-param>
            </xsl:call-template>
         
           <!--  <om:featureOfInterest> 
                <xsl:attribute name="xlink:href">
                    <xsl:value-of select="$resultsByCharacteristic[1]/../wqx:ActivityDescription/wqx:MonitoringLocationIdentifier"/>
                </xsl:attribute>
                <xsl:attribute name="xlink:title" >
                    <xsl:value-of select="$resultsByCharacteristic[1]/../wqx:ActivityDescription/wqx:MonitoringLocationIdentifier"/>
                </xsl:attribute>
              </om:featureOfInterest> 
              -->
               
            
            <wml11:values>
               
                    <xsl:call-template name="toResult">
                        <xsl:with-param name="ResultDescription"
                            select="$resultsByCharacteristic"
                        />
                    </xsl:call-template>
            
            </wml11:values>
        </wml11:timeSeries>
        </xsl:if> 
    
</xsl:template>

    
    <!--   <wml2:point>
        <wml2:TimeValuePairMeasure>
        <wml2:time>2000-01-01T00:00:00.000Z</wml2:time>
        <wml2:value>266</wml2:value>
        </wml2:TimeValuePairMeasure>
        </wml2:point>
        
        -->
    <xsl:template name="toResult">
        <xsl:param name="ResultDescription"/>
        <xsl:for-each select="$ResultDescription">
            <xsl:choose>
                <xsl:when test="wqx:ResultDescription/wqx:ResultMeasure">
                    
            <wml11:value>
              
                 <xsl:attribute name="dateTime"><xsl:call-template name="ActivityToTime" 
                        ><xsl:with-param name="anActivityDescription" 
                            select="../wqx:ActivityDescription" ></xsl:with-param></xsl:call-template>
                 </xsl:attribute>
                    
                  
                    <xsl:if
                        test="../wqx:ActivityDescription/wqx:ActivityIdentifier
                        or wqx:ResultAnalyticalMethod 
                       or wqx:ResultDescription/wqx:ResultDetectionConditionText
">
                      
                                <!-- what to do with method? -->
                                <xsl:if
                                    test="wqx:ResultAnalyticalMethod">
                                   
                                        <xsl:attribute name="methodCode">
                                            <xsl:value-of
                                                select="translate(wqx:ResultAnalyticalMethod/wqx:MethodIdentifier, &quot; &quot;, &quot;_&quot;)"
                                            />
                                        </xsl:attribute>
                                 
                                </xsl:if>
                        
                        <!-- needs to  translate to variableValueType -->
                            <!--    <xsl:if
                                    test="wqx:ResultDescription/wqx:ResultValueTypeName">
                                   
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of
                                                select="concat(translate(wqx:ResultDescription/wqx:ResultValueTypeName, &quot; &quot;, &quot;_&quot;)"
                                            />
                                        </xsl:attribute>
                                    </wml2:comment>
                                </xsl:if>
                                -->
                               
                                <xsl:if
                                    test="wqx:ResultDescription/wqx:ResultDetectionConditionText">
                                    <xsl:choose>
                                        <xsl:when test="wqx:ResultDescription/wqx:ResultDetectionConditionText = 'Not Detected'">
                                          
                                                <xsl:attribute name="censorCode">
                                                    <xsl:text>nc</xsl:text>
                               
                                                </xsl:attribute>

                                        </xsl:when>
                                        <xsl:otherwise>
                                                <xsl:attribute name="censorCode">
                                                    <xsl:value-of
                                                        select="@censorCode"/>
                                                </xsl:attribute>
                                        </xsl:otherwise>
                                    </xsl:choose>
                                    
                                </xsl:if>
                                
                                
                              <xsl:if test="../wqx:ActivityDescription/wqx:ActivityIdentifier">
                                  <xsl:attribute name="sampleCode">
                                      <xsl:value-of select="../wqx:ActivityDescription/wqx:ActivityIdentifier"/>
                                      
                                  </xsl:attribute>
                                
                                  
                                

                                    
                              </xsl:if>
                  
                
                <xsl:value-of
                    select="wqx:ResultDescription/wqx:ResultMeasure/wqx:ResultMeasureValue"
                />
                        </xsl:if>
                        <!-- need templates for samples -->
            </wml11:value>
                </xsl:when>
               <!-- need a when for non-detect  with no values-->
                
            </xsl:choose>
            
               
     
        </xsl:for-each>
    </xsl:template>
    <xsl:template name="samples">
        <xsl:variable name="sampleCode"
            select="../wqx:ActivityDescription/wqx:ActivityIdentifier"/>
        
        <wml2:relatedObservation>
            <om:ObservationContext>
                <om:role>
                    <xsl:attribute name="xlink:href"
                        >http://www.opengis.net/def/relatedObservation/WaterML/2.0/analyticalSample</xsl:attribute>
                    <xsl:attribute name="xlink:title">Analytical Sample Observation</xsl:attribute>
                </om:role>
                <xsl:comment>link if copying to browser convert and amp semicolo to an ampersand <xsl:value-of
                    select="$sampleCode"/>
                </xsl:comment>
                <om:relatedObservation>
                    <xsl:attribute name="xlink:href">
                        <xsl:value-of select="concat($resultUrl,../wqx:ActivityDescription/wqx:MonitoringLocationIdentifier,
                            '&amp;characteristicName=', wqx:ResultDescription/wqx:CharacteristicName)"/>
                    </xsl:attribute>
                    <xsl:attribute name="xlink:title">
                        <xsl:value-of select="concat('Link to org-activity with this data: ', ../wqx:ActivityDescription/wqx:ActivityIdentifier)"/>
                        
                    </xsl:attribute>
                </om:relatedObservation>
            </om:ObservationContext>
            
        </wml2:relatedObservation>  
        
    </xsl:template>
    <xsl:template name="ActivityToTime">
        <xsl:param name="anActivityDescription"></xsl:param>
        <xsl:value-of
            select="$anActivityDescription/wqx:ActivityStartDate"
        /><xsl:text>T</xsl:text>
        <xsl:value-of
            select="$anActivityDescription/wqx:ActivityStartTime/wqx:Time"
        />
        <xsl:choose>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'EDT'">-4</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'EST'">-5</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'CDT'">-5</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'CST'">-6</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'PDT'">-6</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'PST'">-7</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'MDT'">-6</xsl:when>
            <xsl:when test="$anActivityDescription/wqx:ActivityStartTime/wqx:TimeZoneCode = 'MST'">-6</xsl:when>   
        </xsl:choose>
    </xsl:template>

    <xsl:template name="minDate">
        <xsl:param name="Results"/>
        <xsl:variable name="the_min">
            <xsl:for-each select="$Results/../wqx:ActivityDescription/wqx:ActivityStartDate">
                <xsl:sort order="ascending"/>
                <xsl:if test="position()=1">
                    <xsl:value-of select="."/>
                </xsl:if>
            </xsl:for-each>
        </xsl:variable>
        <xsl:value-of select="$the_min"/>
    </xsl:template>

    <xsl:template name="maxDate">
        <xsl:param name="Results"/>
        <xsl:variable name="the_max">
            <xsl:for-each select="$Results/../wqx:ActivityDescription/wqx:ActivityStartDate">
                <xsl:sort order="descending"/>
                <xsl:if test="position()=1">
                    <xsl:value-of select="."/>
                </xsl:if>
            </xsl:for-each>
        </xsl:variable>
        <xsl:value-of select="$the_max"/>
    </xsl:template>


    
</xsl:stylesheet>
