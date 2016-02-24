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
	/// 	This class represents the ComplexType NoteType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"NoteType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class NoteType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for NoteType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public NoteType()
		{
			_elementName = "NoteType";
			Init();
		}
		public NoteType(String elementName)
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
			m_Type = "";
			m_IsValidType = false;
			m_Href = "";
			m_IsValidHref = false;
			m_Title = "";
			m_IsValidTitle = false;
			m_Show = "";
			m_IsValidShow = false;


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
			tns.NoteType newObject = new tns.NoteType(_elementName);
			newObject.m_Type = m_Type;
			newObject.m_IsValidType = m_IsValidType;
			newObject.m_Href = m_Href;
			newObject.m_IsValidHref = m_IsValidHref;
			newObject.m_Title = m_Title;
			newObject.m_IsValidTitle = m_IsValidTitle;
			newObject.m_Show = m_Show;
			newObject.m_IsValidShow = m_IsValidShow;


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

		#region Attribute - type
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("type", "", "IsValidType", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Type
		{
			get 
			{ 
				if (m_IsValidType == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property type is not valid. Set typeValid = true");
				return m_Type;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidType = true;
				m_Type = value;
			}
		}
		/// <summary>
		/// 	Indicates if type contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for type is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get type
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidType
		{
			get
			{
				return m_IsValidType;
			}
			set 
			{ 
				if (value != m_IsValidType)
				{
					Type = "";
					m_IsValidType = value;
				}
			}
		}
		protected Boolean m_IsValidType;
		protected String m_Type;
		#endregion
		#region Attribute - href
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("href", "", "IsValidHref", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Href
		{
			get 
			{ 
				if (m_IsValidHref == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property href is not valid. Set hrefValid = true");
				return m_Href;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidHref = true;
				m_Href = value;
			}
		}
		/// <summary>
		/// 	Indicates if href contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for href is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get href
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidHref
		{
			get
			{
				return m_IsValidHref;
			}
			set 
			{ 
				if (value != m_IsValidHref)
				{
					Href = "";
					m_IsValidHref = value;
				}
			}
		}
		protected Boolean m_IsValidHref;
		protected String m_Href;
		#endregion
		#region Attribute - title
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("title", "", "IsValidTitle", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Title
		{
			get 
			{ 
				if (m_IsValidTitle == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property title is not valid. Set titleValid = true");
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
		/// 	Indicates if title contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for title is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get title
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
		#region Attribute - show
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("show", "", "IsValidShow", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Show
		{
			get 
			{ 
				if (m_IsValidShow == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property show is not valid. Set showValid = true");
				return m_Show;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidShow = true;
				m_Show = value;
			}
		}
		/// <summary>
		/// 	Indicates if show contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for show is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get show
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidShow
		{
			get
			{
				return m_IsValidShow;
			}
			set 
			{ 
				if (value != m_IsValidShow)
				{
					Show = "";
					m_IsValidShow = value;
				}
			}
		}
		protected Boolean m_IsValidShow;
		protected String m_Show;
		#endregion
	
		#region Attribute - ElementText

		/// <summary>
		/// 	The InnerText for this element
		/// </summary>
		/// <remarks>
		/// 	This class represents the element NoteType, this
		/// 	element is open, and as such we can place data into it.
		/// 	<BR>ie &lt;NoteType&gt;Some Data&lt;/NoteType&gt;</BR>
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


