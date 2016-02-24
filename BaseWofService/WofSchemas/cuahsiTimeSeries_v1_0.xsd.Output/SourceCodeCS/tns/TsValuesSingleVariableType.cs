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
	/// 	This class represents the ComplexType TsValuesSingleVariableType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"TsValuesSingleVariableType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class TsValuesSingleVariableType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for TsValuesSingleVariableType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public TsValuesSingleVariableType()
		{
			_elementName = "TsValuesSingleVariableType";
			Init();
		}
		public TsValuesSingleVariableType(String elementName)
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
			m_TimeZoneShiftApplied = false;
			m_IsValidTimeZoneShiftApplied = false;
			m_UnitsAbbreviation = "";
			m_IsValidUnitsAbbreviation = false;
			m_UnitsCode = "";
			m_IsValidUnitsCode = false;
			m_UnitsType = tns.Enumerations.UnitsTypeEnum.Angle;
			m_IsValidUnitsType = false;
			m_Count = 0;
			m_IsValidCount = false;
			m_UnitsAreConverted = LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("false", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse);
			m_IsValidUnitsAreConverted = true;
			m_Value = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.ValueSingleVariable>("value", "http://www.cuahsi.org/waterML/1.0/", 1, -1, false);
			m_Qualifier = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.Qualifier>("qualifier", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_QualityControlLevel = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.QualityControlLevel>("qualityControlLevel", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_Method = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.MethodType>("method", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_Source = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SourceType>("source", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_Offset = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.OffsetType>("offset", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);



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
			tns.TsValuesSingleVariableType newObject = new tns.TsValuesSingleVariableType(_elementName);
			newObject.m_TimeZoneShiftApplied = m_TimeZoneShiftApplied;
			newObject.m_IsValidTimeZoneShiftApplied = m_IsValidTimeZoneShiftApplied;
			newObject.m_UnitsAbbreviation = m_UnitsAbbreviation;
			newObject.m_IsValidUnitsAbbreviation = m_IsValidUnitsAbbreviation;
			newObject.m_UnitsCode = m_UnitsCode;
			newObject.m_IsValidUnitsCode = m_IsValidUnitsCode;
			newObject.m_UnitsType = m_UnitsType;
			newObject.m_IsValidUnitsType = m_IsValidUnitsType;
			newObject.m_Count = m_Count;
			newObject.m_IsValidCount = m_IsValidCount;
			newObject.m_UnitsAreConverted = m_UnitsAreConverted;
			newObject.m_IsValidUnitsAreConverted = m_IsValidUnitsAreConverted;
			foreach (tns.ValueSingleVariable o in m_Value)
				newObject.m_Value.Add((tns.ValueSingleVariable)o.Clone());
			foreach (cuahsiTimeSeries_v1_0Lib.Qualifier o in m_Qualifier)
				newObject.m_Qualifier.Add((cuahsiTimeSeries_v1_0Lib.Qualifier)o.Clone());
			foreach (cuahsiTimeSeries_v1_0Lib.QualityControlLevel o in m_QualityControlLevel)
				newObject.m_QualityControlLevel.Add((cuahsiTimeSeries_v1_0Lib.QualityControlLevel)o.Clone());
			foreach (tns.MethodType o in m_Method)
				newObject.m_Method.Add((tns.MethodType)o.Clone());
			foreach (tns.SourceType o in m_Source)
				newObject.m_Source.Add((tns.SourceType)o.Clone());
			foreach (tns.OffsetType o in m_Offset)
				newObject.m_Offset.Add((tns.OffsetType)o.Clone());


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

		#region Attribute - timeZoneShiftApplied
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("timeZoneShiftApplied", "", "IsValidTimeZoneShiftApplied", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Boolean TimeZoneShiftApplied
		{
			get 
			{ 
				if (m_IsValidTimeZoneShiftApplied == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property timeZoneShiftApplied is not valid. Set timeZoneShiftAppliedValid = true");
				return m_TimeZoneShiftApplied;  
			}
			set 
			{ 
				m_IsValidTimeZoneShiftApplied = true;
				m_TimeZoneShiftApplied = value;
			}
		}
		/// <summary>
		/// 	Indicates if timeZoneShiftApplied contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for timeZoneShiftApplied is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (false).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get timeZoneShiftApplied
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidTimeZoneShiftApplied
		{
			get
			{
				return m_IsValidTimeZoneShiftApplied;
			}
			set 
			{ 
				if (value != m_IsValidTimeZoneShiftApplied)
				{
					TimeZoneShiftApplied = false;
					m_IsValidTimeZoneShiftApplied = value;
				}
			}
		}
		protected Boolean m_IsValidTimeZoneShiftApplied;
		protected Boolean m_TimeZoneShiftApplied;
		#endregion
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
		#region Attribute - count
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("count", "", "IsValidCount", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_integer, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public LiquidTechnologies.Runtime.Net20.BigInteger Count
		{
			get 
			{ 
				if (m_IsValidCount == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property count is not valid. Set countValid = true");
				return m_Count;  
			}
			set 
			{ 
				m_IsValidCount = true;
				m_Count = value;
			}
		}
		/// <summary>
		/// 	Indicates if count contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for count is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get count
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidCount
		{
			get
			{
				return m_IsValidCount;
			}
			set 
			{ 
				if (value != m_IsValidCount)
				{
					Count = 0;
					m_IsValidCount = value;
				}
			}
		}
		protected Boolean m_IsValidCount;
		protected LiquidTechnologies.Runtime.Net20.BigInteger m_Count;
		#endregion
		#region Attribute - unitsAreConverted
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("unitsAreConverted", "", "IsValidUnitsAreConverted", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "false", "", -1, -1, "", "", "", "", -1)]
		public Boolean UnitsAreConverted
		{
			get 
			{ 
				if (m_IsValidUnitsAreConverted == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property unitsAreConverted is not valid. Set unitsAreConvertedValid = true");
				return m_UnitsAreConverted;  
			}
			set 
			{ 
				m_IsValidUnitsAreConverted = true;
				m_UnitsAreConverted = value;
			}
		}
		/// <summary>
		/// 	Indicates if unitsAreConverted contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for unitsAreConverted is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("false", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse)).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get unitsAreConverted
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidUnitsAreConverted
		{
			get
			{
				return m_IsValidUnitsAreConverted;
			}
			set 
			{ 
				// Attributes with Default can not be removed.
				if (!value)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property unitsAreConverted has a a default value, and is an attribute, because of this it can not be removed from the schema");
			}
		}
		protected Boolean m_IsValidUnitsAreConverted;
		protected Boolean m_UnitsAreConverted;
		#endregion
		#region Attribute - value
		/// <summary>
		/// 	A collection of value's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 1 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("value", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.ValueSingleVariable> Value
		{
			get { return m_Value; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.ValueSingleVariable> m_Value;
		
		#endregion
		#region Attribute - qualifier
		/// <summary>
		/// 	A collection of qualifier's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("qualifier", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.Qualifier> Qualifier
		{
			get { return m_Qualifier; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.Qualifier> m_Qualifier;
		
		#endregion
		#region Attribute - qualityControlLevel
		/// <summary>
		/// 	A collection of qualityControlLevel's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("qualityControlLevel", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.QualityControlLevel> QualityControlLevel
		{
			get { return m_QualityControlLevel; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.QualityControlLevel> m_QualityControlLevel;
		
		#endregion
		#region Attribute - method
		/// <summary>
		/// 	A collection of method's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("method", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.MethodType> Method
		{
			get { return m_Method; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.MethodType> m_Method;
		
		#endregion
		#region Attribute - source
		/// <summary>
		/// 	A collection of source's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("source", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SourceType> Source
		{
			get { return m_Source; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SourceType> m_Source;
		
		#endregion
		#region Attribute - offset
		/// <summary>
		/// 	A collection of offset's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("offset", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.OffsetType> Offset
		{
			get { return m_Offset; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.OffsetType> m_Offset;
		
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


