<?xml version="1.0" encoding="utf-8"?>
<!-- Created with Liquid XML Studio Developer Edition (Education) 9.0.11.3078 (http://www.liquid-technologies.com) -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:wml11="http://www.cuahsi.org/waterML/1.1/" xmlns:wml10="http://www.cuahsi.org/waterML/1.0/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
    <xsl:param name="location">
    </xsl:param>
    <xsl:param name="variable">
    </xsl:param>
    <xsl:param name="starttime">
    </xsl:param>
    <xsl:param name="endtime">
    </xsl:param>
    <xsl:output method="xml" version="1.0" encoding="utf-8" indent="yes" />
    <xsl:namespace-alias stylesheet-prefix="wml11" result-prefix="wml10" />
    <xsl:variable name="network">NWISDV</xsl:variable>
    <xsl:variable name="vocabulary">NWISDV</xsl:variable>
    <xsl:template match="//wml10:timeSeriesResponse">
        <xsl:element name="timeSeriesResponse" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:apply-templates />
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml10:timeSeries">
       <xsl:apply-templates />
    </xsl:template>
  
  <xsl:template match="wml11:values">
    <xsl:element name="values" namespace="http://www.cuahsi.org/waterML/1.0/">
   <!--   <xsl:if test="count(wml11:value) >0">
        <xsl:attribute name="count">
          <xsl:value-of select="count(wml11:value)" />
        </xsl:attribute>
      </xsl:if>
      -->
       <xsl:copy-of select="." />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:variable">
    <!-- unit needs to be back transformed -->
    <xsl:element name="variable" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:apply-templates select="wml11:variableCode"/>
      <xsl:apply-templates select="wml11:variableName"/>
      <xsl:apply-templates select="wml11:variableDescription"/>
      <xsl:apply-templates select="wml11:valueType"/>
      <xsl:element name="dataType" namespace="http://www.cuahsi.org/waterML/1.0/">
        <xsl:choose>
          <xsl:when test="wml11:dataType">
            <xsl:value-of select="." />
          </xsl:when>
          <xsl:when test=". = 'Mean'">Average</xsl:when>
          <xsl:when test="wml11:options/wml11:option[@name='Statistic']">
            <xsl:choose>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'Mean'">Average</xsl:when>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'Maximum'">Maximum</xsl:when>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'Median'">Median</xsl:when>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'Minimum'">Minimum</xsl:when>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'Variance'">Variance</xsl:when>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'STD'">StandardDeviation</xsl:when>
              <xsl:when test="wml11:options/wml11:option[@name='Statistic']/child::text() = 'INSTANTANEOUS'">Average</xsl:when>
              <xsl:otherwise>Unknown</xsl:otherwise>
            </xsl:choose>
          </xsl:when>
          <xsl:otherwise>Unknown</xsl:otherwise>
        </xsl:choose>
      </xsl:element>
      <xsl:apply-templates select="wml11:generalCategory"/>
      <xsl:apply-templates select="wml11:sampleMedium"/>
      <xsl:apply-templates select="wml11:unit"/>
      <xsl:apply-templates select="wml11:options"/>
      <xsl:apply-templates select="wml11:note"/>
      <xsl:apply-templates select="wml11:variableProperty"/>
      <xsl:apply-templates select="wml11:speciation"/>
      <xsl:apply-templates select="wml11:related"/>
      <xsl:apply-templates select="wml11:extension"/>
      <xsl:apply-templates select="wml11:noDataValue"/>
      <xsl:apply-templates select="wml11:timeScale"/>
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
     <!-- <xsl:apply-templates /> -->
      <xsl:value-of select="../wml11:variableDescription" />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:variableDescription">
    <xsl:element name="variableDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
     <!-- <xsl:apply-templates /> -->
      <xsl:value-of select="../wml11:variablName" />
      <xsl:if test="../wml11:speciation">
        <xsl:value-of select="concat(' specation:',../wml11:speciation)" />
      </xsl:if>
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:valueType">
    <xsl:element name="valueType" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:value-of select="." />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:dataType">
    <xsl:element name="dataType" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:choose>
        <xsl:when test=". = 'Average'">Average</xsl:when>
        <xsl:when test=". = 'Mean'">Average</xsl:when>
        <xsl:when test="../wml11:options/wml11:option[@name='Statistic']">
          <xsl:choose>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'Mean'">Average</xsl:when>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'Maximum'">Maximum</xsl:when>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'Median'">Median</xsl:when>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'Minimum'">Minimum</xsl:when>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'Variance'">Variance</xsl:when>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'STD'">StandardDeviation</xsl:when>
            <xsl:when test="../wml11:options/wml11:option[@name='Statistic']/child::text() = 'INSTANTANEOUS'">Average</xsl:when>
          </xsl:choose>
        </xsl:when>
        <xsl:otherwise>Unknown</xsl:otherwise>
      </xsl:choose>
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:generalCategory">
    <xsl:element name="generalCategory" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:value-of select="." />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:sampleMedium">
    <xsl:element name="sampleMedium" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:value-of select="." />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:noDataValue">
    <xsl:element name="NoDataValue" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:value-of select="." />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:speciation">
    <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:attribute name="title">
        <xsl:text>speciation</xsl:text>
      </xsl:attribute>
      <xsl:value-of select="." />
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:options">
    <xsl:element name="options" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:for-each select="wml11:option">
        <xsl:element name="option" namespace="http://www.cuahsi.org/waterML/1.0/">
          <xsl:if test="@name">
            <xsl:attribute name="name">

              <xsl:value-of select="@name" />
            </xsl:attribute>
          </xsl:if>
          <xsl:if test="@optionID">
            <xsl:attribute name="optionID">
              <xsl:value-of select="@optionID" />
            </xsl:attribute>
          </xsl:if>
          <xsl:if test="@optionCode">
            <xsl:attribute name="optionCode">
              <xsl:value-of select="@optionCode" />
            </xsl:attribute>
          </xsl:if>

          <xsl:copy-of select="text()" />
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:unit">
    <!-- unit needs to be back transformed
                <units unitsType="Flow" unitsAbbreviation="cfs"/>-->
    <xsl:element name="units" namespace="http://www.cuahsi.org/waterML/1.0/">
      <xsl:if test="wml11:unitsAbbreviation">
        <xsl:attribute name="unitsAbbreviation">
          <xsl:value-of select="unitsAbbreviation" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="wml11:unitType">
        <xsl:attribute name="unitsType">
          <xsl:value-of select="wml11:unitsType" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="wml11:unitCode">
        <xsl:attribute name="unitsCode">
          <xsl:value-of select="wml11:unitCode" />
        </xsl:attribute>
      </xsl:if>
      <xsl:if test="wml11:unitName">
        <xsl:value-of select="wml11:unitName" />
      </xsl:if>
    </xsl:element>
  </xsl:template>
  <xsl:template match="wml11:timeScale">
    <!-- unit needs to be back transformed
                <units unitsType="Flow" unitsAbbreviation="cfs"/>-->
    <xsl:element name="timeSupport" namespace="http://www.cuahsi.org/waterML/1.0/">
      <!--  <unit UnitID="103">
          <UnitDescription>hour</UnitDescription>
          <UnitType>Time</UnitType>
          <UnitAbbreviation>hr</UnitAbbreviation>
        </unit>
        <timeInterval>1</timeInterval>
    -->
      <xsl:choose>
        <xsl:when test="@isRegular=true">
          <xsl:attribute name="isRegular" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:value-of select="@isRegular" />
          </xsl:attribute>
          <xsl:element name="unit" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="wml11:unit/wml11:unitCode">
              <xsl:attribute name="unitsID" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:value-of select="wml11:unitCode" />
              </xsl:attribute>
            </xsl:if>
            <xsl:if test="wml11:unit/wml11:unitName">
              <xsl:element name="UnitDescription" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:value-of select="wml11:unitName" />
              </xsl:element>
            </xsl:if>
            <xsl:if test="wml11:unit/wml11:unitType">
              <xsl:element name="unitsType" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:value-of select="wml11:unitsType" />
              </xsl:element>
            </xsl:if>
            <xsl:if test="wml11:unit/wml11:unitsAbbreviation">
              <xsl:element name="unitAbbreviation" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:value-of select="unitsAbbreviation" />
              </xsl:element>
            </xsl:if>
          </xsl:element>
        </xsl:when>
        <xsl:otherwise>
          <xsl:attribute name="isRegular" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:text>false</xsl:text>
          </xsl:attribute>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:element>
  </xsl:template>
  
  <!-- Query INfo-->
    <xsl:template match="wml10:queryInfo">
        <xsl:element name="queryInfo" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="wml10:creationTime">
                <xsl:element name="creationTime" namespace="http://www.cuahsi.org/waterML/1.0/">
                    <xsl:value-of select="wml10:creationTime" />
                </xsl:element>
            </xsl:if>
            <xsl:if test="wml10:queryUrl">
                <xsl:element name="queryUrl" namespace="http://www.cuahsi.org/waterML/1.0/">
                    <xsl:value-of select="wml10:queryUrl" />
                </xsl:element>
            </xsl:if>
            <xsl:element name="criteria" namespace="http://www.cuahsi.org/waterML/1.0/">
                <xsl:element namespace="http://www.cuahsi.org/waterML/1.0/" name="locationParam">
                    <xsl:value-of select="$location" />
                </xsl:element>
                <xsl:element namespace="http://www.cuahsi.org/waterML/1.0/" name="variableParam">
                    <xsl:value-of select="$variable" />
                </xsl:element>
                <xsl:element namespace="http://www.cuahsi.org/waterML/1.0/" name="timeParam">
                    <xsl:element namespace="http://www.cuahsi.org/waterML/1.0/" name="beginDateTime">
                        <xsl:value-of select="$starttime" />
                   </xsl:element>
                    <xsl:element namespace="http://www.cuahsi.org/waterML/1.0/" name="endDateTime">
                        <xsl:value-of select="$endtime" />
                   </xsl:element>
               </xsl:element>
            </xsl:element>
             <xsl:element name="note"  namespace="http://www.cuahsi.org/waterML/1.0/">
                 <xsl:attribute name="name">usgs_locationParam</xsl:attribute>
                <xsl:value-of select="wml10:criteria/wml10:locationParam" />
            </xsl:element>
            <xsl:element name="note"  namespace="http://www.cuahsi.org/waterML/1.0/">
                 <xsl:attribute name="name">usgs_variableParam</xsl:attribute>
                <xsl:value-of select="wml10:criteria/wml10:variableParam" />
            </xsl:element>
            <xsl:element name="note"  namespace="http://www.cuahsi.org/waterML/1.0/">
                 <xsl:attribute name="name">usgs_beginDateTime</xsl:attribute>
                <xsl:value-of select="wml10:criteria/wml10:timeParam/wml10:beginDateTime" />
            </xsl:element>
            <xsl:element name="note"  namespace="http://www.cuahsi.org/waterML/1.0/">
                 <xsl:attribute name="name">usgs_endDateTime</xsl:attribute>
                <xsl:value-of select="wml10:criteria/wml10:timeParam/wml10:endDateTime" />
           </xsl:element>
            <xsl:apply-templates select="wml10:note" />
            <xsl:if test="wml10:extension">
                <wml10:extension>
                    <xsl:copy-of select="wml10:extension" />
                </wml10:extension>
            </xsl:if>
        </xsl:element>
    </xsl:template>
    <xsl:template match="wml10:note">
        <xsl:element name="note" namespace="http://www.cuahsi.org/waterML/1.0/">
            <xsl:if test="@name">
                <xsl:attribute name="name">
                    <xsl:value-of select="@name" />
                </xsl:attribute>
            </xsl:if>
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
            <xsl:value-of select="." />
        </xsl:element>
    </xsl:template>
</xsl:stylesheet>
