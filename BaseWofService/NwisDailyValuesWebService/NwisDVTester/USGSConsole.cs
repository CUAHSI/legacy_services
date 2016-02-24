using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using NwisWOFService;
using NwisWOFService.gov.usgs.nwis.dailyValues;
using NwisWOFService.v1_0;

namespace NwisWOFService
{

    class USGSConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("USGS DailyValuesTester");
            Console.WriteLine("Use Raw USGS values");
            while (true)
            {
                //Console.WriteLine("Agency:");
                //String agency = Console.ReadLine();
                //Console.WriteLine("Site:");
                //String site = Console.ReadLine();

                //Console.WriteLine("VariableCode:");
                //String vcode = Console.ReadLine();

                //Console.WriteLine("Statistic:");
                //String stat = Console.ReadLine();

                //Console.WriteLine("BeginDate");
                //String bDate = Console.ReadLine();

                //Console.WriteLine("EndDate");
                //String eDate = Console.ReadLine();
               
                String agency = "USGS";
                String site = "01464600";
                String vcode = "00010";
                String stat = "00001";
                String bDate = "1980-07-01";
                String eDate = "1980-08-01";

                Console.WriteLine("HIT return");
                 Console.ReadLine();

                GetValuesDailyUSGS target = new GetValuesDailyUSGS();

                gov.usgs.nwis.dailyValues.GetWSService svc = new gov.usgs.nwis.dailyValues.GetWSService();
                
                //string result = svc.getDV(site, vcode, stat, bDate, eDate, agency);
                //Console.WriteLine(result);

                // original usgs link
                //gov.usgs.nwis.dailyValues.TimeSeriesResponseType response = svc.getDV(site,
                //                     vcode, stat,
                //                     bDate, eDate,
                //                     agency);

                //gov.usgs.nwis.dailyValues. dvmessage = new getDVRequest();
                //dvmessage.siteNum = site;
                //dvmessage.parameterCode = vcode;
                //dvmessage.statisticCode = stat;
                //dvmessage.startDate = bDate;
                //dvmessage.endDate = eDate;
                //dvmessage.agencyCode = agency;

                gov.usgs.nwis.dailyValues.TimeSeriesResponseType 
                    response = 
                    svc.getDV(site, vcode, stat, bDate, eDate, agency);

                StringBuilder sb = new StringBuilder();

                
                // Create an XmlRootAttribute overloaded constructer 
                //and set its namespace.
                XmlRootAttribute tsXmlRootAttribute =
                               new XmlRootAttribute("timeSeriesResponse");
      
                XmlSerializer xs = new XmlSerializer(
                    typeof(gov.usgs.nwis.dailyValues.TimeSeriesResponseType),
                    tsXmlRootAttribute);
                XmlWriter writer = XmlWriter.Create(sb);
                xs.Serialize(writer, response);
                Console.WriteLine(sb.ToString());
                ;
            }
        }
    }

}

