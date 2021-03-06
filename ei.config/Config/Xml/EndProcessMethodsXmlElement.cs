using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class EndProcessMethodsXmlElement : SelfManagedXmlNode
    {

        #region private field

        private List<ThresholdYield> values;

        #endregion

        #region constructor

        public EndProcessMethodsXmlElement(string name)
            : base(name) { }

        #endregion

        #region public override methods

        public override System.Xml.XmlNode WriteTo(System.Xml.XmlNode parent)
        {
            XmlElement endProcessMethodsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (endProcessMethodsElement != null)
            {
                parent.RemoveChild(endProcessMethodsElement);
            }

            endProcessMethodsElement = parent.OwnerDocument.CreateElement(name);
            parent.AppendChild(endProcessMethodsElement);

            if (values != null)
            {
                foreach (ThresholdYield ty in values)
                {
                    XmlElement thresholdYieldElement = parent.OwnerDocument.CreateElement("ThresholdYield");
                    endProcessMethodsElement.AppendChild(thresholdYieldElement);

                    XmlAttribute yieldAttribute = parent.OwnerDocument.CreateAttribute("Yield");
                    yieldAttribute.Value = ty.YieldMax.ToString();
                    thresholdYieldElement.Attributes.Append(yieldAttribute);

                    //Methods for threshold yield
                    XmlElement endMethodElement = thresholdYieldElement.SelectSingleNode("child::EndMethod") as XmlElement;
                    if (endMethodElement != null)
                    {
                        thresholdYieldElement.RemoveChild(endMethodElement);
                    }

                    foreach (ProcessMethod method in ty.Methods)
                    {
                        endMethodElement = thresholdYieldElement.OwnerDocument.CreateElement("EndMethod");

                        endMethodElement.InnerText = method.MethodName;
                        thresholdYieldElement.AppendChild(endMethodElement);

                        XmlAttribute sequenceAttribute = thresholdYieldElement.OwnerDocument.CreateAttribute("Sequence");
                        sequenceAttribute.Value = method.Sequence.ToString();
                        endMethodElement.Attributes.Append(sequenceAttribute);
                    }

                }
            }

            return null;
        }

        public override System.Xml.XmlNode ReadFrom(System.Xml.XmlNode parent)
        {
            values = new List<ThresholdYield>();

            XmlElement endProcessMethodsElement = parent.SelectSingleNode("child::" + name) as XmlElement;
            if (endProcessMethodsElement != null)
            {
                XmlNodeList thresholdYieldElements = endProcessMethodsElement.SelectNodes("child::ThresholdYield");

                foreach (XmlNode thresholdYieldNode in thresholdYieldElements)
                {
                    if (thresholdYieldNode is XmlElement)
                    {
                        XmlElement thresholdYieldElement = thresholdYieldNode as XmlElement;
                        if (thresholdYieldElement != null)
                        {
                            //methods for Yield
                            XmlNodeList endMethodElements = thresholdYieldElement.SelectNodes("child::EndMethod");

                            List<ProcessMethod> methods = new List<ProcessMethod>();
                            foreach (XmlNode endMethodNode in endMethodElements)
                            {
                                if (endMethodNode is XmlElement)
                                {
                                    XmlElement endMethodElement = endMethodNode as XmlElement;
                                    if (endMethodElement != null)
                                        methods.Add(new ProcessMethod(GetIntegerAttribute(endMethodElement, "Sequence", 0), endMethodElement.InnerText));
                                }
                            }
                            methods.Sort(delegate(ProcessMethod a, ProcessMethod b)
                            {
                                return a.Sequence - b.Sequence;
                            });

                            values.Add(new ThresholdYield(GetIntegerAttribute(thresholdYieldElement, "Yield", 0), methods));
                        }
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

        public List<ThresholdYield> Values
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
