using System;
using System.Collections;
using System.Xml;
using System.Diagnostics;
using System.Collections.Specialized;

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
	public class Enumerations
	{
		// All the enumerations used within the Schema

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}
namespace msdata 
{
	public class Enumerations
	{
		// All the enumerations used within the Schema

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}
namespace gml 
{
	public class Enumerations
	{
		// All the enumerations used within the Schema

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}
namespace xlink 
{
	public class Enumerations
	{
		// All the enumerations used within the Schema

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}
namespace sql 
{
	public class Enumerations
	{
		// All the enumerations used within the Schema

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}
namespace tns 
{
	public class Enumerations
	{
		// All the enumerations used within the Schema

		#region Enumeration 'GeneralCategoryEnum'
		#region Enumeration Declaration
		public enum GeneralCategoryEnum
		{
        	WaterSpaceQuality,
        	Climate,
        	Hydrology,
        	Geology,
        	Biota,
        	Unknown,
        	Instrumentation
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a GeneralCategoryEnum enumeration
		/// </summary>
		public static String GeneralCategoryEnumToString(tns.Enumerations.GeneralCategoryEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.GeneralCategoryEnum.WaterSpaceQuality:
	    		return "Water Quality";
		    case tns.Enumerations.GeneralCategoryEnum.Climate:
	    		return "Climate";
		    case tns.Enumerations.GeneralCategoryEnum.Hydrology:
	    		return "Hydrology";
		    case tns.Enumerations.GeneralCategoryEnum.Geology:
	    		return "Geology";
		    case tns.Enumerations.GeneralCategoryEnum.Biota:
	    		return "Biota";
		    case tns.Enumerations.GeneralCategoryEnum.Unknown:
	    		return "Unknown";
		    case tns.Enumerations.GeneralCategoryEnum.Instrumentation:
	    		return "Instrumentation";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.GeneralCategoryEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a GeneralCategoryEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.GeneralCategoryEnum GeneralCategoryEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "Water Quality":
	    		return tns.Enumerations.GeneralCategoryEnum.WaterSpaceQuality;
			case "Climate":
	    		return tns.Enumerations.GeneralCategoryEnum.Climate;
			case "Hydrology":
	    		return tns.Enumerations.GeneralCategoryEnum.Hydrology;
			case "Geology":
	    		return tns.Enumerations.GeneralCategoryEnum.Geology;
			case "Biota":
	    		return tns.Enumerations.GeneralCategoryEnum.Biota;
			case "Unknown":
	    		return tns.Enumerations.GeneralCategoryEnum.Unknown;
			case "Instrumentation":
	    		return tns.Enumerations.GeneralCategoryEnum.Instrumentation;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.GeneralCategoryEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.GeneralCategoryEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.GeneralCategoryEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection GeneralCategoryEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(GeneralCategoryEnum);
			foreach (GeneralCategoryEnum e in Enum.GetValues(t))
				ret.Add(GeneralCategoryEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'DataTypeEnum'
		#region Enumeration Declaration
		public enum DataTypeEnum
		{
        	Continuous,
        	Instantaneous,
        	Cumulative,
        	Incremental,
        	Average,
        	Maximum,
        	Minimum,
        	ConstantSpaceOverSpaceInterval,
        	Categorical,
        	BestSpaceEasySpaceSystematicSpaceEstimatorSpace,
        	Unknown,
        	Variance,
        	Median,
        	Mode,
        	BestSpaceEasySpaceSystematicSpaceEstimator,
        	StandardSpaceDeviation,
        	Skewness,
        	EquivalentSpaceMean,
        	Sporadic
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a DataTypeEnum enumeration
		/// </summary>
		public static String DataTypeEnumToString(tns.Enumerations.DataTypeEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.DataTypeEnum.Continuous:
	    		return "Continuous";
		    case tns.Enumerations.DataTypeEnum.Instantaneous:
	    		return "Instantaneous";
		    case tns.Enumerations.DataTypeEnum.Cumulative:
	    		return "Cumulative";
		    case tns.Enumerations.DataTypeEnum.Incremental:
	    		return "Incremental";
		    case tns.Enumerations.DataTypeEnum.Average:
	    		return "Average";
		    case tns.Enumerations.DataTypeEnum.Maximum:
	    		return "Maximum";
		    case tns.Enumerations.DataTypeEnum.Minimum:
	    		return "Minimum";
		    case tns.Enumerations.DataTypeEnum.ConstantSpaceOverSpaceInterval:
	    		return "Constant Over Interval";
		    case tns.Enumerations.DataTypeEnum.Categorical:
	    		return "Categorical";
		    case tns.Enumerations.DataTypeEnum.BestSpaceEasySpaceSystematicSpaceEstimatorSpace:
	    		return "Best Easy Systematic Estimator ";
		    case tns.Enumerations.DataTypeEnum.Unknown:
	    		return "Unknown";
		    case tns.Enumerations.DataTypeEnum.Variance:
	    		return "Variance";
		    case tns.Enumerations.DataTypeEnum.Median:
	    		return "Median";
		    case tns.Enumerations.DataTypeEnum.Mode:
	    		return "Mode";
		    case tns.Enumerations.DataTypeEnum.BestSpaceEasySpaceSystematicSpaceEstimator:
	    		return "Best Easy Systematic Estimator";
		    case tns.Enumerations.DataTypeEnum.StandardSpaceDeviation:
	    		return "Standard Deviation";
		    case tns.Enumerations.DataTypeEnum.Skewness:
	    		return "Skewness";
		    case tns.Enumerations.DataTypeEnum.EquivalentSpaceMean:
	    		return "Equivalent Mean";
		    case tns.Enumerations.DataTypeEnum.Sporadic:
	    		return "Sporadic";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.DataTypeEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a DataTypeEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.DataTypeEnum DataTypeEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "Continuous":
	    		return tns.Enumerations.DataTypeEnum.Continuous;
			case "Instantaneous":
	    		return tns.Enumerations.DataTypeEnum.Instantaneous;
			case "Cumulative":
	    		return tns.Enumerations.DataTypeEnum.Cumulative;
			case "Incremental":
	    		return tns.Enumerations.DataTypeEnum.Incremental;
			case "Average":
	    		return tns.Enumerations.DataTypeEnum.Average;
			case "Maximum":
	    		return tns.Enumerations.DataTypeEnum.Maximum;
			case "Minimum":
	    		return tns.Enumerations.DataTypeEnum.Minimum;
			case "Constant Over Interval":
	    		return tns.Enumerations.DataTypeEnum.ConstantSpaceOverSpaceInterval;
			case "Categorical":
	    		return tns.Enumerations.DataTypeEnum.Categorical;
			case "Best Easy Systematic Estimator ":
	    		return tns.Enumerations.DataTypeEnum.BestSpaceEasySpaceSystematicSpaceEstimatorSpace;
			case "Unknown":
	    		return tns.Enumerations.DataTypeEnum.Unknown;
			case "Variance":
	    		return tns.Enumerations.DataTypeEnum.Variance;
			case "Median":
	    		return tns.Enumerations.DataTypeEnum.Median;
			case "Mode":
	    		return tns.Enumerations.DataTypeEnum.Mode;
			case "Best Easy Systematic Estimator":
	    		return tns.Enumerations.DataTypeEnum.BestSpaceEasySpaceSystematicSpaceEstimator;
			case "Standard Deviation":
	    		return tns.Enumerations.DataTypeEnum.StandardSpaceDeviation;
			case "Skewness":
	    		return tns.Enumerations.DataTypeEnum.Skewness;
			case "Equivalent Mean":
	    		return tns.Enumerations.DataTypeEnum.EquivalentSpaceMean;
			case "Sporadic":
	    		return tns.Enumerations.DataTypeEnum.Sporadic;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.DataTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.DataTypeEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.DataTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection DataTypeEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(DataTypeEnum);
			foreach (DataTypeEnum e in Enum.GetValues(t))
				ret.Add(DataTypeEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'ValueTypeEnum'
		#region Enumeration Declaration
		public enum ValueTypeEnum
		{
        	FieldSpaceObservation,
        	Sample,
        	ModelSpaceSimulationSpaceResult,
        	DerivedSpaceValue,
        	Unknown
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a ValueTypeEnum enumeration
		/// </summary>
		public static String ValueTypeEnumToString(tns.Enumerations.ValueTypeEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.ValueTypeEnum.FieldSpaceObservation:
	    		return "Field Observation";
		    case tns.Enumerations.ValueTypeEnum.Sample:
	    		return "Sample";
		    case tns.Enumerations.ValueTypeEnum.ModelSpaceSimulationSpaceResult:
	    		return "Model Simulation Result";
		    case tns.Enumerations.ValueTypeEnum.DerivedSpaceValue:
	    		return "Derived Value";
		    case tns.Enumerations.ValueTypeEnum.Unknown:
	    		return "Unknown";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.ValueTypeEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a ValueTypeEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.ValueTypeEnum ValueTypeEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "Field Observation":
	    		return tns.Enumerations.ValueTypeEnum.FieldSpaceObservation;
			case "Sample":
	    		return tns.Enumerations.ValueTypeEnum.Sample;
			case "Model Simulation Result":
	    		return tns.Enumerations.ValueTypeEnum.ModelSpaceSimulationSpaceResult;
			case "Derived Value":
	    		return tns.Enumerations.ValueTypeEnum.DerivedSpaceValue;
			case "Unknown":
	    		return tns.Enumerations.ValueTypeEnum.Unknown;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.ValueTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.ValueTypeEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.ValueTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection ValueTypeEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(ValueTypeEnum);
			foreach (ValueTypeEnum e in Enum.GetValues(t))
				ret.Add(ValueTypeEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'QualityControlLevelEnum'
		#region Enumeration Declaration
		public enum QualityControlLevelEnum
		{
        	RawSpacedata,
        	QualitySpacecontrolledSpacedata,
        	DerivedSpaceproducts,
        	InterpretedSpaceproducts,
        	KnowledgeSpaceproducts,
        	Unknown
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a QualityControlLevelEnum enumeration
		/// </summary>
		public static String QualityControlLevelEnumToString(tns.Enumerations.QualityControlLevelEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.QualityControlLevelEnum.RawSpacedata:
	    		return "Raw data";
		    case tns.Enumerations.QualityControlLevelEnum.QualitySpacecontrolledSpacedata:
	    		return "Quality controlled data";
		    case tns.Enumerations.QualityControlLevelEnum.DerivedSpaceproducts:
	    		return "Derived products";
		    case tns.Enumerations.QualityControlLevelEnum.InterpretedSpaceproducts:
	    		return "Interpreted products";
		    case tns.Enumerations.QualityControlLevelEnum.KnowledgeSpaceproducts:
	    		return "Knowledge products";
		    case tns.Enumerations.QualityControlLevelEnum.Unknown:
	    		return "Unknown";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.QualityControlLevelEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a QualityControlLevelEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.QualityControlLevelEnum QualityControlLevelEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "Raw data":
	    		return tns.Enumerations.QualityControlLevelEnum.RawSpacedata;
			case "Quality controlled data":
	    		return tns.Enumerations.QualityControlLevelEnum.QualitySpacecontrolledSpacedata;
			case "Derived products":
	    		return tns.Enumerations.QualityControlLevelEnum.DerivedSpaceproducts;
			case "Interpreted products":
	    		return tns.Enumerations.QualityControlLevelEnum.InterpretedSpaceproducts;
			case "Knowledge products":
	    		return tns.Enumerations.QualityControlLevelEnum.KnowledgeSpaceproducts;
			case "Unknown":
	    		return tns.Enumerations.QualityControlLevelEnum.Unknown;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.QualityControlLevelEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.QualityControlLevelEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.QualityControlLevelEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection QualityControlLevelEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(QualityControlLevelEnum);
			foreach (QualityControlLevelEnum e in Enum.GetValues(t))
				ret.Add(QualityControlLevelEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'UnitsTypeEnum'
		#region Enumeration Declaration
		public enum UnitsTypeEnum
		{
        	Angle,
        	Area,
        	Dimensionless,
        	Energy,
        	EnergySpaceFlux,
        	Flow,
        	Force,
        	Frequency,
        	Length,
        	Light,
        	Mass,
        	Permeability,
        	Power,
        	PressureSlashStress,
        	Resolution,
        	Scale,
        	Temperature,
        	Time,
        	Velocity,
        	Volume
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a UnitsTypeEnum enumeration
		/// </summary>
		public static String UnitsTypeEnumToString(tns.Enumerations.UnitsTypeEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.UnitsTypeEnum.Angle:
	    		return "Angle";
		    case tns.Enumerations.UnitsTypeEnum.Area:
	    		return "Area";
		    case tns.Enumerations.UnitsTypeEnum.Dimensionless:
	    		return "Dimensionless";
		    case tns.Enumerations.UnitsTypeEnum.Energy:
	    		return "Energy";
		    case tns.Enumerations.UnitsTypeEnum.EnergySpaceFlux:
	    		return "Energy Flux";
		    case tns.Enumerations.UnitsTypeEnum.Flow:
	    		return "Flow";
		    case tns.Enumerations.UnitsTypeEnum.Force:
	    		return "Force";
		    case tns.Enumerations.UnitsTypeEnum.Frequency:
	    		return "Frequency";
		    case tns.Enumerations.UnitsTypeEnum.Length:
	    		return "Length";
		    case tns.Enumerations.UnitsTypeEnum.Light:
	    		return "Light";
		    case tns.Enumerations.UnitsTypeEnum.Mass:
	    		return "Mass";
		    case tns.Enumerations.UnitsTypeEnum.Permeability:
	    		return "Permeability";
		    case tns.Enumerations.UnitsTypeEnum.Power:
	    		return "Power";
		    case tns.Enumerations.UnitsTypeEnum.PressureSlashStress:
	    		return "Pressure/Stress";
		    case tns.Enumerations.UnitsTypeEnum.Resolution:
	    		return "Resolution";
		    case tns.Enumerations.UnitsTypeEnum.Scale:
	    		return "Scale";
		    case tns.Enumerations.UnitsTypeEnum.Temperature:
	    		return "Temperature";
		    case tns.Enumerations.UnitsTypeEnum.Time:
	    		return "Time";
		    case tns.Enumerations.UnitsTypeEnum.Velocity:
	    		return "Velocity";
		    case tns.Enumerations.UnitsTypeEnum.Volume:
	    		return "Volume";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.UnitsTypeEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a UnitsTypeEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.UnitsTypeEnum UnitsTypeEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "Angle":
	    		return tns.Enumerations.UnitsTypeEnum.Angle;
			case "Area":
	    		return tns.Enumerations.UnitsTypeEnum.Area;
			case "Dimensionless":
	    		return tns.Enumerations.UnitsTypeEnum.Dimensionless;
			case "Energy":
	    		return tns.Enumerations.UnitsTypeEnum.Energy;
			case "Energy Flux":
	    		return tns.Enumerations.UnitsTypeEnum.EnergySpaceFlux;
			case "Flow":
	    		return tns.Enumerations.UnitsTypeEnum.Flow;
			case "Force":
	    		return tns.Enumerations.UnitsTypeEnum.Force;
			case "Frequency":
	    		return tns.Enumerations.UnitsTypeEnum.Frequency;
			case "Length":
	    		return tns.Enumerations.UnitsTypeEnum.Length;
			case "Light":
	    		return tns.Enumerations.UnitsTypeEnum.Light;
			case "Mass":
	    		return tns.Enumerations.UnitsTypeEnum.Mass;
			case "Permeability":
	    		return tns.Enumerations.UnitsTypeEnum.Permeability;
			case "Power":
	    		return tns.Enumerations.UnitsTypeEnum.Power;
			case "Pressure/Stress":
	    		return tns.Enumerations.UnitsTypeEnum.PressureSlashStress;
			case "Resolution":
	    		return tns.Enumerations.UnitsTypeEnum.Resolution;
			case "Scale":
	    		return tns.Enumerations.UnitsTypeEnum.Scale;
			case "Temperature":
	    		return tns.Enumerations.UnitsTypeEnum.Temperature;
			case "Time":
	    		return tns.Enumerations.UnitsTypeEnum.Time;
			case "Velocity":
	    		return tns.Enumerations.UnitsTypeEnum.Velocity;
			case "Volume":
	    		return tns.Enumerations.UnitsTypeEnum.Volume;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.UnitsTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.UnitsTypeEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.UnitsTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection UnitsTypeEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(UnitsTypeEnum);
			foreach (UnitsTypeEnum e in Enum.GetValues(t))
				ret.Add(UnitsTypeEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'SampleMediumEnum'
		#region Enumeration Declaration
		public enum SampleMediumEnum
		{
        	SurfaceSpaceWater,
        	GroundSpaceWater,
        	Sediment,
        	Soil,
        	Air,
        	Tissue,
        	Precipitation,
        	Unknown,
        	Other,
        	Snow,
        	NotSpaceRelevant
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a SampleMediumEnum enumeration
		/// </summary>
		public static String SampleMediumEnumToString(tns.Enumerations.SampleMediumEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.SampleMediumEnum.SurfaceSpaceWater:
	    		return "Surface Water";
		    case tns.Enumerations.SampleMediumEnum.GroundSpaceWater:
	    		return "Ground Water";
		    case tns.Enumerations.SampleMediumEnum.Sediment:
	    		return "Sediment";
		    case tns.Enumerations.SampleMediumEnum.Soil:
	    		return "Soil";
		    case tns.Enumerations.SampleMediumEnum.Air:
	    		return "Air";
		    case tns.Enumerations.SampleMediumEnum.Tissue:
	    		return "Tissue";
		    case tns.Enumerations.SampleMediumEnum.Precipitation:
	    		return "Precipitation";
		    case tns.Enumerations.SampleMediumEnum.Unknown:
	    		return "Unknown";
		    case tns.Enumerations.SampleMediumEnum.Other:
	    		return "Other";
		    case tns.Enumerations.SampleMediumEnum.Snow:
	    		return "Snow";
		    case tns.Enumerations.SampleMediumEnum.NotSpaceRelevant:
	    		return "Not Relevant";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.SampleMediumEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a SampleMediumEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.SampleMediumEnum SampleMediumEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "Surface Water":
	    		return tns.Enumerations.SampleMediumEnum.SurfaceSpaceWater;
			case "Ground Water":
	    		return tns.Enumerations.SampleMediumEnum.GroundSpaceWater;
			case "Sediment":
	    		return tns.Enumerations.SampleMediumEnum.Sediment;
			case "Soil":
	    		return tns.Enumerations.SampleMediumEnum.Soil;
			case "Air":
	    		return tns.Enumerations.SampleMediumEnum.Air;
			case "Tissue":
	    		return tns.Enumerations.SampleMediumEnum.Tissue;
			case "Precipitation":
	    		return tns.Enumerations.SampleMediumEnum.Precipitation;
			case "Unknown":
	    		return tns.Enumerations.SampleMediumEnum.Unknown;
			case "Other":
	    		return tns.Enumerations.SampleMediumEnum.Other;
			case "Snow":
	    		return tns.Enumerations.SampleMediumEnum.Snow;
			case "Not Relevant":
	    		return tns.Enumerations.SampleMediumEnum.NotSpaceRelevant;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.SampleMediumEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.SampleMediumEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.SampleMediumEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection SampleMediumEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(SampleMediumEnum);
			foreach (SampleMediumEnum e in Enum.GetValues(t))
				ret.Add(SampleMediumEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'CensorCodeEnum'
		#region Enumeration Declaration
		public enum CensorCodeEnum
		{
        	Lt,
        	Gt,
        	Nc,
        	Nd,
        	Pnq
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a CensorCodeEnum enumeration
		/// </summary>
		public static String CensorCodeEnumToString(tns.Enumerations.CensorCodeEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.CensorCodeEnum.Lt:
	    		return "lt";
		    case tns.Enumerations.CensorCodeEnum.Gt:
	    		return "gt";
		    case tns.Enumerations.CensorCodeEnum.Nc:
	    		return "nc";
		    case tns.Enumerations.CensorCodeEnum.Nd:
	    		return "nd";
		    case tns.Enumerations.CensorCodeEnum.Pnq:
	    		return "pnq";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.CensorCodeEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a CensorCodeEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.CensorCodeEnum CensorCodeEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "lt":
	    		return tns.Enumerations.CensorCodeEnum.Lt;
			case "gt":
	    		return tns.Enumerations.CensorCodeEnum.Gt;
			case "nc":
	    		return tns.Enumerations.CensorCodeEnum.Nc;
			case "nd":
	    		return tns.Enumerations.CensorCodeEnum.Nd;
			case "pnq":
	    		return tns.Enumerations.CensorCodeEnum.Pnq;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.CensorCodeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.CensorCodeEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.CensorCodeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection CensorCodeEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(CensorCodeEnum);
			foreach (CensorCodeEnum e in Enum.GetValues(t))
				ret.Add(CensorCodeEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

		#region Enumeration 'SampleTypeEnum'
		#region Enumeration Declaration
		public enum SampleTypeEnum
		{
        	FD,
        	FF,
        	FL,
        	LF,
        	GW,
        	PB,
        	PD,
        	PE,
        	PI,
        	PW,
        	RE,
        	SE,
        	SR,
        	SS,
        	SW,
        	TE,
        	TI,
        	TW,
        	VE,
        	VI,
        	VW,
        	Grab,
        	Unknown,
        	NoSpaceSample
		}
		#endregion


		#region Conversion functions
		/// <summary>
		/// 	Converts a string to a SampleTypeEnum enumeration
		/// </summary>
		public static String SampleTypeEnumToString(tns.Enumerations.SampleTypeEnum enumValue)
		{
		    switch(enumValue)
		    {
		    case tns.Enumerations.SampleTypeEnum.FD:
	    		return "FD";
		    case tns.Enumerations.SampleTypeEnum.FF:
	    		return "FF";
		    case tns.Enumerations.SampleTypeEnum.FL:
	    		return "FL";
		    case tns.Enumerations.SampleTypeEnum.LF:
	    		return "LF";
		    case tns.Enumerations.SampleTypeEnum.GW:
	    		return "GW";
		    case tns.Enumerations.SampleTypeEnum.PB:
	    		return "PB";
		    case tns.Enumerations.SampleTypeEnum.PD:
	    		return "PD";
		    case tns.Enumerations.SampleTypeEnum.PE:
	    		return "PE";
		    case tns.Enumerations.SampleTypeEnum.PI:
	    		return "PI";
		    case tns.Enumerations.SampleTypeEnum.PW:
	    		return "PW";
		    case tns.Enumerations.SampleTypeEnum.RE:
	    		return "RE";
		    case tns.Enumerations.SampleTypeEnum.SE:
	    		return "SE";
		    case tns.Enumerations.SampleTypeEnum.SR:
	    		return "SR";
		    case tns.Enumerations.SampleTypeEnum.SS:
	    		return "SS";
		    case tns.Enumerations.SampleTypeEnum.SW:
	    		return "SW";
		    case tns.Enumerations.SampleTypeEnum.TE:
	    		return "TE";
		    case tns.Enumerations.SampleTypeEnum.TI:
	    		return "TI";
		    case tns.Enumerations.SampleTypeEnum.TW:
	    		return "TW";
		    case tns.Enumerations.SampleTypeEnum.VE:
	    		return "VE";
		    case tns.Enumerations.SampleTypeEnum.VI:
	    		return "VI";
		    case tns.Enumerations.SampleTypeEnum.VW:
	    		return "VW";
		    case tns.Enumerations.SampleTypeEnum.Grab:
	    		return "Grab";
		    case tns.Enumerations.SampleTypeEnum.Unknown:
	    		return "Unknown";
		    case tns.Enumerations.SampleTypeEnum.NoSpaceSample:
	    		return "No Sample";
			default:
	    		throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.SampleTypeEnum [" + enumValue.ToString() + "]");
			}
		}
	
		/// <summary>
		/// 	Converts a SampleTypeEnum enumeration to a string (suitable for the XML document)
		/// </summary>
		public static tns.Enumerations.SampleTypeEnum SampleTypeEnumFromString(String enumValue)
		{
		    switch(LiquidTechnologies.Runtime.Net20.WhitespaceUtils.Collapse(enumValue))
		    {
			case "FD":
	    		return tns.Enumerations.SampleTypeEnum.FD;
			case "FF":
	    		return tns.Enumerations.SampleTypeEnum.FF;
			case "FL":
	    		return tns.Enumerations.SampleTypeEnum.FL;
			case "LF":
	    		return tns.Enumerations.SampleTypeEnum.LF;
			case "GW":
	    		return tns.Enumerations.SampleTypeEnum.GW;
			case "PB":
	    		return tns.Enumerations.SampleTypeEnum.PB;
			case "PD":
	    		return tns.Enumerations.SampleTypeEnum.PD;
			case "PE":
	    		return tns.Enumerations.SampleTypeEnum.PE;
			case "PI":
	    		return tns.Enumerations.SampleTypeEnum.PI;
			case "PW":
	    		return tns.Enumerations.SampleTypeEnum.PW;
			case "RE":
	    		return tns.Enumerations.SampleTypeEnum.RE;
			case "SE":
	    		return tns.Enumerations.SampleTypeEnum.SE;
			case "SR":
	    		return tns.Enumerations.SampleTypeEnum.SR;
			case "SS":
	    		return tns.Enumerations.SampleTypeEnum.SS;
			case "SW":
	    		return tns.Enumerations.SampleTypeEnum.SW;
			case "TE":
	    		return tns.Enumerations.SampleTypeEnum.TE;
			case "TI":
	    		return tns.Enumerations.SampleTypeEnum.TI;
			case "TW":
	    		return tns.Enumerations.SampleTypeEnum.TW;
			case "VE":
	    		return tns.Enumerations.SampleTypeEnum.VE;
			case "VI":
	    		return tns.Enumerations.SampleTypeEnum.VI;
			case "VW":
	    		return tns.Enumerations.SampleTypeEnum.VW;
			case "Grab":
	    		return tns.Enumerations.SampleTypeEnum.Grab;
			case "Unknown":
	    		return tns.Enumerations.SampleTypeEnum.Unknown;
			case "No Sample":
	    		return tns.Enumerations.SampleTypeEnum.NoSpaceSample;
			default:
				// ##HAND_CODED_BLOCK_START ID="Default Enum tns.Enumerations.SampleTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
				throw new LiquidTechnologies.Runtime.Net20.LtInvalidValueException("Unknown enumeration value for tns.Enumerations.SampleTypeEnum [" + enumValue + "]");
				// ##HAND_CODED_BLOCK_END ID="Default Enum tns.Enumerations.SampleTypeEnum"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			}
		}
		
		public static StringCollection SampleTypeEnumNames()
		{
			StringCollection ret = new StringCollection();
			System.Type t = typeof(SampleTypeEnum);
			foreach (SampleTypeEnum e in Enum.GetValues(t))
				ret.Add(SampleTypeEnumToString(e));
			return ret;
		}
		
		#endregion
		#endregion

// ##HAND_CODED_BLOCK_START ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS

// Add Additional Methods and members here...

// ##HAND_CODED_BLOCK_END ID="Additional Methods"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
	}
}
	
namespace cuahsiTimeSeries_v1_0Lib 
{
	internal class Registration
	{
		private static int RegisterLicense()
		{
			LiquidTechnologies.Runtime.Net20.XmlObjectBase.Register("UCSD/San Diego Supercomputer Center - Educational for Non Commercial Use Only (2 * Developer Edition)", "cuahsiTimeSeries_v1_0.xsd", "WR41XD1E6UY4U3CQ000000AA");
			
// ##HAND_CODED_BLOCK_START ID="Namespace Declarations"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
// Add Additional namespace declarations here...
			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.SchemaType = LiquidTechnologies.Runtime.Net20.SchemaType.XSD;
//			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.DefaultNamespaceURI = "http://www.fpml.org/2003/FpML-4-0";
//			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.NamespaceAliases.Add("dsig", "http://www.w3.org/2000/09/xmldsig#");

			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.NamespaceAliases.Add("xs", "http://www.w3.org/2001/XMLSchema-instance");
			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.NamespaceAliases.Add("msdata", "urn:schemas-microsoft-com:xml-msdata");
			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.NamespaceAliases.Add("gml", "http://www.opengis.net/gml");
			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.NamespaceAliases.Add("xlink", "http://www.w3.org/1999/xlink");
			LiquidTechnologies.Runtime.Net20.XmlSerializationContext.Default.NamespaceAliases.Add("sql", "urn:schemas-microsoft-com:mapping-schema");

// ##HAND_CODED_BLOCK_END ID="Namespace Declarations"## DO NOT MODIFY ANYTHING OUTSIDE OF THESE TAGS
			
			return 1;
		}
		static public int iRegistrationIndicator = RegisterLicense();
	}
}




