<?xml version="1.0" encoding="utf-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 8.1.4.2482 (http://www.liquid-technologies.com) -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:wml11="http://www.cuahsi.org/waterML/1.1/" xmlns:wml10="http://www.cuahsi.org/waterML/1.0/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <xsl:namespace-alias stylesheet-prefix="wml11" result-prefix="wml10" />
    <xsl:variable name="network">NWISIID</xsl:variable>
    <xsl:variable name="vocabulary">NWISIID</xsl:variable>
    
  <xsl:param name="location"></xsl:param>
  <xsl:param name="variable"></xsl:param>
  <xsl:param name="starttime"></xsl:param>
  <xsl:param name="endtime"></xsl:param>
    
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
              <xsl:apply-templates/> 
        <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:attribute name="title">CUAHSI</xsl:attribute>Tranformed from WaterML 1.1 </xsl:element>
        </xsl:element>
    </xsl:template>
     <xsl:template match="wml11:creationTime">
        <xsl:element name="creationTime" namespace="http://www.cuahsi.org/waterML/1.0/">
             <xsl:apply-templates/> 
        </xsl:element>
    </xsl:template>
     <xsl:template match="wml11:queryURL">
        <xsl:element name="queryURL" namespace="http://www.cuahsi.org/waterML/1.0/">
           <xsl:apply-templates/> 
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

       <wml10:criteria>
         <wml10:locationParam>
           <xsl:value-of select="$location"/>
         </wml10:locationParam>
         <wml10:variableParam>
           <xsl:value-of select="$variable"/>
         </wml10:variableParam>
         <wml10:timeParam>
           <wml10:beginDateTime>
             <xsl:value-of select="$starttime"/>
           </wml10:beginDateTime>
           <wml10:endDateTime>
             <xsl:value-of select="$endtime"/>
           </wml10:endDateTime>
         </wml10:timeParam>
         </wml10:criteria>
         <xsl:apply-templates select="wml11:parameter"/> 
        
    </xsl:template>
     <xsl:template match="wml11:parameter">
        <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">

          <xsl:attribute name="title">
            <xsl:value-of select="concat('USGS_output_', @name)"/>
          </xsl:attribute> 
        
          <xsl:value-of select="@value"/>
        </xsl:element>
    </xsl:template>
    
     <xsl:template match="wml11:variableParam">
        <xsl:element name="variableParam" namespace="http://www.cuahsi.org/waterML/1.0/">
           <xsl:apply-templates/> 
        </xsl:element>
    </xsl:template>
     <xsl:template match="wml11:timeParam">
        <xsl:element name="timeParam" namespace="http://www.cuahsi.org/waterML/1.0/">
           <xsl:apply-templates/> 
        </xsl:element>
    </xsl:template>
     <xsl:template match="wml11:beginDateTime">
        <xsl:element name="beginDateTime" namespace="http://www.cuahsi.org/waterML/1.0/">
           <xsl:apply-templates/> 
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:endDateTime">
        <xsl:element name="endDateTime" namespace="http://www.cuahsi.org/waterML/1.0/">
           <xsl:apply-templates/> 
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
            <xsl:apply-templates />
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
            <xsl:apply-templates select="wml11:geoLocation"/>
           
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:elevation_m">
    <xsl:element name="elevation_m" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="." />
            </xsl:element>
            
    </xsl:template>
     <xsl:template match="wml11:verticalDatum">
        <xsl:element name="verticalDatum" namespace="http://www.cuahsi.org/waterML/1.0/">
             <xsl:value-of select="." /> 
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
-->           <xsl:attribute name="xsi:type">LatLonPointType</xsl:attribute>
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
    
     <xsl:template match="wml11:localSiteXY">
        <xsl:element name="localSiteXY" namespace="http://www.cuahsi.org/waterML/1.0/">
<xsl:if test="@projectionInformation">
          <xsl:attribute name="projectionInformation">
            <xsl:value-of select="@projectionInformation"/>
          </xsl:attribute> 
        </xsl:if>
            <xsl:element name="X" namespace="http://www.cuahsi.org/waterML/1.0/"> 
          <xsl:value-of select="wml11:X"/>
          </xsl:element>
            <xsl:element name="Y" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:value-of select="wml11:Y"/>
        </xsl:element> 
        </xsl:element>
    </xsl:template>
    
      <xsl:template match="wml11:siteProperty">
        <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">

          <xsl:attribute name="title">
            <xsl:value-of select="@name"/>
          </xsl:attribute> 
        
          <xsl:value-of select="."/>
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
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:variableDescription">
        <xsl:element name="variableDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:valueType">
        <xsl:element name="valueType" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:choose>
             <xsl:when test=". = 'Average'">Average</xsl:when> 
                <xsl:otherwise>Unknown</xsl:otherwise>
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
        <xsl:element name="units" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="unitsAbbreviation">
                <xsl:attribute name="unitsAbbreviation">
                    <xsl:value-of select="unitsAbbreviation" />
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="unitsAbbreviation">
                <xsl:attribute name="unitsType">
                    <xsl:value-of select="unitsType" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
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
    <xsl:template match="wml11:qualifierCode" > QualifierCode:<xsl:value-of select="." />
    </xsl:template>
    <xsl:template match="wml11:qualifierDescription">  QualifierDescription:<xsl:value-of select="." /> 
 </xsl:template>
    <xsl:template match="wml11:method">
        <xsl:element name="method" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@qualifierID">
                <xsl:attribute name="qualifierID">
                    <!-- not correct, but will have to work for now -->
                    <xsl:value-of select="@qualifierID" />
                </xsl:attribute>
            </xsl:if>
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:methodDescription">
        <xsl:element name="MethodDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml11:methodCode">
        <xsl:element name="methodCode" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
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
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
</xsl:stylesheet>
