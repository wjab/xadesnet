using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Xml;

namespace XadesNetLib.Common
{
    public class ExtendedSignedXml : SignedXml
    {
        public const string XmlDsigSignatureProperties = "http://www.w3.org/2000/09/xmldsig#SignatureProperties";
        public XmlElement PropertiesNode { get; set; }
        private readonly List<DataObject> _dataObjects = new List<DataObject>();

        public ExtendedSignedXml(XmlDocument document): base(document) {}

        public override XmlElement GetIdElement(XmlDocument doc, string id)
        {
            if (String.IsNullOrEmpty(id)) return null;

            var xmlElement = base.GetIdElement(doc, id);
            if (xmlElement != null) return xmlElement;

            if (_dataObjects.Count == 0) return null;
            foreach (var dataObject in _dataObjects)
            {
                var nodeWithSameId = XmlHelper.FindNodeWithAttributeValueIn(dataObject.Data, "Id", id);
                if (nodeWithSameId != null) return nodeWithSameId;
            }
            return null;
        }
        public new void AddObject(DataObject dataObject)
        {
            base.AddObject(dataObject);
            _dataObjects.Add(dataObject);
        }

        public const string XmlDSigTimestampNamespace = "http://xadesnet.codeplex.com/#timestamp";
    }
}