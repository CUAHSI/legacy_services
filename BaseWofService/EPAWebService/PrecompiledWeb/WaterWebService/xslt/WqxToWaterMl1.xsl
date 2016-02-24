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
    <xsl:include href="wqxSiteResultToFoi.xsl"/>
    <xsl:variable name="siteUrl">http://qwwebservices.usgs.gov/Station/search?siteid=</xsl:variable>
    <xsl:variable name="resultUrl">http://qwwebservices.usgs.gov/Result/search?siteid=</xsl:variable>
    <xsl:variable name="currentDateTime">2099-10-19T00:00:00Z</xsl:variable>
    
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
       
    <xsl:template match="//wqx:WQX">
        <wml2:Collection  xmlns:gml="http://www.opengis.net/gml/3.2"
            xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:om="http://www.opengis.net/om/2.0"
            xmlns:xlink="http://www.w3.org/1999/xlink"
            xmlns:sa="http://www.opengis.net/sampling/2.0"
            xmlns:sams="http://www.opengis.net/samplingSpatial/2.0"
            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
          >
            <xsl:attribute name="gml:id">
                <xsl:value-of select="generate-id(.)"/>
            </xsl:attribute>
            <gml:description>WaterML2.0 generated from WQX result service</gml:description>
            <wml2:metadata>
                <wml2:DocumentMetadata >
                    <xsl:attribute name="gml:id">
                        <xsl:value-of select="generate-id(.)"/>
                    </xsl:attribute>
                    <wml2:generationDate><xsl:value-of select="$currentDateTime"/></wml2:generationDate>
                    <!--			<wml2:version></wml2:version>-->
                    <wml2:generationSystem>wqx xslt</wml2:generationSystem>
                </wml2:DocumentMetadata>
            </wml2:metadata>

            <xsl:apply-templates/>
        </wml2:Collection>
    </xsl:template>
    
    <xsl:template match="wqx:Organization"> 
        <xsl:variable name="characteristicNames" select="wqx:Activity/wqx:Result/wqx:ResultDescription/wqx:CharacteristicName[generate-id(.) =
        generate-id(key('charName',.)[1])]">
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
                </xsl:call-template>
        </xsl:for-each>

    </xsl:template>
    
