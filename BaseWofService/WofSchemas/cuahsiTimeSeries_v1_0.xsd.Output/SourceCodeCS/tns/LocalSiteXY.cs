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
	/// 	This class represents the ComplexType localSiteXY
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"localSiteXY", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class LocalSiteXY : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for LocalSiteXY
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public LocalSiteXY()
		{
			_elementName = "localSiteXY";
			Init();
		}
		public LocalSiteXY(String elementName)
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
			m_ProjectionInformation = "";
			m_IsValidProjectionInformation = false;
			m_X = 0;
			m_Y = 0;
			m_Z = 0;
			m_IsValidZ = false; 
			m_Note = new cuahsiTimeSeries_v1_0Lib.XmlObjectCollection<tns.NoteType>("note", "http://www.cuahsi.org/waterML/1.0/", 0, -1, false);



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
			tns.LocalSiteXY newObject = new tns.LocalSiteXY(_elementName);
			newObject.m_ProjectionInformation = m_ProjectionInformation;
			newObject.m_IsValidProjectionInformation = m_IsValidProjectionInformation;
			newObject.m_X = m_X;
			newObject.m_Y = m_Y;
			newObject.m_Z = m_Z;
			newObject.m_IsValidZ = m_IsValidZ;
			foreach (tns.NoteType o in m_Note)
				newObject.m_Note.Add((tns.NoteType)o.Clone());


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

		#region Attribute - projectionInformation
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("projectionInformation", "", "IsValidProjectionInformation", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, null, "", -1, -1, "", "", "", "", -1)]
		public String ProjectionInformation
		{
			get 
			{ 
				if (m_IsValidProjectionInformation == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property projectionInformation is not valid. Set projectionInformationValid = true");
				return m_ProjectionInformation;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidProjectionInformation = true;
				m_ProjectionInformation = value;
			}
		}
		/// <summary>
		/// 	Indicates if projectionInformation contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for projectionInformation is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get projectionInformation
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidProjectionInformation
		{
			get
			{
				return m_IsValidProjectionInformation;
			}
			set 
			{ 
				if (value != m_IsValidProjectionInformation)
				{
					ProjectionInformation = "";
					m_IsValidProjectionInformation = value;
				}
			}
		}
		protected Boolean m_IsValidProjectionInformation;
		protected String m_ProjectionInformation;
		#endregion
		#region Attribute - X
		/// <summary>
		///		Represents a mandatory Element in the XML document
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Element in the XML.</BR>
		///		<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>It is defaulted to 0.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("X", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Double X
		{
			get 
			{ 
				return m_X;  
			}
			set 
			{ 
				m_X = value;
			}
		}
		protected Double m_X;

		#endregion
		#region Attribute - Y
		/// <summary>
		///		Represents a mandatory Element in the XML document
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Element in the XML.</BR>
		///		<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>It is defaulted to 0.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("Y", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Double Y
		{
			get 
			{ 
				return m_Y;  
			}
			set 
			{ 
				m_Y = value;
			}
		}
		protected Double m_Y;

		#endregion
		#region Attribute - Z
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("Z", "http://www.cuahsi.org/waterML/1.0/", "IsValidZ", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Double Z
		{
			get 
			{ 
				if (m_IsValidZ == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property Z is not valid. Set ZValid = true");
				return m_Z;  
			}
			set 
			{ 
				m_IsValidZ = true;
				m_Z = value;
			}
		}
		/// <summary>
		/// 	Indicates if Z contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for Z is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get Z
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidZ
		{
			get
			{
				return m_IsValidZ;
			}
			set 
			{ 
				if (value != m_IsValidZ)
				{
					Z = 0;
					m_IsValidZ = value;
				}
			}
		}
		protected Boolean m_IsValidZ;
		protected Double m_Z;
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


