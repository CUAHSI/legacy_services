using System;
using System.Collections.Generic;
using System.Text;


using WaterOneFlow.Utilities.Service;
using WaterOneFlowImpl;
using VariableParam=WaterOneFlowImpl.v1_0.VariableParam;

namespace RestServiceClient
{
    namespace Generic.v10
    {
        using WaterOneFlow.Service.v1_0;
        using WaterOneFlow.Schema.v1;

       public  class DataInformationService : DataInfoService
    {
           private static BaseRestClient GetNewBaseClient()
           {
               BaseRestClient restServiceClient; 
               restServiceClient = new BaseRestClient();
               restServiceClient.BaseUrl = "http://www2.mvr.usace.army.mil/watercontrol/webservices/rest/webserviceWaterML.cfm?";
               return restServiceClient;
           }

           public override SiteInfoType[] GetSites(locationParam[] sites)
           {
               BaseRestClient restServiceClient = GetNewBaseClient();
               string[] parameters;
               Type vType = typeof(SiteInfoResponseType);
               restServiceClient.ResponseType = vType;

               if (sites == null || sites.Length == 0 )
               {
                   restServiceClient.PathFormat = "Meth={0}";
                   parameters = new string[1];
                   parameters[0] = "GetSites";
               } else
               {
                   restServiceClient.PathFormat = "Meth={0}";
                   int len = sites.Length;
                   parameters = new string[sites.Length + 1];
                   parameters[0] = "GetSites";
                   for (int i = 0; i < sites.Length ; i++)
                   {
                       parameters[i+1] = sites[i].SiteCode;
                       restServiceClient.PathFormat += "&site={" + i +1 + "}";

                   }
               }
              

               object res = restServiceClient.GetResponseAsObject(parameters);

              
               SiteInfoResponseType response = (SiteInfoResponseType)res;
               if (response != null && response.site != null)
               {
                   List<SiteInfoType> siteInfoTypes = new List<SiteInfoType>();
                   foreach (site s  in response.site)
                   {
                       siteInfoTypes.Add(s.siteInfo);
                   }
                   return siteInfoTypes.ToArray();
               } else
               {
                   throw new WaterOneFlowSourceException("No Sites Returned");
               }
           }

           public override SiteInfoType GetSite(locationParam site)
           {
               locationParam[] sites ;
               if ( site == null)
               {
                   sites = new locationParam[0];
               }
               else
               {
                   sites = new locationParam[1];
                   sites[0] = site;
               }
               SiteInfoType[] siteInfoTypes =  GetSites(sites);
              if (siteInfoTypes == null || siteInfoTypes.Length == 0)
              {
                  return null;
              } else
              {
                  
                      return siteInfoTypes[0];

                 
              }
           }

           public override SiteInfoType[] GetSiteInfoObjects(locationParam[] sites)
           {
               BaseRestClient restServiceClient = GetNewBaseClient();
               string[] parameters;
               Type vType = typeof(SiteInfoResponseType);
               restServiceClient.ResponseType = vType;

               if (sites == null || sites.Length == 0)
               {
                   restServiceClient.PathFormat = "Meth={0}";
                   parameters = new string[1];
                   parameters[0] = "GetSiteInfo";
               }
               else
               {
                   restServiceClient.PathFormat = "Meth={0}";
                   int len = sites.Length;
                   parameters = new string[sites.Length + 1];
                   parameters[0] = "GetSiteInfo";
                   for (int i = 0; i < sites.Length ; i++)
                   {
                       parameters[i+1] = sites[i].SiteCode;
                       restServiceClient.PathFormat += "&sid={"+ i +1 + "}" ;
                   }
               }


               object res = restServiceClient.GetResponseAsObject(parameters);


               SiteInfoResponseType response = (SiteInfoResponseType)res;
               if (response != null && response.site != null)
               {
                   List<SiteInfoType> siteInfoTypes = new List<SiteInfoType>();
                   foreach (site s in response.site)
                   {
                       siteInfoTypes.Add(s.siteInfo);
                   }
                   return siteInfoTypes.ToArray();
               }
               else
               {
                   throw new WaterOneFlowSourceException("No Sites Returned");
               }
           }

