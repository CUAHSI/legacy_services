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
	/// 	This class represents the ComplexType ContactInformationType
	/// </summary>
	[LiquidTechnologies.Runtime.Net20.XmlObjectInfo(LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementGroupType.Sequence,
													LiquidTechnologies.Runtime.Net20.XmlObjectBase.XmlElementType.Element,
													"ContactInformationType", "http://www.cuahsi.org/waterML/1.0/", true, false)]
	public partial class ContactInformationType : cuahsiTimeSeries_v1_0Lib.XmlCommonBase
	{
		#region Constructors
		/// <summary>
		///		Constructor for ContactInformationType
		/// </summary>
		/// <remarks>
		///		<BR>The class is created with all the mandatory fields populated with the
		///		default data. </BR>
		///		<BR>All Collection object are created.</BR>
		///		<BR>However any 1-n relationships (these are represented as collections) are
		///		empty. To comply with the schema these must be populated before the xml
		///		obtained from ToXml is valid against the schema C:\dev2005\BaseWofService\WofSchemas\cuahsiTimeSeries_v1_0.xsd</BR>
		/// </remarks>
		public ContactInformationType()
		{
			_elementName = "ContactInformationType";
			Init();
		}
		public ContactInformationType(String elementName)
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
			m_ContactName = "";
			m_TypeOfContact = "";
			m_IsValidTypeOfContact = false; 
			m_Phone = "";
			m_IsValidPhone = false; 
			m_Email = "";
			m_IsValidEmail = false; 
			m_Address = null;



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
			tns.ContactInformationType newObject = new tns.ContactInformationType(_elementName);
			newObject.m_ContactName = m_ContactName;
			newObject.m_TypeOfContact = m_TypeOfContact;
			newObject.m_IsValidTypeOfContact = m_IsValidTypeOfContact;
			newObject.m_Phone = m_Phone;
			newObject.m_IsValidPhone = m_IsValidPhone;
			newObject.m_Email = m_Email;
			newObject.m_IsValidEmail = m_IsValidEmail;
			newObject.m_Address = null;
			if (m_Address != null)
				newObject.m_Address = (LiquidTechnologies.Runtime.Net20.Element)m_Address.Clone();


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

		#region Attribute - ContactName
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
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimMnd("ContactName", "http://www.cuahsi.org/waterML/1.0/", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String ContactName
		{
			get 
			{ 
				return m_ContactName;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_ContactName = value;
			}
		}
		protected String m_ContactName;

		#endregion
		#region Attribute - TypeOfContact
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("TypeOfContact", "http://www.cuahsi.org/waterML/1.0/", "IsValidTypeOfContact", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String TypeOfContact
		{
			get 
			{ 
				if (m_IsValidTypeOfContact == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property TypeOfContact is not valid. Set TypeOfContactValid = true");
				return m_TypeOfContact;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidTypeOfContact = true;
				m_TypeOfContact = value;
			}
		}
		/// <summary>
		/// 	Indicates if TypeOfContact contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for TypeOfContact is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get TypeOfContact
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidTypeOfContact
		{
			get
			{
				return m_IsValidTypeOfContact;
			}
			set 
			{ 
				if (value != m_IsValidTypeOfContact)
				{
					TypeOfContact = "";
					m_IsValidTypeOfContact = value;
				}
			}
		}
		protected Boolean m_IsValidTypeOfContact;
		protected String m_TypeOfContact;
		#endregion
		#region Attribute - Phone
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("Phone", "http://www.cuahsi.org/waterML/1.0/", "IsValidPhone", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String Phone
		{
			get 
			{ 
				if (m_IsValidPhone == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property Phone is not valid. Set PhoneValid = true");
				return m_Phone;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidPhone = true;
				m_Phone = value;
			}
		}
		/// <summary>
		/// 	Indicates if Phone contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for Phone is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get Phone
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidPhone
		{
			get
			{
				return m_IsValidPhone;
			}
			set 
			{ 
				if (value != m_IsValidPhone)
				{
					Phone = "";
					m_IsValidPhone = value;
				}
			}
		}
		protected Boolean m_IsValidPhone;
		protected String m_Phone;
		#endregion
		#region Attribute - Email
		/// <summary>
		///		Represents an optional Element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>This property is represented as an Element in the XML.</BR>
		/// 	<BR>It is optional, initially it is not valid.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqPrimOpt("Email", "http://www.cuahsi.org/waterML/1.0/", "IsValidEmail", LiquidTechnologies.Runtime.Net20.Conversions.ConversionType.type_string, null, LiquidTechnologies.Runtime.Net20.WhitespaceUtils.WhitespaceRule.Preserve, "", -1, -1, "", "", "", "", -1)]
		public String Email
		{
			get 
			{ 
				if (m_IsValidEmail == false)
					throw new LiquidTechnologies.Runtime.Net20.LtInvalidStateException("The Property Email is not valid. Set EmailValid = true");
				return m_Email;  
			}
			set 
			{ 
				// Apply whitespace rules appropriatley
				value = LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Preserve(value); 
				m_IsValidEmail = true;
				m_Email = value;
			}
		}
		/// <summary>
		/// 	Indicates if Email contains a valid value.
		/// </summary>
		/// <remarks>
		/// 	<BR>true if the value for Email is valid, false if not.</BR>
		///		<BR>If this is set to true then the property is considered valid, and assigned its
		///		default value ("").</BR>
		///		<BR>If its set to false then its made invalid, and susiquent calls to get Email
		///		will raise an exception.</BR>
		/// </remarks>
		public Boolean IsValidEmail
		{
			get
			{
				return m_IsValidEmail;
			}
			set 
			{ 
				if (value != m_IsValidEmail)
				{
					Email = "";
					m_IsValidEmail = value;
				}
			}
		}
		protected Boolean m_IsValidEmail;
		protected String m_Email;
		#endregion
		#region Attribute - Address
		/// <summary>
		///		Represents an optional untyped element in the XML document
		/// 	
		/// </summary>
		/// <remarks>
		/// 	<BR></BR>
		/// 	<BR>It is optional, initially it is null.</BR>
		/// </remarks>
        [LiquidTechnologies.Runtime.Net20.ElementInfoSeqUntpdOpt("Address", "http://www.cuahsi.org/waterML/1.0/", "##any", "http://www.cuahsi.org/waterML/1.0/")]
		public LiquidTechnologies.Runtime.Net20.Element Address
		{
			get
			{
				return m_Address;  
			}
			set
			{
				if (value != null)
					LiquidTechnologies.Runtime.Net20.Element.TestNamespace(value.Namespace, "##any", "http://www.cuahsi.org/waterML/1.0/");
				m_Address = value; 
			}
		}
		protected LiquidTechnologies.Runtime.Net20.Element m_Address;
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


