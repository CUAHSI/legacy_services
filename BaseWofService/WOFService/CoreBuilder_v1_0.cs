using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Data;
using WaterOneFlowImpl;

namespace WaterOneFlow.Service
{


    namespace v1_0
    {

        using WaterOneFlow.Schema.v1;

        using WaterOneFlowImpl.v1_0;

        /// <summary>
        /// This class contains static method to convert DataRow to 
        /// Cuahsi WaterML Elements.
        /// </summary>
        public class CoreBuilder
        {

            /// <summary>
            /// Builds a VariableInfoType which is part of the VariablesResponse;
            /// Columns:
            /// VariableID
            /// VariableCode (R)
            /// VariableVocabulary 
            /// VariableName (r) - will display 'not specified'
            /// </summary>
            /// <param name="aRow"></param>
            /// <returns></returns>
            public static VariableInfoType CreateVariableRecord(DataRow aRow)
            {

                CoreTables.VariablesDataTable vDs = new CoreTables.VariablesDataTable();

                vDs.ImportRow(aRow);

                vDs.AcceptChanges();

                VariableInfoType vit = new VariableInfoType();
                if (vDs.Rows.Count > 0)
                {
                    CoreTables.VariablesRow row =
                        (CoreTables.VariablesRow)vDs.Rows[0];
                    {
                        // set attributes
                        if (!row.IsVariableIDNull()) vit.oid = row.VariableID.ToString();

                        // add a vCode
                        vit.variableCode = new variableCode[1];
                        variableCode vCode = new variableCode();
                        if (!row.IsVariableVocabularyNull())
                        {
                            vCode.vocabulary = row.VariableVocabulary;
                            vCode.@default = true;
                            vCode.defaultSpecified = true;
                        }
                        vCode.Value = row.VariableCode;
                        vit.variableCode[0] = vCode;

                        // add name
                        if (!row.IsVariableNameNull())
                        {
                            vit.variableName = row.VariableName;
                        }
                        else
                        {
                            vit.variableName = "Not Specified.";
                        }

                        // value type
                        if (!row.IsValueTypeNull())
                        {

                            SetEnumFromText(vit, row, "valueType", typeof(valueTypeEnum));

                        }
                        //add DataType
                        if (!row.IsDataTypeNull())
                        {
                            SetEnumFromText(vit, row, "dataType", typeof(dataTypeEnum));
                        }
                        //add General Categoy
                        //
                        if (!row.IsGeneralCategoryNull())
                        {
                            SetEnumFromText(vit, row, "generalCategory", typeof(generalCategoryEnum));
                        }
                        if (!row.IsSampleMediumNull())
                        {
                            SetEnumFromText(vit, row, "sampleMedium", typeof(SampleMediumEnum));
                        }

                        // Units
                        // if just the ID exists... then it's not useful
                        if (!row.IsVariableUnitsNameNull() ||
                            !row.IsVariableUnitsAbbreviationNull())
                        {
                            units unit = new units();
                            if (!row.IsVariableUnitsNameNull()) unit.Value = row.VariableUnitsName;
                            if (!row.IsVariableUnitsAbbreviationNull())
                                unit.unitsAbbreviation = row.VariableUnitsAbbreviation;
                            if (!row.IsVariableUnitsIDNull())
                            {
                                unit.unitsCode = row.VariableUnitsID.ToString();
                            }
                            vit.units = unit;
                        }
                    }

                    // add time support
                    if (!row.IsIsRegularNull() && row.IsRegular)
                    {
                        vit.timeSupport = new VariableInfoTypeTimeSupport();
                        vit.timeSupport.isRegular = row.IsRegular;
                        vit.timeSupport.isRegularSpecified = true;

                        // add time support

                        // check to be sure we've got some vaild stuff
                        if (!row.IsTimeSupportNull())
                        {
                            vit.timeSupport.timeInterval = row.TimeSupport;
                            vit.timeSupport.timeIntervalSpecified = true;
                        }

                        if (!row.IsTimeUnitsNameNull() ||
                            !row.IsTimeUnitsAbbreviationNull()
                            )
                        {
                            vit.timeSupport.unit = new UnitsType();
                            
                            if (!row.IsTimeUnitsNameNull())
                            {
                                vit.timeSupport.unit.UnitName = row.TimeUnitsName;
                            }
                            if (!row.IsTimeUnitsAbbreviationNull())
                            {
                                vit.timeSupport.unit.UnitAbbreviation = row.TimeUnitsAbbreviation;
                            }
                            if (!row.IsTimeUnitsIDNull())
                            {
                                vit.timeSupport.unit.UnitID = row.TimeUnitsID;
                                vit.timeSupport.unit.UnitIDSpecified = true;

                            }
                            vit.timeSupport.unit.UnitType = (UnitsTypeEnum)CoreBuilder.GetTextAsEnum("Time", typeof(UnitsTypeEnum));
                        }
                        else
                        {
                            // try to get info from time unitsID
                            ///@TODO fix this 
                            //if (!row.IsTimeUnitsIDNull())
                            //{

                            //    vit.timeSupport.unit = new UnitsType();
                            //    vit.timeSupport.unit.UnitID = 104;
                            //    vit.timeSupport.unit.UnitIDSpecified = true;
                            //    vit.timeSupport.unit.UnitDescription = "day";
                            //    vit.timeSupport.unit.UnitAbbreviation = "d";
                            //    vit.timeSupport.unit.UnitType = (UnitsTypeEnum)CoreBuilder.GetTextAsEnum("Time", typeof(UnitsTypeEnum)); ;

                            //} 
                        }
                    }

                }

                return vit;
            }

