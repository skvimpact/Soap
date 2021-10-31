using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Soap
{
    public class SoapEnvelopeBuilder
    {
        private List<XElement> parameters = new List<XElement>();
        private XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        private XNamespace srv; 
        private string method;
        public XDocument Envelope() => 
            new (
                new XDeclaration("1.0", "utf-8", string.Empty),
                new XElement(soapenv + "Envelope",
                    new XAttribute(XNamespace.Xmlns + nameof(soapenv), soapenv),
                    new XAttribute(XNamespace.Xmlns + nameof(srv), srv),
                    new XElement(soapenv + "Header"),
                    new XElement(soapenv + "Body",
                        new XElement(srv + method,
                            parameters))));               

        public SoapEnvelopeBuilder InCodeunit(string codeunit)
        {
            srv = $"urn:microsoft-dynamics-schemas/codeunit/{codeunit}";
            return this;
        }

        public SoapEnvelopeBuilder InPage(string page)
        {
            srv = $"urn:microsoft-dynamics-schemas/page/{page}";
            return this;
        }

        public SoapEnvelopeBuilder CallMethod(string value)
        {
            method = value;
            return this;
        }

        public SoapEnvelopeBuilder WithParameter(string name, Func<string, string> value)
        {
            parameters.Add(new XElement(srv + name, value));
            return this;
        }

        public SoapEnvelopeBuilder AndParameter(string name, Func<string, string> value) =>
            WithParameter(name, value);
    }
}
