using System;
using System.Collections.Generic;
using System.Text;
using WaterOneFlowImpl;
using WaterOneFlowImpl.v1_1;

namespace WaterOneFlow.Service
{
    namespace v1_0
    {
        using WaterOneFlow.Schema.v1;
        using VariableParam = WaterOneFlowImpl.v1_0.VariableParam;

        public abstract class DataInfoService
        {
            public string VariableVocabulary;
            public string SiteVocabulary;
            private  Dictionary<string,object> parameters = new Dictionary<string, object>();

            protected DataInfoService()
            {

            }

            public Dictionary<string, object> Parameters
            {
                get { return parameters; }
                set { parameters = value; }
            }


            public abstract SiteInfoType[] GetSites(locationParam[] sites);
            public abstract SiteInfoType GetSite(locationParam site);

            public abstract SiteInfoType[] GetSiteInfoObjects(locationParam[] sites);
            public abstract SiteInfoType GetSiteInfoObject(locationParam site);

            public seriesCatalogType[] GetSeries(locationParam site)
            {
                return GetSeries(site, TimeSeriesTypeEnum.Interval);
            }

            public abstract seriesCatalogType[] GetSeries(locationParam site, TimeSeriesTypeEnum seriesType);

            public abstract VariableInfoType[] GetVariableInfoObject(VariableParam[] variables);
            public abstract VariableInfoType[] GetVariableInfoObject(VariableParam variable); // can return multiple
        }
    }

    namespace v1_1
    {
        using WaterOneFlow.Schema.v1_1;
        using VariableParam = WaterOneFlowImpl.v1_1.VariableParam;

        public abstract class DataInfoService
        {
            protected DataInfoService()
            {

            }


            public abstract SiteInfoType[] GetSites(locationParam[] sites);
            public abstract SiteInfoType GetSite(locationParam site);

            public abstract SiteInfoType[] GetSiteInfoObjects(locationParam[] sites);
            public abstract SiteInfoType GetSiteInfoObject(locationParam site);

            public abstract seriesCatalogType[] GetSeries(locationParam site);

            public abstract VariableInfoType[] GetVariableInfoObject(VariableParam[] variables);
            public abstract VariableInfoType[] GetVariableInfoObject(VariableParam variable); // can return multiple
        }
    }
}