            public static SiteInfoType CreateASiteInfoTypeWithLatLongPoint(
                string SiteVocabulary,
                string SiteCode,
                string SiteName,
               float? Latitude,
               float? Longitude)
            {

                String spatialReferenceSystem = "ESPG:4326";


                return CreateASiteInfoTypeWithLatLongPoint(SiteVocabulary,
                    SiteCode, SiteName,
                    Latitude, Longitude, spatialReferenceSystem);

            }

            public static SiteInfoType CreateASiteInfoTypeWithLatLongPoint(
          string SiteVocabulary,
                string SiteCode,
           string SiteName,
          float? Latitude,
          float? Longitude,
               String spatialReferenceSystem)
            {
                // if we don't have a code or name, that is really not good.
                if (String.IsNullOrEmpty(SiteCode)) return null;

                SiteInfoType si = new SiteInfoType();
                si.siteName = SiteName;
                if (Latitude.HasValue && Longitude.HasValue)
                {
                    si.geoLocation = new SiteInfoTypeGeoLocation();

                    LatLonPointType point = new LatLonPointType();
                    point.latitude = Latitude.Value;
                    point.longitude = Longitude.Value;
                    point.srs = spatialReferenceSystem;
                    si.geoLocation.geogLocation = point;
                }
                else
                {
                    // just add an empty one
                    si.geoLocation = new SiteInfoTypeGeoLocation();
                    LatLonPointType point = new LatLonPointType();
                }

                si.siteCode = new SiteInfoTypeSiteCode[1];
                si.siteCode[0] = new SiteInfoTypeSiteCode();
                si.siteCode[0].Value = SiteCode;
                si.siteCode[0].network = SiteVocabulary;
                si.siteCode[0].defaultId = true;
                si.siteCode[0].defaultIdSpecified = true;


                return si;

            }
            public static SiteInfoType createSiteInfoRecord(DataRow aRow)
            {

                CoreTables.SitesDataTable sDs = new CoreTables.SitesDataTable();

                sDs.ImportRow(aRow);

                sDs.AcceptChanges();


                SiteInfoType si = new SiteInfoType();

                if (sDs.Rows.Count > 0)
                {
                    CoreTables.SitesRow row =
                        (CoreTables.SitesRow)sDs.Rows[0];

                    string siteVocabulary;
                    string siteCode;
                    string siteName;
                    float? latitude = null;
                    float? longitude = null;
                    string spatialReferenceSystem = null;


                    siteName = row.IsSiteNameNull() ? null : row.SiteName;
                    siteCode = row.SiteCode;
                    siteVocabulary = row.IsSiteVocabularyNull() ? null : row.SiteVocabulary;
                    if (!row.IsLatitudeNull()) latitude = row.Latitude;
                    if (!row.IsLongitudeNull()) longitude = row.Longitude;
                    if (!row.IsLatLongDatumNameNull()) spatialReferenceSystem = row.LatLongDatumName;
                    si =
                        CreateASiteInfoTypeWithLatLongPoint(siteVocabulary, siteCode, siteName, latitude, longitude,
                                                            spatialReferenceSystem);
                    // add other standard items
                    if (!row.IsElevation_mNull())
                    {

                        si.elevation_m = row.Elevation_m;
                        si.elevation_mSpecified = true;
                        if (!row.IsVerticalDatumNull()) si.verticalDatum = row.VerticalDatum;
                    }
                    if (!row.IsCommentsNull())
                    {
                        NoteType n = new NoteType();
                        n.type = "comment";
                        n.title = "comment";
                        n.Value = row.Comments;
                        si.note = addNote(si.note, n);

                    }
                    if (!row.IsStateNull())
                    {
                        NoteType n = new NoteType();
                        n.title = "State";
                        n.Value = row.State;
                        si.note = addNote(si.note, n);
                    }
                    if (!row.IsCountyNull())
                    {
                        NoteType n = new NoteType();
                        n.title = "County";
                        n.Value = row.County;
                        si.note = addNote(si.note, n);
                    }
                    // assuming that if you have an enumated name, that it will work
                    if (!row.Isodws_TimeZoneAbbreviationNull()) row.TimeZoneAbbreviation = row.odws_TimeZoneAbbreviation;
                    if (!row.Isodws_TimeZoneOffsetNull()) row.TimeZoneOffset = row.odws_TimeZoneOffset;

                    // time zone
                    if (!row.IsTimeZoneAbbreviationNull() || !row.IsTimeZoneOffsetNull())
                    {
                        timeZoneInfo tz = new timeZoneInfo();
                        tz.defaultTimeZone = new timeZoneInfoDefaultTimeZone();
                        tz.defaultTimeZone.ZoneOffset = row.IsTimeZoneOffsetNull() ?
                             null : row.TimeZoneOffset;

                        // if TZ abbreviation. figure out the offset
                        if (!row.IsTimeZoneAbbreviationNull())
                        {
                            tz.defaultTimeZone.ZoneAbbreviation = row.TimeZoneAbbreviation;
                            if (tz.defaultTimeZone.ZoneOffset == null)
                            {
                                // calc timezone 
                                // right now this returns null
                                tz.defaultTimeZone.ZoneOffset = timeZoneOffset(row.TimeZoneAbbreviation);
                            }

                        }
                        si.timeZoneInfo = tz;
                    }
                }


                return si;
            }

