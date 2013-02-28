using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldFpMethods : XmlOldBase
    {
        #region private fields

        private StartProcessMethodsXmlElement startProcessMethodsElement;
        private EndProcessMethodsXmlElement endProcessMethodsElement;
        private BooleanXmlElement enabledElement;

        #endregion

        #region constructors

        public XmlOldFpMethods()
        {
            configElement = new SelfManagedXmlElement("FpMethods");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(enabledElement);

            startProcessMethodsElement = new StartProcessMethodsXmlElement("StartProcessMethods");
            configElement.AddChild(startProcessMethodsElement);

            endProcessMethodsElement = new EndProcessMethodsXmlElement("EndProcessMethods");
            configElement.AddChild(endProcessMethodsElement);
        }

        #endregion

        #region public properties

        public List<ProcessMethod> StartProcessMethodsList
        {
            get { return startProcessMethodsElement.Values; }
            set { startProcessMethodsElement.Values = value; }
        }

        public List<ThresholdYield> EndProcessMethodsList
        {
            get { return endProcessMethodsElement.Values; }
            set { endProcessMethodsElement.Values = value; }
        }

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        #endregion
    }
}
