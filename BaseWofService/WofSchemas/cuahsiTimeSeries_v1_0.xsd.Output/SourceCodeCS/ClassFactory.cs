using System;
using System.Xml;

/**********************************************************************************************
 * Copyright (c) 2001-2010 Liquid Technologies Limited. All rights reserved.
 * See www.liquid-technologies.com for product details.
 *
 * Please see products End User License Agreement for distribution permissions.
 *
 * WARNING: THIS FILE IS GENERATED
 * Changes made outside of ##HAND_CODED_BLOCK_START blocks will be overwritten
 *
 * Generation  : by Liquid XML Data Binder 8.1.4.2482
 * Using Schema: C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd
 **********************************************************************************************/

namespace cuahsiTimeSeries_v1_0Lib 
{
	public class ClassFactory : LiquidTechnologies.Runtime.Net20.ClassFactoryBase
	{


		/// <summary>
		/// Creates an object from XML data held in a string.
		/// </summary>
		/// <param name="xmlIn">The data to be loaded</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXml( String xmlIn )
		{
			return FromXml( xmlIn, LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default );
		}
		/// <summary>
		/// Creates an object from XML data held in a string.
		/// </summary>
		/// <param name="xmlIn">The data to be loaded</param>
		/// <param name="context">The context to use when loading the data</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXml( String xmlIn, LiquidTechnologies.Runtime.Net20.XmlSerializationContext context )
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.PreserveWhitespace  = true;
			xmlDoc.LoadXml(xmlIn);
			return FromXmlElement(xmlDoc.DocumentElement, context);
		}

		/// <summary>
		/// Creates an object from XML data held in a File
		/// </summary>
		/// <param name="FileName">The file to be loaded</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXmlFile( String FileName )
		{
			return FromXmlFile(FileName, LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default);
		}
		/// <summary>
		/// Creates an object from XML data held in a File
		/// </summary>
		/// <param name="FileName">The file to be loaded</param>
		/// <param name="context">The context to use when loading the data</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXmlFile( String FileName, LiquidTechnologies.Runtime.Net20.XmlSerializationContext context )
		{
			using (System.IO.Stream stream = new System.IO.FileStream(FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read,System.IO.FileShare.Read))
			{
				return FromXmlStream(stream, context);
			}
		}

		/// <summary>
		/// Creates an object from XML data held in a stream.
		/// </summary>
		/// <param name="stream">The data to be loaded</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXmlStream(System.IO.Stream stream)
		{
			return FromXmlStream(stream, LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default);
		}
		/// <summary>
		/// Creates an object from XML data held in a stream.
		/// </summary>
		/// <param name="stream">The data to be loaded</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXmlStream(System.IO.Stream stream, LiquidTechnologies.Runtime.Net20.XmlSerializationContext context)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.PreserveWhitespace  = true;
			// use regular XML Parser
			xmlDoc.Load(stream);
	