<xsl:template name="renderResultsForSite">
    <xsl:param name="thisSite" ></xsl:param>
    <xsl:param name="Activities" ></xsl:param>
    <xsl:param name="characteristics"></xsl:param>
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
        <om:OM_Observation >
            <xsl:attribute name="gml:id">
                <xsl:value-of select="concat('obs-',generate-id($resultsByCharacteristic))"/>
            </xsl:attribute>
            <xsl:variable name="timeId">
                <xsl:value-of select="concat('timerange-',generate-id($resultsByCharacteristic))"/>
            </xsl:variable>
            <om:phenomenonTime>
                
                <gml:TimePeriod>
                    <xsl:attribute name="gml:id">
                        <xsl:value-of select="$timeId"/>
                    </xsl:attribute>
                    <!--                           <gml:beginPosition>2000-01-01T00:00:00Z</gml:beginPosition>
                        <gml:endPosition>2000-01-10T00:00:00Z</gml:endPosition>
                    -->
                    <gml:beginPosition>
                        <xsl:call-template name="minDate">
                            <xsl:with-param name="Results" select="$resultsByCharacteristic"/>
                        </xsl:call-template>
                    </gml:beginPosition>
                    <gml:endPosition>
                        <xsl:call-template name="maxDate">
                            <xsl:with-param name="Results" select="$resultsByCharacteristic"/>
                        </xsl:call-template>
                    </gml:endPosition>
                </gml:TimePeriod>
            </om:phenomenonTime>
            <om:resultTime>
                <gml:TimeInstant>
                    <xsl:attribute name="gml:id">
                        <xsl:value-of select="concat('resulttime-',generate-id($resultsByCharacteristic))"/>
                    </xsl:attribute>
                    <gml:timePosition>2000-01-10T00:00:00Z</gml:timePosition>
                </gml:TimeInstant>
            </om:resultTime>
            <om:procedure>
                <!-- This can also be a simple href/title procedure without detailled data -->
                <!-- wqx   <Result>
                    <ResultDescription>
                        <CharacteristicName>Temperature, air</CharacteristicName>
                        <ResultMeasure>
                            <ResultMeasureValue>33.0</ResultMeasureValue>
                            <MeasureUnitCode>deg C</MeasureUnitCode>
                        </ResultMeasure>
                        <ResultStatusIdentifier>Historical</ResultStatusIdentifier>
                        <ResultValueTypeName>Actual</ResultValueTypeName>
                        <USGSPCode>00020</USGSPCode>
                    </ResultDescription>
                    ResultAnalyticalMethod  not always preesent
                    <ResultAnalyticalMethod>
                        <MethodIdentifier>THM04</MethodIdentifier>
                        <MethodIdentifierContext>USGS</MethodIdentifierContext>
                        <MethodName>Temperature, air, thermistor</MethodName>
                        <MethodDescriptionText>USGS National Field Manual, Chapter A6.1</MethodDescriptionText>
                    </ResultAnalyticalMethod>
                </Result>
              end wqx  -->
                <wml2:ObservationProcess> 
                    <xsl:attribute name="gml:id">
                        <xsl:value-of select="concat('process-',generate-id($resultsByCharacteristic))"/>
                    </xsl:attribute>
                    <wml2:processType
                        xlink:href="http://www.opengis.net/def/processType/WaterML/2.0/Unknown"
                        xlink:title="Unknown"/>
                    <!--					<wml2:originatingProcess></wml2:originatingProcess>-->
                    <!--					<wml2:gaugeDatum></wml2:gaugeDatum>-->
                  <!--  <wml2:aggregationPeriod>P1D</wml2:aggregationPeriod> -->
                    <!--A list of the inputs used in the process. This may be a list of references to the data sets used (e.g. model input series) or a input array to an algorithm.-->
                    <!--					<wml2:processReference></wml2:processReference>-->
                    <!--Reference to an external process definition.-->
                </wml2:ObservationProcess>
            </om:procedure>
            <om:observedProperty >
            <xsl:attribute name="xlink:href">
                <xsl:value-of select="concat('#',translate($CharacteristicName,' ', ''))">
                    
                </xsl:value-of>
            </xsl:attribute>
                <xsl:attribute name="xlink:title" ><xsl:value-of select="$CharacteristicName"/></xsl:attribute>
            </om:observedProperty>
           <!--  <om:featureOfInterest> 
                <xsl:attribute name="xlink:href">
                    <xsl:value-of select="$resultsByCharacteristic[1]/../wqx:ActivityDescription/wqx:MonitoringLocationIdentifier"/>
                </xsl:attribute>
                <xsl:attribute name="xlink:title" >
                    <xsl:value-of select="$resultsByCharacteristic[1]/../wqx:ActivityDescription/wqx:MonitoringLocationIdentifier"/>
                </xsl:attribute>
              </om:featureOfInterest> 
              -->
                <xsl:call-template name="FOIFromUrl">
                    <xsl:with-param name="sitesurl" select="$siteUrl"></xsl:with-param>
                    <xsl:with-param name="siteId" select="$siteId"></xsl:with-param>
                </xsl:call-template>
            
            <om:result>
                <wml2:Timeseries >
                    <xsl:attribute name="gml:id">
                        <xsl:value-of select="concat('timeseries-',generate-id($resultsByCharacteristic))"/>
                    </xsl:attribute>
                    <wml2:temporalExtent>
                        <xsl:attribute name="xlink:href">
                            <xsl:value-of select="concat('#',$timeId)"/>
                        </xsl:attribute>
                    </wml2:temporalExtent>
                    <wml2:defaultPointMetadata>
                        <wml2:DefaultTVPMetadata>
                            <wml2:interpolationType>
                                
                                <xsl:attribute name="xlink:href">
                                    <xsl:value-of
                                        select="concat('http://www.opengis.net/def/timeseriesType/WaterML/2.0/','Sporadic')"
                                    />
                                </xsl:attribute>
                                <xsl:attribute name="xlink:title">
                                    <xsl:text >Sporadic (Analytical Samples)"</xsl:text>
                                </xsl:attribute>
                            </wml2:interpolationType>
             <!--               <xsl:if
                                test=" count(wml:method) > 0 ">
                                <wml2:comment>
                                    <xsl:attribute name="xlink:href">
                                        <xsl:value-of
                                            select="concat('#method-',translate(wml:method[1]/wml:methodCode, &quot; &quot;, &quot;_&quot;))"
                                        />
                                    </xsl:attribute>
                                </wml2:comment>
                            </xsl:if>
                            -->
                            <!--              <wml2:uom>
                                <xsl:attribute name="uom">
                                    <xsl:call-template name="UOMCreator">
                                        <xsl:with-param name="Unit"
                                            select="../wml:variable/wml:unit"/>
                                    </xsl:call-template>
                                    
                                </xsl:attribute>
                            </wml2:uom>
                            --> 
                        </wml2:DefaultTVPMetadata>
                    </wml2:defaultPointMetadata>
                    <xsl:call-template name="toResult">
                        <xsl:with-param name="ResultDescription"
                            select="$resultsByCharacteristic"
                        />
                    </xsl:call-template>
                </wml2:Timeseries>
            </om:result>
        </om:OM_Observation>
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
                    
            <wml2:point>
                <wml2:TimeValuePairMeasure>
                    <wml2:time><xsl:call-template name="ActivityToTime" 
                        ><xsl:with-param name="anActivityDescription" 
                            select="../wqx:ActivityDescription" ></xsl:with-param></xsl:call-template>
                    </wml2:time>
                    <wml2:value><xsl:value-of
                        select="wqx:ResultDescription/wqx:ResultMeasure/wqx:ResultMeasureValue"
                    /></wml2:value>
                    <xsl:if
                        test="../wqx:ActivityDescription/wqx:ActivityIdentifier
                        or wqx:ResultAnalyticalMethod 
                       or wqx:ResultDescription/wqx:ResultDetectionConditionText
                       or wqx:ResultDescription/wqx:ResultSampleFractionText
                        or wqx:ResultDescription/wqx:ResultValueTypeName
                        or wqx:ResultDescription/wqx:ResultWeightBasisText
                        or wqx:ResultDescription/wqx:ResultParticleSizeBasisText">
                        <wml2:metadata>
                            <wml2:TVPMetadata>
                               
                                <!-- what to do with method? -->
                                <xsl:if
                                    test="wqx:ResultAnalyticalMethod">
                                    <wml2:comment>
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of
                                                select="concat('#method-',translate(wqx:ResultAnalyticalMethod/wqx:MethodIdentifier, &quot; &quot;, &quot;_&quot;))"
                                            />
                                        </xsl:attribute>
                                    </wml2:comment>
                                </xsl:if>
                                <xsl:if
                                    test="wqx:ResultDescription/wqx:ResultValueTypeName">
                                    <wml2:comment>
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of
                                                select="concat('#ResultValueTypeName-',translate(wqx:ResultDescription/wqx:ResultValueTypeName, &quot; &quot;, &quot;_&quot;))"
                                            />
                                        </xsl:attribute>
                                    </wml2:comment>
                                </xsl:if>
                                <xsl:if
                                    test="wqx:ResultDescription/wqx:ResultWeightBasisText">
                                    <wml2:comment>
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of
                                                select="concat('ResultWeightBasisText-',translate(wqx:ResultDescription/wqx:ResultWeightBasisText, &quot; &quot;, &quot;_&quot;))"
                                            />
                                        </xsl:attribute>
                                    </wml2:comment>
                                </xsl:if>
                                <xsl:if
                                    test="wqx:ResultDescription/wqx:ResultParticleSizeBasisText">
                                   
                                    <wml2:qualifier>
                                        <xsl:attribute name="xlink:href">
                                            <xsl:value-of
                                                select="concat('#qualifer-',translate(@qualifiers, &quot; &quot;, &quot;_&quot;))"
                                            />
                                        </xsl:attribute>
                                    </wml2:qualifier>
                                </xsl:if>
                                <xsl:if
                                    test="wqx:ResultDescription/wqx:ResultDetectionConditionText">
                                    <xsl:choose>
                                        <xsl:when test="wqx:ResultDescription/wqx:ResultDetectionConditionText = 'Not Detected'">
                                            <wml2:censoredReason>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:text>Not Detected</xsl:text>
                               
                                                </xsl:attribute>
                                            </wml2:censoredReason>
                                        </xsl:when>
                                        <xsl:otherwise>
                                            <wml2:censoredReason>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of
                                                        select="concat('#censorCode-',@censorCode)"/>
                                                </xsl:attribute>
                                            </wml2:censoredReason>
                                        </xsl:otherwise>
                                    </xsl:choose>
                                    
                                </xsl:if>
                                
                                
                              <xsl:if test="../wqx:ActivityDescription/wqx:ActivityIdentifier">
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

                                    
                              </xsl:if>
                            </wml2:TVPMetadata>
                        </wml2:metadata>
                    </xsl:if>
                </wml2:TimeValuePairMeasure>
                
            </wml2:point>
                </xsl:when>
                <xsl:when test="wqx:ResultDescription/wqx:ResultDetectionConditionText">
                    <!-- <ResultDetectionConditionText>Not Detected</ResultDetectionConditionText> -->
                    <wml2:point>
                        <wml2:TimeValuePairMeasure>
                            <wml2:time><xsl:call-template name="ActivityToTime" 
                                ><xsl:with-param name="anActivityDescription" 
                                    select="../wqx:ActivityDescription" ></xsl:with-param></xsl:call-template>
                            </wml2:time>
                            <wml2:value xsi:nil="true"/>
                            <xsl:if
                                test="../wqx:ActivityDescription/wqx:ActivityIdentifier
                                or wqx:ResultAnalyticalMethod 
                                or wqx:ResultDescription/wqx:ResultDetectionConditionText
                                or wqx:ResultDescription/wqx:ResultSampleFractionText
                                or wqx:ResultDescription/wqx:ResultValueTypeName
                                or wqx:ResultDescription/wqx:ResultWeightBasisText
                                or wqx:ResultDescription/wqx:ResultParticleSizeBasisText">
                                <wml2:metadata>
                                    <wml2:TVPMetadata>
                                        
                                        <!-- what to do with method? -->
                                        <xsl:if
                                            test="wqx:ResultAnalyticalMethod">
                                            <wml2:comment>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of
                                                        select="concat('#method-',translate(wqx:ResultAnalyticalMethod/wqx:MethodIdentifier, &quot; &quot;, &quot;_&quot;))"
                                                    />
                                                </xsl:attribute>
                                            </wml2:comment>
                                        </xsl:if>
                                        <xsl:if
                                            test="wqx:ResultDescription/wqx:ResultValueTypeName">
                                            <wml2:comment>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of
                                                        select="concat('#ResultValueTypeName-',translate(wqx:ResultDescription/wqx:ResultValueTypeName, &quot; &quot;, &quot;_&quot;))"
                                                    />
                                                </xsl:attribute>
                                            </wml2:comment>
                                        </xsl:if>
                                        <xsl:if
                                            test="wqx:ResultDescription/wqx:ResultWeightBasisText">
                                            <wml2:comment>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of
                                                        select="concat('ResultWeightBasisText-',translate(wqx:ResultDescription/wqx:ResultWeightBasisText, &quot; &quot;, &quot;_&quot;))"
                                                    />
                                                </xsl:attribute>
                                            </wml2:comment>
                                        </xsl:if>
                                        <xsl:if
                                            test="wqx:ResultDescription/wqx:ResultParticleSizeBasisText">
                                            
                                            <wml2:qualifier>
                                                <xsl:attribute name="xlink:href">
                                                    <xsl:value-of
                                                        select="concat('#qualifer-',translate(@qualifiers, &quot; &quot;, &quot;_&quot;))"
                                                    />
                                                </xsl:attribute>
                                            </wml2:qualifier>
                                        </xsl:if>
                                        <xsl:if
                                            test="wqx:ResultDescription/wqx:ResultDetectionConditionText">
                                            <xsl:choose>
                                                <xsl:when test="wqx:ResultDescription/wqx:ResultDetectionConditionText = 'Not Detected'">
                                                    <wml2:censoredReason>
                                                        <xsl:attribute name="xlink:href">
                                                            <xsl:text>Not Detected</xsl:text>
                                                            
                                                        </xsl:attribute>
                                                    </wml2:censoredReason>
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <wml2:censoredReason>
                                                        <xsl:attribute name="xlink:href">
                                                            <xsl:value-of
                                                                select="concat('#censorCode-',@censorCode)"/>
                                                        </xsl:attribute>
                                                    </wml2:censoredReason>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                            
                                        </xsl:if>
                                        
                                        
                                        
                                        <xsl:if test="../wqx:ActivityDescription/wqx:ActivityIdentifier">
                                            <xsl:variable name="sampleCode"
                                                select="../wqx:ActivityDescription/wqx:ActivityIdentifier"/>
                                           
                                            <wml2:relatedObservation>
                                                <om:ObservationContext>
                                                    <om:role>
                                                        <xsl:attribute name="xlink:href"
                                                            >http://www.opengis.net/def/relatedObservation/WaterML/2.0/analyticalSample</xsl:attribute>
                                                        <xsl:attribute name="xlink:title">Analytical Sample Observation</xsl:attribute>
                                                    </om:role>
                                                    <xsl:comment>if copying to browser, change amperand amp semicolon to amperand
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
                                            
                                            
                                        </xsl:if>
                                    </wml2:TVPMetadata>
                                </wml2:metadata>
                            </xsl:if>
                        </wml2:TimeValuePairMeasure>
                        
                    </wml2:point>
                </xsl:when>
            </xsl:choose>
            
               
     
        </xsl:for-each>
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
