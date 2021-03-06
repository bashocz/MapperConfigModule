using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class CustomScriptsXmlElement : SelfManagedXmlNode
    {
        private List<CustomScript> values;

        public CustomScriptsXmlElement(string name)
            : base(name) { }

        public override System.Xml.XmlNode WriteTo(XmlNode parent)
        {
            XmlElement scriptsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (scriptsElement != null)
            {
                parent.RemoveChild(scriptsElement);
            }

            scriptsElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(scriptsElement);

            if (values != null)
            {
                foreach (CustomScript script in values)
                {
                    XmlElement scriptElement = parent.OwnerDocument.CreateElement("CustomScript");
                    scriptsElement.AppendChild(scriptElement);

                    XmlAttribute enabledAttribute = parent.OwnerDocument.CreateAttribute("Enabled");
                    enabledAttribute.Value = script.Enabled.ToString();
                    scriptElement.Attributes.Append(enabledAttribute);

                    XmlElement processEventElement = parent.OwnerDocument.CreateElement("ProcessEvent");
                    processEventElement.InnerText = script.ProcessEvent.ToString();
                    scriptElement.AppendChild(processEventElement);

                    XmlElement commandElement = parent.OwnerDocument.CreateElement("Command");
                    commandElement.InnerText = script.Command;
                    scriptElement.AppendChild(commandElement);

                    XmlAttribute waitForCompletionAttribute = parent.OwnerDocument.CreateAttribute("WaitForCompletion");
                    waitForCompletionAttribute.Value = script.WaitForCompletion.ToString();
                    scriptElement.Attributes.Append(waitForCompletionAttribute);

                    XmlAttribute openInConsoleAttribute = parent.OwnerDocument.CreateAttribute("OpenInConsole");
                    openInConsoleAttribute.Value = script.OpenInConsole.ToString();
                    scriptElement.Attributes.Append(openInConsoleAttribute);
                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(XmlNode parent)
        {
            values = new List<CustomScript>();

            XmlElement scriptsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (scriptsElement != null)
            {
                XmlNodeList ruleElements = scriptsElement.SelectNodes("child::CustomScript");

                foreach (XmlNode ruleNode in ruleElements)
                {
                    if (ruleNode is XmlElement)
                    {
                        XmlElement scriptElement = ruleNode as XmlElement;
                        CustomScript script = new CustomScript();

                        script.Enabled = GetBooleanAttribute(scriptElement, "Enabled", true);

                        XmlElement processEventElement = scriptElement.SelectSingleNode("child::ProcessEvent") as XmlElement;
                        if (processEventElement != null)
                        {
                            script.ProcessEvent = (ProcessEvent)Enum.Parse(typeof(ProcessEvent), processEventElement.InnerText);
                        }

                        XmlElement commandElement = scriptElement.SelectSingleNode("child::Command") as XmlElement;
                        if (commandElement != null)
                        {
                            script.Command = commandElement.InnerText;
                        }

                        script.WaitForCompletion = GetBooleanAttribute(scriptElement, "WaitForCompletion", true);

                        script.OpenInConsole = GetBooleanAttribute(scriptElement, "OpenInConsole", true);

                        values.Add(script);
                    }
                }
            }

            return null;
        }

        public override void AddChild(SelfManagedXmlNode child)
        {
            throw new InvalidOperationException("Can not add children to this type of node.");
        }

        private bool GetBooleanAttribute(XmlElement element, string name, bool defaultValue)
        {
            XmlNode attribute = element.Attributes.GetNamedItem(name);
            if (attribute is XmlAttribute)
            {
                return Boolean.Parse((attribute as XmlAttribute).Value);
            }
            else
            {
                return defaultValue;
            }
        }

        public List<CustomScript> Values
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
