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
	/// 	This class represents the ComplexType OffsetType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"OffsetType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class OffsetType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for OffsetType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public OffsetType()
		{
			_elementName = "OffsetType";
			Init();
		}
		public OffsetType(String elementName)
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
			m_OffsetTypeID = 0;
			m_IsValidOffsetTypeID = false;
			m_OffsetValue = 0F;
			m_OffsetDescription = "";
			m_IsValidOffsetDescription = false; 
			m_Units = new cuahsiTimeSeries_v1_0Lib.Units("units");
			m_OffsetIsVertical = LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("true", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse);
			m_IsValidOffsetIsVertical = false; 
			m_OffsetHorizDirectionDegrees = 0;
			m_IsValidOffsetHorizDirectionDegrees = false; 



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
			tns.OffsetType newObject = new tns.OffsetType(_elementName);
			newObject.m_OffsetTypeID = m_OffsetTypeID;
			newObject.m_IsValidOffsetTypeID = m_IsValidOffsetTypeID;
			newObject.m_OffsetValue = m_OffsetValue;
			newObject.m_OffsetDescription = m_OffsetDescription;
			newObject.m_IsValidOffsetDescription = m_IsValidOffsetDescription;
			newObject.m_Units = null;
			if (m_Units != null)
				newObject.m_Units = (cuahsiTimeSeries_v1_0Lib.Units)m_Units.Clone();
			newObject.m_OffsetIsVertical = m_OffsetIsVertical;
			newObject.m_IsValidOffsetIsVertical = m_IsValidOffsetIsVertical;
			newObject.m_OffsetHorizDirectionDegrees = m_OffsetHorizDirectionDegrees;
			newObject.m_IsValidOffsetHorizDirectionDegrees = m_IsValidOffsetHorizDirectionDegrees;


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

		#region Attribute - offsetTypeID
		/// <summary>
		///		Represents an optional Attribute in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Attribute in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.AttributeInfoPrimitive("offsetTypeID", "", "IsValidOffsetTypeID", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, null, "", -1, -1, "", "", "", "", -1)]
		public Int32 OffsetTypeID
		{
			get 
			{ 
				if (m_IsValidOffsetTypeID == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetTypeID is not valid. Set offsetTypeIDValid = true");
				return m_OffsetTypeID;  
			}
			set 
			{ 
				m_IsValidOffsetTypeID = true;
				m_OffsetTypeID = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetTypeID contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetTypeID is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetTypeID
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetTypeID
		{
			get
			{
				return m_IsValidOffsetTypeID;
			}
			set 
			{ 
				if (value != m_IsValidOffsetTypeID)
				{
					OffsetTypeID = 0;
					m_IsValidOffsetTypeID = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetTypeID;
		protected Int32 m_OffsetTypeID;
		#endregion
		#region Attribute - offsetValue
		/// <summary>
		///		Represents a mandatory Element in the XML document
		///		
		/// </summary>
		/// <remarks>
		///		<BR></BR>
		///		<BR>This property is represented as an Element in the XML.</BR>
		///		<BR>It is mandatory and therefore must be populated within the XML.</BR>
		///		<BR>It is defaulted to 0F.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("offsetValue", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_r4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Single OffsetValue
		{
			get 
			{ 
				return m_OffsetValue;  
			}
			set 
			{ 
				m_OffsetValue = value;
			}
		}
		protected Single m_OffsetValue;

		#endregion
		#region Attribute - offsetDescription
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("offsetDescription", "http://www.cuahsi.org/waterML/1.0/", "IsValidOffsetDescription", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String OffsetDescription
		{
			get 
			{ 
				if (m_IsValidOffsetDescription == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetDescription is not valid. Set offsetDescriptionValid = true");
				return m_OffsetDescription;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidOffsetDescription = true;
				m_OffsetDescription = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetDescription contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetDescription is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetDescription
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetDescription
		{
			get
			{
				return m_IsValidOffsetDescription;
			}
			set 
			{ 
				if (value != m_IsValidOffsetDescription)
				{
					OffsetDescription = "";
					m_IsValidOffsetDescription = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetDescription;
		protected String m_OffsetDescription;
		#endregion
		#region Attribute - units
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqClsMnd("units", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element, typeof(cuahsiTimeSeries_v1_0Lib.Units), false)]
		public cuahsiTimeSeries_v1_0Lib.Units Units
		{
			get 
			{ 
				return m_Units;  
			}
			set 
			{ 
				Throw_IfPropertyIsNull(value, "units");
				if (value != null)
					SetElementName(value, "units");
				m_Units = value;
			}
		}
		protected cuahsiTimeSeries_v1_0Lib.Units m_Units;
		
		#endregion
		#region Attribute - offsetIsVertical
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("offsetIsVertical", "http://www.cuahsi.org/waterML/1.0/", "IsValidOffsetIsVertical", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_boolean, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Boolean OffsetIsVertical
		{
			get 
			{ 
				if (m_IsValidOffsetIsVertical == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetIsVertical is not valid. Set offsetIsVerticalValid = true");
				return m_OffsetIsVertical;  
			}
			set 
			{ 
				m_IsValidOffsetIsVertical = true;
				m_OffsetIsVertical = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetIsVertical contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetIsVertical is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("true", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse)).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetIsVertical
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetIsVertical
		{
			get
			{
				return m_IsValidOffsetIsVertical;
			}
			set 
			{ 
				if (value != m_IsValidOffsetIsVertical)
				{
					OffsetIsVertical = LiquidTechnologies.Runtime.Net20.Conversions.booleanFromString("true", LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse);
					m_IsValidOffsetIsVertical = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetIsVertical;
		protected Boolean m_OffsetIsVertical;
		#endregion
		#region Attribute - offsetHorizDirectionDegrees
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("offsetHorizDirectionDegrees", "http://www.cuahsi.org/waterML/1.0/", "IsValidOffsetHorizDirectionDegrees", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_i4, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Collapse, "", -1, -1, "", "", "", "", -1)]
		public Int32 OffsetHorizDirectionDegrees
		{
			get 
			{ 
				if (m_IsValidOffsetHorizDirectionDegrees == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property offsetHorizDirectionDegrees is not valid. Set offsetHorizDirectionDegreesValid = true");
				return m_OffsetHorizDirectionDegrees;  
			}
			set 
			{ 
				m_IsValidOffsetHorizDirectionDegrees = true;
				m_OffsetHorizDirectionDegrees = value;
			}
		}
		/// <summary>
		/// 	Indicates if offsetHorizDirectionDegrees contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for offsetHorizDirectionDegrees is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value (0).</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get offsetHorizDirectionDegrees
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidOffsetHorizDirectionDegrees
		{
			get
			{
				return m_IsValidOffsetHorizDirectionDegrees;
			}
			set 
			{ 
				if (value != m_IsValidOffsetHorizDirectionDegrees)
				{
					OffsetHorizDirectionDegrees = 0;
					m_IsValidOffsetHorizDirectionDegrees = value;
				}
			}
		}
		protected Boolean m_IsValidOffsetHorizDirectionDegrees;
		protected Int32 m_OffsetHorizDirectionDegrees;
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


