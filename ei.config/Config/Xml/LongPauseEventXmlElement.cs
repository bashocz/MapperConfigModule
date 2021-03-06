﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    internal class LongPauseEventXmlElement : SelfManagedXmlNode
    {
        #region private field

        private List<LongPauseEventListData> values;

        #endregion
        
        #region constructors

        /// <summary>
        /// Creates new instance with the given tag name.
        /// </summary>
        /// <param name="name">The name of XML tag which will contain lot filters.</param>
        public LongPauseEventXmlElement(string name)
            : base(name) { }

        #endregion

        #region public methods

        public override System.Xml.XmlNode WriteTo(System.Xml.XmlNode parent)
        {
            XmlElement lpEventsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (lpEventsElement != null)
            {
                parent.RemoveChild(lpEventsElement);
            }

            lpEventsElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(lpEventsElement);

            if (values != null)
            {
                foreach (LongPauseEventListData lpEvent in values)
                {
                    XmlElement nameElement = parent.OwnerDocument.CreateElement("LpEvent");
                    lpEventsElement.AppendChild(nameElement);

                    XmlAttribute nameAttribute = parent.OwnerDocument.CreateAttribute("Name");
                    nameAttribute.Value = lpEvent.Name;
                    nameElement.Attributes.Append(nameAttribute);

                    XmlAttribute enambledAttribute = parent.OwnerDocument.CreateAttribute("Enabled");
                    enambledAttribute.Value = lpEvent.Enabled.ToString();
                    nameElement.Attributes.Append(enambledAttribute);

                    XmlAttribute reasonCodeAttribute = parent.OwnerDocument.CreateAttribute("ReasonCode");
                    reasonCodeAttribute.Value = lpEvent.ReasonCode.ToString();
                    nameElement.Attributes.Append(reasonCodeAttribute);

                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(System.Xml.XmlNode parent)
        {
            values = new List<LongPauseEventListData>();

            XmlElement lpEventsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (lpEventsElement != null)
            {
                XmlNodeList nameElements = lpEventsElement.SelectNodes("child::LpEvent");

                foreach (XmlNode nameNode in nameElements)
                {
                    if (nameNode is XmlElement)
                    {
                        XmlElement eventElement = nameNode as XmlElement;
                        LongPauseEventListData lpEvent = new LongPauseEventListData();

                        if (eventElement != null && eventElement is XmlElement)
                        {
                            lpEvent.Name = eventElement.Attributes.GetNamedItem("Name").Value;
                            lpEvent.Enabled = Boolean.Parse(eventElement.Attributes.GetNamedItem("Enabled").Value);
                            lpEvent.ReasonCode = Int32.Parse(eventElement.Attributes.GetNamedItem("ReasonCode").Value);

                            values.Add(lpEvent);
                        }

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
        public List<LongPauseEventListData> Values
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
