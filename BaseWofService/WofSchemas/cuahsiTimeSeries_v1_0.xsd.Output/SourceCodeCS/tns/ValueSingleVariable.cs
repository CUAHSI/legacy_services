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
	/// 	This class represents the ComplexType ValueSingleVariable
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"ValueSingleVariable", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class ValueSingleVariable : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for ValueSingleVariable
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public ValueSingleVariable()
		{
			_elementName = "ValueSingleVariable";
			Init();
		}
		public ValueSingleVariable(String elementName)
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
			m_Qualifiers = "";
			m_IsValidQualifiers = false;
			m_CensorCode = tns.Enumerations.CensorCodeEnum.Lt;
			m_IsValidCensorCode = false;
			m_DateTime = new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime);
			m_QualityControlLevel = tns.Enumerations.QualityControlLevelEnum.RawSpacedata;
			m_IsValidQualityControlLevel = false;
			m_MethodID = 0;
			m_IsValidMethodID = false;
			m_SourceID = 0;
			m_IsValidSourceID = false;
			m_AccuracyStdDev = 0;
			m_IsValidAccuracyStdDev = false;
			m_CodedVocabulary = false;
			m_IsValidCodedVocabulary = false;
			m_CodedVocabularyTerm = "";
			m_IsValidCodedVocabularyTerm = false;
			m_SampleID = 0;
			m_IsValidSampleID = false;
			m_OffsetValue = 0;
			m_IsValidOffsetValue = false;
			m_OffsetTypeID = 0;
			m_IsValidOffsetTypeID = false;
			m_OffsetDescription = "";
			m_IsValidOffsetDescription = false;
			m_OffsetUnitsAbbreviation = "";
			m_IsValidOffsetUnitsAbbreviation = false;
			m_OffsetUnitsCode = "";
			m_IsValidOffsetUnitsCode = false;
			m_Oid = "";
			m_IsValidOid = false;
			m_MetadataDateTime = new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime);
			m_IsValidMetadataDateTime = false;


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
			tns.ValueSingleVariable newObject = new tns.ValueSingleVariable(_elementName);
			newObject.m_Qualifiers = m_Qualifiers;
			newObject.m_IsValidQualifiers = m_IsValidQualifiers;
			newObject.m_CensorCode = m_CensorCode;
			newObject.m_IsValidCensorCode = m_IsValidCensorCode;
			newObject.m_DateTime = (LiquidTechnologies.Runtime.Net20.XmlDateTime)m_DateTime.Clone();
			newObject.m_QualityControlLevel = m_QualityControlLevel;
			newObject.m_IsValidQualityControlLevel = m_IsValidQualityControlLevel;
			newObject.m_MethodID = m_MethodID;
			newObject.m_IsValidMethodID = m_IsValidMethodID;
			newObject.m_SourceID = m_SourceID;
			newObject.m_IsValidSourceID = m_IsValidSourceID;
			newObject.m_AccuracyStdDev = m_AccuracyStdDev;
			newObject.m_IsValidAccuracyStdDev = m_IsValidAccuracyStdDev;
			newObject.m_CodedVocabulary = m_CodedVocabulary;
			newObject.m_IsValidCodedVocabulary = m_IsValidCodedVocabulary;
			newObject.m_CodedVocabularyTerm = m_CodedVocabularyTerm;
			newObject.m_IsValidCodedVocabularyTerm = m_IsValidCodedVocabularyTerm;
			newObject.m_SampleID = m_SampleID;
			newObject.m_IsValidSampleID = m_IsValidSampleID;
			newObject.m_OffsetValue = m_OffsetValue;
			newObject.m_IsValidOffsetValue = m_IsValidOffsetValue;
			newObject.m_OffsetTypeID = m_OffsetTypeID;
			newObject.m_IsValidOffsetTypeID = m_IsValidOffsetTypeID;
			newObject.m_OffsetDescription = m_OffsetDescription;
			newObject.m_IsValidOffsetDescription = m_IsValidOffsetDescription;
			newObject.m_OffsetUnitsAbbreviation = m_OffsetUnitsAbbreviation;
			newObject.m_IsValidOffsetUnitsAbbreviation = m_IsValidOffsetUnitsAbbreviation;
			newObject.m_OffsetUnitsCode = m_OffsetUnitsCode;
			newObject.m_IsValidOffsetUnitsCode = m_IsValidOffsetUnitsCode;
			newObject.m_Oid = m_Oid;
			newObject.m_IsValidOid = m_IsValidOid;
			newObject.m_MetadataDateTime = (LiquidTechnologies.Runtime.Net20.XmlDateTime)m_MetadataDateTime.Clone();
			newObject.m_IsValidMetadataDateTime = m_IsValidMetadataDateTime;


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

		#region Attribute - qualifiers
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("qualifiers", "", "IsValidQualifiers", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String Qualifiers
		{
			get 
			{ 
				if (m_IsValidQualifiers == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property qualifiers is not valid. Set qualifiersValid = true");
				return m_Qualifiers;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidQualifiers = true;
				m_Qualifiers = value;
			}
		}
		/// <summary>
		/// 	Indicates if qualifiers contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for qualifiers is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get qualifiers
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidQualifiers
		{
			get
			{
				return m_IsValidQualifiers;
			}
			set 
			{ 
				if (value != m_IsValidQualifiers)
				{
					Qualifiers = "";
					m_IsValidQualifiers = value;
				}
			}
		}
		protected Boolean m_IsValidQualifiers;
		protected String m_Qualifiers;
		#endregion
		#region Attribute - censorCode
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoEnum("censorCode", "", "IsValidCensorCode", typeof(tns.Enumerations), "CensorCodeEnumFromString", "CensorCodeEnumToString", null)]
		public tns.Enumerations.CensorCodeEnum CensorCode
		{
			get 
			{ 
				if (m_IsValidCensorCode == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property censorCode is not valid. Set censorCodeValid = true");
				return m_CensorCode;  
			}
			set 
			{ 
				m_CensorCode = value;
				m_IsValidCensorCode = true;
			}
		}
		/// <summary>
		/// 	Indicates if censorCode contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for censorCode is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.CensorCodeEnum.Lt).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get censorCode
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidCensorCode
		{
			get { return m_IsValidCensorCode;  }
			set 
			{ 
				if (value != m_IsValidCensorCode)
				{
					CensorCode = tns.Enumerations.CensorCodeEnum.Lt;
					m_IsValidCensorCode = value;
				}
			}
		}
		protected tns.Enumerations.CensorCodeEnum m_CensorCode;
		protected Boolean m_IsValidCensorCode;

		#endregion
		#region Attribute - dateTime
		/// <summary>
		///		Represents a mandatory Attribute in the XML document
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Attribute in the XML.</BR>
		///		<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>It is defaulted to new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime).</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("dateTime", "", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_datetime, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public LiquidTechnologies.Runtime.Net20.XmlDateTime DateTime
		{
			get 
			{ 
				return m_DateTime;  
			}
			set 
			{ 
				m_DateTime.SetDateTime(value, m_DateTime.Type); 
			}
		}
		protected LiquidTechnologies.Runtime.Net20.XmlDateTime m_DateTime;

		#endregion
		#region Attribute - qualityControlLevel
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoEnum("qualityControlLevel", "", "IsValidQualityControlLevel", typeof(tns.Enumerations), "QualityControlLevelEnumFromString", "QualityControlLevelEnumToString", null)]
		public tns.Enumerations.QualityControlLevelEnum QualityControlLevel
		{
			get 
			{ 
				if (m_IsValidQualityControlLevel == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property qualityControlLevel is not valid. Set qualityControlLevelValid = true");
				return m_QualityControlLevel;  
			}
			set 
			{ 
				m_QualityControlLevel = value;
				m_IsValidQualityControlLevel = true;
			}
		}
		/// <summary>
		/// 	Indicates if qualityControlLevel contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for qualityControlLevel is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (tns.Enumerations.QualityControlLevelEnum.RawSpacedata).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get qualityControlLevel
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidQualityControlLevel
		{
			get { return m_IsValidQualityControlLevel;  }
			set 
			{ 
				if (value != m_IsValidQualityControlLevel)
				{
					QualityControlLevel = tns.Enumerations.QualityControlLevelEnum.RawSpacedata;
					m_IsValidQualityControlLevel = value;
				}
			}
		}
		protected tns.Enumerations.QualityControlLevelEnum m_QualityControlLevel;
		protected Boolean m_IsValidQualityControlLevel;

		#endregion
		#region Attribute - methodID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("methodID", "", "IsValidMethodID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Int32 MethodID
		{
			get 
			{ 
				if (m_IsValidMethodID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property methodID is not valid. Set methodIDValid = true");
				return m_MethodID;  
			}
			set 
			{ 
				m_IsValidMethodID = true;
				m_MethodID = value;
			}
		}
		/// <summary>
		/// 	Indicates if methodID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for methodID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get methodID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidMethodID
		{
			get
			{
				return m_IsValidMethodID;
			}
			set 
			{ 
				if (value != m_IsValidMethodID)
				{
					MethodID = 0;
					m_IsValidMethodID = value;
				}
			}
		}
		protected Boolean m_IsValidMethodID;
		protected Int32 m_MethodID;
		#endregion
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
		#region Attribute - accuracyStdDev
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("accuracyStdDev", "", "IsValidAccuracyStdDev", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Double AccuracyStdDev
		{
			get 
			{ 
				if (m_IsValidAccuracyStdDev == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property accuracyStdDev is not valid. Set accuracyStdDevValid = true");
				return m_AccuracyStdDev;  
			}
			set 
			{ 
				m_IsValidAccuracyStdDev = true;
				m_AccuracyStdDev = value;
			}
		}
		/// <summary>
		/// 	Indicates if accuracyStdDev contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for accuracyStdDev is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get accuracyStdDev
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidAccuracyStdDev
		{
			get
			{
				return m_IsValidAccuracyStdDev;
			}
			set 
			{ 
				if (value != m_IsValidAccuracyStdDev)
				{
					AccuracyStdDev = 0;
					m_IsValidAccuracyStdDev = value;
				}
			}
		}
		protected Boolean m_IsValidAccuracyStdDev;
		protected Double m_AccuracyStdDev;
		#endregion
		#region Attribute - codedVocabulary
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("codedVocabulary", "", "IsValidCodedVocabulary", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Boolean CodedVocabulary
		{
			get 
			{ 
				if (m_IsValidCodedVocabulary == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property codedVocabulary is not valid. Set codedVocabularyValid = true");
				return m_CodedVocabulary;  
			}
			set 
			{ 
				m_IsValidCodedVocabulary = true;
				m_CodedVocabulary = value;
			}
		}
		/// <summary>
		/// 	Indicates if codedVocabulary contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for codedVocabulary is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (false).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get codedVocabulary
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidCodedVocabulary
		{
			get
			{
				return m_IsValidCodedVocabulary;
			}
			set 
			{ 
				if (value != m_IsValidCodedVocabulary)
				{
					CodedVocabulary = false;
					m_IsValidCodedVocabulary = value;
				}
			}
		}
		protected Boolean m_IsValidCodedVocabulary;
		protected Boolean m_CodedVocabulary;
		#endregion
		#region Attribute - codedVocabularyTerm
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("codedVocabularyTerm", "", "IsValidCodedVocabularyTerm", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String CodedVocabularyTerm
		{
			get 
			{ 
				if (m_IsValidCodedVocabularyTerm == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property codedVocabularyTerm is not valid. Set codedVocabularyTermValid = true");
				return m_CodedVocabularyTerm;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidCodedVocabularyTerm = true;
				m_CodedVocabularyTerm = value;
			}
		}
		/// <summary>
		/// 	Indicates if codedVocabularyTerm contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for codedVocabularyTerm is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get codedVocabularyTerm
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidCodedVocabularyTerm
		{
			get
			{
				return m_IsValidCodedVocabularyTerm;
			}
			set 
			{ 
				if (value != m_IsValidCodedVocabularyTerm)
				{
					CodedVocabularyTerm = "";
					m_IsValidCodedVocabularyTerm = value;
				}
			}
		}
		protected Boolean m_IsValidCodedVocabularyTerm;
		protected String m_CodedVocabularyTerm;
		#endregion
		#region Attribute - sampleID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("sampleID", "", "IsValidSampleID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Int32 SampleID
		{
			get 
			{ 
				if (m_IsValidSampleID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property sampleID is not valid. Set sampleIDValid = true");
				return m_SampleID;  
			}
			set 
			{ 
				m_IsValidSampleID = true;
				m_SampleID = value;
			}
		}
		/// <summary>
		/// 	Indicates if sampleID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for sampleID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get sampleID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSampleID
		{
			get
			{
				return m_IsValidSampleID;
			}
			set 
			{ 
				if (value != m_IsValidSampleID)
				{
					SampleID = 0;
					m_IsValidSampleID = value;
				}
			}
		}
		protected Boolean m_IsValidSampleID;
		protected Int32 m_SampleID;
		#endregion
		#region Attribute - offsetValue
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("offsetValue", "", "IsValidOffsetValue", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Double OffsetValue
		{
			get 
			{ 
				if (m_IsValidOffsetValue == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetValue is not valid. Set offsetValueValid = true");
				return m_OffsetValue;  
			}
			set 
			{ 
				m_IsValidOffsetValue = true;
				m_OffsetValue = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetValue contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetValue is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetValue
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetValue
		{
			get
			{
				return m_IsValidOffsetValue;
			}
			set 
			{ 
				if (value != m_IsValidOffsetValue)
				{
					OffsetValue = 0;
					m_IsValidOffsetValue = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetValue;
		protected Double m_OffsetValue;
		#endregion
		#region Attribute - offsetTypeID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("offsetTypeID", "", "IsValidOffsetTypeID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Int32 OffsetTypeID
		{
			get 
			{ 
				if (m_IsValidOffsetTypeID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetTypeID is not valid. Set offsetTypeIDValid = true");
				return m_OffsetTypeID;  
			}
			set 
			{ 
				m_IsValidOffsetTypeID = true;
				m_OffsetTypeID = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetTypeID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetTypeID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetTypeID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetTypeID
		{
			get
			{
				return m_IsValidOffsetTypeID;
			}
			set 
			{ 
				if (value != m_IsValidOffsetTypeID)
				{
					OffsetTypeID = 0;
					m_IsValidOffsetTypeID = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetTypeID;
		protected Int32 m_OffsetTypeID;
		#endregion
		#region Attribute - offsetDescription
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("offsetDescription", "", "IsValidOffsetDescription", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String OffsetDescription
		{
			get 
			{ 
				if (m_IsValidOffsetDescription == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetDescription is not valid. Set offsetDescriptionValid = true");
				return m_OffsetDescription;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidOffsetDescription = true;
				m_OffsetDescription = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetDescription contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetDescription is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetDescription
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetDescription
		{
			get
			{
				return m_IsValidOffsetDescription;
			}
			set 
			{ 
				if (value != m_IsValidOffsetDescription)
				{
					OffsetDescription = "";
					m_IsValidOffsetDescription = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetDescription;
		protected String m_OffsetDescription;
		#endregion
		#region Attribute - offsetUnitsAbbreviation
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("offsetUnitsAbbreviation", "", "IsValidOffsetUnitsAbbreviation", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String OffsetUnitsAbbreviation
		{
			get 
			{ 
				if (m_IsValidOffsetUnitsAbbreviation == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetUnitsAbbreviation is not valid. Set offsetUnitsAbbreviationValid = true");
				return m_OffsetUnitsAbbreviation;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidOffsetUnitsAbbreviation = true;
				m_OffsetUnitsAbbreviation = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetUnitsAbbreviation contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetUnitsAbbreviation is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetUnitsAbbreviation
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetUnitsAbbreviation
		{
			get
			{
				return m_IsValidOffsetUnitsAbbreviation;
			}
			set 
			{ 
				if (value != m_IsValidOffsetUnitsAbbreviation)
				{
					OffsetUnitsAbbreviation = "";
					m_IsValidOffsetUnitsAbbreviation = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetUnitsAbbreviation;
		protected String m_OffsetUnitsAbbreviation;
		#endregion
		#region Attribute - offsetUnitsCode
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("offsetUnitsCode", "", "IsValidOffsetUnitsCode", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String OffsetUnitsCode
		{
			get 
			{ 
				if (m_IsValidOffsetUnitsCode == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetUnitsCode is not valid. Set offsetUnitsCodeValid = true");
				return m_OffsetUnitsCode;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidOffsetUnitsCode = true;
				m_OffsetUnitsCode = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetUnitsCode contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetUnitsCode is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetUnitsCode
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetUnitsCode
		{
			get
			{
				return m_IsValidOffsetUnitsCode;
			}
			set 
			{ 
				if (value != m_IsValidOffsetUnitsCode)
				{
					OffsetUnitsCode = "";
					m_IsValidOffsetUnitsCode = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetUnitsCode;
		protected String m_OffsetUnitsCode;
		#endregion
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
	
		#region Attribute - ElementText

		/// <summary>
		/// 	The InnerText for this element
		/// </summary>
		/// <remarks>
		/// 	This class represents the element ValueSingleVariable, this
		/// 	element is open, and as such we can place data into it.
		/// 	<BR>ie &lt;ValueSingleVariable&gt;Some Data&lt;/ValueSingleVariable&gt;</BR>
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