            public static seriesCatalogTypeSeries CreateSeriesRecord(DataRow row)
            {
                seriesCatalogTypeSeries series = new seriesCatalogTypeSeries();

                CoreTables.SeriesCatalogDataTable scDt = new CoreTables.SeriesCatalogDataTable();
                scDt.ImportRow(row);

                CoreTables.SeriesCatalogRow scRow = (CoreTables.SeriesCatalogRow)scDt.Rows[0];
                //series.variable = variable != null ? variable : CreateVariableDescriptionType();
                //VariableInfoType vdt = new VariableInfoType();
                //variableCode[] var = new variableCode[1];
                //var[0] = new variableCode();
                //vdt.variableCode = var;
                //vdt.units = new units();
                //return vdt;

                // create a VariablesRow, fill it. pass it to row2Variable()
                CoreTables.VariablesDataTable vDt = new CoreTables.VariablesDataTable();
                vDt.ImportRow(row);

                series.variable = CreateVariableRecord(row);


                if (!scRow.IsValueCountNull())
                {
                    series.valueCount = new seriesCatalogTypeSeriesValueCount();
                    series.valueCount.Value = scRow.ValueCount;

                }



                //set the time interval

                // if (isRealTime)
                if (!scRow.IsRealTimeStationNull()
                    && scRow.RealTimeStation)
                {
                    TimePeriodRealTimeType rt = new TimePeriodRealTimeType();
                    int timeInterval = 0;
                    if (!scRow.IsRealTimeAvailabilityInDaysNull())
                    {
                        rt.realTimeDataPeriod = scRow.RealTimeAvailabilityInDays.ToString(); // 31 day Period               

                        rt.beginDateTime = DateTime.Today.AddDays((-1) * scRow.RealTimeAvailabilityInDays);

                    }
                    else
                    {
                        rt.realTimeDataPeriod = "31"; // 31 day Period
                        rt.beginDateTime = DateTime.Today.AddDays(-31);

                    }

                    rt.endDateTime = DateTime.Today;
                    series.variableTimeInterval = rt;
                }
                else
                {
                    if (!scRow.IsBeginDateTimeNull())
                    {
                        TimeIntervalType tm = new TimeIntervalType();

                        tm.beginDateTime = DateTime.Parse(scRow.BeginDateTime);

                        if (!scRow.IsEndDateTimeNull())
                        {
                            tm.endDateTime = DateTime.Parse(scRow.EndDateTime); ;
                        }
                        else
                        {
                            tm.endDateTime = tm.beginDateTime;
                        }
                        series.variableTimeInterval = tm;

                    }
                }

                /* TODO: fully populate
                 * These need to use ID< and fully populat from database
                 */
                // if (!String.IsNullOrEmpty(QualityControlLevelTerm))
                if (!scRow.IsQualityControlLevelIDNull()
                    || !scRow.IsQualityControlLevelTermNull())
                {
                    series.QualityControlLevel = new QualityControlLevelType();
                    // need to have a dataset with an enum so we can
                    // SetEnumFromText(qsds,row,series.QualityControlLevel, typeof(QualityControlLevelEnum));


                    if (!scRow.IsQualityControlLevelTermNull())
                    {
                        series.QualityControlLevel.Value = scRow.QualityControlLevelTerm;

                        // originally defined as an enum, but enums cannot be empty, and we have an id
                        // QualityControlLevelTerm = QualityControlLevelTerm.Replace(" ", "");
                        // if (Enum.IsDefined(typeof(QualityControlLevelEnum), QualityControlLevelTerm))
                        // {
                        //     object aEnum = Enum.Parse(typeof(QualityControlLevelEnum), QualityControlLevelTerm);
                        //     series.QualityControlLevel.Value = (QualityControlLevelEnum)aEnum;
                        // }

                    }
                    else
                    {
                        // hard code conversion to term
                        int qcId = scRow.QualityControlLevelID;
                        switch (qcId)
                        {
                            case 0:
                                series.QualityControlLevel.Value = "Raw data";
                                break;
                            case 1:
                                series.QualityControlLevel.Value = "Quality controlled data";
                                break;

                            case 2:
                                series.QualityControlLevel.Value = "Derived products";
                                break;

                            case 3:
                                series.QualityControlLevel.Value = "Interpreted products";
                                break;
                            case 4:
                                series.QualityControlLevel.Value = "Knowledge products";
                                break;
                            case -9999:
                            default:
                                series.QualityControlLevel.Value = "Unknown";
                                break;
                        }

                    }
                }
                else
                {
                    series.QualityControlLevel = new QualityControlLevelType();
                    series.QualityControlLevel.Value = "Unknown";
                }

                /* TODO: fully populate
                 * These need to use ID< and fully populat from database
                 */
                if (!scRow.IsMethodNameNull())
                {
                    MethodType method = new MethodType();
                    if (!String.IsNullOrEmpty(scRow.MethodName))
                    {
                        method.MethodDescription = scRow.MethodName;
                    }

                    series.Method = method;
                }

                if (!scRow.IsSourceDescriptionNull() ||
                    !scRow.IsOrganizationNull())
                {
                    SourceType source = new SourceType();
                    if (!scRow.IsSourceDescriptionNull())
                    {
                        source.SourceDescription = scRow.SourceDescription;
                    }
                    if (!scRow.IsOrganizationNull())
                    {
                        source.Organization = scRow.Organization;
                    }

                    series.Source = source;
                }
                return series;
            }

