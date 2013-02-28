using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    /// <summary>
    /// XML representation of multiple <code>LaserscribeFormat</code> objects.
    /// </summary>
    public class LaserscribeFormatsXmlElement : SelfManagedXmlNode
    {
        #region private fields

        private List<LaserscribeFormat> values;

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance with the given tag name.
        /// </summary>
        /// <param name="name">The name of XML tag which will contain laserscribe formats.</param>
        public LaserscribeFormatsXmlElement(string name)
            : base(name) { }

        #endregion

        #region public methods

        public override System.Xml.XmlNode WriteTo(XmlNode parent)
        {
            XmlElement laserscribeFormatsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (laserscribeFormatsElement != null)
            {
                parent.RemoveChild(laserscribeFormatsElement);
            }

            laserscribeFormatsElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(laserscribeFormatsElement);

            if (values != null)
            {
                foreach (LaserscribeFormat laserscribeFormat in values)
                {
                    XmlElement formatElement = parent.OwnerDocument.CreateElement("LaserscribeFormat");
                    laserscribeFormatsElement.AppendChild(formatElement);

                    XmlAttribute enabledAttribute = parent.OwnerDocument.CreateAttribute("Enabled");
                    enabledAttribute.Value = laserscribeFormat.Enabled.ToString();
                    formatElement.Attributes.Append(enabledAttribute);

                    XmlAttribute maskAttribute = parent.OwnerDocument.CreateAttribute("Mask");
                    maskAttribute.Value = laserscribeFormat.Mask.ToString();
                    formatElement.Attributes.Append(maskAttribute);
                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(XmlNode parent)
        {
            values = new List<LaserscribeFormat>();

            XmlElement laserscribeFormatsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (laserscribeFormatsElement != null)
            {
                XmlNodeList formatElements = laserscribeFormatsElement.SelectNodes("child::LaserscribeFormat");

                foreach (XmlNode formatNode in formatElements)
                {
                    if (formatNode is XmlElement)
                    {
                        XmlElement formatElement = formatNode as XmlElement;
                        LaserscribeFormat laserscribeFormat = new LaserscribeFormat();

                        laserscribeFormat.Enabled = Boolean.Parse(formatElement.Attributes.GetNamedItem("Enabled").Value);

                        laserscribeFormat.Mask = formatElement.Attributes.GetNamedItem("Mask").Value;

                        values.Add(laserscribeFormat);
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
        /// List of laserscribe formats read or to be stored into XML.
        /// </summary>
        public List<LaserscribeFormat> Values
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
