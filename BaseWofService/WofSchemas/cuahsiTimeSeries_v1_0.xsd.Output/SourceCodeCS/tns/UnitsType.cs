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
	/// 	This class represents the ComplexType UnitsType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"UnitsType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class UnitsType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for UnitsType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public UnitsType()
		{
			_elementName = "UnitsType";
			Init();
		}
		public UnitsType(String elementName)
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
			m_UnitID = 0;
			m_IsValidUnitID = false;
			m_UnitName = "";
			m_IsValidUnitName = false; 
			m_UnitDescription = "";
			m_IsValidUnitDescription = false; 
			m_UnitType = tns.Enumerations.UnitsTypeEnum.Angle;
			m_IsValidUnitType = false;
			m_UnitAbbreviation = "";
			m_IsValidUnitAbbreviation = false; 



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
			tns.UnitsType newObject = new tns.UnitsType(_elementName);
			newObject.m_UnitID = m_UnitID;
			newObject.m_IsValidUnitID = m_IsValidUnitID;
			newObject.m_UnitName = m_UnitName;
			newObject.m_IsValidUnitName = m_IsValidUnitName;
			newObject.m_UnitDescription = m_UnitDescription;
			newObject.m_IsValidUnitDescription = m_IsValidUnitDescription;
			newObject.m_UnitType = m_UnitType;
			newObject.m_IsValidUnitType = m_IsValidUnitType;
			newObject.m_UnitAbbreviation = m_UnitAbbreviation;
			newObject.m_IsValidUnitAbbreviation = m_IsValidUnitAbbreviation;


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

		#region Attribute - UnitID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("UnitID", "", "IsValidUnitID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Int32 UnitID
		{
			get 
			{ 
				if (m_IsValidUnitID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property UnitID is not valid. Set UnitIDValid = true");
				return m_UnitID;  
			}
			set 
			{ 
				m_IsValidUnitID = true;
				m_UnitID = value;
			}
		}
		/// <summary>
		/// 	Indicates if UnitID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for UnitID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get UnitID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitID
		{
			get
			{
				return m_IsValidUnitID;
			}
			set 
			{ 
				if (value != m_IsValidUnitID)
				{
					UnitID = 0;
					m_IsValidUnitID = value;
				}
			}
		}
		protected Boolean m_IsValidUnitID;
		protected Int32 m_UnitID;
		#endregion
		#region Attribute - UnitName
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("UnitName", "http://www.cuahsi.org/waterML/1.0/", "IsValidUnitName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String UnitName
		{
			get 
			{ 
				if (m_IsValidUnitName == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property UnitName is not valid. Set UnitNameValid = true");
				return m_UnitName;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidUnitName = true;
				m_UnitName = value;
			}
		}
		/// <summary>
		/// 	Indicates if UnitName contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for UnitName is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get UnitName
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitName
		{
			get
			{
				return m_IsValidUnitName;
			}
			set 
			{ 
				if (value != m_IsValidUnitName)
				{
					UnitName = "";
					m_IsValidUnitName = value;
				}
			}
		}
		protected Boolean m_IsValidUnitName;
		protected String m_UnitName;
		#endregion
		#region Attribute - UnitDescription
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("UnitDescription", "http://www.cuahsi.org/waterML/1.0/", "IsValidUnitDescription", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String UnitDescription
		{
			get 
			{ 
				if (m_IsValidUnitDescription == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property UnitDescription is not valid. Set UnitDescriptionValid = true");
				return m_UnitDescription;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidUnitDescription = true;
				m_UnitDescription = value;
			}
		}
		/// <summary>
		/// 	Indicates if UnitDescription contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for UnitDescription is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get UnitDescription
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitDescription
		{
			get
			{
				return m_IsValidUnitDescription;
			}
			set 
			{ 
				if (value != m_IsValidUnitDescription)
				{
					UnitDescription = "";
					m_IsValidUnitDescription = value;
				}
			}
		}
		protected Boolean m_IsValidUnitDescription;
		protected String m_UnitDescription;
		#endregion
		#region Attribute - UnitType
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqEnumOpt("UnitType", "http://www.cuahsi.org/waterML/1.0/", "IsValidUnitType", typeof(tns.Enumerations), "UnitsTypeEnumFromString", "UnitsTypeEnumToString")]
		public tns.Enumerations.UnitsTypeEnum UnitType
		{
			get 
			{ 
				if (m_IsValidUnitType == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property UnitType is not valid. Set UnitTypeValid = true");
				return m_UnitType;  
			}
			set 
			{ 
				m_UnitType = value;
				m_IsValidUnitType = true;
			}
		}
		/// <summary>
		/// 	Indicates if UnitType contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for UnitType is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.UnitsTypeEnum.Angle).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get UnitType
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitType
		{
			get { return m_IsValidUnitType;  }
			set 
			{ 
				if (value != m_IsValidUnitType)
				{
					UnitType = tns.Enumerations.UnitsTypeEnum.Angle;
					m_IsValidUnitType = value;
				}
			}
		}
		protected tns.Enumerations.UnitsTypeEnum m_UnitType;
		protected Boolean m_IsValidUnitType;

		#endregion
		#region Attribute - UnitAbbreviation
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("UnitAbbreviation", "http://www.cuahsi.org/waterML/1.0/", "IsValidUnitAbbreviation", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String UnitAbbreviation
		{
			get 
			{ 
				if (m_IsValidUnitAbbreviation == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property UnitAbbreviation is not valid. Set UnitAbbreviationValid = true");
				return m_UnitAbbreviation;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidUnitAbbreviation = true;
				m_UnitAbbreviation = value;
			}
		}
		/// <summary>
		/// 	Indicates if UnitAbbreviation contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for UnitAbbreviation is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get UnitAbbreviation
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitAbbreviation
		{
			get
			{
				return m_IsValidUnitAbbreviation;
			}
			set 
			{ 
				if (value != m_IsValidUnitAbbreviation)
				{
					UnitAbbreviation = "";
					m_IsValidUnitAbbreviation = value;
				}
			}
		}
		protected Boolean m_IsValidUnitAbbreviation;
		protected String m_UnitAbbreviation;
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


