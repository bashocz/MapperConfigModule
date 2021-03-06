using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    /// <summary>
    /// XML representation of multiple <code>LotFilter</code> objects.
    /// </summary>
    public class CulturesXmlElement : SelfManagedXmlNode
    {
        #region private fields

        private List<Culture> values;

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance with the given tag name.
        /// </summary>
        /// <param name="name">The name of XML tag which will contain lot filters.</param>
        public CulturesXmlElement(string name)
            : base(name) { }

        #endregion

        #region public methods

        public override System.Xml.XmlNode WriteTo(XmlNode parent)
        {
            XmlElement culturesElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (culturesElement != null)
            {
                parent.RemoveChild(culturesElement);
            }

            culturesElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(culturesElement);

            if (values != null)
            {
                foreach (Culture culture in values)
                {
                    XmlElement cultureElement = parent.OwnerDocument.CreateElement("Culture");
                    culturesElement.AppendChild(cultureElement);

                    XmlAttribute nameAttribute = parent.OwnerDocument.CreateAttribute("name");
                    nameAttribute.Value = culture.Name;
                    cultureElement.Attributes.Append(nameAttribute);

                    XmlAttribute codeAttribute = parent.OwnerDocument.CreateAttribute("code");
                    codeAttribute.Value = culture.Code;
                    cultureElement.Attributes.Append(codeAttribute);
                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(XmlNode parent)
        {
            values = new List<Culture>();

            XmlElement cuturesElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (cuturesElement != null)
            {
                XmlNodeList cultureElements = cuturesElement.SelectNodes("child::Culture");

                foreach (XmlNode lotNode in cultureElements)
                {
                    if (lotNode is XmlElement)
                    {
                        XmlElement lotElement = lotNode as XmlElement;

                        string cultureName = lotElement.Attributes.GetNamedItem("name").Value;
                        string cultureCode = lotElement.Attributes.GetNamedItem("code").Value;

                        Culture culture = new Culture(cultureName, cultureCode);

                        values.Add(culture);
                    }
                }
            }

            return null;
        }

        public override void AddChild(SelfManagedXmlNode child)
        {
            throw new InvalidOperationException("Can not add children to this type of node.");
        }

        #endregion

        #region public properties

        /// <summary>
        /// List of lot filters read or to be stored into XML.
        /// </summary>
        public List<Culture> Values
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
