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
        <xsl:copy-of select="." />
    </xsl:template>
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
