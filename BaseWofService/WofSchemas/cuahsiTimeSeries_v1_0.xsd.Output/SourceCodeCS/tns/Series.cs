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
	/// 	This class represents the ComplexType series
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"series", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class Series : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for Series
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public Series()
		{
			_elementName = "series";
			Init();
		}
		public Series(String elementName)
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
			m_DataType = tns.Enumerations.DataTypeEnum.Continuous;
			m_IsValidDataType = false;
			m_Variable = new tns.VariableInfoType("variable");
			m_ValueCount = new tns.ValueCount("valueCount");
			m_VariableTimeInterval = null;
			m_ValueType = tns.Enumerations.ValueTypeEnum.FieldSpaceObservation;
			m_IsValidValueType = false;
			m_GeneralCategory = tns.Enumerations.GeneralCategoryEnum.WaterSpaceQuality;
			m_IsValidGeneralCategory = false;
			m_SampleMedium = tns.Enumerations.SampleMediumEnum.SurfaceSpaceWater;
			m_IsValidSampleMedium = false;
			m_Method = null;
			m_Source = null;
			m_QualityControlLevel = null;
			m_Extension = null;



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
			tns.Series newObject = new tns.Series(_elementName);
			newObject.m_DataType = m_DataType;
			newObject.m_IsValidDataType = m_IsValidDataType;
			newObject.m_Variable = null;
			if (m_Variable != null)
				newObject.m_Variable = (tns.VariableInfoType)m_Variable.Clone();
			newObject.m_ValueCount = null;
			if (m_ValueCount != null)
				newObject.m_ValueCount = (tns.ValueCount)m_ValueCount.Clone();
			newObject.m_VariableTimeInterval = null;
			if (m_VariableTimeInterval != null)
				newObject.m_VariableTimeInterval = (tns.ITimePeriodType)m_VariableTimeInterval.Clone();
			newObject.m_ValueType = m_ValueType;
			newObject.m_IsValidValueType = m_IsValidValueType;
			newObject.m_GeneralCategory = m_GeneralCategory;
			newObject.m_IsValidGeneralCategory = m_IsValidGeneralCategory;
			newObject.m_SampleMedium = m_SampleMedium;
			newObject.m_IsValidSampleMedium = m_IsValidSampleMedium;
			newObject.m_Method = null;
			if (m_Method != null)
				newObject.m_Method = (tns.MethodType)m_Method.Clone();
			newObject.m_Source = null;
			if (m_Source != null)
				newObject.m_Source = (tns.SourceType)m_Source.Clone();
			newObject.m_QualityControlLevel = null;
			if (m_QualityControlLevel != null)
				newObject.m_QualityControlLevel = (tns.QualityControlLevelType)m_QualityControlLevel.Clone();
			newObject.m_Extension = null;
			if (m_Extension != null)
				newObject.m_Extension = (LiquidTechnologies.Runtime.Net20.Element)m_Extension.Clone();


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

		#region Attribute - dataType
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqEnumOpt("dataType", "http://www.cuahsi.org/waterML/1.0/", "IsValidDataType", typeof(tns.Enumerations), "DataTypeEnumFromString", "DataTypeEnumToString")]
		public tns.Enumerations.DataTypeEnum DataType
		{
			get 
			{ 
				if (m_IsValidDataType == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property dataType is not valid. Set dataTypeValid = true");
				return m_DataType;  
			}
			set 
			{ 
				m_DataType = value;
				m_IsValidDataType = true;
			}
		}
		/// <summary>
		/// 	Indicates if dataType contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for dataType is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.DataTypeEnum.Continuous).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get dataType
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidDataType
		{
			get { return m_IsValidDataType;  }
			set 
			{ 
				if (value != m_IsValidDataType)
				{
					DataType = tns.Enumerations.DataTypeEnum.Continuous;
					m_IsValidDataType = value;
				}
			}
		}
		protected tns.Enumerations.DataTypeEnum m_DataType;
		protected Boolean m_IsValidDataType;

		#endregion
		#region Attribute - variable
		/// <summary>
		///		Represents a mandatory Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>If this property is set, then the object will be COPIED. If the property is set to null an exception is raised.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsMnd("variable", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.VariableInfoType), true)]
		public tns.VariableInfoType Variable
		{
			get 
			{ 
				return m_Variable;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "variable");
				if (value != null)
					SetElementName(value, "variable");
				m_Variable = value;
			}
		}
		protected tns.VariableInfoType m_Variable;
		
		#endregion
		#region Attribute - valueCount
		/// <summary>
		///		Represents a mandatory Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>If this property is set, then the object will be COPIED. If the property is set to null an exception is raised.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsMnd("valueCount", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.ValueCount), false)]
		public tns.ValueCount ValueCount
		{
			get 
			{ 
				return m_ValueCount;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "valueCount");
				if (value != null)
					SetElementName(value, "valueCount");
				m_ValueCount = value;
			}
		}
		protected tns.ValueCount m_ValueCount;
		
		#endregion
		#region Attribute - variableTimeInterval
		/// <summary>
		///		Represents a mandatory Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>If this property is set, then the object will be COPIED. If the property is set to null an exception is raised.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqAbsClsMnd("variableTimeInterval", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.ClassFactory), "ITimePeriodTypeCreateObject")]
		public tns.ITimePeriodType VariableTimeInterval
		{
			get 
			{ 
				return m_VariableTimeInterval;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "variableTimeInterval");
				if (value != null)
				{
					// The object being set needs to take the element name from the class (the type="" attribute will then be set in the XML)
					SetElementName(value.GetBase(), "variableTimeInterval");
				}
				m_VariableTimeInterval = value; 
			}
		}
		protected tns.ITimePeriodType m_VariableTimeInterval;

		#endregion
		#region Attribute - valueType
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqEnumOpt("valueType", "http://www.cuahsi.org/waterML/1.0/", "IsValidValueType", typeof(tns.Enumerations), "ValueTypeEnumFromString", "ValueTypeEnumToString")]
		public tns.Enumerations.ValueTypeEnum ValueType
		{
			get 
			{ 
				if (m_IsValidValueType == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property valueType is not valid. Set valueTypeValid = true");
				return m_ValueType;  
			}
			set 
			{ 
				m_ValueType = value;
				m_IsValidValueType = true;
			}
		}
		/// <summary>
		/// 	Indicates if valueType contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for valueType is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.ValueTypeEnum.FieldSpaceObservation).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get valueType
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidValueType
		{
			get { return m_IsValidValueType;  }
			set 
			{ 
				if (value != m_IsValidValueType)
				{
					ValueType = tns.Enumerations.ValueTypeEnum.FieldSpaceObservation;
					m_IsValidValueType = value;
				}
			}
		}
		protected tns.Enumerations.ValueTypeEnum m_ValueType;
		protected Boolean m_IsValidValueType;

		#endregion
		#region Attribute - generalCategory
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqEnumOpt("generalCategory", "http://www.cuahsi.org/waterML/1.0/", "IsValidGeneralCategory", typeof(tns.Enumerations), "GeneralCategoryEnumFromString", "GeneralCategoryEnumToString")]
		public tns.Enumerations.GeneralCategoryEnum GeneralCategory
		{
			get 
			{ 
				if (m_IsValidGeneralCategory == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property generalCategory is not valid. Set generalCategoryValid = true");
				return m_GeneralCategory;  
			}
			set 
			{ 
				m_GeneralCategory = value;
				m_IsValidGeneralCategory = true;
			}
		}
		/// <summary>
		/// 	Indicates if generalCategory contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for generalCategory is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.GeneralCategoryEnum.WaterSpaceQuality).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get generalCategory
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidGeneralCategory
		{
			get { return m_IsValidGeneralCategory;  }
			set 
			{ 
				if (value != m_IsValidGeneralCategory)
				{
					GeneralCategory = tns.Enumerations.GeneralCategoryEnum.WaterSpaceQuality;
					m_IsValidGeneralCategory = value;
				}
			}
		}
		protected tns.Enumerations.GeneralCategoryEnum m_GeneralCategory;
		protected Boolean m_IsValidGeneralCategory;

		#endregion
		#region Attribute - sampleMedium
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqEnumOpt("sampleMedium", "http://www.cuahsi.org/waterML/1.0/", "IsValidSampleMedium", typeof(tns.Enumerations), "SampleMediumEnumFromString", "SampleMediumEnumToString")]
		public tns.Enumerations.SampleMediumEnum SampleMedium
		{
			get 
			{ 
				if (m_IsValidSampleMedium == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property sampleMedium is not valid. Set sampleMediumValid = true");
				return m_SampleMedium;  
			}
			set 
			{ 
				m_SampleMedium = value;
				m_IsValidSampleMedium = true;
			}
		}
		/// <summary>
		/// 	Indicates if sampleMedium contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for sampleMedium is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.SampleMediumEnum.SurfaceSpaceWater).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get sampleMedium
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSampleMedium
		{
			get { return m_IsValidSampleMedium;  }
			set 
			{ 
				if (value != m_IsValidSampleMedium)
				{
					SampleMedium = tns.Enumerations.SampleMediumEnum.SurfaceSpaceWater;
					m_IsValidSampleMedium = value;
				}
			}
		}
		protected tns.Enumerations.SampleMediumEnum m_SampleMedium;
		protected Boolean m_IsValidSampleMedium;

		#endregion
		#region Attribute - Method
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("Method", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.MethodType))]
		public tns.MethodType Method
		{
			get 
			{ 
				return m_Method;  
			}
			set 
			{ 
				if (value == null)
					m_Method = null;
				else
				{
					SetElementName(value, "Method");
					m_Method = value; 
				}
			}
		}
		protected tns.MethodType m_Method;
		
		#endregion
		#region Attribute - Source
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("Source", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.SourceType))]
		public tns.SourceType Source
		{
			get 
			{ 
				return m_Source;  
			}
			set 
			{ 
				if (value == null)
					m_Source = null;
				else
				{
					SetElementName(value, "Source");
					m_Source = value; 
				}
			}
		}
		protected tns.SourceType m_Source;
		
		#endregion
		#region Attribute - QualityControlLevel
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("QualityControlLevel", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.QualityControlLevelType))]
		public tns.QualityControlLevelType QualityControlLevel
		{
			get 
			{ 
				return m_QualityControlLevel;  
			}
			set 
			{ 
				if (value == null)
					m_QualityControlLevel = null;
				else
				{
					SetElementName(value, "QualityControlLevel");
					m_QualityControlLevel = value; 
				}
			}
		}
		protected tns.QualityControlLevelType m_QualityControlLevel;
		
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


