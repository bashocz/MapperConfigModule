using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    internal class XmlOldTester : XmlOldBase
    {
        #region private fields

        private StringXmlElement activeTesterElement;
        private IntegerXmlElement testerTimeoutElement;
        private BooleanXmlElement simulatorEnabledElement;

        #endregion

        #region constructors

        public XmlOldTester()
        {
            configElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(configElement);

            activeTesterElement = new StringXmlElement("ActiveTester", string.Empty);
            configElement.AddChild(activeTesterElement);

            testerTimeoutElement = new IntegerXmlElement("TesterTimeout", 30);
            configElement.AddChild(testerTimeoutElement);

            simulatorEnabledElement = new BooleanXmlElement("TesterSimulatorEnabled", false);
            configElement.AddChild(simulatorEnabledElement);
        }

        #endregion

        #region public properties

        public string ActiveTester
        {
            get { return activeTesterElement.Value; }
            set { activeTesterElement.Value = value; }
        }

        public int Timeout
        {
            get { return testerTimeoutElement.Value; }
            set { testerTimeoutElement.Value = value; }
        }

        public bool SimulatorEnabled
        {
            get { return simulatorEnabledElement.Value; }
            set { simulatorEnabledElement.Value = value; }
        }

        #endregion
    }
}
