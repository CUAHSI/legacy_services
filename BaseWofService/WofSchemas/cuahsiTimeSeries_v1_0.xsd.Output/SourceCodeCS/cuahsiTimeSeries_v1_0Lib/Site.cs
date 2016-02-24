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
	/// 	This class represents the ComplexType site
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"site", "", true, false)]
	public partial class Site : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for Site
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public Site()
		{
			_elementName = "site";
			Init();
		}
		public Site(String elementName)
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
			m_SiteInfo = new tns.SiteInfoType("siteInfo");
			m_SeriesCatalog = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SeriesCatalogType>("seriesCatalog", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
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
			cuahsiTimeSeries_v1_0Lib.Site newObject = new cuahsiTimeSeries_v1_0Lib.Site(_elementName);
			newObject.m_SiteInfo = null;
			if (m_SiteInfo != null)
				newObject.m_SiteInfo = (tns.SiteInfoType)m_SiteInfo.Clone();
			foreach (tns.SeriesCatalogType o in m_SeriesCatalog)
				newObject.m_SeriesCatalog.Add((tns.SeriesCatalogType)o.Clone());
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
			get { return ""; }
		}

		#region Attribute - siteInfo
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsMnd("siteInfo", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.SiteInfoType), true)]
		public tns.SiteInfoType SiteInfo
		{
			get 
			{ 
				return m_SiteInfo;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "siteInfo");
				if (value != null)
					SetElementName(value, "siteInfo");
				m_SiteInfo = value;
			}
		}
		protected tns.SiteInfoType m_SiteInfo;
		
		#endregion
		#region Attribute - seriesCatalog
		/// <summary>
		/// 	A collection of seriesCatalog's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("seriesCatalog", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SeriesCatalogType> SeriesCatalog
		{
			get { return m_SeriesCatalog; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.SeriesCatalogType> m_SeriesCatalog;
		
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


