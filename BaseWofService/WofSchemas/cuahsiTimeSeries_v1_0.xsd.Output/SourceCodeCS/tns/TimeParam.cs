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
	/// 	This class represents the ComplexType timeParam
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"timeParam", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class TimeParam : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for TimeParam
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public TimeParam()
		{
			_elementName = "timeParam";
			Init();
		}
		public TimeParam(String elementName)
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
			m_BeginDateTime = "";
			m_IsValidBeginDateTime = false; 
			m_EndDateTime = "";
			m_IsValidEndDateTime = false; 



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
			tns.TimeParam newObject = new tns.TimeParam(_elementName);
			newObject.m_BeginDateTime = m_BeginDateTime;
			newObject.m_IsValidBeginDateTime = m_IsValidBeginDateTime;
			newObject.m_EndDateTime = m_EndDateTime;
			newObject.m_IsValidEndDateTime = m_IsValidEndDateTime;


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

		#region Attribute - beginDateTime
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("beginDateTime", "http://www.cuahsi.org/waterML/1.0/", "IsValidBeginDateTime", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String BeginDateTime
		{
			get 
			{ 
				if (m_IsValidBeginDateTime == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property beginDateTime is not valid. Set beginDateTimeValid = true");
				return m_BeginDateTime;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidBeginDateTime = true;
				m_BeginDateTime = value;
			}
		}
		/// <summary>
		/// 	Indicates if beginDateTime contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for beginDateTime is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get beginDateTime
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidBeginDateTime
		{
			get
			{
				return m_IsValidBeginDateTime;
			}
			set 
			{ 
				if (value != m_IsValidBeginDateTime)
				{
					BeginDateTime = "";
					m_IsValidBeginDateTime = value;
				}
			}
		}
		protected Boolean m_IsValidBeginDateTime;
		protected String m_BeginDateTime;
		#endregion
		#region Attribute - endDateTime
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("endDateTime", "http://www.cuahsi.org/waterML/1.0/", "IsValidEndDateTime", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String EndDateTime
		{
			get 
			{ 
				if (m_IsValidEndDateTime == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property endDateTime is not valid. Set endDateTimeValid = true");
				return m_EndDateTime;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidEndDateTime = true;
				m_EndDateTime = value;
			}
		}
		/// <summary>
		/// 	Indicates if endDateTime contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for endDateTime is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get endDateTime
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidEndDateTime
		{
			get
			{
				return m_IsValidEndDateTime;
			}
			set 
			{ 
				if (value != m_IsValidEndDateTime)
				{
					EndDateTime = "";
					m_IsValidEndDateTime = value;
				}
			}
		}
		protected Boolean m_IsValidEndDateTime;
		protected String m_EndDateTime;
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


