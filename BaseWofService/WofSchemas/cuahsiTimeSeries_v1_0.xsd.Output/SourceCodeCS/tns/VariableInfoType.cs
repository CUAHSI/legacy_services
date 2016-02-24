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
	/// 	This class represents the ComplexType VariableInfoType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"VariableInfoType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class VariableInfoType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for VariableInfoType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public VariableInfoType()
		{
			_elementName = "VariableInfoType";
			Init();
		}
		public VariableInfoType(String elementName)
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
			m_Network = "";
			m_IsValidNetwork = false;
			m_Vocabulary = "";
			m_IsValidVocabulary = false;
			m_Default = false;
			m_IsValidDefault = false;
			m_VariableCode = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.VariableCode>("variableCode", "http://www.cuahsi.org/waterML/1.0/", 1, -1, false);
			m_VariableName = "";
			m_IsValidVariableName = false; 
			m_VariableDescription = "";
			m_IsValidVariableDescription = false; 
			m_ValueType = tns.Enumerations.ValueTypeEnum.FieldSpaceObservation;
			m_IsValidValueType = false;
			m_DataType = tns.Enumerations.DataTypeEnum.Continuous;
			m_IsValidDataType = false;
			m_GeneralCategory = tns.Enumerations.GeneralCategoryEnum.WaterSpaceQuality;
			m_IsValidGeneralCategory = false;
			m_SampleMedium = tns.Enumerations.SampleMediumEnum.SurfaceSpaceWater;
			m_IsValidSampleMedium = false;
			m_Units = null;
			m_Options = null;
			m_Note = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType>("note", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_Related = null;
			m_Extension = null;
			m_NoDataValue = "";
			m_IsValidNoDataValue = false; 
			m_TimeSupport = null;



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
			tns.VariableInfoType newObject = new tns.VariableInfoType(_elementName);
			newObject.m_Oid = m_Oid;
			newObject.m_IsValidOid = m_IsValidOid;
			newObject.m_MetadataDateTime = (LiquidTechnologies.Runtime.Net20.XmlDateTime)m_MetadataDateTime.Clone();
			newObject.m_IsValidMetadataDateTime = m_IsValidMetadataDateTime;
			newObject.m_Network = m_Network;
			newObject.m_IsValidNetwork = m_IsValidNetwork;
			newObject.m_Vocabulary = m_Vocabulary;
			newObject.m_IsValidVocabulary = m_IsValidVocabulary;
			newObject.m_Default = m_Default;
			newObject.m_IsValidDefault = m_IsValidDefault;
			foreach (cuahsiTimeSeries_v1_0Lib.VariableCode o in m_VariableCode)
				newObject.m_VariableCode.Add((cuahsiTimeSeries_v1_0Lib.VariableCode)o.Clone());
			newObject.m_VariableName = m_VariableName;
			newObject.m_IsValidVariableName = m_IsValidVariableName;
			newObject.m_VariableDescription = m_VariableDescription;
			newObject.m_IsValidVariableDescription = m_IsValidVariableDescription;
			newObject.m_ValueType = m_ValueType;
			newObject.m_IsValidValueType = m_IsValidValueType;
			newObject.m_DataType = m_DataType;
			newObject.m_IsValidDataType = m_IsValidDataType;
			newObject.m_GeneralCategory = m_GeneralCategory;
			newObject.m_IsValidGeneralCategory = m_IsValidGeneralCategory;
			newObject.m_SampleMedium = m_SampleMedium;
			newObject.m_IsValidSampleMedium = m_IsValidSampleMedium;
			newObject.m_Units = null;
			if (m_Units != null)
				newObject.m_Units = (cuahsiTimeSeries_v1_0Lib.Units)m_Units.Clone();
			newObject.m_Options = null;
			if (m_Options != null)
				newObject.m_Options = (cuahsiTimeSeries_v1_0Lib.Options)m_Options.Clone();
			foreach (tns.NoteType o in m_Note)
				newObject.m_Note.Add((tns.NoteType)o.Clone());
			newObject.m_Related = null;
			if (m_Related != null)
				newObject.m_Related = (tns.Related)m_Related.Clone();
			newObject.m_Extension = null;
			if (m_Extension != null)
				newObject.m_Extension = (LiquidTechnologies.Runtime.Net20.Element)m_Extension.Clone();
			newObject.m_NoDataValue = m_NoDataValue;
			newObject.m_IsValidNoDataValue = m_IsValidNoDataValue;
			newObject.m_TimeSupport = null;
			if (m_TimeSupport != null)
				newObject.m_TimeSupport = (tns.TimeSupport)m_TimeSupport.Clone();


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
		#region Attribute - network
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("network", "", "IsValidNetwork", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Network
		{
			get 
			{ 
				if (m_IsValidNetwork == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property network is not valid. Set networkValid = true");
				return m_Network;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidNetwork = true;
				m_Network = value;
			}
		}
		/// <summary>
		/// 	Indicates if network contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for network is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get network
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidNetwork
		{
			get
			{
				return m_IsValidNetwork;
			}
			set 
			{ 
				if (value != m_IsValidNetwork)
				{
					Network = "";
					m_IsValidNetwork = value;
				}
			}
		}
		protected Boolean m_IsValidNetwork;
		protected String m_Network;
		#endregion
		#region Attribute - vocabulary
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("vocabulary", "", "IsValidVocabulary", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Vocabulary
		{
			get 
			{ 
				if (m_IsValidVocabulary == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property vocabulary is not valid. Set vocabularyValid = true");
				return m_Vocabulary;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidVocabulary = true;
				m_Vocabulary = value;
			}
		}
		/// <summary>
		/// 	Indicates if vocabulary contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for vocabulary is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get vocabulary
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidVocabulary
		{
			get
			{
				return m_IsValidVocabulary;
			}
			set 
			{ 
				if (value != m_IsValidVocabulary)
				{
					Vocabulary = "";
					m_IsValidVocabulary = value;
				}
			}
		}
		protected Boolean m_IsValidVocabulary;
		protected String m_Vocabulary;
		#endregion
		#region Attribute - default
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("default", "", "IsValidDefault", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Boolean default_
		{
			get 
			{ 
				if (m_IsValidDefault == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property default_ is not valid. Set default_Valid = true");
				return m_Default;  
			}
			set 
			{ 
				m_IsValidDefault = true;
				m_Default = value;
			}
		}
		/// <summary>
		/// 	Indicates if default_ contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for default_ is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (false).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get default_
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidDefault
		{
			get
			{
				return m_IsValidDefault;
			}
			set 
			{ 
				if (value != m_IsValidDefault)
				{
					default_ = false;
					m_IsValidDefault = value;
				}
			}
		}
		protected Boolean m_IsValidDefault;
		protected Boolean m_Default;
		#endregion
		#region Attribute - variableCode
		/// <summary>
		/// 	A collection of variableCode's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 1 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("variableCode", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.VariableCode> VariableCode
		{
			get { return m_VariableCode; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<cuahsiTimeSeries_v1_0Lib.VariableCode> m_VariableCode;
		
		#endregion
		#region Attribute - variableName
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("variableName", "http://www.cuahsi.org/waterML/1.0/", "IsValidVariableName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String VariableName
		{
			get 
			{ 
				if (m_IsValidVariableName == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property variableName is not valid. Set variableNameValid = true");
				return m_VariableName;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidVariableName = true;
				m_VariableName = value;
			}
		}
		/// <summary>
		/// 	Indicates if variableName contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for variableName is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get variableName
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidVariableName
		{
			get
			{
				return m_IsValidVariableName;
			}
			set 
			{ 
				if (value != m_IsValidVariableName)
				{
					VariableName = "";
					m_IsValidVariableName = value;
				}
			}
		}
		protected Boolean m_IsValidVariableName;
		protected String m_VariableName;
		#endregion
		#region Attribute - variableDescription
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("variableDescription", "http://www.cuahsi.org/waterML/1.0/", "IsValidVariableDescription", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String VariableDescription
		{
			get 
			{ 
				if (m_IsValidVariableDescription == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property variableDescription is not valid. Set variableDescriptionValid = true");
				return m_VariableDescription;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidVariableDescription = true;
				m_VariableDescription = value;
			}
		}
		/// <summary>
		/// 	Indicates if variableDescription contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for variableDescription is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get variableDescription
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidVariableDescription
		{
			get
			{
				return m_IsValidVariableDescription;
			}
			set 
			{ 
				if (value != m_IsValidVariableDescription)
				{
					VariableDescription = "";
					m_IsValidVariableDescription = value;
				}
			}
		}
		protected Boolean m_IsValidVariableDescription;
		protected String m_VariableDescription;
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
		#region Attribute - units
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("units", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(cuahsiTimeSeries_v1_0Lib.Units))]
		public cuahsiTimeSeries_v1_0Lib.Units Units
		{
			get 
			{ 
				return m_Units;  
			}
			set 
			{ 
				if (value == null)
					m_Units = null;
				else
				{
					SetElementName(value, "units");
					m_Units = value; 
				}
			}
		}
		protected cuahsiTimeSeries_v1_0Lib.Units m_Units;
		
		#endregion
		#region Attribute - options
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("options", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(cuahsiTimeSeries_v1_0Lib.Options))]
		public cuahsiTimeSeries_v1_0Lib.Options Options
		{
			get 
			{ 
				return m_Options;  
			}
			set 
			{ 
				if (value == null)
					m_Options = null;
				else
				{
					SetElementName(value, "options");
					m_Options = value; 
				}
			}
		}
		protected cuahsiTimeSeries_v1_0Lib.Options m_Options;
		
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
		#region Attribute - related
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("related", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.Related))]
		public tns.Related Related
		{
			get 
			{ 
				return m_Related;  
			}
			set 
			{ 
				if (value == null)
					m_Related = null;
				else
				{
					SetElementName(value, "related");
					m_Related = value; 
				}
			}
		}
		protected tns.Related m_Related;
		
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
		#region Attribute - NoDataValue
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("NoDataValue", "http://www.cuahsi.org/waterML/1.0/", "IsValidNoDataValue", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String NoDataValue
		{
			get 
			{ 
				if (m_IsValidNoDataValue == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property NoDataValue is not valid. Set NoDataValueValid = true");
				return m_NoDataValue;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidNoDataValue = true;
				m_NoDataValue = value;
			}
		}
		/// <summary>
		/// 	Indicates if NoDataValue contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for NoDataValue is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get NoDataValue
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidNoDataValue
		{
			get
			{
				return m_IsValidNoDataValue;
			}
			set 
			{ 
				if (value != m_IsValidNoDataValue)
				{
					NoDataValue = "";
					m_IsValidNoDataValue = value;
				}
			}
		}
		protected Boolean m_IsValidNoDataValue;
		protected String m_NoDataValue;
		#endregion
		#region Attribute - timeSupport
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("timeSupport", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.TimeSupport))]
		public tns.TimeSupport TimeSupport
		{
			get 
			{ 
				return m_TimeSupport;  
			}
			set 
			{ 
				if (value == null)
					m_TimeSupport = null;
				else
				{
					SetElementName(value, "timeSupport");
					m_TimeSupport = value; 
				}
			}
		}
		protected tns.TimeSupport m_TimeSupport;
		
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


