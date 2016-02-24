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
	/// 	This class represents the ComplexType criteria
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"criteria", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class Criteria : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for Criteria
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public Criteria()
		{
			_elementName = "criteria";
			Init();
		}
		public Criteria(String elementName)
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
			m_LocationParam = "";
			m_IsValidLocationParam = false; 
			m_VariableParam = "";
			m_IsValidVariableParam = false; 
			m_TimeParam = null;



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
			tns.Criteria newObject = new tns.Criteria(_elementName);
			newObject.m_LocationParam = m_LocationParam;
			newObject.m_IsValidLocationParam = m_IsValidLocationParam;
			newObject.m_VariableParam = m_VariableParam;
			newObject.m_IsValidVariableParam = m_IsValidVariableParam;
			newObject.m_TimeParam = null;
			if (m_TimeParam != null)
				newObject.m_TimeParam = (tns.TimeParam)m_TimeParam.Clone();


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

		#region Attribute - locationParam
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("locationParam", "http://www.cuahsi.org/waterML/1.0/", "IsValidLocationParam", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String LocationParam
		{
			get 
			{ 
				if (m_IsValidLocationParam == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property locationParam is not valid. Set locationParamValid = true");
				return m_LocationParam;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidLocationParam = true;
				m_LocationParam = value;
			}
		}
		/// <summary>
		/// 	Indicates if locationParam contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for locationParam is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get locationParam
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidLocationParam
		{
			get
			{
				return m_IsValidLocationParam;
			}
			set 
			{ 
				if (value != m_IsValidLocationParam)
				{
					LocationParam = "";
					m_IsValidLocationParam = value;
				}
			}
		}
		protected Boolean m_IsValidLocationParam;
		protected String m_LocationParam;
		#endregion
		#region Attribute - variableParam
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("variableParam", "http://www.cuahsi.org/waterML/1.0/", "IsValidVariableParam", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String VariableParam
		{
			get 
			{ 
				if (m_IsValidVariableParam == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property variableParam is not valid. Set variableParamValid = true");
				return m_VariableParam;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidVariableParam = true;
				m_VariableParam = value;
			}
		}
		/// <summary>
		/// 	Indicates if variableParam contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for variableParam is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get variableParam
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidVariableParam
		{
			get
			{
				return m_IsValidVariableParam;
			}
			set 
			{ 
				if (value != m_IsValidVariableParam)
				{
					VariableParam = "";
					m_IsValidVariableParam = value;
				}
			}
		}
		protected Boolean m_IsValidVariableParam;
		protected String m_VariableParam;
		#endregion
		#region Attribute - timeParam
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("timeParam", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.TimeParam))]
		public tns.TimeParam TimeParam
		{
			get 
			{ 
				return m_TimeParam;  
			}
			set 
			{ 
				if (value == null)
					m_TimeParam = null;
				else
				{
					SetElementName(value, "timeParam");
					m_TimeParam = value; 
				}
			}
		}
		protected tns.TimeParam m_TimeParam;
		
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


