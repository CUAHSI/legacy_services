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
	/// 	This class represents the ComplexType TimeSeriesType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"TimeSeriesType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class TimeSeriesType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for TimeSeriesType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public TimeSeriesType()
		{
			_elementName = "TimeSeriesType";
			Init();
		}
		public TimeSeriesType(String elementName)
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
			m_SourceInfo = null;
			m_Variable = new tns.VariableInfoType("variable");
			m_Values = new tns.TsValuesSingleVariableType("values");



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
			tns.TimeSeriesType newObject = new tns.TimeSeriesType(_elementName);
			newObject.m_Name = m_Name;
			newObject.m_IsValidName = m_IsValidName;
			newObject.m_SourceInfo = null;
			if (m_SourceInfo != null)
				newObject.m_SourceInfo = (tns.ISourceInfoType)m_SourceInfo.Clone();
			newObject.m_Variable = null;
			if (m_Variable != null)
				newObject.m_Variable = (tns.VariableInfoType)m_Variable.Clone();
			newObject.m_Values = null;
			if (m_Values != null)
				newObject.m_Values = (tns.TsValuesSingleVariableType)m_Values.Clone();


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
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("name", "", "IsValidName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
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
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
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
		#region Attribute - sourceInfo
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqAbsClsMnd("sourceInfo", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.ClassFactory), "ISourceInfoTypeCreateObject")]
		public tns.ISourceInfoType SourceInfo
		{
			get 
			{ 
				return m_SourceInfo;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "sourceInfo");
				if (value != null)
				{
					// The object being set needs to take the element name from the class (the type="" attribute will then be set in the XML)
					SetElementName(value.GetBase(), "sourceInfo");
				}
				m_SourceInfo = value; 
			}
		}
		protected tns.ISourceInfoType m_SourceInfo;

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
		#region Attribute - values
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsMnd("values", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.TsValuesSingleVariableType), true)]
		public tns.TsValuesSingleVariableType Values
		{
			get 
			{ 
				return m_Values;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "values");
				if (value != null)
					SetElementName(value, "values");
				m_Values = value;
			}
		}
		protected tns.TsValuesSingleVariableType m_Values;
		
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


