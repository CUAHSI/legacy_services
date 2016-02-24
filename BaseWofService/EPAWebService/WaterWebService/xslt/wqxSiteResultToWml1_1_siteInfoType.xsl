<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl" exclude-result-prefixes="xd"
    xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
    xmlns:wqx="http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/"
    xmlns:wml11="http://www.cuahsi.org/waterML/1.1/"
    xmlns:wml10="http://www.cuahsi.org/waterML/1.0/" xmlns:gml="http://www.opengis.net/gml/3.2"
    xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:om="http://www.opengis.net/om/2.0"
    xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:sa="http://www.opengis.net/sampling/2.0"
    xmlns:sams="http://www.opengis.net/samplingSpatial/2.0" version="1.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Oct 25, 2011</xd:p>
            <xd:p><xd:b>Author:</xd:b> valentin</xd:p>
            <xd:p/>
        </xd:desc>
    </xd:doc>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template name="siteInfoTypeFromUrl">
        <xsl:param name="sitesurl"/>
        <xsl:param name="siteId"/>
        <xsl:variable name="siteDocument" select="document(concat($sitesurl,$siteId))"/>
        <wml11:sourceInfo xsi:type="SiteInfoType">
            <xsl:call-template name="siteInfoType">
                <xsl:with-param name="site"
                    select="$siteDocument/wqx:WQX/wqx:Organization/wqx:MonitoringLocation[1]"/>
            </xsl:call-template>
        </wml11:sourceInfo>
    </xsl:template>

    <xsl:template match="wqx:WQX">
        <wml11:sitesResponse>
            <xsl:for-each select="wqx:Organization/wqx:MonitoringLocation">
                <wml11:site>
                    <xsl:call-template name="siteInfoType">
                        <xsl:with-param name="site" select="."/>
                    </xsl:call-template>
                </wml11:site>
            </xsl:for-each>
        </wml11:sitesResponse>
    </xsl:template>
    <!--  <sourceInfo xsi:type="SiteInfoType">
        <siteName>Utah State University Experimental Farm near Wellsville, Utah</siteName>
        <siteCode network="UNDEFINEDnetwork" siteID="3">USU-LBR-ExpFarm</siteCode>
        <geoLocation>
        <geogLocation xsi:type="LatLonPointType" srs="EPSG:4269">
        <latitude>41.666993</latitude>
        <longitude>-111.890567</longitude>
        </geogLocation>
        <localSiteXY projectionInformation=" NAD83 / UTM zone 12N">
        <X>425861.714</X>
        <Y>4613186.929</Y>
        </localSiteXY>
        </geoLocation>
        <elevation_m>1369</elevation_m>
        <verticalDatum>NGVD29</verticalDatum>
        <siteProperty name="County">Cache</siteProperty>
        <siteProperty name="State">Utah</siteProperty>
        <siteProperty name="Site Comments">This is a continuous weather station.</siteProperty>
        <siteProperty name="PosAccuracy_m">3</siteProperty>
        </sourceInfo>
        
        -->
    <xsl:template name="siteInfoType">
        <xsl:param name="site"/>
        <xsl:param name="network">USGSWQX</xsl:param>
        <xsl:param name="variable">USGSWQX</xsl:param>


        <xsl:if test="$site/wqx:MonitoringLocationIdentity/wqx:MonitoringLocationName">

            <wml11:siteName>
                <xsl:value-of
                    select="$site/wqx:MonitoringLocationIdentity/wqx:MonitoringLocationName"/>
            </wml11:siteName>
        </xsl:if>
        <wml11:siteCode>
            <xsl:attribute name="network">
                <xsl:value-of select="$network"/>
            </xsl:attribute>
            <xsl:value-of
                select="$site/wqx:MonitoringLocationIdentity/wqx:MonitoringLocationIdentifier"/>
        </wml11:siteCode>
        <wml11:geoLocation>
            <wml11:geogLocation xsi:type="LatLonPointType" srs="EPSG:4269">
                <wml11:latitude>
                    <xsl:value-of
                        select="$site/wqx:MonitoringLocationGeospatial/wqx:LatitudeMeasure"/>
                </wml11:latitude>
                <wml11:longitude>
                    <xsl:value-of
                        select="$site/wqx:MonitoringLocationGeospatial/wqx:LongitudeMeasure"/>
                </wml11:longitude>
            </wml11:geogLocation>

        </wml11:geoLocation>

        <xsl:choose>
            <xsl:when
                test="$site/wqx:MonitoringLocationGeospatial/wqx:VerticalMeasure/wqx:MeasureUnitCode = 'feet'">
                <wml11:elevation_m>
                    <xsl:value-of
                        select="($site/wqx:MonitoringLocationGeospatial/wqx:VerticalMeasure/wqx:MeasureValue) div 3.3"
                    />
                </wml11:elevation_m>
            </xsl:when>
            <xsl:when test="$site/wqx:MonitoringLocationGeospatial/wqx:MeasureUnitCode ='meters'">
                <wml11:elevation_m>
                    <xsl:value-of
                        select="$site/wqx:MonitoringLocationGeospatial/wqx:VerticalMeasure/wqx:MeasureValue"
                    />
                </wml11:elevation_m>
            </xsl:when>
        </xsl:choose>
        <xsl:if
            test="$site/wqx:MonitoringLocationGeospatial/wqx:VerticalCoordinateReferenceSystemDatumName">
            <wml11:verticalDatum>
                <xsl:value-of
                    select="$site/wqx:MonitoringLocationGeospatial/wqx:VerticalCoordinateReferenceSystemDatumName"
                />
            </wml11:verticalDatum>
        </xsl:if>

        <xsl:apply-templates
            select="$site/wqx:MonitoringLocationGeospatial/wqx:CountyCode
                 | $site/wqx:MonitoringLocationGeospatial/wqx:StateCode
                  | $site/wqx:MonitoringLocationGeospatial/wqx:CountryCode
                  | $site/wqx:MonitoringLocationIdentity/wqx:MonitoringLocationTypeName"/>


    </xsl:template>
    
    <xsl:template match="wqx:MonitoringLocationIdentity/wqx:MonitoringLocationTypeName">
        <xsl:call-template name="saParam" >
            <xsl:with-param name="name">siteType</xsl:with-param>
            
        </xsl:call-template>
        
    </xsl:template>
    <xsl:template match="wqx:MonitoringLocationGeospatial/wqx:CountyCode">
        <xsl:call-template name="saParam">
            <xsl:with-param name="name">CountyCode</xsl:with-param>

        </xsl:call-template>
    </xsl:template>
    <xsl:template match="wqx:MonitoringLocationGeospatial/wqx:StateCode">
        <xsl:call-template name="saParam">
            <xsl:with-param name="name">StateCode</xsl:with-param>

        </xsl:call-template>
    </xsl:template>
    <xsl:template match="wqx:MonitoringLocationGeospatial/wqx:CountryCode">
        <xsl:call-template name="saParam">
            <xsl:with-param name="name">CountryCode</xsl:with-param>

        </xsl:call-template>
    </xsl:template>

    <xsl:template name="saParam">
        <xsl:param name="name"/>

        <xsl:if test="text() != ''">
            <!-- this is derived from a sampling feature, therefore sa namespace -->
            <wml11:siteProperty>
                <xsl:attribute name="name">
                    <xsl:value-of select="$name"/>
                </xsl:attribute>
                <xsl:value-of select="."/>
            </wml11:siteProperty>
        </xsl:if>
    </xsl:template>

</xsl:stylesheet>