			return FromXmlElement(xmlDoc.DocumentElement, context);

		}

		
		/// <summary>
		/// Creates an object from an XML Element.
		/// </summary>
		/// <param name="xmlParent">The data that needs loading</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXmlElement(XmlElement xmlParent)
		{
			return FromXmlElement(xmlParent, LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default);
		}
			
		/// <summary>
		/// Creates an object from an XML Element.
		/// </summary>
		/// <param name="xmlParent">The data that needs loading</param>
		/// <param name="context">The context to use when loading the data</param>
		/// <returns>The wrapper object, loaded with the supplied data</returns>
		/// <remarks>Throws an exception if the XML data is not compatable with the schema</remarks>
		static public LiquidTechnologies.Runtime.Net20.XmlObjectBase FromXmlElement(XmlElement xmlParent, LiquidTechnologies.Runtime.Net20.XmlSerializationContext context)
		{
			LiquidTechnologies.Runtime.Net20.XmlObjectBase retVal = null;
			String elementName;
			String elementNamespaceUri;


			// Get the type name this is either 
			// from the element ie <Parent>... = Parent
			// or from the type ie <Parent xsi:type="someNS:SomeElement">... = SomeElement
			if (GetElementType(xmlParent) == "")
			{
				elementName = xmlParent.LocalName;
				elementNamespaceUri = xmlParent.NamespaceURI;
			}
			else
			{
				elementName = GetElementType(xmlParent);
				elementNamespaceUri = GetElementTypeNamespaceUri(xmlParent);
			}

			// create the appropriate object
			if (elementName == null || elementName == String.Empty)
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidParamException("The element to load has no name"); 
			else if (elementName == "ContactInformationType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.ContactInformationType();
			else if (elementName == "criteria" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Criteria();
			else if (elementName == "datasetInfo" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.DatasetInfo();
			else if (elementName == "DataSetInfoType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.DataSetInfoType();
			else if (elementName == "daylightSavingsTimeZone" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.DaylightSavingsTimeZone();
			else if (elementName == "defaultTimeZone" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.DefaultTimeZone();
			else if (elementName == "extension" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Extension();
			else if (elementName == "GeogLocationType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.GeogLocationType();
			else if (elementName == "geoLocation" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.GeoLocation();
			else if (elementName == "latLonBox" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonBox();
			else if (elementName == "LatLonBoxType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonBoxType();
			else if (elementName == "latLonPoint" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonPoint();
			else if (elementName == "LatLonPointType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonPointType();
			else if (elementName == "localSiteXY" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LocalSiteXY();
			else if (elementName == "MetaDataType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.MetaDataType();
			else if (elementName == "MethodType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.MethodType();
			else if (elementName == "NoteType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.NoteType();
			else if (elementName == "OffsetType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.OffsetType();
			else if (elementName == "option" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.Option();
			else if (elementName == "option" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Option();
			else if (elementName == "optionGroup" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.OptionGroup();
			else if (elementName == "options" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.Options();
			else if (elementName == "options" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Options();
			else if (elementName == "parentID" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.ParentID();
			else if (elementName == "qualifier" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.Qualifier();
			else if (elementName == "qualifier" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Qualifier();
			else if (elementName == "qualifier" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.QualifierA();
			else if (elementName == "qualityControlLevel" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.QualityControlLevel();
			else if (elementName == "qualityControlLevel" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.QualityControlLevel();
			else if (elementName == "QualityControlLevelType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.QualityControlLevelType();
			else if (elementName == "QueryInfoType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.QueryInfoType();
			else if (elementName == "related" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Related();
			else if (elementName == "relatedID" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.RelatedID();
			else if (elementName == "series" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Series();
			else if (elementName == "seriesCatalogType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SeriesCatalogType();
			else if (elementName == "site" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.Site();
			else if (elementName == "site" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Site();
			else if (elementName == "siteCode" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SiteCode();
			else if (elementName == "SiteInfoType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SiteInfoType();
			else if (elementName == "sitesResponse" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SitesResponse();
			else if (elementName == "SourceInfoType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SourceInfoType();
			else if (elementName == "SourceType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SourceType();
			else if (elementName == "TimeIntervalType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeIntervalType();
			else if (elementName == "timeParam" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeParam();
			else if (elementName == "TimePeriodRealTimeType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimePeriodRealTimeType();
			else if (elementName == "TimePeriodType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimePeriodType();
			else if (elementName == "timeSeriesResponse" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeSeriesResponse();
			else if (elementName == "TimeSeriesType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeSeriesType();
			else if (elementName == "TimeSingleType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeSingleType();
			else if (elementName == "timeSupport" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeSupport();
			else if (elementName == "timeZoneInfo" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.TimeZoneInfo();
			else if (elementName == "timeZoneInfo" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeZoneInfo();
			else if (elementName == "TsValuesSingleVariableType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TsValuesSingleVariableType();
			else if (elementName == "units" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.Units();
			else if (elementName == "units" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Units();
			else if (elementName == "UnitsType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.UnitsType();
			else if (elementName == "valueCount" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.ValueCount();
			else if (elementName == "ValueSingleVariable" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.ValueSingleVariable();
			else if (elementName == "variableCode" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.VariableCode();
			else if (elementName == "variableCode" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.VariableCode();
			else if (elementName == "VariableInfoType" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.VariableInfoType();
			else if (elementName == "VariableInfoType_related_Group" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.VariableInfoType_related_Group();
			else if (elementName == "variables" && elementNamespaceUri == "")
				retVal = new cuahsiTimeSeries_v1_0Lib.Variables();
			else if (elementName == "variables" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.Variables();
			else if (elementName == "variablesResponse" && elementNamespaceUri == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.VariablesResponse();
			else
			{
				throw new LiquidTechnologies.Runtime.Net20.LtException(
					string.Format("Failed load the element {0}:{1}. No appropriate class exists to load the data into. Ensure that the XML document complies with the schema.", 
						xmlParent.Name, xmlParent.NamespaceURI)); 
			}
			
			// load the data into the object
			retVal.FromXmlElement(xmlParent, context);

			return retVal;
		}


	}
}
namespace msdata 
{
	public class ClassFactory : LiquidTechnologies.Runtime.Net20.ClassFactoryBase
	{


	}
}
namespace gml 
{
	public class ClassFactory : LiquidTechnologies.Runtime.Net20.ClassFactoryBase
	{


	}
}
namespace xlink 
{
	public class ClassFactory : LiquidTechnologies.Runtime.Net20.ClassFactoryBase
	{


	}
}
namespace sql 
{
	public class ClassFactory : LiquidTechnologies.Runtime.Net20.ClassFactoryBase
	{


	}
}
namespace tns 
{
	public class ClassFactory : LiquidTechnologies.Runtime.Net20.ClassFactoryBase
	{



		// Were trying to create a class, however it may be any one of the derived 
		// classes that be want, so we need to create them, if they fail move on to
		// the next, until we have one that fits.		
		static public IGeogLocationType IGeogLocationTypeCreateObject(XmlElement xmlParent)
		{
			tns.IGeogLocationType retVal = null;

			// Get the type name
			String typeName = GetElementType(xmlParent);

			if (typeName == "")
				return new tns.GeogLocationType();
		
			
			if (retVal == null && typeName == "GeogLocationType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.GeogLocationType();
			if (retVal == null && typeName == "latLonBox"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonBox();
			if (retVal == null && typeName == "LatLonBoxType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonBoxType();
			if (retVal == null && typeName == "latLonPoint"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonPoint();
			if (retVal == null && typeName == "LatLonPointType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.LatLonPointType();
		
			return retVal;
		}

		// Were trying to create a class, however it may be any one of the derived 
		// classes that be want, so we need to create them, if they fail move on to
		// the next, until we have one that fits.		
		static public ISourceInfoType ISourceInfoTypeCreateObject(XmlElement xmlParent)
		{
			tns.ISourceInfoType retVal = null;

			// Get the type name
			String typeName = GetElementType(xmlParent);

			if (typeName == "")
				return new tns.SourceInfoType();
		
			
			if (retVal == null && typeName == "SourceInfoType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SourceInfoType();
			if (retVal == null && typeName == "datasetInfo"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.DatasetInfo();
			if (retVal == null && typeName == "DataSetInfoType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.DataSetInfoType();
			if (retVal == null && typeName == "SiteInfoType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.SiteInfoType();
		
			return retVal;
		}

		// Were trying to create a class, however it may be any one of the derived 
		// classes that be want, so we need to create them, if they fail move on to
		// the next, until we have one that fits.		
		static public ITimePeriodType ITimePeriodTypeCreateObject(XmlElement xmlParent)
		{
			tns.ITimePeriodType retVal = null;

			// Get the type name
			String typeName = GetElementType(xmlParent);

			if (typeName == "")
				return new tns.TimePeriodType();
		
			
			if (retVal == null && typeName == "TimePeriodType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimePeriodType();
			if (retVal == null && typeName == "TimeSingleType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeSingleType();
			if (retVal == null && typeName == "TimePeriodRealTimeType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimePeriodRealTimeType();
			if (retVal == null && typeName == "TimeIntervalType"  && GetElementTypeNamespaceUri(xmlParent) == "http://www.cuahsi.org/waterML/1.0/")
				retVal = new tns.TimeIntervalType();
		
			return retVal;
		}
	}
}

