using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


/* this was to developed to test
 * the serialization of the Values
 * 
 * */
namespace WofSchemaCommandLine
{
    using WaterOneFlow.Schema.v1;

    class Program
    {
        static void Main(string[] args)
        {

            XmlSchemaSet    xmlSchemaSet = new XmlSchemaSet();
            xmlSchemaSet.XmlResolver = new XmlUrlResolver();
            //XmlSchema xmlSchema = WaterOneFlow.Schema.GetSchema.SchemaV1_0(); ;
            String xsd = WaterOneFlow.Schema.GetSchema.SchemaXmlV1_0();
            XmlSchema xmlSchema = XmlSchema.Read(new StringReader(xsd), new ValidationEventHandler(ValidationCallBack));
            xmlSchemaSet.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
            xmlSchemaSet.Add(xmlSchema);

            XmlSerializer serializer =
               new XmlSerializer(typeof(ValueSingleVariable));

            XmlRootAttribute root = new XmlRootAttribute("value");
            XmlSerializer serializerRoot =
               new XmlSerializer(typeof(ValueSingleVariable), root);


            ValueSingleVariable value = new ValueSingleVariable();
            value.dateTime = DateTime.Now;
            value.Value = 1;
            value.qualifiers = "AD:CD ab:ab";
            System.Console.WriteLine("NoRoot\n-----------------");
            serializer.Serialize(System.Console.Out, value);
            System.Console.WriteLine("\nWithRoot\n-----------------");
            serializerRoot.Serialize(System.Console.Out, value);



            serializer =
               new XmlSerializer(typeof(TsValuesSingleVariableType));
            TsValuesSingleVariableType ts = new TsValuesSingleVariableType();

            ts.value = new ValueSingleVariable[1];
            ts.value[0] = value;
            ts.method = new MethodType[1];
            ts.method[0] = new MethodType();
            ts.method[0].MethodDescription = "method";
            ts.count = ts.value.Length.ToString();
            System.Console.WriteLine("\nTimeSeries\n-----------------");
            serializer.Serialize(System.Console.Out, ts);

            System.Console.WriteLine("\nHit AnyKey to continue");  
            System.Console.ReadKey();
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}
