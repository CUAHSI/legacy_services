using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using log4net;


namespace WaterOneFlow.Service.Data
{
    namespace V1_0
    {
using WaterOneFlow.Schema.v1;

        public class DataValuesBuilder
        {
            protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //public static WaterOneFlow.Schema.v1.TsValuesSingleVariableType
            //    CreateValuesElement(DataTable table)
            //{
            //    /* logic, look into datatable to get
            //     * - variableUnitsAbbreviation
            //     * if all the same, create values 
            //     * - values
            //     * Then get qualifiers
            //     * 
            //     * Future
            //    * if no MethodID and SourceID exists, but MethodDescript, and SourceDescrition exists
            //     * - create MethodID, and SourceID, and           
            //     */

            //    TsValuesSingleVariableType valuesElement = new TsValuesSingleVariableType();
            //    List<ValueSingleVariable> valuesList = new List<ValueSingleVariable>();
                
            //    foreach (DataRow row in table.Rows)
            //    {
            //        ValueSingleVariable value = row2Value(row);
            //        if (value != null) valuesList.Add(value);
            //    }

            //    valuesElement.value = valuesList.ToArray();
            //    valuesElement.count = valuesList.Count.ToString();

            //    return valuesElement;
            //}

            public static WaterOneFlow.Schema.v1.TsValuesSingleVariableType
                  CreateValuesElement(DataRow[] rows)
            {
                /* logic, look into datatable to get
                 * - variableUnitsAbbreviation
                 * if all the same, create values 
                 * - values
                 * Then get qualifiers
                 * 
                 * Future
                * if no MethodID and SourceID exists, but MethodDescript, and SourceDescrition exists
                 * - create MethodID, and SourceID, and           
                 */

                TsValuesSingleVariableType valuesElement = new TsValuesSingleVariableType();
                List<ValueSingleVariable> valuesList = new List<ValueSingleVariable>();

                foreach (DataRow row in rows)
                {
                    ValueSingleVariable value = row2Value(row);
                    if (value != null) valuesList.Add(value);
                }

                valuesElement.value = valuesList.ToArray();
                valuesElement.count = valuesList.Count.ToString();

                return valuesElement;
            }

            public static ValueSingleVariable
                row2Value(DataRow aRow)
            {
                DataValuesTables.DataValuesDataTable dvT = new DataValuesTables.DataValuesDataTable();
                dvT.ImportRow(aRow);
                dvT.AcceptChanges();

                DataValuesTables.DataValuesRow row = dvT[0];

                ValueSingleVariable valueElement = new ValueSingleVariable();
                try
                {
                    if (!row.IsLocalDateTimeNull())
                    {
                        valueElement.dateTime = row.LocalDateTime;
                       
                    }
                    else
                    {
                        log.Error("Value with No DateTime provided to CreateValuesElement");
                        return null;
                    }

                    if (!row.IsQualfiersNull())
                    {
                        valueElement.qualifiers = row.Qualfiers;
                    }
                    if (!row.IsQualityControlLevelTermNull())
                    {

                    }
                    if (!row.IsMethodIDNull())
                    {
                        valueElement.methodID = row.MethodID;
                    }
                    if (!row.IsSourceIDNull())
                    {
                        valueElement.sourceID = row.SourceID;
                    }
                    if (!row.IsDataValueNull())
                    {
                        valueElement.Value = Convert.ToDecimal(row.DataValue); ;
                    }
                    else
                    {
                        log.Error("No DataValue");
                        valueElement.Value = 0;
                        valueElement.censorCode = CensorCodeEnum.lt;
                        valueElement.censorCodeSpecified = true;
                    }





                }
                catch
                {
                    log.Error("Could not convert value");
                    return null;
                }
                return valueElement;

            }

            public static ValueSingleVariable CreateValue(
                double DataValue,
                WaterOneFlowImpl.W3CDateTime localDateTime,
                string CensorCode,
                string Qualifiers,
               string MethodID,
                string SourceID,
                string QualityControlLevel
                )
            {

                ValueSingleVariable valueElement = new ValueSingleVariable();
                // make as datarow

                return valueElement;
            }

        }
    }
}
