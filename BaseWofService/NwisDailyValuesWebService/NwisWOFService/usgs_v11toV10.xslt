<?xml version="1.0" encoding="utf-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 8.1.7.2743 (http://www.liquid-technologies.com) -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:wml11="http://www.cuahsi.org/waterML/1.1/" xmlns:wml10="http://www.cuahsi.org/waterML/1.0/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <xsl:namespace-alias stylesheet-prefix="wml11" result-prefix="wml10" />
    <xsl:variable name="network">NWISUV</xsl:variable>
    <xsl:variable name="vocabulary">NWISUV</xsl:variable>
    <xsl:template match="//wml11:timeSeriesResponse">
        <xsl:element name="timeSeriesResponse" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <!-- ***********************************
      generic
        **********************************-->
    <xsl:template match="wml11:note">
        <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@title">
                <xsl:attribute name="title">
                    <xsl:value-of select="@title" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@type">
                <xsl:attribute name="type">
                    <xsl:value-of select="@type" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@href">
                <xsl:attribute name="href">
                    <xsl:value-of select="@href" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <!--
    <xsl:copy  >
        <xsl:call-template name="doCopy"  />
        <xsl:apply-templates/>
    </xsl:copy>
   -->
    <!--<xsl:template name="doCopy" match="*|text()|@*">
    
    <xsl:copy>
        <xsl:apply-templates select="@*"/>
        <xsl:apply-templates/>
    </xsl:copy>
</xsl:template>  
    -->
    <xsl:template name="doCopy">
        <xsl:copy>
            <xsl:apply-templates select="@*" />
            <xsl:apply-templates />
        </xsl:copy>
    </xsl:template>
    <xsl:template match="wml11:queryInfo">
        <xsl:element name="queryInfo" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
            <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:attribute name="title">CUAHSI</xsl:attribute>Tranformed from WaterML 1.1 </xsl:element>
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:creationTime">
        <xsl:element name="creationTime" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:queryURL">
        <xsl:element name="queryURL" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:note">
        <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@title">
                <xsl:attribute name="title">
                    <xsl:value-of select="@title" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@href">
                <xsl:attribute name="href">
                    <xsl:value-of select="@href" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@type">
                <xsl:attribute name="type">
                    <xsl:value-of select="@type" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@show">
                <xsl:attribute name="show">
                    <xsl:value-of select="@show" />
                </xsl:attribute>
            </xsl:if>
            <xsl:value-of select="." />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:criteria">
        <xsl:element name="criteria" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:locationParam">
        <xsl:element name="locationParam" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:variableParam">
        <xsl:element name="variableParam" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:timeParam">
        <xsl:element name="timeParam" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:beginDateTime">
        <xsl:element name="beginDateTime" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:endDateTime">
        <xsl:element name="endDateTime" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:timeSeries">
        <xsl:element name="timeSeries" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <!-- ***********************************
        Source and Site 
        **********************************-->
    <xsl:template match="wml11:sourceInfo">
        <xsl:element name="sourceInfo" namespace="http://www.cuahsi.org/waterML/1.0/">
            <!-- this will need to trap datasettype isteinforo type -->
            <!--       <xsl:value-of select="@xsi:type" /> -->
            <xsl:attribute name="xsi:type">SiteInfoType</xsl:attribute>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:siteName">
        <xsl:element name="siteName" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:siteCode">
        <xsl:element name="siteCode" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:attribute name="network">
                <xsl:value-of select="$network" />
            </xsl:attribute>
            <xsl:attribute name="agencyCode">
                <xsl:value-of select="@agencyCode" />
            </xsl:attribute>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:geoLocation">
        <xsl:element name="geoLocation" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:geogLocation">
        <xsl:element name="geogLocation" namespace="http://www.cuahsi.org/waterML/1.0/">
            <!-- xsi:type="ns1:LatLonPointType" srs="EPSG:4326" -->
            <xsl:attribute name="srs">
                <xsl:value-of select="@srs" />
            </xsl:attribute>
            <!--           <xsl:attribute name="xsi:type">
                <xsl:value-of select="@xsi:type" />
            </xsl:attribute>
