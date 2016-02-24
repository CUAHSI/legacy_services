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
	/// 	This class represents the ComplexType MetaDataType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"MetaDataType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class MetaDataType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for MetaDataType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public MetaDataType()
		{
			_elementName = "MetaDataType";
			Init();
		}
		public MetaDataType(String elementName)
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
			m_TopicCategory = "";
			m_IsValidTopicCategory = false; 
			m_Title = "";
			m_IsValidTitle = false; 
			m_Abstract = "";
			m_IsValidAbstract = false; 
			m_ProfileVersion = "";
			m_IsValidProfileVersion = false; 
			m_MetadataLink = "";
			m_IsValidMetadataLink = false; 



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
			tns.MetaDataType newObject = new tns.MetaDataType(_elementName);
			newObject.m_TopicCategory = m_TopicCategory;
			newObject.m_IsValidTopicCategory = m_IsValidTopicCategory;
			newObject.m_Title = m_Title;
			newObject.m_IsValidTitle = m_IsValidTitle;
			newObject.m_Abstract = m_Abstract;
			newObject.m_IsValidAbstract = m_IsValidAbstract;
			newObject.m_ProfileVersion = m_ProfileVersion;
			newObject.m_IsValidProfileVersion = m_IsValidProfileVersion;
			newObject.m_MetadataLink = m_MetadataLink;
			newObject.m_IsValidMetadataLink = m_IsValidMetadataLink;


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

		#region Attribute - TopicCategory
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("TopicCategory", "http://www.cuahsi.org/waterML/1.0/", "IsValidTopicCategory", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String TopicCategory
		{
			get 
			{ 
				if (m_IsValidTopicCategory == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property TopicCategory is not valid. Set TopicCategoryValid = true");
				return m_TopicCategory;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidTopicCategory = true;
				m_TopicCategory = value;
			}
		}
		/// <summary>
		/// 	Indicates if TopicCategory contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for TopicCategory is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get TopicCategory
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidTopicCategory
		{
			get
			{
				return m_IsValidTopicCategory;
			}
			set 
			{ 
				if (value != m_IsValidTopicCategory)
				{
					TopicCategory = "";
					m_IsValidTopicCategory = value;
				}
			}
		}
		protected Boolean m_IsValidTopicCategory;
		protected String m_TopicCategory;
		#endregion
		#region Attribute - Title
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("Title", "http://www.cuahsi.org/waterML/1.0/", "IsValidTitle", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String Title
		{
			get 
			{ 
				if (m_IsValidTitle == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property Title is not valid. Set TitleValid = true");
				return m_Title;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidTitle = true;
				m_Title = value;
			}
		}
		/// <summary>
		/// 	Indicates if Title contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for Title is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get Title
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidTitle
		{
			get
			{
				return m_IsValidTitle;
			}
			set 
			{ 
				if (value != m_IsValidTitle)
				{
					Title = "";
					m_IsValidTitle = value;
				}
			}
		}
		protected Boolean m_IsValidTitle;
		protected String m_Title;
		#endregion
		#region Attribute - Abstract
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("Abstract", "http://www.cuahsi.org/waterML/1.0/", "IsValidAbstract", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String abstract_
		{
			get 
			{ 
				if (m_IsValidAbstract == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property abstract_ is not valid. Set abstract_Valid = true");
				return m_Abstract;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidAbstract = true;
				m_Abstract = value;
			}
		}
		/// <summary>
		/// 	Indicates if abstract_ contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for abstract_ is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get abstract_
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidAbstract
		{
			get
			{
				return m_IsValidAbstract;
			}
			set 
			{ 
				if (value != m_IsValidAbstract)
				{
					abstract_ = "";
					m_IsValidAbstract = value;
				}
			}
		}
		protected Boolean m_IsValidAbstract;
		protected String m_Abstract;
		#endregion
		#region Attribute - ProfileVersion
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("ProfileVersion", "http://www.cuahsi.org/waterML/1.0/", "IsValidProfileVersion", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String ProfileVersion
		{
			get 
			{ 
				if (m_IsValidProfileVersion == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property ProfileVersion is not valid. Set ProfileVersionValid = true");
				return m_ProfileVersion;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidProfileVersion = true;
				m_ProfileVersion = value;
			}
		}
		/// <summary>
		/// 	Indicates if ProfileVersion contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for ProfileVersion is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get ProfileVersion
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidProfileVersion
		{
			get
			{
				return m_IsValidProfileVersion;
			}
			set 
			{ 
				if (value != m_IsValidProfileVersion)
				{
					ProfileVersion = "";
					m_IsValidProfileVersion = value;
				}
			}
		}
		protected Boolean m_IsValidProfileVersion;
		protected String m_ProfileVersion;
		#endregion
		#region Attribute - MetadataLink
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("MetadataLink", "http://www.cuahsi.org/waterML/1.0/", "IsValidMetadataLink", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public String MetadataLink
		{
			get 
			{ 
				if (m_IsValidMetadataLink == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property MetadataLink is not valid. Set MetadataLinkValid = true");
				return m_MetadataLink;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidMetadataLink = true;
				m_MetadataLink = value;
			}
		}
		/// <summary>
		/// 	Indicates if MetadataLink contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for MetadataLink is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get MetadataLink
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidMetadataLink
		{
			get
			{
				return m_IsValidMetadataLink;
			}
			set 
			{ 
				if (value != m_IsValidMetadataLink)
				{
					MetadataLink = "";
					m_IsValidMetadataLink = value;
				}
			}
		}
		protected Boolean m_IsValidMetadataLink;
		protected String m_MetadataLink;
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


