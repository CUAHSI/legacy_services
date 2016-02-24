using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WaterOneFlow.Utilities
{
    /// <summary>
    /// Fatory class.
    /// Creating a serializer for a custom class is a performance hit.
    /// </summary>
    public class WOFXmlSerializerFactory
    {
        private WOFXmlSerializerFactory() { }
        private static Hashtable serializers = new Hashtable();
        public static XmlSerializer GetSerializer(Type t)
        {
            XmlSerializer xs = null;
            lock (serializers.SyncRoot)
            {
                xs = serializers[t] as XmlSerializer;
                if (xs == null)
                {
                    xs = new XmlSerializer(t);
                    serializers.Add(t, xs);
                }
            }
            return xs;
        }
        public static XmlSerializer GetSerializer(Type t,XmlRootAttribute root)
        {
            XmlSerializer xs = null;
            lock (serializers.SyncRoot)
            {
                
                xs = serializers[t] as XmlSerializer;
                if (xs == null)
                {
                    xs = new XmlSerializer(t,root);
                    serializers.Add(t, xs);
                }
            }
            return xs;
        }
    }
}
