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

namespace tns
{
	/// <summary>
	/// 	This class represents the ComplexType SiteInfoType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"SiteInfoType", "http://www.cuahsi.org/waterML/1.0/", true, true)]
	public partial class SiteInfoType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
					, tns.ISourceInfoType
	{
		#region Constructors
		/// <summary>
		///		Constructor for SiteInfoType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public SiteInfoType()
		{
			_elementName = "SiteInfoType";
			Init();
		}
		public SiteInfoType(String elementName)
		{
			_elementName = elementName;
			Init();
		}
		#endregion

		#region Initilization methods for the class
		/// <summary>
		///		Initilizes the class
		/// </summary>
		/// <remarks>
		///		<BR>The Creates all the mandatory fields (populated with the default data) 
		///		All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd.</BR>
		/// </remarks>
		protected override void Init()
		{
			cuahsiTimeSeries_v1_0Lib.Registration.iRegistrationIndicator = 0; // causes registration to take place
			m_Oid = "";
			m_IsValidOid = false;
			m_MetadataDateTime = new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime);
			m_IsValidMetadataDateTime = false;
			m_SiteName = "";
			m_IsValidSiteName = false; 
			m_SiteCode = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SiteCode>("siteCode", "http://www.cuahsi.org/waterML/1.0/", 1, -1, false);
			m_TimeZoneInfo = null;
			m_GeoLocation = null;
			m_Elevation_m = 0;
			m_IsValidElevation_m = false; 
			m_VerticalDatum = "";
			m_IsValidVerticalDatum = false; 
			m_Note = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType>("note", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_Extension = null;
			m_Altname = new cuahsiTimeSeries_v1_0Lib.XmlSimpleTypeCollection<String>("altname", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, 0, -1, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, new LiquidTechnologies.Runtime.Net20.PrimitiveRestrictions("", -1, -1, "", "", "", "", -1));



// ##HAND_CODED_BLOCK_START ID="Additional Inits"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional initilization code here...

// ##HAND_CODED_BLOCK_END ID="Additional Inits"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
		}
		#endregion

		#region ICloneable Interface
		/// <summary>
		///		Allows the class to be copied
		/// </summary>
		/// <remarks>
		///		Performs a 'deep copy' of all the data in the class (and its children)
		/// </remarks>
		public override object Clone()
		{
			tns.SiteInfoType newObject = new tns.SiteInfoType(_elementName);
			newObject.m_Oid = m_Oid;
			newObject.m_IsValidOid = m_IsValidOid;
			newObject.m_MetadataDateTime = (LiquidTechnologies.Runtime.Net20.XmlDateTime)m_MetadataDateTime.Clone();
			newObject.m_IsValidMetadataDateTime = m_IsValidMetadataDateTime;
			newObject.m_SiteName = m_SiteName;
			newObject.m_IsValidSiteName = m_IsValidSiteName;
			foreach (tns.SiteCode o in m_SiteCode)
				newObject.m_SiteCode.Add((tns.SiteCode)o.Clone());
			newObject.m_TimeZoneInfo = null;
			if (m_TimeZoneInfo != null)
				newObject.m_TimeZoneInfo = (cuahsiTimeSeries_v1_0Lib.TimeZoneInfo)m_TimeZoneInfo.Clone();
			newObject.m_GeoLocation = null;
			if (m_GeoLocation != null)
				newObject.m_GeoLocation = (tns.GeoLocation)m_GeoLocation.Clone();
			newObject.m_Elevation_m = m_Elevation_m;
			newObject.m_IsValidElevation_m = m_IsValidElevation_m;
			newObject.m_VerticalDatum = m_VerticalDatum;
			newObject.m_IsValidVerticalDatum = m_IsValidVerticalDatum;
			foreach (tns.NoteType o in m_Note)
				newObject.m_Note.Add((tns.NoteType)o.Clone());
			newObject.m_Extension = null;
			if (m_Extension != null)
				newObject.m_Extension = (LiquidTechnologies.Runtime.Net20.Element)m_Extension.Clone();
			foreach (String o in m_Altname)
				newObject.m_Altname.Add(o);


// ##HAND_CODED_BLOCK_START ID="Additional clone"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional clone code here...

// ##HAND_CODED_BLOCK_END ID="Additional clone"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

			return newObject;
		}
		#endregion

		#region Member variables

		protected override String TargetNamespace
		{
			get { return "http://www.cuahsi.org/waterML/1.0/"; }
		}

		#region Attribute - oid
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("oid", "", "IsValidOid", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String Oid
		{
			get 
			{ 
				if (m_IsValidOid == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property oid is not valid. Set oidValid = true");
				return m_Oid;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidOid = true;
				m_Oid = value;
			}
		}
		/// <summary>
		/// 	Indicates if oid contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for oid is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get oid
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOid
		{
			get
			{
				return m_IsValidOid;
			}
			set 
			{ 
				if (value != m_IsValidOid)
				{
					Oid = "";
					m_IsValidOid = value;
				}
			}
		}
		protected Boolean m_IsValidOid;
		protected String m_Oid;
		#endregion
		#region Attribute - metadataDateTime
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("metadataDateTime", "", "IsValidMetadataDateTime", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_datetime, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public LiquidTechnologies.Runtime.Net20.XmlDateTime MetadataDateTime
		{
			get 
			{ 
				if (m_IsValidMetadataDateTime == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property metadataDateTime is not valid. Set metadataDateTimeValid = true");
				return m_MetadataDateTime;  
			}
			set 
			{ 
				m_IsValidMetadataDateTime = true;
				m_MetadataDateTime.SetDateTime(value, m_MetadataDateTime.Type); 
			}
		}
		/// <summary>
		/// 	Indicates if metadataDateTime contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for metadataDateTime is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime)).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get metadataDateTime
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidMetadataDateTime
		{
			get
			{
				return m_IsValidMetadataDateTime;
			}
			set 
			{ 
				if (value != m_IsValidMetadataDateTime)
				{
					MetadataDateTime = new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime);
					m_IsValidMetadataDateTime = value;
				}
			}
		}
		protected Boolean m_IsValidMetadataDateTime;
		protected LiquidTechnologies.Runtime.Net20.XmlDateTime m_MetadataDateTime;
		#endregion
		#region Attribute - siteName
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("siteName", "http://www.cuahsi.org/waterML/1.0/", "IsValidSiteName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String SiteName
		{
			get 
			{ 
				if (m_IsValidSiteName == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property siteName is not valid. Set siteNameValid = true");
				return m_SiteName;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidSiteName = true;
				m_SiteName = value;
			}
		}
		/// <summary>
		/// 	Indicates if siteName contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for siteName is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get siteName
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSiteName
		{
			get
			{
				return m_IsValidSiteName;
			}
			set 
			{ 
				if (value != m_IsValidSiteName)
				{
					SiteName = "";
					m_IsValidSiteName = value;
				}
			}
		}
		protected Boolean m_IsValidSiteName;
		protected String m_SiteName;
		#endregion
		#region Attribute - siteCode
		/// <summary>
		/// 	A collection of siteCode's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 1 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("siteCode", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SiteCode> SiteCode
		{
			get { return m_SiteCode; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SiteCode> m_SiteCode;
		
		#endregion
		#region Attribute - timeZoneInfo
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("timeZoneInfo", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(cuahsiTimeSeries_v1_0Lib.TimeZoneInfo))]
		public cuahsiTimeSeries_v1_0Lib.TimeZoneInfo TimeZoneInfo
		{
			get 
			{ 
				return m_TimeZoneInfo;  
			}
			set 
			{ 
				if (value == null)
					m_TimeZoneInfo = null;
				else
				{
					SetElementName(value, "timeZoneInfo");
					m_TimeZoneInfo = value; 
				}
			}
		}
		protected cuahsiTimeSeries_v1_0Lib.TimeZoneInfo m_TimeZoneInfo;
		
		#endregion
		#region Attribute - geoLocation
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("geoLocation", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.GeoLocation))]
		public tns.GeoLocation GeoLocation
		{
			get 
			{ 
				return m_GeoLocation;  
			}
			set 
			{ 
				if (value == null)
					m_GeoLocation = null;
				else
				{
					SetElementName(value, "geoLocation");
					m_GeoLocation = value; 
				}
			}
		}
		protected tns.GeoLocation m_GeoLocation;
		
		#endregion
		#region Attribute - elevation_m
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("elevation_m", "http://www.cuahsi.org/waterML/1.0/", "IsValidElevation_m", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Double Elevation_m
		{
			get 
			{ 
				if (m_IsValidElevation_m == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property elevation_m is not valid. Set elevation_mValid = true");
				return m_Elevation_m;  
			}
			set 
			{ 
				m_IsValidElevation_m = true;
				m_Elevation_m = value;
			}
		}
		/// <summary>
		/// 	Indicates if elevation_m contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for elevation_m is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get elevation_m
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidElevation_m
		{
			get
			{
				return m_IsValidElevation_m;
			}
			set 
			{ 
				if (value != m_IsValidElevation_m)
				{
					Elevation_m = 0;
					m_IsValidElevation_m = value;
				}
			}
		}
		protected Boolean m_IsValidElevation_m;
		protected Double m_Elevation_m;
		#endregion
		#region Attribute - verticalDatum
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("verticalDatum", "http://www.cuahsi.org/waterML/1.0/", "IsValidVerticalDatum", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String VerticalDatum
		{
			get 
			{ 
				if (m_IsValidVerticalDatum == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property verticalDatum is not valid. Set verticalDatumValid = true");
				return m_VerticalDatum;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidVerticalDatum = true;
				m_VerticalDatum = value;
			}
		}
		/// <summary>
		/// 	Indicates if verticalDatum contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for verticalDatum is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get verticalDatum
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidVerticalDatum
		{
			get
			{
				return m_IsValidVerticalDatum;
			}
			set 
			{ 
				if (value != m_IsValidVerticalDatum)
				{
					VerticalDatum = "";
					m_IsValidVerticalDatum = value;
				}
			}
		}
		protected Boolean m_IsValidVerticalDatum;
		protected String m_VerticalDatum;
		#endregion
		#region Attribute - note
		/// <summary>
		/// 	A collection of note's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("note", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType> Note
		{
			get { return m_Note; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType> m_Note;
		
		#endregion
		#region Attribute - extension
		/// <summary>
		///		Represents an optional untyped element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqUntpdOpt("extension", "http://www.cuahsi.org/waterML/1.0/", "##any", "http://www.cuahsi.org/waterML/1.0/")]
		public LiquidTechnologies.Runtime.Net20.Element Extension
		{
			get
			{
				return m_Extension;  
			}
			set
			{
				if (value != null)
					LiquidTechnologies.Runtime.Net20.Element.TestNamespace(value.Namespace, "##any", "http://www.cuahsi.org/waterML/1.0/");
				m_Extension = value; 
			}
		}
		protected LiquidTechnologies.Runtime.Net20.Element m_Extension;
		#endregion
		#region Attribute - altname
		/// <summary>
		///		A collection of String's
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Element in the XML.</BR>
		///		<BR>This collection may contain 0 to Many String's.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimCol("altname", "http://www.cuahsi.org/waterML/1.0/")]
		public cuahsiTimeSeries_v1_0Lib.XmlSimpleTypeCollection<String> Altname
		{
			get { return m_Altname; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlSimpleTypeCollection<String> m_Altname;

		#endregion
	
		#region Attribute - Namespace
		public override String Namespace
		{
			get { return "http://www.cuahsi.org/waterML/1.0/"; }
		}	
		#endregion	

		#region Attribute - GetBase
		public override LiquidTechnologies.Runtime.Net20.XmlObjectBase GetBase()
		{
			return this;
		}
		#endregion
		#endregion

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}


