using System;
using System.Collections.Generic;
using System.Text;

namespace WaterOneFlowImpl
{
    class ParseDateTimeString
    {
 
            private static string formatString = "yyyy-MM-ddTHH:mm:ss.fffffffzzz";
            private static System.Globalization.CultureInfo CInfo = new System.Globalization.CultureInfo("en-US", true);

            [XmlIgnore]
            public System.DateTime internal_DateTimeField;
            [XmlIgnore]
            public bool DateTimeFieldIsNull;

            [XmlElement(IsNullable = true)]
            public string DateTimeField
            {
                set
                {
                    if ((value != null) && (value != ""))
                    {
                        internal_DateTimeField = System.DateTime.ParseExact(value, formatString, CInfo);
                        DateTimeFieldIsNull = false;
                    }
                    else
                        DateTimeFieldIsNull = true;
                }
                get
                {
                    return (DateTimeFieldIsNull) ?
                    null :
                    internal_DateTimeField.ToString(formatString);
                }
            }
         
    }
}