            public static seriesCatalogTypeSeries CreateSeriesRecord(string VariableCode, string VariableName, string VariableUnitName, string VariableUnitAbrreviation, string VariableUnitCode, string sampleMedium, string dataType, string valueType, string generalCategory, W3CDateTime? beginDateTime, W3CDateTime? endDateTime, int? valueCount, bool? valueCountIsEstimated, int? TimeInterval, string TimeIntervalUnits, bool isRealTime, string QualityControlLevelTerm, string methodName, string organization, string sourceDescription, string VariableVocabulary)
            {
                /* don't forget to check the VariableInfoType for the 
                 * dataType,ValueType and General Category
                 * 
                 */
                /*
                 * logic
                 * create seriesCatalogTypeSeries
                 * if variable != null use it. if null, make an empty variable
                 * if variable != null
                 *    and sampleMedium,dataType,valueType or generalCategory is null
                 *    try to get value from variable
                 * add datTime interface logic
                 * 
                 */
                seriesCatalogTypeSeries series = new seriesCatalogTypeSeries();


                //series.variable = variable != null ? variable : CreateVariableDescriptionType();
                //VariableInfoType vdt = new VariableInfoType();
                //variableCode[] var = new variableCode[1];
                //var[0] = new variableCode();
                //vdt.variableCode = var;
                //vdt.units = new units();
                //return vdt;

                // create a VariablesRow, fill it. pass it to row2Variable()
                CoreTables.VariablesDataTable vDs = new CoreTables.VariablesDataTable();
                CoreTables.VariablesRow row = vDs.NewVariablesRow();
                row.VariableCode = VariableCode;
                row.VariableName = VariableName;
                row.VariableUnitsName = VariableUnitName;
                row.VariableUnitsAbbreviation = VariableUnitAbrreviation;
                row.ValueType = valueType;
                row.DataType = dataType;
                row.SampleMedium = sampleMedium;
                row.GeneralCategory = generalCategory;
                row.VariableVocabulary = VariableVocabulary;
                vDs.Rows.Add(row);
                vDs.AcceptChanges();

                series.variable = CreateVariableRecord(row);

                if (valueCount.HasValue)
                {
                    series.valueCount = new seriesCatalogTypeSeriesValueCount();
                    series.valueCount.Value = valueCount.Value;
                }



                //set the time interval

                if (isRealTime)
                {
                    TimePeriodRealTimeType rt = new TimePeriodRealTimeType();
                    rt.realTimeDataPeriod = TimeInterval.ToString(); // 31 day Period
                    rt.beginDateTime = DateTime.Today.AddDays(-31);
                    rt.endDateTime = DateTime.Today;
                    series.variableTimeInterval = rt;
                }
                else
                {
                    if (beginDateTime.HasValue)
                    {
                        TimeIntervalType tm = new TimeIntervalType();

                        tm.beginDateTime = beginDateTime.Value.DateTime;

                        if (endDateTime.HasValue)
                        {
                            tm.endDateTime = endDateTime.Value.DateTime;
                        }
                        else
                        {
                            tm.endDateTime = tm.beginDateTime;
                        }
                        series.variableTimeInterval = tm;

                    }
                }

                /* TODO: fully populate
                 * These need to use ID< and fully populat from database
                 */
                if (!String.IsNullOrEmpty(QualityControlLevelTerm))
                {
                    series.QualityControlLevel = new QualityControlLevelType();
                    // need to have a dataset with an enum so we can
                    // SetEnumFromText(qsds,row,series.QualityControlLevel, typeof(QualityControlLevelEnum));


                    if (!String.IsNullOrEmpty(QualityControlLevelTerm))
                    {
                        series.QualityControlLevel.Value = QualityControlLevelTerm;

                        // originally defined as an enum, but enums cannot be empty, and we have an id
                        // QualityControlLevelTerm = QualityControlLevelTerm.Replace(" ", "");
                        // if (Enum.IsDefined(typeof(QualityControlLevelEnum), QualityControlLevelTerm))
                        // {
                        //     object aEnum = Enum.Parse(typeof(QualityControlLevelEnum), QualityControlLevelTerm);
                        //     series.QualityControlLevel.Value = (QualityControlLevelEnum)aEnum;
                        // }

                    }
                }

                /* TODO: fully populate
                 * These need to use ID< and fully populat from database
                 */
                if (!String.IsNullOrEmpty(methodName))
                {
                    MethodType method = new MethodType();
                    if (!String.IsNullOrEmpty(methodName))
                    {
                        method.MethodDescription = methodName;
                    }

                    series.Method = method;
                }
                if (!String.IsNullOrEmpty(sourceDescription) ||
                    !String.IsNullOrEmpty(organization))
                {
                    SourceType source = new SourceType();
                    if (!String.IsNullOrEmpty(sourceDescription) ||
                    !String.IsNullOrEmpty(organization))
                    {
                        source.SourceDescription = sourceDescription;
                        source.Organization = organization;
                    }

                    series.Source = source;
                }

                return series;

            }

