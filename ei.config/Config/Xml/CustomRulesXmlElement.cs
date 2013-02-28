using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class CustomRulesXmlElement : SelfManagedXmlNode
    {
        private List<ConsecutiveFailCustomRule> values;

        public CustomRulesXmlElement(string name)
            : base(name) { }

        public override System.Xml.XmlNode WriteTo(XmlNode parent)
        {
            XmlElement rulesElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (rulesElement != null)
            {
                parent.RemoveChild(rulesElement);
            }

            rulesElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(rulesElement);

            if (values != null)
            {
                foreach (ConsecutiveFailCustomRule rule in values)
                {
                    XmlElement ruleElement = parent.OwnerDocument.CreateElement("CustomRule");
                    rulesElement.AppendChild(ruleElement);

                    XmlAttribute enabledAttribute = parent.OwnerDocument.CreateAttribute("Enabled");
                    enabledAttribute.Value = rule.Enabled.ToString();
                    ruleElement.Attributes.Append(enabledAttribute);

                    XmlAttribute limitAttribute = parent.OwnerDocument.CreateAttribute("Limit");
                    limitAttribute.Value = rule.Threshold.ToString();
                    ruleElement.Attributes.Append(limitAttribute);

                    XmlElement binsElement = parent.OwnerDocument.CreateElement("Bins");
                    ruleElement.AppendChild(binsElement);

                    foreach (int bin in rule.BinList)
                    {
                        XmlElement binElement = parent.OwnerDocument.CreateElement("Bin");
                        binElement.InnerText = bin.ToString();
                        binsElement.AppendChild(binElement);
                    }

                    XmlElement messageElement = parent.OwnerDocument.CreateElement("UserMessage");
                    messageElement.InnerText = rule.Message;
                    ruleElement.AppendChild(messageElement);
                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(XmlNode parent)
        {
            values = new List<ConsecutiveFailCustomRule>();

            XmlElement rulesElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (rulesElement != null)
            {
                XmlNodeList ruleElements = rulesElement.SelectNodes("child::CustomRule");

                foreach (XmlNode ruleNode in ruleElements)
                {
                    if (ruleNode is XmlElement)
                    {
                        XmlElement ruleElement = ruleNode as XmlElement;                        

                        bool enabled = Boolean.Parse(ruleElement.Attributes.GetNamedItem("Enabled").Value);

                        int threshold = Int32.Parse(ruleElement.Attributes.GetNamedItem("Limit").Value);

                        List<int> bins = new List<int>();
                        XmlElement binsElement = ruleElement.SelectSingleNode("child::Bins") as XmlElement;
                        if (binsElement != null)
                        {
                            XmlNodeList binNodes = binsElement.SelectNodes("child::Bin");
                            foreach (XmlNode binNode in binNodes)
                            {
                                if (binNode is XmlElement)
                                {
                                    XmlElement binElement = binNode as XmlElement;
                                    bins.Add(Int32.Parse(binElement.InnerText));
                                }
                            }
                        }

                        XmlElement messageElement = ruleElement.SelectSingleNode("child::UserMessage") as XmlElement;
                        string message = string.Empty;
                        if (messageElement != null)
                        {
                            message = messageElement.InnerText;
                        }

                        ConsecutiveFailCustomRule rule = null;
                        if ((threshold > 0) && (bins.Count > 0))
                            rule = new ConsecutiveFailCustomRule(enabled, threshold, message, bins);

                        if (rule != null)
                            values.Add(rule);
                    }
                }
            }

            return null;
        }

        public override void AddChild(SelfManagedXmlNode child)
        {
            throw new InvalidOperationException("Can not add children to this type of node.");
        }

        public List<ConsecutiveFailCustomRule> Values
        {
            get { return values; } // TODO clone
            set
            {
                OutOfSync = true;
                this.values = value;
            } // TODO clone
        }
    }
}
