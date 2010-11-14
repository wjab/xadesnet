using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace XadesNetLib.Xml
{
    class XmlHelper
    {
        public static XmlElement CreateNodeIn(XmlDocument document, string nodeName, string nameSpace, XmlElement rootNode)
        {
            var result = document.CreateElement(nodeName, nameSpace);
            rootNode.AppendChild(result);
            return result;
        }
        public static XmlElement CreateNodeWithTextIn(XmlDocument document, string nodeName, string text, string nameSpace, XmlElement rootNode)
        {
            var newNode = CreateNodeIn(document, nodeName, nameSpace, rootNode);
            newNode.InnerText = text;
            return newNode;
        }

        public static string DateTimeToCanonicalRepresentation(DateTime ahora)
        {
            return ahora.Year.ToString("0000") + "-" + ahora.Month.ToString("00") +
                   "-" + ahora.Day.ToString("00") +
                   "T" + ahora.Hour.ToString("00") + ":" +
                   ahora.Minute.ToString("00") + ":" + ahora.Second.ToString("00") +
                   "Z";
        }
        public static string NowInCanonicalRepresentation()
        {
            var now = DateTime.Now.ToUniversalTime();
            return DateTimeToCanonicalRepresentation(now);
        }

        public static XmlElement FindNodeWithAttributeValueIn(XmlNodeList nodeList, string attributeName, string value)
        {
            if (nodeList.Count == 0) return null;
            foreach (XmlNode node in nodeList)
            {
                var nodeWithSameId = FindNodeWithAttributeValueIn(node, attributeName, value);
                if (nodeWithSameId != null) return nodeWithSameId;
            }
            return null;
        }

        private static XmlElement FindNodeWithAttributeValueIn(XmlNode node, string attributeName, string value)
        {
            var attributeValueInNode = GetAttributeValueInNodeOrNull(node, attributeName);
            if ((attributeValueInNode != null) && (attributeValueInNode.Equals(value))) return (XmlElement)node;
            return FindNodeWithAttributeValueIn(node.ChildNodes, attributeName, value);
        }

        private static string GetAttributeValueInNodeOrNull(XmlNode node, string attributeName)
        {
            var xmlAttributeCollection = node.Attributes;
            if (xmlAttributeCollection != null)
            {
                var attribute = xmlAttributeCollection[attributeName];
                if (attribute != null) return attribute.Value;
            }
            return null;
        }

        public static void ValidateFromSchemas(string inputPath, params XmlSchemaDescriptor[] schemas)
        {
            var xmlReader = new XmlTextReader(inputPath);

            var settings = new XmlReaderSettings { ProhibitDtd = false, ValidationType = ValidationType.Schema };
            settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;

            foreach (var xmlSchemaDescriptor in schemas)
            {
                settings.Schemas.Add(xmlSchemaDescriptor.Namespace, XmlReader.Create(xmlSchemaDescriptor.Path, settings));
                
            }
            using (var valReader = XmlReader.Create(xmlReader, settings))
            {
                while (valReader.Read()) { }
            }
        }

        public static XmlElement DescendantWith(XmlElement rootNode, Func<XmlElement, bool> conditionToComply)
        {
            return rootNode.ChildNodes.Cast<XmlElement>().FirstOrDefault(conditionToComply);
        }
        public static List<XmlElement> DescendantsWith(XmlElement rootNode, Func<XmlElement, bool> conditionToComply)
        {
            return rootNode.ChildNodes.Cast<XmlElement>().Where(conditionToComply).ToList();
        }

        public static List<XmlElement> FindNodesIn(XmlElement rootNode, string path)
        {
            var results = new List<XmlElement>();
            if (string.IsNullOrEmpty(path)) return results;
            if (!path.Contains("/")) return DescendantsWith(rootNode, n => path.Equals(n.Name));
            var token = path.Split('/')[0];
            var descendantsWithNameCorrect = DescendantsWith(rootNode, n => token.Equals(n.Name));
            if (descendantsWithNameCorrect.Count == 0) return results;
            foreach (var xmlElement in descendantsWithNameCorrect)
            {
                results.AddRange(FindNodesIn(xmlElement, path.Substring(token.Length + 1)));
            }
            return results;
        }

        public static XmlDocument ReadXmlFromUri(string uri)
        {
            var results = new XmlDocument();
            var reader = new XmlTextReader(uri);
            results.Load(reader);
            return results;
        }

        public static string AttributeOf(XmlElement node, string attributeName)
        {
            var xmlAttribute = node.Attributes[attributeName];
            return xmlAttribute == null ? null : xmlAttribute.Value;
        }
    }
}