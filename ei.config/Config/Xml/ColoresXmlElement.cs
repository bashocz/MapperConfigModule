using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    /// <summary>
    /// XML representation of multiple <code>LotFilter</code> objects.
    /// </summary>
    public class ColoresXmlElement : SelfManagedXmlNode
    {
        #region private fields

        private List<DrawProperty> values;

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance with the given tag name.
        /// </summary>
        /// <param name="name">The name of XML tag which will contain lot filters.</param>
        public ColoresXmlElement(string name)
            : base(name) { }

        #endregion

        #region public methods

        public override System.Xml.XmlNode WriteTo(XmlNode parent)
        {
            XmlElement themesElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (themesElement != null)
            {
                parent.RemoveChild(themesElement);
            }

            themesElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(themesElement);

            if (values != null)
            {
                foreach (DrawProperty drawProperty in values)
                {
                    XmlElement drawPropertyElement = parent.OwnerDocument.CreateElement("param");
                    themesElement.AppendChild(drawPropertyElement);

                    XmlAttribute variableNameAttribute = parent.OwnerDocument.CreateAttribute("variableName");
                    variableNameAttribute.Value = drawProperty.VariableName;
                    drawPropertyElement.Attributes.Append(variableNameAttribute);

                    XmlAttribute nameAttribute = parent.OwnerDocument.CreateAttribute("name");
                    nameAttribute.Value = drawProperty.NameItem;
                    drawPropertyElement.Attributes.Append(nameAttribute);

                    XmlAttribute fontAttribute = parent.OwnerDocument.CreateAttribute("font");
                    fontAttribute.Value = drawProperty.Font.Name;
                    drawPropertyElement.Attributes.Append(fontAttribute);

                    XmlAttribute fontBoldAttribute = parent.OwnerDocument.CreateAttribute("bold");
                    fontBoldAttribute.Value = drawProperty.Font.Bold.ToString();
                    drawPropertyElement.Attributes.Append(fontBoldAttribute);

                    XmlAttribute fontSizeAttribute = parent.OwnerDocument.CreateAttribute("size");
                    fontSizeAttribute.Value = drawProperty.Font.Size.ToString();
                    drawPropertyElement.Attributes.Append(fontSizeAttribute);

                    XmlAttribute backColorAttribute = parent.OwnerDocument.CreateAttribute("backColor");
                    if (string.Compare(drawProperty.BackColor.Name.Substring(0, 2), "ff", true) != 0)
                        backColorAttribute.Value = drawProperty.BackColor.Name.ToString();
                    else
                        backColorAttribute.Value = "Custom;" + drawProperty.BackColor.R.ToString() + ";" + drawProperty.BackColor.G.ToString() + ";" + drawProperty.BackColor.B.ToString();
                    drawPropertyElement.Attributes.Append(backColorAttribute);

                    XmlAttribute foreColorAttribute = parent.OwnerDocument.CreateAttribute("foreColor");
                    if (string.Compare(drawProperty.ForeColor.Name.Substring(0, 2), "ff", true) != 0)
                        foreColorAttribute.Value = drawProperty.ForeColor.Name.ToString();
                    else
                        foreColorAttribute.Value = "Custom;" + drawProperty.ForeColor.R.ToString() + ";" + drawProperty.ForeColor.G.ToString() + ";" + drawProperty.ForeColor.B.ToString();
                    drawPropertyElement.Attributes.Append(foreColorAttribute);
                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(XmlNode parent)
        {
            values = new List<DrawProperty>();

            XmlElement themesElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (themesElement != null)
            {
                XmlNodeList drawPropertyElements = themesElement.SelectNodes("child::param");

                foreach (XmlNode drawPropertyNode in drawPropertyElements)
                {
                    if (drawPropertyNode is XmlElement)
                    {
                        XmlElement drawPropertyElement = drawPropertyNode as XmlElement;

                        string variableName = drawPropertyElement.Attributes.GetNamedItem("variableName").Value;
                        string nameItem = drawPropertyElement.Attributes.GetNamedItem("name").Value;
                        string fontName = drawPropertyElement.Attributes.GetNamedItem("font").Value;
                        bool fontBold = Convert.ToBoolean(drawPropertyElement.Attributes.GetNamedItem("bold").Value);
                        float fontSize = Convert.ToSingle(drawPropertyElement.Attributes.GetNamedItem("size").Value);
                        Font font;
                        if (fontBold)
                            font = new Font(fontName, fontSize, FontStyle.Bold);
                        else
                            font = new Font(fontName, fontSize, FontStyle.Regular);
                        string[] backColorStr = drawPropertyElement.Attributes.GetNamedItem("backColor").Value.Split(';');
                        Color backColor;
                        if (string.Compare(backColorStr[0], "Custom", true) != 0)
                            backColor = Color.FromName(backColorStr[0]);
                        else
                            backColor = Color.FromArgb(Convert.ToInt32(backColorStr[1]), Convert.ToInt32(backColorStr[2]), Convert.ToInt32(backColorStr[3]));
                        string[] foreColorStr = drawPropertyElement.Attributes.GetNamedItem("foreColor").Value.Split(';');
                        Color foreColor;
                        if (string.Compare(foreColorStr[0], "Custom", true) != 0)
                            foreColor = Color.FromName(foreColorStr[0]);
                        else
                            foreColor = Color.FromArgb(Convert.ToInt32(foreColorStr[1]), Convert.ToInt32(foreColorStr[2]), Convert.ToInt32(foreColorStr[3]));

                        DrawProperty drawProperty = new DrawProperty(variableName, nameItem, font, backColor, foreColor);

                        values.Add(drawProperty);
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
        public List<DrawProperty> Values
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
