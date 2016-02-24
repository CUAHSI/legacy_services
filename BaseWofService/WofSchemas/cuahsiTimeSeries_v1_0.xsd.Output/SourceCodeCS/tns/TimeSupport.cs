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
	/// 	This class represents the ComplexType timeSupport
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"timeSupport", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class TimeSupport : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for TimeSupport
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public TimeSupport()
		{
			_elementName = "timeSupport";
			Init();
		}
		public TimeSupport(String elementName)
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
			m_IsRegular = false;
			m_IsValidIsRegular = false;
			m_Unit = null;
			m_TimeInterval = 0;
			m_IsValidTimeInterval = false; 



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
			tns.TimeSupport newObject = new tns.TimeSupport(_elementName);
			newObject.m_IsRegular = m_IsRegular;
			newObject.m_IsValidIsRegular = m_IsValidIsRegular;
			newObject.m_Unit = null;
			if (m_Unit != null)
				newObject.m_Unit = (tns.UnitsType)m_Unit.Clone();
			newObject.m_TimeInterval = m_TimeInterval;
			newObject.m_IsValidTimeInterval = m_IsValidTimeInterval;


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

		#region Attribute - isRegular
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("isRegular", "", "IsValidIsRegular", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Boolean IsRegular
		{
			get 
			{ 
				if (m_IsValidIsRegular == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property isRegular is not valid. Set isRegularValid = true");
				return m_IsRegular;  
			}
			set 
			{ 
				m_IsValidIsRegular = true;
				m_IsRegular = value;
			}
		}
		/// <summary>
		/// 	Indicates if isRegular contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for isRegular is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (false).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get isRegular
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidIsRegular
		{
			get
			{
				return m_IsValidIsRegular;
			}
			set 
			{ 
				if (value != m_IsValidIsRegular)
				{
					IsRegular = false;
					m_IsValidIsRegular = value;
				}
			}
		}
		protected Boolean m_IsValidIsRegular;
		protected Boolean m_IsRegular;
		#endregion
		#region Attribute - unit
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("unit", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.UnitsType))]
		public tns.UnitsType Unit
		{
			get 
			{ 
				return m_Unit;  
			}
			set 
			{ 
				if (value == null)
					m_Unit = null;
				else
				{
					SetElementName(value, "unit");
					m_Unit = value; 
				}
			}
		}
		protected tns.UnitsType m_Unit;
		
		#endregion
		#region Attribute - timeInterval
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("timeInterval", "http://www.cuahsi.org/waterML/1.0/", "IsValidTimeInterval", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Int32 TimeInterval
		{
			get 
			{ 
				if (m_IsValidTimeInterval == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property timeInterval is not valid. Set timeIntervalValid = true");
				return m_TimeInterval;  
			}
			set 
			{ 
				m_IsValidTimeInterval = true;
				m_TimeInterval = value;
			}
		}
		/// <summary>
		/// 	Indicates if timeInterval contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for timeInterval is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get timeInterval
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidTimeInterval
		{
			get
			{
				return m_IsValidTimeInterval;
			}
			set 
			{ 
				if (value != m_IsValidTimeInterval)
				{
					TimeInterval = 0;
					m_IsValidTimeInterval = value;
				}
			}
		}
		protected Boolean m_IsValidTimeInterval;
		protected Int32 m_TimeInterval;
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


