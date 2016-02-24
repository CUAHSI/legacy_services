using System;
using System.Xml;
using System.Xml.Xsl;

namespace WaterOneFlow.Service.values
{
    public class CompiledXslt
    {
        private string _filename;
        private DateTime lastUpdate;
        XslCompiledTransform  myXslTransform;

        public CompiledXslt(string filename)
        {
            _filename = filename;
                loadXslt();
        }

        private void loadXslt()
        {
            myXslTransform  = new XslCompiledTransform();
            myXslTransform.Load(_filename);
        }

        /// <summary>
        /// see http://msdn.microsoft.com/en-us/library/ms163433(v=VS.80).aspx
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Transform(XmlReader input,XsltArgumentList argList, XmlWriter output)
        {
            myXslTransform.Transform(input, argList, output);
        }

        /// <summary>
        /// see http://msdn.microsoft.com/en-us/library/ms163433(v=VS.80).aspx
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public void Transform(XmlReader input, XmlWriter output)
        {
            myXslTransform.Transform(input, output);
        }
    }
}
