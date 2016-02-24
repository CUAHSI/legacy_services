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
	/// 	This class represents the Element timeZoneInfo
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"timeZoneInfo", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class TimeZoneInfo : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for TimeZoneInfo
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public TimeZoneInfo()
		{
			_elementName = "timeZoneInfo";
			Init();
		}
		public TimeZoneInfo(String elementName)
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
			m_SiteUsesDaylightSavingsTime = LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("false", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse);
			m_IsValidSiteUsesDaylightSavingsTime = true;
			m_DefaultTimeZone = null;
			m_DaylightSavingsTimeZone = null;



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
			tns.TimeZoneInfo newObject = new tns.TimeZoneInfo(_elementName);
			newObject.m_SiteUsesDaylightSavingsTime = m_SiteUsesDaylightSavingsTime;
			newObject.m_IsValidSiteUsesDaylightSavingsTime = m_IsValidSiteUsesDaylightSavingsTime;
			newObject.m_DefaultTimeZone = null;
			if (m_DefaultTimeZone != null)
				newObject.m_DefaultTimeZone = (tns.DefaultTimeZone)m_DefaultTimeZone.Clone();
			newObject.m_DaylightSavingsTimeZone = null;
			if (m_DaylightSavingsTimeZone != null)
				newObject.m_DaylightSavingsTimeZone = (tns.DaylightSavingsTimeZone)m_DaylightSavingsTimeZone.Clone();


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

		#region Attribute - siteUsesDaylightSavingsTime
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("siteUsesDaylightSavingsTime", "", "IsValidSiteUsesDaylightSavingsTime", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "false", "", -1, -1, "", "", "", "", -1)]
		public Boolean SiteUsesDaylightSavingsTime
		{
			get 
			{ 
				if (m_IsValidSiteUsesDaylightSavingsTime == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property siteUsesDaylightSavingsTime is not valid. Set siteUsesDaylightSavingsTimeValid = true");
				return m_SiteUsesDaylightSavingsTime;  
			}
			set 
			{ 
				m_IsValidSiteUsesDaylightSavingsTime = true;
				m_SiteUsesDaylightSavingsTime = value;
			}
		}
		/// <summary>
		/// 	Indicates if siteUsesDaylightSavingsTime contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for siteUsesDaylightSavingsTime is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("false", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse)).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get siteUsesDaylightSavingsTime
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSiteUsesDaylightSavingsTime
		{
			get
			{
				return m_IsValidSiteUsesDaylightSavingsTime;
			}
			set 
			{ 
				// Attributes with Default can not be removed.
				if (!value)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property siteUsesDaylightSavingsTime has a a default value, and is an attribute, because of this it can not be removed from the schema");
			}
		}
		protected Boolean m_IsValidSiteUsesDaylightSavingsTime;
		protected Boolean m_SiteUsesDaylightSavingsTime;
		#endregion
		#region Attribute - defaultTimeZone
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("defaultTimeZone", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.DefaultTimeZone))]
		public tns.DefaultTimeZone DefaultTimeZone
		{
			get 
			{ 
				return m_DefaultTimeZone;  
			}
			set 
			{ 
				if (value == null)
					m_DefaultTimeZone = null;
				else
				{
					SetElementName(value, "defaultTimeZone");
					m_DefaultTimeZone = value; 
				}
			}
		}
		protected tns.DefaultTimeZone m_DefaultTimeZone;
		
		#endregion
		#region Attribute - daylightSavingsTimeZone
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("daylightSavingsTimeZone", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.DaylightSavingsTimeZone))]
		public tns.DaylightSavingsTimeZone DaylightSavingsTimeZone
		{
			get 
			{ 
				return m_DaylightSavingsTimeZone;  
			}
			set 
			{ 
				if (value == null)
					m_DaylightSavingsTimeZone = null;
				else
				{
					SetElementName(value, "daylightSavingsTimeZone");
					m_DaylightSavingsTimeZone = value; 
				}
			}
		}
		protected tns.DaylightSavingsTimeZone m_DaylightSavingsTimeZone;
		
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