            /// <summary>
            /// This converts Strings into XML enumerations.
            /// Converting requires that the parent object of the enumerator be passed.
            /// For example, VariablesType has four  enumerations, valueType,generalCategory,sampleMedium, and dataType
            /// The class enumerations defined in the dataset do not have spaces
            /// so matching requires removing spaces.
            /// If there is not match, then no value is returned.
            /// </summary>
            /// <param name="xmlObjectWithEnum">object which is parent of enumeratot</param>
            /// <param name="datasetRow">row that has value</param>
            /// <param name="fieldToModify">name of field</param>
            /// <param name="enumType">enumerator type</param>
            public static void SetEnumFromText(object xmlObjectWithEnum, DataRow datasetRow, String fieldToModify, Type enumType)
            {
                Type vType = xmlObjectWithEnum.GetType();
                PropertyInfo setEnum = vType.GetProperty(fieldToModify);
                PropertyInfo setEnumSpecified = vType.GetProperty(fieldToModify + "Specified");
                String aValue = null;

                if (datasetRow.Table.Columns.Contains(fieldToModify))
                {
                    if (datasetRow[fieldToModify] != DBNull.Value)
                    {
                        aValue = (String)datasetRow[fieldToModify];
                    }
                }
                object aEnum = GetTextAsEnum(aValue, enumType);
                if (aEnum != null)
                {
                    setEnum.SetValue(xmlObjectWithEnum, aEnum, null);
                    setEnumSpecified.SetValue(xmlObjectWithEnum, true, null);
                }

            }

            /// <summary>
            /// Get the eNum text without the exceptions.
            /// Returns if Enum is not a valid value.
            /// </summary>
            /// <param name="aValue"></param>
            /// <param name="enumType"></param>
            /// <returns></returns>
            public static Object GetTextAsEnum(string aValue, Type enumType)
            {
                if (String.IsNullOrEmpty(aValue) || enumType == null) return null;

                aValue = aValue.Replace(" ", "");
                aValue = aValue.Replace("/", "");
                if (Enum.IsDefined(enumType, aValue))
                {
                    object aEnum = Enum.Parse(enumType, aValue);
                    return aEnum;
                }
                return null;
            }

            public static NoteType[] addNote(NoteType[] notesField, NoteType aNote)
            {
                List<NoteType> notes;
                if (notesField == null)
                {
                    notes = new List<NoteType>();
                }
                else
                {
                    notes = new List<NoteType>(notesField);
                }
                notes.Add(aNote);
                return notes.ToArray();

            }

            private static string timeZoneOffset(String timeZoneAbbreviation)
            {
                return null;
            }
        }
    }
}