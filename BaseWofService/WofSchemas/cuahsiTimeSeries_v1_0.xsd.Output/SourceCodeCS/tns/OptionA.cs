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
	/// 	This class represents the Element option
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"option", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class Option : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for Option
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public Option()
		{
			_elementName = "option";
			Init();
		}
		public Option(String elementName)
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
			m_Name = "";
			m_IsValidName = false;
			m_OptionID = 0;
			m_IsValidOptionID = false;
			m_OptionCode = "";
			m_IsValidOptionCode = false;


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
			tns.Option newObject = new tns.Option(_elementName);
			newObject.m_Name = m_Name;
			newObject.m_IsValidName = m_IsValidName;
			newObject.m_OptionID = m_OptionID;
			newObject.m_IsValidOptionID = m_IsValidOptionID;
			newObject.m_OptionCode = m_OptionCode;
			newObject.m_IsValidOptionCode = m_IsValidOptionCode;


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

		#region Attribute - name
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("name", "", "IsValidName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String Name
		{
			get 
			{ 
				if (m_IsValidName == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property name is not valid. Set nameValid = true");
				return m_Name;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidName = true;
				m_Name = value;
			}
		}
		/// <summary>
		/// 	Indicates if name contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for name is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get name
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidName
		{
			get
			{
				return m_IsValidName;
			}
			set 
			{ 
				if (value != m_IsValidName)
				{
					Name = "";
					m_IsValidName = value;
				}
			}
		}
		protected Boolean m_IsValidName;
		protected String m_Name;
		#endregion
		#region Attribute - optionID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("optionID", "", "IsValidOptionID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_integer, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public LiquidTechnologies.Runtime.Net20.BigInteger OptionID
		{
			get 
			{ 
				if (m_IsValidOptionID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property optionID is not valid. Set optionIDValid = true");
				return m_OptionID;  
			}
			set 
			{ 
				m_IsValidOptionID = true;
				m_OptionID = value;
			}
		}
		/// <summary>
		/// 	Indicates if optionID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for optionID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get optionID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOptionID
		{
			get
			{
				return m_IsValidOptionID;
			}
			set 
			{ 
				if (value != m_IsValidOptionID)
				{
					OptionID = 0;
					m_IsValidOptionID = value;
				}
			}
		}
		protected Boolean m_IsValidOptionID;
		protected LiquidTechnologies.Runtime.Net20.BigInteger m_OptionID;
		#endregion
		#region Attribute - optionCode
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("optionCode", "", "IsValidOptionCode", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String OptionCode
		{
			get 
			{ 
				if (m_IsValidOptionCode == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property optionCode is not valid. Set optionCodeValid = true");
				return m_OptionCode;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidOptionCode = true;
				m_OptionCode = value;
			}
		}
		/// <summary>
		/// 	Indicates if optionCode contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for optionCode is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get optionCode
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOptionCode
		{
			get
			{
				return m_IsValidOptionCode;
			}
			set 
			{ 
				if (value != m_IsValidOptionCode)
				{
					OptionCode = "";
					m_IsValidOptionCode = value;
				}
			}
		}
		protected Boolean m_IsValidOptionCode;
		protected String m_OptionCode;
		#endregion
	
		#region Attribute - ElementText

		/// <summary>
		/// 	The InnerText for this element
		/// </summary>
		/// <remarks>
		/// 	This class represents the element Option, this
		/// 	element is open, and as such we can place data into it.
		/// 	<BR>ie &lt;Option&gt;Some Data&lt;/Option&gt;</BR>
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


