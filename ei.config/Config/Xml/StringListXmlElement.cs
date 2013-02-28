using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    /// <summary>
    /// XML representation of multiple <code>LotFilter</code> objects.
    /// </summary>
    public class StringListXmlElement : SelfManagedXmlNode
    {
        #region private fields

        private List<string> values;

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance with the given tag name.
        /// </summary>
        /// <param name="name">The name of XML tag which will contain lot filters.</param>
        public StringListXmlElement(string name)
            : base(name) { }

        #endregion

        #region public methods

        public override System.Xml.XmlNode WriteTo(XmlNode parent)
        {
            XmlElement stringsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (stringsElement != null)
            {
                parent.RemoveChild(stringsElement);
            }

            stringsElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(stringsElement);

            if (values != null)
            {
                foreach (string item in values)
                {
                    XmlElement itemElement = parent.OwnerDocument.CreateElement("Item");
                    itemElement.InnerText = item;
                    stringsElement.AppendChild(itemElement);
                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(XmlNode parent)
        {
            values = new List<string>();

            XmlElement stringsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (stringsElement != null)
            {
                XmlNodeList stringElements = stringsElement.SelectNodes("child::Item");

                foreach (XmlNode itemNode in stringElements)
                {
                    if (itemNode is XmlElement)
                    {
                        XmlElement stringElement = itemNode as XmlElement;
                        values.Add(stringElement.InnerText);
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
        public List<string> Values
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