           public override SiteInfoType GetSiteInfoObject(locationParam site)
           {
               locationParam[] sites;
               if (site == null)
               {
                   sites = new locationParam[0];
               }
               else
               {
                   sites = new locationParam[1];
                   sites[0] = site;
               }
               SiteInfoType[] siteInfoTypes = GetSites(sites);
               if (siteInfoTypes == null || siteInfoTypes.Length == 0)
               {
                   return null;
               }
               else
               {
                   return siteInfoTypes[0];
               }
           }

           public override seriesCatalogType[] GetSeries(locationParam site, TimeSeriesTypeEnum seriesType)
           {
               BaseRestClient restServiceClient = GetNewBaseClient();
               string[] parameters;
               Type vType = typeof(SiteInfoResponseType);
               restServiceClient.ResponseType = vType;

               if (site != null )
               {
                   restServiceClient.PathFormat = "Meth={0}&site={1}";
                   parameters = new string[2];
                   parameters[0] = "GetSiteInfo";
                   parameters[1] = site.SiteCode;
               } else
               {
                   return null;
               }

               object res = restServiceClient.GetResponseAsObject(parameters);


               SiteInfoResponseType response = (SiteInfoResponseType)res;
               if (response != null && response.site != null)
               {
                   WaterOneFlow.Schema.v1.site s = response.site[0];
                   if (s.seriesCatalog != null )
                   {
                       return s.seriesCatalog;
                   } else
                   {
                       return null;
                   }
               }
               else
               {
                   throw new WaterOneFlowSourceException("No Site Returned");
               }
           }

        

           public override VariableInfoType[] GetVariableInfoObject(VariableParam[] variables)
           {
               BaseRestClient restServiceClient = GetNewBaseClient();
               string[] parameters;

               {
                   restServiceClient.PathFormat = "Meth={0}&variable={1}";


                   Type vType = typeof (VariablesResponseType);
                   restServiceClient.ResponseType = vType;
                   parameters = new string[5];
                   parameters[0] = "getVariableInfo";
                   if (variables == null || variables.Length == 0)
                   {
                       parameters[1] = String.Empty;
                   } else {
                       parameters[1] = variables[0].Code;
                   }
                   
                   VariablesResponseType res = (VariablesResponseType)restServiceClient.GetResponseAsObject(parameters);
                   return res.variables;
               }
           }

           public override VariableInfoType[] GetVariableInfoObject(VariableParam variable)
           {
              VariableParam[] variables;
              if (variable == null )
               {
                   variables = new VariableParam[0];
               }
               else
               {
                  variables = new VariableParam[1];
               variables[0] = variable; 
               }
               return GetVariableInfoObject(variables);
           }
    }
    }
    namespace Generic.v11
    {
        using WaterOneFlow.Service.v1_1;
        using WaterOneFlow.Schema.v1_1;
        public class DataInformationService : DataInfoService
        {
            public override SiteInfoType[] GetSites(locationParam[] sites)
            {
                throw new NotImplementedException();
            }

            public override SiteInfoType GetSite(locationParam site)
            {
                throw new NotImplementedException();
            }

            public override SiteInfoType[] GetSiteInfoObjects(locationParam[] sites)
            {
                throw new NotImplementedException();
            }

            public override SiteInfoType GetSiteInfoObject(locationParam site)
            {
                throw new NotImplementedException();
            }

            public override seriesCatalogType[] GetSeries(locationParam site)
            {
                throw new NotImplementedException();
            }

            public override VariableInfoType[] GetVariableInfoObject(WaterOneFlowImpl.v1_1.VariableParam[] variables)
            {
                throw new NotImplementedException();
            }

            public override VariableInfoType[] GetVariableInfoObject(WaterOneFlowImpl.v1_1.VariableParam variable)
            {
                throw new NotImplementedException();
            }

 
        }
    }
}
