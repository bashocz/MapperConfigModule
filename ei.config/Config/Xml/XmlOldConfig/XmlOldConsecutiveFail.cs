using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldConsecutiveFail : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private IntegerXmlElement limitElement;
        private BooleanXmlElement resetCounterElement;
        private CustomRulesXmlElement customRulesElement;

        #endregion

        #region constructors

        public XmlOldConsecutiveFail()
        {
            configElement = new SelfManagedXmlElement("ConsecutiveFail");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(enabledElement);

            limitElement = new IntegerXmlElement("Limit", 5);
            configElement.AddChild(limitElement);

            resetCounterElement = new BooleanXmlElement("ResetCounterOnEachRow", false);
            configElement.AddChild(resetCounterElement);

            customRulesElement = new CustomRulesXmlElement("CustomRules");
            configElement.AddChild(customRulesElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public int Limit
        {
            get { return limitElement.Value; }
            set { limitElement.Value = value; }
        }

        public bool ResetCounterOnEachRow
        {
            get { return resetCounterElement.Value; }
            set { resetCounterElement.Value = value; }
        }

        public List<ConsecutiveFailCustomRule> CustomRules
        {
            get { return customRulesElement.Values; }
            set { customRulesElement.Values = value; }
        }

        #endregion
    }
}
