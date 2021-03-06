using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldCheckin : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement canDisableSspElement;
        private BooleanXmlElement reverseOrderElement;
        private BooleanXmlElement uncheckWafersElement;
        private BooleanXmlElement operatorIdEnableElement;
        private BooleanXmlElement checkSetupEnabledElement;
        private IntegerXmlElement setupMinMatchLengthElement;

        #endregion

        #region constructors

        public XmlOldCheckin()
        {
            configElement = new SelfManagedXmlElement("Checkin");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            canDisableSspElement = new BooleanXmlElement("CanDisableSsp", false);
            configElement.AddChild(canDisableSspElement);

            reverseOrderElement = new BooleanXmlElement("ReverseOrder", false);
            configElement.AddChild(reverseOrderElement);

            uncheckWafersElement = new BooleanXmlElement("UncheckAllWafers", false);
            configElement.AddChild(uncheckWafersElement);

            operatorIdEnableElement = new BooleanXmlElement("OperatorIdEnabled", false);
            configElement.AddChild(operatorIdEnableElement);

            checkSetupEnabledElement = new BooleanXmlElement("CheckSetupName", false);
            configElement.AddChild(checkSetupEnabledElement);

            setupMinMatchLengthElement = new IntegerXmlElement("SetupMinimalMatchLength", 4);
            configElement.AddChild(setupMinMatchLengthElement);
        }

        #endregion

        #region public properties

        public bool CanDisableSsp
        {
            get { return canDisableSspElement.Value; }
            set { canDisableSspElement.Value = value; }
        }

        public bool UncheckWafers
        {
            get { return uncheckWafersElement.Value; }
            set { uncheckWafersElement.Value = value; }
        }

        public bool ReverseOrder
        {
            get { return reverseOrderElement.Value; }
            set { reverseOrderElement.Value = value; }
        }

        public bool OperatorIdEnable
        {
            get { return operatorIdEnableElement.Value; }
            set { operatorIdEnableElement.Value = value; }
        }

        public bool CheckSetup
        {
            get { return checkSetupEnabledElement.Value; }
            set { checkSetupEnabledElement.Value = value; }
        }

        public int SetupMinMatchLength
        {
            get { return setupMinMatchLengthElement.Value; }
            set { setupMinMatchLengthElement.Value = value; }
        }

        #endregion
    }
}
