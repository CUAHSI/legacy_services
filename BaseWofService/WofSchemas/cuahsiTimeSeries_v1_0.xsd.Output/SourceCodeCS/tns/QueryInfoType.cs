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
	/// 	This class represents the ComplexType QueryInfoType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"QueryInfoType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class QueryInfoType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for QueryInfoType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public QueryInfoType()
		{
			_elementName = "QueryInfoType";
			Init();
		}
		public QueryInfoType(String elementName)
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
			m_CreationTime = new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime);
			m_IsValidCreationTime = false; 
			m_QueryURL = "";
			m_IsValidQueryURL = false; 
			m_QuerySQL = "";
			m_IsValidQuerySQL = false; 
			m_Criteria = null;
			m_Note = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType>("note", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
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
			tns.QueryInfoType newObject = new tns.QueryInfoType(_elementName);
			newObject.m_CreationTime = (LiquidTechnologies.Runtime.Net20.XmlDateTime)m_CreationTime.Clone();
			newObject.m_IsValidCreationTime = m_IsValidCreationTime;
			newObject.m_QueryURL = m_QueryURL;
			newObject.m_IsValidQueryURL = m_IsValidQueryURL;
			newObject.m_QuerySQL = m_QuerySQL;
			newObject.m_IsValidQuerySQL = m_IsValidQuerySQL;
			newObject.m_Criteria = null;
			if (m_Criteria != null)
				newObject.m_Criteria = (tns.Criteria)m_Criteria.Clone();
			foreach (tns.NoteType o in m_Note)
				newObject.m_Note.Add((tns.NoteType)o.Clone());
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

		#region Attribute - creationTime
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("creationTime", "http://www.cuahsi.org/waterML/1.0/", "IsValidCreationTime", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_datetime, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public LiquidTechnologies.Runtime.Net20.XmlDateTime CreationTime
		{
			get 
			{ 
				if (m_IsValidCreationTime == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property creationTime is not valid. Set creationTimeValid = true");
				return m_CreationTime;  
			}
			set 
			{ 
				m_IsValidCreationTime = true;
				m_CreationTime.SetDateTime(value, m_CreationTime.Type); 
			}
		}
		/// <summary>
		/// 	Indicates if creationTime contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for creationTime is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime)).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get creationTime
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidCreationTime
		{
			get
			{
				return m_IsValidCreationTime;
			}
			set 
			{ 
				if (value != m_IsValidCreationTime)
				{
					CreationTime = new LiquidTechnologies.Runtime.Net20.XmlDateTime(LiquidTechnologies.Runtime.Net20.XmlDateTime.DateType.dateTime);
					m_IsValidCreationTime = value;
				}
			}
		}
		protected Boolean m_IsValidCreationTime;
		protected LiquidTechnologies.Runtime.Net20.XmlDateTime m_CreationTime;
		#endregion
		#region Attribute - queryURL
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("queryURL", "http://www.cuahsi.org/waterML/1.0/", "IsValidQueryURL", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String QueryURL
		{
			get 
			{ 
				if (m_IsValidQueryURL == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property queryURL is not valid. Set queryURLValid = true");
				return m_QueryURL;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidQueryURL = true;
				m_QueryURL = value;
			}
		}
		/// <summary>
		/// 	Indicates if queryURL contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for queryURL is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get queryURL
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidQueryURL
		{
			get
			{
				return m_IsValidQueryURL;
			}
			set 
			{ 
				if (value != m_IsValidQueryURL)
				{
					QueryURL = "";
					m_IsValidQueryURL = value;
				}
			}
		}
		protected Boolean m_IsValidQueryURL;
		protected String m_QueryURL;
		#endregion
		#region Attribute - querySQL
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("querySQL", "http://www.cuahsi.org/waterML/1.0/", "IsValidQuerySQL", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String QuerySQL
		{
			get 
			{ 
				if (m_IsValidQuerySQL == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property querySQL is not valid. Set querySQLValid = true");
				return m_QuerySQL;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidQuerySQL = true;
				m_QuerySQL = value;
			}
		}
		/// <summary>
		/// 	Indicates if querySQL contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for querySQL is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get querySQL
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidQuerySQL
		{
			get
			{
				return m_IsValidQuerySQL;
			}
			set 
			{ 
				if (value != m_IsValidQuerySQL)
				{
					QuerySQL = "";
					m_IsValidQuerySQL = value;
				}
			}
		}
		protected Boolean m_IsValidQuerySQL;
		protected String m_QuerySQL;
		#endregion
		#region Attribute - criteria
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("criteria", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.Criteria))]
		public tns.Criteria Criteria
		{
			get 
			{ 
				return m_Criteria;  
			}
			set 
			{ 
				if (value == null)
					m_Criteria = null;
				else
				{
					SetElementName(value, "criteria");
					m_Criteria = value; 
				}
			}
		}
		protected tns.Criteria m_Criteria;
		
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


