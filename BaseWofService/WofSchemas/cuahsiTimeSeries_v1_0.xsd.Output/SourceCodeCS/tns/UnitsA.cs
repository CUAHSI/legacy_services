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
	/// 	This class represents the Element units
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"units", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class Units : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for Units
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public Units()
		{
			_elementName = "units";
			Init();
		}
		public Units(String elementName)
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
			m_UnitsAbbreviation = "";
			m_IsValidUnitsAbbreviation = false;
			m_UnitsCode = "";
			m_IsValidUnitsCode = false;
			m_UnitsType = tns.Enumerations.UnitsTypeEnum.Angle;
			m_IsValidUnitsType = false;


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
			tns.Units newObject = new tns.Units(_elementName);
			newObject.m_UnitsAbbreviation = m_UnitsAbbreviation;
			newObject.m_IsValidUnitsAbbreviation = m_IsValidUnitsAbbreviation;
			newObject.m_UnitsCode = m_UnitsCode;
			newObject.m_IsValidUnitsCode = m_IsValidUnitsCode;
			newObject.m_UnitsType = m_UnitsType;
			newObject.m_IsValidUnitsType = m_IsValidUnitsType;


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

		#region Attribute - unitsAbbreviation
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("unitsAbbreviation", "", "IsValidUnitsAbbreviation", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String UnitsAbbreviation
		{
			get 
			{ 
				if (m_IsValidUnitsAbbreviation == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property unitsAbbreviation is not valid. Set unitsAbbreviationValid = true");
				return m_UnitsAbbreviation;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidUnitsAbbreviation = true;
				m_UnitsAbbreviation = value;
			}
		}
		/// <summary>
		/// 	Indicates if unitsAbbreviation contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for unitsAbbreviation is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get unitsAbbreviation
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitsAbbreviation
		{
			get
			{
				return m_IsValidUnitsAbbreviation;
			}
			set 
			{ 
				if (value != m_IsValidUnitsAbbreviation)
				{
					UnitsAbbreviation = "";
					m_IsValidUnitsAbbreviation = value;
				}
			}
		}
		protected Boolean m_IsValidUnitsAbbreviation;
		protected String m_UnitsAbbreviation;
		#endregion
		#region Attribute - unitsCode
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("unitsCode", "", "IsValidUnitsCode", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String UnitsCode
		{
			get 
			{ 
				if (m_IsValidUnitsCode == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property unitsCode is not valid. Set unitsCodeValid = true");
				return m_UnitsCode;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidUnitsCode = true;
				m_UnitsCode = value;
			}
		}
		/// <summary>
		/// 	Indicates if unitsCode contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for unitsCode is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get unitsCode
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitsCode
		{
			get
			{
				return m_IsValidUnitsCode;
			}
			set 
			{ 
				if (value != m_IsValidUnitsCode)
				{
					UnitsCode = "";
					m_IsValidUnitsCode = value;
				}
			}
		}
		protected Boolean m_IsValidUnitsCode;
		protected String m_UnitsCode;
		#endregion
		#region Attribute - unitsType
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoEnum("unitsType", "", "IsValidUnitsType", typeof(tns.Enumerations), "UnitsTypeEnumFromString", "UnitsTypeEnumToString", null)]
		public tns.Enumerations.UnitsTypeEnum UnitsType
		{
			get 
			{ 
				if (m_IsValidUnitsType == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property unitsType is not valid. Set unitsTypeValid = true");
				return m_UnitsType;  
			}
			set 
			{ 
				m_UnitsType = value;
				m_IsValidUnitsType = true;
			}
		}
		/// <summary>
		/// 	Indicates if unitsType contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for unitsType is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.UnitsTypeEnum.Angle).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get unitsType
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitsType
		{
			get { return m_IsValidUnitsType;  }
			set 
			{ 
				if (value != m_IsValidUnitsType)
				{
					UnitsType = tns.Enumerations.UnitsTypeEnum.Angle;
					m_IsValidUnitsType = value;
				}
			}
		}
		protected tns.Enumerations.UnitsTypeEnum m_UnitsType;
		protected Boolean m_IsValidUnitsType;

		#endregion
	
		#region Attribute - ElementText

		/// <summary>
		/// 	The InnerText for this element
		/// </summary>
		/// <remarks>
		/// 	This class represents the element Units, this
		/// 	element is open, and as such we can place data into it.
		/// 	<BR>ie &lt;Units&gt;Some Data&lt;/Units&gt;</BR>
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


