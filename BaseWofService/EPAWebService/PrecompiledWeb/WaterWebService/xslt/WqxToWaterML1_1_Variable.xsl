<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:xd="http://www.oxygenxml.com/ns/doc/xsl"
    exclude-result-prefixes="xd"
    xmlns:wqx="http://qwwebservices.usgs.gov/schemas/WQX-Outbound/2_0/"
    xmlns:wml11="http://www.cuahsi.org/waterML/1.1/"
    xmlns:wml10="http://www.cuahsi.org/waterML/1.0/" xmlns:gml="http://www.opengis.net/gml/3.2"
    xmlns:wml2="http://www.opengis.net/waterml/2.0" xmlns:om="http://www.opengis.net/om/2.0"
    xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:sa="http://www.opengis.net/sampling/2.0"
    xmlns:sams="http://www.opengis.net/samplingSpatial/2.0" 
    version="1.0">
    <xd:doc scope="stylesheet">
        <xd:desc>
            <xd:p><xd:b>Created on:</xd:b> Nov 3, 2011</xd:p>
            <xd:p><xd:b>Author:</xd:b> valentin</xd:p>
            <xd:p></xd:p>
        </xd:desc>
    </xd:doc>
    <xsl:template name="ResultToVariable">
       <xsl:param name="aResult"></xsl:param>
        <xsl:param name="vocabulary"></xsl:param>
       
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
        <wml11:variable>
            <wml11:variableCode vocabulary="UNDEFINEDVocab" default="true" >
                    USU3</wml11:variableCode>
            <wml11:variableName><xsl:value-of select="$aResult/wqx:ResultDescription/wqx:CharacteristicName"/></wml11:variableName>
            <wml11:valueType>Field Observation</wml11:valueType>
            <wml11:dataType>Unknown</wml11:dataType>
            <wml11:generalCategory>Unknown</wml11:generalCategory>
                <xsl:if test="../wqx:ActivityDescription/wqx:ActivityMediaName">
                    <wml11:sampleMedium><xsl:value-of select="$aResult/../wqx:ActivityDescription/wqx:ActivityMediaName"/></wml11:sampleMedium>
                </xsl:if>
            <xsl:if test="$aResult/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode">
                   
               
               <xsl:call-template name="MeasureUnitCodeToUnit">
                   <xsl:with-param name="MeasureUnitCode" select="$aResult/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode"></xsl:with-param>
               </xsl:call-template>
               </xsl:if>
              <!--  <noDataValue>-9999</noDataValue> -->
            <wml11:timeScale isRegular="true">
                <wml11:unit>
                    <wml11:unitName>minute</wml11:unitName>
                    <wml11:unitType>Time</wml11:unitType>
                    <wml11:unitAbbreviation>min</wml11:unitAbbreviation>
                    <wml11:unitCode>102</wml11:unitCode>
                    </wml11:unit>
                <wml11:timeSupport>30</wml11:timeSupport>
                </wml11:timeScale>
            <xsl:if test="$aResult/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode">
            <xsl:call-template name="MeasureUnitCodeToSpeciation">
                <xsl:with-param name="MeasureUnitCode" select="$aResult/wqx:ResultDescription/wqx:ResultMeasure/wqx:MeasureUnitCode"></xsl:with-param>
            </xsl:call-template>
                </xsl:if>
            </wml11:variable>
            
          
        </xsl:template>
    <xsl:template name="MeasureUnitCodeToUnit" >
        <!-- this needs to be a large mapping table -->
        <xsl:param name="MeasureUnitCode">Unknown</xsl:param>  
        <wml11:unit>
            <wml11:unitName><xsl:value-of select="$MeasureUnitCode"/></wml11:unitName>
            <!-- <wml11:unitType>Potential Difference</wml11:unitType> -->
            <wml11:unitAbbreviation><xsl:value-of select="$MeasureUnitCode"/></wml11:unitAbbreviation>
            <!-- <wml11:unitCode></wml11:unitCode> -->
    </wml11:unit>
        
    </xsl:template>
    <xsl:template name="MeasureUnitCodeToSpeciation" >
        <!-- this needs to be a large mapping table -->
        <xsl:param name="MeasureUnitCode">Unknown</xsl:param>  
        <xsl:choose>
            <xsl:when test="contains($MeasureUnitCode, ' AS P')"><wml11:speciation>P</wml11:speciation></xsl:when>
            <xsl:when test="contains($MeasureUnitCode, ' AS C')"><wml11:speciation>C</wml11:speciation></xsl:when> 
            <xsl:otherwise><wml11:speciation>Unknown</wml11:speciation></xsl:otherwise>
        </xsl:choose>
      
            
        
    </xsl:template>
</xsl:stylesheet>