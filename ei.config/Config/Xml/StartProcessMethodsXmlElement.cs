using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class StartProcessMethodsXmlElement : SelfManagedXmlNode
    {
        #region private field

        private List<ProcessMethod> values;

        #endregion

        #region constructor

        public StartProcessMethodsXmlElement(string name)
            : base(name) { }

        #endregion

        #region public override methods

        public override System.Xml.XmlNode WriteTo(System.Xml.XmlNode parent)
        {
            XmlElement startProcessMethodsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (startProcessMethodsElement != null)
            {
                parent.RemoveChild(startProcessMethodsElement);
            }

            startProcessMethodsElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(startProcessMethodsElement);

            if (values != null)
            {
                foreach (ProcessMethod method in values)
                {
                    XmlElement startMethodElement = parent.OwnerDocument.CreateElement("StartMethod");
                    startMethodElement.InnerText = method.MethodName;
                    startProcessMethodsElement.AppendChild(startMethodElement);

                    XmlAttribute sequenceAttribute = parent.OwnerDocument.CreateAttribute("Sequence");
                    sequenceAttribute.Value = method.Sequence.ToString();
                    startMethodElement.Attributes.Append(sequenceAttribute);

                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(System.Xml.XmlNode parent)
        {
            values = new List<ProcessMethod>();

            XmlElement startProcessMethodsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (startProcessMethodsElement != null)
            {
                XmlNodeList startMethodElements = startProcessMethodsElement.SelectNodes("child::StartMethod");

                foreach (XmlNode startMethodNode in startMethodElements)
                {
                    if (startMethodNode is XmlElement)
                    {
                        XmlElement startMethodElement = startMethodNode as XmlElement;
                        if (startMethodElement != null)
                            values.Add(new ProcessMethod(GetIntegerAttribute(startMethodElement, "Sequence", 0), startMethodElement.InnerText));
                    }
                }
            }

            return null;
        }

        #endregion

        #region private methods

        private int GetIntegerAttribute(XmlElement element, string name, int defaultValue)
        {
            XmlNode attribute = element.Attributes.GetNamedItem(name);
            if (attribute is XmlAttribute)
            {
                return Int32.Parse((attribute as XmlAttribute).Value);
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion

        #region public properties

        public List<ProcessMethod> Values
        {
            get { return values; } // TODO clone
            set
            {
                OutOfSync = true;
                this.values = value;
            } // TODO clone
        }

        #endregion
    }
}