-->
            <xsl:attribute name="xsi:type">LatLonPointType</xsl:attribute>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:latitude">
        <xsl:element name="latitude" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:longitude">
        <xsl:element name="longitude" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <!-- ***********************************
        Variable
        **********************************-->
    <xsl:template match="wml11:variable">
        <!-- unit needs to be back transformed -->
        <xsl:element name="variable" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:variableCode">
        <!-- network="NWIS" vocabulary="NWIS:UnitValues" default="true" -->
        <xsl:element name="variableCode" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:attribute name="network">
                <xsl:value-of select="$network" />
            </xsl:attribute>
            <xsl:attribute name="vocabulary">
                <xsl:value-of select="$vocabulary" />
            </xsl:attribute>
            <xsl:attribute name="default">
                <xsl:value-of select="@default" />
            </xsl:attribute>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:variableName">
        <xsl:element name="variableName" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:variableDescription">
        <xsl:element name="variableDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
            
            <xsl:choose>
                <xsl:when test=". = 'UNKNOWN'"><xsl:value-of select="../wml11:variableName" disable-output-escaping="yes" /></xsl:when>
                
                <xsl:otherwise><xsl:value-of select="." disable-output-escaping="yes" /></xsl:otherwise>
            </xsl:choose>
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:valueType">
        <xsl:element name="valueType" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:choose>
                <xsl:when test=". = '00060'">Field Observation</xsl:when>
                
                <xsl:otherwise>Field Observation</xsl:otherwise>
            </xsl:choose>
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:dataType">
        <xsl:element name="dataType" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:noDataValue">
        <xsl:element name="NoDataValue" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:unit">
        <!-- unit needs to be back transformed 
                <units unitsType="Flow" unitsAbbreviation="cfs"/>-->
        <xsl:choose>
            <xsl:when test="wml11:unitCode = 'UNKNOWN'">
                <xsl:call-template name="UnitsFix">
                    <xsl:with-param name="varCode">
                        <xsl:value-of select="../wml11:variableCode" />
                    </xsl:with-param>
                </xsl:call-template>
                <!--  <xsl:element name="units" namespace="http://www.cuahsi.org/waterML/1.0/">
                    <xsl:attribute name="unitsType">Flow</xsl:attribute>
                    <xsl:attribute name="unitsAbbreviation">cfs</xsl:attribute>
                    <xsl:text>cubic feet per second</xsl:text>
                </xsl:element>
                -->
            </xsl:when>
            <xsl:otherwise>
                <xsl:element name="units" namespace="http://www.cuahsi.org/waterML/1.0/">
                    <xsl:if test="unitsAbbreviation">
                        <xsl:attribute name="unitsAbbreviation">
                            <xsl:value-of select="unitsAbbreviation" />
                        </xsl:attribute>
                    </xsl:if>
                    <xsl:if test="unitsType">
                        <xsl:attribute name="unitsType">
                            <xsl:value-of select="unitsType" />
                        </xsl:attribute>
                    </xsl:if>
                    <xsl:apply-templates />
                </xsl:element>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
    <!-- ***********************************
        Values
        **********************************-->
    <xsl:template match="wml11:values">
        <xsl:element name="values" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:value">
        <!-- codes need to be mapped to id's -->
        <xsl:element name="value" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@dateTime">
                <xsl:attribute name="dateTime">
                    <xsl:value-of select="@dateTime" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@qualifiers">
                <xsl:attribute name="qualifiers">
                    <xsl:value-of select="@qualifiers" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@methodId">
                <xsl:attribute name="methodId">
                    <xsl:value-of select="@methodId" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@methodCode">
                <xsl:attribute name="methodId">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@methodCode" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@sourceId">
                <xsl:attribute name="sourceId">
                    <xsl:value-of select="@sourceId" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@sourceCode">
                <xsl:attribute name="sourceId">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@sourceCode" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:qualifier">
        <xsl:element name="qualifier" namespace="http://www.cuahsi.org/waterML/1.0/">
            <!--      <ns1:qualifier 
            qualifierID="0" 
            ns1:network="NWIS" 
            ns1:vocabulary="uv_rmk_cd">
   -->
            <xsl:if test="@qualifierID">
                <xsl:attribute name="qualifierID">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@qualifierID" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@network">
                <xsl:attribute name="network">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="$network" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="@vocabulary">
                <xsl:attribute name="vocabulary">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@vocabulary" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:qualifierCode"> QualifierCode:<xsl:value-of select="." /></xsl:template>
    <xsl:template match="wml11:qualifierDescription">  QualifierDescription:<xsl:value-of select="." /></xsl:template>
    <xsl:template match="wml11:method">
        <xsl:element name="method" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@methodID">
                <xsl:attribute name="methodID">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@methodID" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:methodDescription">
        <xsl:element name="MethodDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:methodCode">
        <xsl:element name="methodCode" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:methodLink">
        <xsl:element name="methodLink" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <!-- add a source
        <ns1:source sourceID="">
            <ns1:sourceCode >USGS</ns1:sourceCode>
            <ns1:organization></ns1:organization>
            <ns1:sourceDescription></ns1:sourceDescription>
        </ns1:source> 
        -->
    <xsl:template match="wml11:source">
        <xsl:element name="source" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@sourceID">
                <xsl:attribute name="sourceID">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@sourceID" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:sourceCode">
        <xsl:element name="sourceCode" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:organization">
        <xsl:element name="organization" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:sourceDescription">
        <xsl:element name="sourceDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="." disable-output-escaping="yes" />
        </xsl:element>
    </xsl:template>
    
    
    <xsl:template name="CreateUnits">
        <xsl:param name="unitsType" />
        <xsl:param name="unitsAbbreviation" />
        <xsl:param name="unitsName" />
        <xsl:element name="units" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:attribute name="unitsType">
                <xsl:value-of select="$unitsType" />
            </xsl:attribute>
            <xsl:attribute name="unitsAbbreviation">
                <xsl:value-of select="$unitsAbbreviation" />
            </xsl:attribute>
            <xsl:value-of select="$unitsName" />
        </xsl:element>
    </xsl:template>
    <xsl:template name="UnitsFix">
        <xsl:param name="varCode" />
        <xsl:choose>
            <xsl:when test="$varCode ='00060'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Flow</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">cfs</xsl:with-param>
                    <xsl:with-param name="unitsName">cubic feet per second</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00065'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">f</xsl:with-param>
                    <xsl:with-param name="unitsName">feet</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00010'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Temperature</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">degC</xsl:with-param>
                    <xsl:with-param name="unitsName">deg C</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00011'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Temperature</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">degF</xsl:with-param>
                    <xsl:with-param name="unitsName">deg F</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00045'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">in</xsl:with-param>
                    <xsl:with-param name="unitsName">inches</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='72019'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ft</xsl:with-param>
                    <xsl:with-param name="unitsName">feet</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00095'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Electrical Conductivity</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">mS/cm</xsl:with-param>
                    <xsl:with-param name="unitsName">millisiemens per centimeter</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00055'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Velocity</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ft/sec</xsl:with-param>
                    <xsl:with-param name="unitsName">feet per second</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='00400'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">pH</xsl:with-param>
                    <xsl:with-param name="unitsName">pH</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='63680'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Turbidity</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">FNU</xsl:with-param>
                    <xsl:with-param name="unitsName">FNU</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$varCode ='63160'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ft</xsl:with-param>
                    <xsl:with-param name="unitsName">feet</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            
             <xsl:when test="$varCode ='00062'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ft</xsl:with-param>
                    <xsl:with-param name="unitsName">feet</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
             <xsl:when test="$varCode ='00021'">
                <xsl:call-template name="CreateUnits">
                     <xsl:with-param name="unitsType">Temperature</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">degF</xsl:with-param>
                    <xsl:with-param name="unitsName">deg F</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
             <xsl:when test="$varCode ='00020'">
                <xsl:call-template name="CreateUnits">
                     <xsl:with-param name="unitsType">Temperature</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">degC</xsl:with-param>
                    <xsl:with-param name="unitsName">deg C</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
                         <xsl:when test="$varCode ='00035'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Velocity</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">mph</xsl:with-param>
                    <xsl:with-param name="unitsName">miles per hour</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
                         <xsl:when test="$varCode ='00036'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Dimensionless</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">deg</xsl:with-param>
                    <xsl:with-param name="unitsName">Wind direction</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
                         <xsl:when test="$varCode ='00054'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Volume</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ac ft</xsl:with-param>
                    <xsl:with-param name="unitsName">acre feet</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
                         <xsl:when test="$varCode ='00480'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Concentration</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ppth</xsl:with-param>
                    <xsl:with-param name="unitsName">parts per thousand</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
                         <xsl:when test="$varCode ='62614'">
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Length</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">ft</xsl:with-param>
                    <xsl:with-param name="unitsName">feet</xsl:with-param>
                </xsl:call-template>
            </xsl:when>
            
            <!-- mssing
            70969
            72020
            00300
            -->
            <xsl:otherwise>
                <xsl:call-template name="CreateUnits">
                    <xsl:with-param name="unitsType">Dimensionless</xsl:with-param>
                    <xsl:with-param name="unitsAbbreviation">UNK</xsl:with-param>
                    <xsl:with-param name="unitsName">Unknown</xsl:with-param>
                </xsl:call-template>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
</xsl:stylesheet>
