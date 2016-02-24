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
	/// 	This class represents the ComplexType siteCode
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"siteCode", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class SiteCode : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for SiteCode
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public SiteCode()
		{
			_elementName = "siteCode";
			Init();
		}
		public SiteCode(String elementName)
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
			m_DefaultId = false;
			m_IsValidDefaultId = false;
			m_Network = "";
			m_SiteID = "";
			m_IsValidSiteID = false;
			m_AgencyCode = "";
			m_IsValidAgencyCode = false;
			m_AgencyName = "";
			m_IsValidAgencyName = false;


			_elementText = "";

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
			tns.SiteCode newObject = new tns.SiteCode(_elementName);
			newObject.m_DefaultId = m_DefaultId;
			newObject.m_IsValidDefaultId = m_IsValidDefaultId;
			newObject.m_Network = m_Network;
			newObject.m_SiteID = m_SiteID;
			newObject.m_IsValidSiteID = m_IsValidSiteID;
			newObject.m_AgencyCode = m_AgencyCode;
			newObject.m_IsValidAgencyCode = m_IsValidAgencyCode;
			newObject.m_AgencyName = m_AgencyName;
			newObject.m_IsValidAgencyName = m_IsValidAgencyName;


			newObject._elementText = _elementText;
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

		#region Attribute - defaultId
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("defaultId", "", "IsValidDefaultId", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Boolean DefaultId
		{
			get 
			{ 
				if (m_IsValidDefaultId == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property defaultId is not valid. Set defaultIdValid = true");
				return m_DefaultId;  
			}
			set 
			{ 
				m_IsValidDefaultId = true;
				m_DefaultId = value;
			}
		}
		/// <summary>
		/// 	Indicates if defaultId contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for defaultId is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (false).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get defaultId
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidDefaultId
		{
			get
			{
				return m_IsValidDefaultId;
			}
			set 
			{ 
				if (value != m_IsValidDefaultId)
				{
					DefaultId = false;
					m_IsValidDefaultId = value;
				}
			}
		}
		protected Boolean m_IsValidDefaultId;
		protected Boolean m_DefaultId;
		#endregion
		#region Attribute - network
		/// <summary>
		///		Represents a mandatory Attribute in the XML document
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Attribute in the XML.</BR>
		///		<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>It is defaulted to "".</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("network", "", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String Network
		{
			get 
			{ 
				return m_Network;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_Network = value;
			}
		}
		protected String m_Network;

		#endregion
		#region Attribute - siteID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("siteID", "", "IsValidSiteID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String SiteID
		{
			get 
			{ 
				if (m_IsValidSiteID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property siteID is not valid. Set siteIDValid = true");
				return m_SiteID;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidSiteID = true;
				m_SiteID = value;
			}
		}
		/// <summary>
		/// 	Indicates if siteID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for siteID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get siteID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSiteID
		{
			get
			{
				return m_IsValidSiteID;
			}
			set 
			{ 
				if (value != m_IsValidSiteID)
				{
					SiteID = "";
					m_IsValidSiteID = value;
				}
			}
		}
		protected Boolean m_IsValidSiteID;
		protected String m_SiteID;
		#endregion
		#region Attribute - agencyCode
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("agencyCode", "", "IsValidAgencyCode", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String AgencyCode
		{
			get 
			{ 
				if (m_IsValidAgencyCode == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property agencyCode is not valid. Set agencyCodeValid = true");
				return m_AgencyCode;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidAgencyCode = true;
				m_AgencyCode = value;
			}
		}
		/// <summary>
		/// 	Indicates if agencyCode contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for agencyCode is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get agencyCode
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidAgencyCode
		{
			get
			{
				return m_IsValidAgencyCode;
			}
			set 
			{ 
				if (value != m_IsValidAgencyCode)
				{
					AgencyCode = "";
					m_IsValidAgencyCode = value;
				}
			}
		}
		protected Boolean m_IsValidAgencyCode;
		protected String m_AgencyCode;
		#endregion
		#region Attribute - agencyName
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("agencyName", "", "IsValidAgencyName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String AgencyName
		{
			get 
			{ 
				if (m_IsValidAgencyName == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property agencyName is not valid. Set agencyNameValid = true");
				return m_AgencyName;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidAgencyName = true;
				m_AgencyName = value;
			}
		}
		/// <summary>
		/// 	Indicates if agencyName contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for agencyName is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get agencyName
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidAgencyName
		{
			get
			{
				return m_IsValidAgencyName;
			}
			set 
			{ 
				if (value != m_IsValidAgencyName)
				{
					AgencyName = "";
					m_IsValidAgencyName = value;
				}
			}
		}
		protected Boolean m_IsValidAgencyName;
		protected String m_AgencyName;
		#endregion
	
		#region Attribute - ElementText

		/// <summary>
		/// 	The InnerText for this element
		/// </summary>
		/// <remarks>
		/// 	This class represents the element SiteCode, this
		/// 	element is open, and as such we can place data into it.
		/// 	<BR>ie &lt;SiteCode&gt;Some Data&lt;/SiteCode&gt;</BR>
		/// </remarks>
		public String Text
		{
			get
			{
				return _elementText;
			}
			set
			{
				_elementText = value;
			}
		}
		protected String _elementText;
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


