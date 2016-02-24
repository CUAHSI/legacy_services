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
	/// 	This class represents the Element datasetInfo
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"datasetInfo", "http://www.cuahsi.org/waterML/1.0/", true, true)]
	public partial class DatasetInfo : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
					, tns.ISourceInfoType
	{
		#region Constructors
		/// <summary>
		///		Constructor for DatasetInfo
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public DatasetInfo()
		{
			_elementName = "datasetInfo";
			Init();
		}
		public DatasetInfo(String elementName)
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
			m_DataSetIdentifier = "";
			m_TimeZoneInfo = null;
			m_DataSetDescription = "";
			m_IsValidDataSetDescription = false; 
			m_Note = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType>("note", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);
			m_DataSetLocation = null;
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
			tns.DatasetInfo newObject = new tns.DatasetInfo(_elementName);
			newObject.m_DataSetIdentifier = m_DataSetIdentifier;
			newObject.m_TimeZoneInfo = null;
			if (m_TimeZoneInfo != null)
				newObject.m_TimeZoneInfo = (cuahsiTimeSeries_v1_0Lib.TimeZoneInfo)m_TimeZoneInfo.Clone();
			newObject.m_DataSetDescription = m_DataSetDescription;
			newObject.m_IsValidDataSetDescription = m_IsValidDataSetDescription;
			foreach (tns.NoteType o in m_Note)
				newObject.m_Note.Add((tns.NoteType)o.Clone());
			newObject.m_DataSetLocation = null;
			if (m_DataSetLocation != null)
				newObject.m_DataSetLocation = (tns.IGeogLocationType)m_DataSetLocation.Clone();
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

		#region Attribute - dataSetIdentifier
		/// <summary>
		///		Represents a mandatory Element in the XML document
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Element in the XML.</BR>
		///		<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>It is defaulted to "".</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("dataSetIdentifier", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String DataSetIdentifier
		{
			get 
			{ 
				return m_DataSetIdentifier;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_DataSetIdentifier = value;
			}
		}
		protected String m_DataSetIdentifier;

		#endregion
		#region Attribute - timeZoneInfo
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsOpt("timeZoneInfo", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(cuahsiTimeSeries_v1_0Lib.TimeZoneInfo))]
		public cuahsiTimeSeries_v1_0Lib.TimeZoneInfo TimeZoneInfo
		{
			get 
			{ 
				return m_TimeZoneInfo;  
			}
			set 
			{ 
				if (value == null)
					m_TimeZoneInfo = null;
				else
				{
					SetElementName(value, "timeZoneInfo");
					m_TimeZoneInfo = value; 
				}
			}
		}
		protected cuahsiTimeSeries_v1_0Lib.TimeZoneInfo m_TimeZoneInfo;
		
		#endregion
		#region Attribute - dataSetDescription
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("dataSetDescription", "http://www.cuahsi.org/waterML/1.0/", "IsValidDataSetDescription", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String DataSetDescription
		{
			get 
			{ 
				if (m_IsValidDataSetDescription == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property dataSetDescription is not valid. Set dataSetDescriptionValid = true");
				return m_DataSetDescription;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidDataSetDescription = true;
				m_DataSetDescription = value;
			}
		}
		/// <summary>
		/// 	Indicates if dataSetDescription contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for dataSetDescription is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get dataSetDescription
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidDataSetDescription
		{
			get
			{
				return m_IsValidDataSetDescription;
			}
			set 
			{ 
				if (value != m_IsValidDataSetDescription)
				{
					DataSetDescription = "";
					m_IsValidDataSetDescription = value;
				}
			}
		}
		protected Boolean m_IsValidDataSetDescription;
		protected String m_DataSetDescription;
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
		#region Attribute - dataSetLocation
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqAbsClsOpt("dataSetLocation", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(tns.ClassFactory), "IGeogLocationTypeCreateObject")]
		public tns.IGeogLocationType DataSetLocation
		{
			get 
			{ 
				return m_DataSetLocation;  
			}
			set 
			{ 
				if (value == null)
					m_DataSetLocation = null;
				else
				{
					m_DataSetLocation = value; 
					// The object being set needs to take the element name from the class (the type="" attribute will then be set in the XML)
					SetElementName(value.GetBase(), "dataSetLocation");
				}
			}
		}
		protected tns.IGeogLocationType m_DataSetLocation;

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


