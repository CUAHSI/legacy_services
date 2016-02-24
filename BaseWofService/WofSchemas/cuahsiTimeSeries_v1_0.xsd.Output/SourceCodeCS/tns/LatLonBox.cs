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
	/// 	This class represents the Element latLonBox
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"latLonBox", "http://www.cuahsi.org/waterML/1.0/", true, true)]
	public partial class LatLonBox : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
					, tns.IGeogLocationType
	{
		#region Constructors
		/// <summary>
		///		Constructor for LatLonBox
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public LatLonBox()
		{
			_elementName = "latLonBox";
			Init();
		}
		public LatLonBox(String elementName)
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
			m_Srs = LiquidTechnologies.Runtime.Net20.Conversions.stringFromString("EPSG:4326", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse);
			m_IsValidSrs = true;
			m_South = 0;
			m_West = 0;
			m_North = 0;
			m_East = 0;



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
			tns.LatLonBox newObject = new tns.LatLonBox(_elementName);
			newObject.m_Srs = m_Srs;
			newObject.m_IsValidSrs = m_IsValidSrs;
			newObject.m_South = m_South;
			newObject.m_West = m_West;
			newObject.m_North = m_North;
			newObject.m_East = m_East;


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

		#region Attribute - srs
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("srs", "", "IsValidSrs", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "EPSG:4326", "", -1, -1, "", "", "", "", -1)]
		public String Srs
		{
			get 
			{ 
				if (m_IsValidSrs == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property srs is not valid. Set srsValid = true");
				return m_Srs;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidSrs = true;
				m_Srs = value;
			}
		}
		/// <summary>
		/// 	Indicates if srs contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for srs is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (LiquidTechnologies.Runtime.Net20.Conversions.stringFromString("EPSG:4326", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse)).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get srs
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidSrs
		{
			get
			{
				return m_IsValidSrs;
			}
			set 
			{ 
				// Attributes with Default can not be removed.
				if (!value)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property srs has a a default value, and is an attribute, because of this it can not be removed from the schema");
			}
		}
		protected Boolean m_IsValidSrs;
		protected String m_Srs;
		#endregion
		#region Attribute - south
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("south", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "-90.00", "90.00", "", "", -1)]
		public Double South
		{
			get 
			{ 
				return m_South;  
			}
			set 
			{ 
				CheckElementRestriction(0, value);
				m_South = value;
			}
		}
		protected Double m_South;

		#endregion
		#region Attribute - west
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("west", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "-180.00", "180.00", "", "", -1)]
		public Double West
		{
			get 
			{ 
				return m_West;  
			}
			set 
			{ 
				CheckElementRestriction(1, value);
				m_West = value;
			}
		}
		protected Double m_West;

		#endregion
		#region Attribute - north
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("north", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "-90.00", "90.00", "", "", -1)]
		public Double North
		{
			get 
			{ 
				return m_North;  
			}
			set 
			{ 
				CheckElementRestriction(2, value);
				m_North = value;
			}
		}
		protected Double m_North;

		#endregion
		#region Attribute - east
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("east", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r8, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "-180.00", "180.00", "", "", -1)]
		public Double East
		{
			get 
			{ 
				return m_East;  
			}
			set 
			{ 
				CheckElementRestriction(3, value);
				m_East = value;
			}
		}
		protected Double m_East;

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


