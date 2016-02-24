using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace NwisWOFService
{
    using NWISWS = NwisWOFService.gov.usgs.waterservices.unitvalues;
    namespace v1_0.Passthrough
    {

        using WaterOneFlow.Service.Response.v1;
        // using WaterOneFlow.Schema.v1;
        using WaterOneFlow.Service.Constants.v1;


        #region TimeSeries
        //  [XmlSchemaProvider("WaterMLSchema")]
        [XmlRoot(ElementName = "timeSeriesResponse",
           Namespace = ServiceDescriptions.XML_SCHEMA_NAMSPACE,
           IsNullable = false)]
        public class TimeSeriesResponseFromRest : TimeSeriesResponseType, IXmlSerializable
        {
        }
        #endregion
    }
}
