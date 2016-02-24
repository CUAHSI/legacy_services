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
	/// 	This class represents the ComplexType SourceType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"SourceType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class SourceType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for SourceType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public SourceType()
		{
			_elementName = "SourceType";
			Init();
		}
		public SourceType(String elementName)
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
			m_SourceID = 0;
			m_IsValidSourceID = false;
			m_Organization = "";
			m_IsValidOrganization = false; 
			m_SourceDescription = "";
			m_IsValidSourceDescription = false; 
			m_Metadata = null;
			m_ContactInformation = null;
			m_SourceLink = "";
			m_IsValidSourceLink = false; 



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
			tns.SourceType newObject = new tns.SourceType(_elementName);
			newObject.m_SourceID = m_SourceID;
			newObject.m_IsValidSourceID = m_IsValidSourceID;
			newObject.m_Organization = m_Organization;
			newObject.m_IsValidOrganization = m_IsValidOrganization;
			newObject.m_SourceDescription = m_SourceDescription;
			newObject.m_IsValidSourceDescription = m_IsValidSourceDescription;
			newObject.m_Metadata = null;
			if (m_Metadata != null)
				newObject.m_Metadata = (tns.MetaDataType)m_Metadata.Clone();
			newObject.m_ContactInformation = null;
			if (m_ContactInformation != null)
				newObject.m_ContactInformation = (tns.ContactInformationType)m_ContactInformation.Clone();
			newObject.m_SourceLink = m_SourceLink;
			newObject.m_IsValidSourceLink = m_IsValidSourceLink;


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

		#region Attribute - sourceID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("sourceID", "", "IsValidSourceID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Int32 SourceID
		{
			get 
			{ 
				if (m_IsValidSourceID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property sourceID is not valid. Set sourceIDValid = true");
				return m_SourceID;  
			}
			set 
			{ 
				m_IsValidSourceID = true;
				m_SourceID = value;
			}
		}
		/// <summary>
		/// 	Indicates if sourceID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for sourceID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get sourceID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSourceID
		{
			get
			{
				return m_IsValidSourceID;
			}
			set 
			{ 
				if (value != m_IsValidSourceID)
				{
					SourceID = 0;
					m_IsValidSourceID = value;
				}
			}
		}
		protected Boolean m_IsValidSourceID;
		protected Int32 m_SourceID;
		#endregion
		#region Attribute - Organization
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("Organization", "http://www.cuahsi.org/waterML/1.0/", "IsValidOrganization", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String Organization
		{
			get 
			{ 
				if (m_IsValidOrganization == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property Organization is not valid. Set OrganizationValid = true");
				return m_Organization;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidOrganization = true;
				m_Organization = value;
			}
		}
		/// <summary>
		/// 	Indicates if Organization contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for Organization is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get Organization
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOrganization
		{
			get
			{
				return m_IsValidOrganization;
			}
			set 
			{ 
				if (value != m_IsValidOrganization)
				{
					Organization = "";
					m_IsValidOrganization = value;
				}
			}
		}
		protected Boolean m_IsValidOrganization;
		protected String m_Organization;
		#endregion
		#region Attribute - SourceDescription
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("SourceDescription", "http://www.cuahsi.org/waterML/1.0/", "IsValidSourceDescription", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String SourceDescription
		{
			get 
			{ 
				if (m_IsValidSourceDescription == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property SourceDescription is not valid. Set SourceDescriptionValid = true");
				return m_SourceDescription;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidSourceDescription = true;
				m_SourceDescription = value;
			}
		}
		/// <summary>
		/// 	Indicates if SourceDescription contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for SourceDescription is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get SourceDescription
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSourceDescription
		{
			get
			{
				return m_IsValidSourceDescription;
			}
			set 
			{ 
				if (value != m_IsValidSourceDescription)
				{
					SourceDescription = "";
					m_IsValidSourceDescription = value;
				}
			}
		}
		protected Boolean m_IsValidSourceDescription;
		protected String m_SourceDescription;
		#endregion
		#region Attribute - Metadata
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("Metadata", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.MetaDataType))]
		public tns.MetaDataType Metadata
		{
			get 
			{ 
				return m_Metadata;  
			}
			set 
			{ 
				if (value == null)
					m_Metadata = null;
				else
				{
					SetElementName(value, "Metadata");
					m_Metadata = value; 
				}
			}
		}
		protected tns.MetaDataType m_Metadata;
		
		#endregion
		#region Attribute - ContactInformation
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("ContactInformation", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.ContactInformationType))]
		public tns.ContactInformationType ContactInformation
		{
			get 
			{ 
				return m_ContactInformation;  
			}
			set 
			{ 
				if (value == null)
					m_ContactInformation = null;
				else
				{
					SetElementName(value, "ContactInformation");
					m_ContactInformation = value; 
				}
			}
		}
		protected tns.ContactInformationType m_ContactInformation;
		
		#endregion
		#region Attribute - SourceLink
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("SourceLink", "http://www.cuahsi.org/waterML/1.0/", "IsValidSourceLink", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public String SourceLink
		{
			get 
			{ 
				if (m_IsValidSourceLink == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property SourceLink is not valid. Set SourceLinkValid = true");
				return m_SourceLink;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidSourceLink = true;
				m_SourceLink = value;
			}
		}
		/// <summary>
		/// 	Indicates if SourceLink contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for SourceLink is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get SourceLink
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSourceLink
		{
			get
			{
				return m_IsValidSourceLink;
			}
			set 
			{ 
				if (value != m_IsValidSourceLink)
				{
					SourceLink = "";
					m_IsValidSourceLink = value;
				}
			}
		}
		protected Boolean m_IsValidSourceLink;
		protected String m_SourceLink;
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


