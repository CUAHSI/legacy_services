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
	/// 	This class represents the ComplexType seriesCatalogType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"seriesCatalogType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class SeriesCatalogType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for SeriesCatalogType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public SeriesCatalogType()
		{
			_elementName = "seriesCatalogType";
			Init();
		}
		public SeriesCatalogType(String elementName)
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
			m_MenuGroupName = "";
			m_IsValidMenuGroupName = false;
			m_ServiceWsdl = "";
			m_IsValidServiceWsdl = false;
			m_Note = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType>("note", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_Series = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.Series>("series", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
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
			tns.SeriesCatalogType newObject = new tns.SeriesCatalogType(_elementName);
			newObject.m_MenuGroupName = m_MenuGroupName;
			newObject.m_IsValidMenuGroupName = m_IsValidMenuGroupName;
			newObject.m_ServiceWsdl = m_ServiceWsdl;
			newObject.m_IsValidServiceWsdl = m_IsValidServiceWsdl;
			foreach (tns.NoteType o in m_Note)
				newObject.m_Note.Add((tns.NoteType)o.Clone());
			foreach (tns.Series o in m_Series)
				newObject.m_Series.Add((tns.Series)o.Clone());
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
			get { return "http://www.cuahsi.org/waterML/1.0/"; }
		}

		#region Attribute - menuGroupName
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("menuGroupName", "", "IsValidMenuGroupName", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String MenuGroupName
		{
			get 
			{ 
				if (m_IsValidMenuGroupName == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property menuGroupName is not valid. Set menuGroupNameValid = true");
				return m_MenuGroupName;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidMenuGroupName = true;
				m_MenuGroupName = value;
			}
		}
		/// <summary>
		/// 	Indicates if menuGroupName contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for menuGroupName is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get menuGroupName
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidMenuGroupName
		{
			get
			{
				return m_IsValidMenuGroupName;
			}
			set 
			{ 
				if (value != m_IsValidMenuGroupName)
				{
					MenuGroupName = "";
					m_IsValidMenuGroupName = value;
				}
			}
		}
		protected Boolean m_IsValidMenuGroupName;
		protected String m_MenuGroupName;
		#endregion
		#region Attribute - serviceWsdl
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("serviceWsdl", "", "IsValidServiceWsdl", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public String ServiceWsdl
		{
			get 
			{ 
				if (m_IsValidServiceWsdl == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property serviceWsdl is not valid. Set serviceWsdlValid = true");
				return m_ServiceWsdl;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(value); 
				m_IsValidServiceWsdl = true;
				m_ServiceWsdl = value;
			}
		}
		/// <summary>
		/// 	Indicates if serviceWsdl contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for serviceWsdl is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get serviceWsdl
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidServiceWsdl
		{
			get
			{
				return m_IsValidServiceWsdl;
			}
			set 
			{ 
				if (value != m_IsValidServiceWsdl)
				{
					ServiceWsdl = "";
					m_IsValidServiceWsdl = value;
				}
			}
		}
		protected Boolean m_IsValidServiceWsdl;
		protected String m_ServiceWsdl;
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
		#region Attribute - series
		/// <summary>
		/// 	A collection of series's
		///		
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>This collection may contain 0 to Many objects.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsCol("series", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element)]
		public cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.Series> Series
		{
			get { return m_Series; }
		}
		protected cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.Series> m_Series;
		
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


