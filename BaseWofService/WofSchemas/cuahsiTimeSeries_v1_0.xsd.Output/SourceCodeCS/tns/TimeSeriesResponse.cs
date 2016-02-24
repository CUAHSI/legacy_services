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
	/// 	This class represents the Element timeSeriesResponse
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"timeSeriesResponse", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class TimeSeriesResponse : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for TimeSeriesResponse
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public TimeSeriesResponse()
		{
			_elementName = "timeSeriesResponse";
			Init();
		}
		public TimeSeriesResponse(String elementName)
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
			m_QueryInfo = null;
			m_TimeSeries = new tns.TimeSeriesType("timeSeries");



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
			tns.TimeSeriesResponse newObject = new tns.TimeSeriesResponse(_elementName);
			newObject.m_QueryInfo = null;
			if (m_QueryInfo != null)
				newObject.m_QueryInfo = (tns.QueryInfoType)m_QueryInfo.Clone();
			newObject.m_TimeSeries = null;
			if (m_TimeSeries != null)
				newObject.m_TimeSeries = (tns.TimeSeriesType)m_TimeSeries.Clone();


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

		#region Attribute - queryInfo
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("queryInfo", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.QueryInfoType))]
		public tns.QueryInfoType QueryInfo
		{
			get 
			{ 
				return m_QueryInfo;  
			}
			set 
			{ 
				if (value == null)
					m_QueryInfo = null;
				else
				{
					SetElementName(value, "queryInfo");
					m_QueryInfo = value; 
				}
			}
		}
		protected tns.QueryInfoType m_QueryInfo;
		
		#endregion
		#region Attribute - timeSeries
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsMnd("timeSeries", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.TimeSeriesType), true)]
		public tns.TimeSeriesType TimeSeries
		{
			get 
			{ 
				return m_TimeSeries;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "timeSeries");
				if (value != null)
					SetElementName(value, "timeSeries");
				m_TimeSeries = value;
			}
		}
		protected tns.TimeSeriesType m_TimeSeries;
		
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


