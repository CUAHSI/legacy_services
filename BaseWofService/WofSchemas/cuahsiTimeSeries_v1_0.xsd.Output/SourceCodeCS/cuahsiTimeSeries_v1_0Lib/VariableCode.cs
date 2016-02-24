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

namespace cuahsiTimeSeries_v1_0Lib
{
	/// <summary>
	/// 	This class represents the ComplexType variableCode
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"variableCode", "", true, false)]
	public partial class VariableCode : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for VariableCode
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public VariableCode()
		{
			_elementName = "variableCode";
			Init();
		}
		public VariableCode(String elementName)
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
			m_Network = "";
			m_IsValidNetwork = false;
			m_Vocabulary = "";
			m_IsValidVocabulary = false;
			m_Default = false;
			m_IsValidDefault = false;
			m_VariableID = 0;
			m_IsValidVariableID = false;


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
			cuahsiTimeSeries_v1_0Lib.VariableCode newObject = new cuahsiTimeSeries_v1_0Lib.VariableCode(_elementName);
			newObject.m_Network = m_Network;
			newObject.m_IsValidNetwork = m_IsValidNetwork;
			newObject.m_Vocabulary = m_Vocabulary;
			newObject.m_IsValidVocabulary = m_IsValidVocabulary;
			newObject.m_Default = m_Default;
			newObject.m_IsValidDefault = m_IsValidDefault;
			newObject.m_VariableID = m_VariableID;
			newObject.m_IsValidVariableID = m_IsValidVariableID;


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
			get { return ""; }
		}

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
		#region Attribute - variableID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("variableID", "", "IsValidVariableID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_integer, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public LiquidTechnologies.Runtime.Net20.BigInteger VariableID
		{
			get 
			{ 
				if (m_IsValidVariableID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property variableID is not valid. Set variableIDValid = true");
				return m_VariableID;  
			}
			set 
			{ 
				m_IsValidVariableID = true;
				m_VariableID = value;
			}
		}
		/// <summary>
		/// 	Indicates if variableID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for variableID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get variableID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidVariableID
		{
			get
			{
				return m_IsValidVariableID;
			}
			set 
			{ 
				if (value != m_IsValidVariableID)
				{
					VariableID = 0;
					m_IsValidVariableID = value;
				}
			}
		}
		protected Boolean m_IsValidVariableID;
		protected LiquidTechnologies.Runtime.Net20.BigInteger m_VariableID;
		#endregion
	
		#region Attribute - ElementText

		/// <summary>
		/// 	The InnerText for this element
		/// </summary>
		/// <remarks>
		/// 	This class represents the element VariableCode, this
		/// 	element is open, and as such we can place data into it.
		/// 	<BR>ie &lt;VariableCode&gt;Some Data&lt;/VariableCode&gt;</BR>
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
			get { return ""; }
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


