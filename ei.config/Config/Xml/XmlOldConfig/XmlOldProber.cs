using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    internal class XmlOldProber : XmlOldBase
    {
        #region private fields

        private StringXmlElement activeProberElement;
        private IntegerXmlElement proberTimeoutElement;
        private BooleanXmlElement simulatorEnabledElement;

        private BooleanXmlElement isProbeCleanEnabledElement;
        private IntegerXmlElement probeCleanCountElement;
        private BooleanXmlElement isProbeXyScrubElement;

        #endregion

        #region constructors

        public XmlOldProber()
        {
            configElement = new SelfManagedXmlElement("Prober");
            rootElement.AddChild(configElement);

            activeProberElement = new StringXmlElement("ActiveProber", string.Empty);
            configElement.AddChild(activeProberElement);

            proberTimeoutElement = new IntegerXmlElement("ProberTimeout", 30);
            configElement.AddChild(proberTimeoutElement);

            simulatorEnabledElement = new BooleanXmlElement("ProberSimulatorEnabled", false);
            configElement.AddChild(simulatorEnabledElement);

            isProbeCleanEnabledElement = new BooleanXmlElement("IsProbeCleanEnabled", false);
            configElement.AddChild(isProbeCleanEnabledElement);

            probeCleanCountElement = new IntegerXmlElement("ProbeCleanCount", 1000);
            configElement.AddChild(probeCleanCountElement);

            isProbeXyScrubElement = new BooleanXmlElement("IsProbeXyScrub", false);
            configElement.AddChild(isProbeXyScrubElement);
        }

        #endregion

        #region public properties

        public string ActiveProber
        {
            get { return activeProberElement.Value; }
            set { activeProberElement.Value = value; }
        }

        public int Timeout
        {
            get { return proberTimeoutElement.Value; }
            set { proberTimeoutElement.Value = value; }
        }

        public bool SimulatorEnabled
        {
            get { return simulatorEnabledElement.Value; }
            set { simulatorEnabledElement.Value = value; }
        }

        public bool IsProbeCleanEnabled
        {
            get { return isProbeCleanEnabledElement.Value; }
            set { isProbeCleanEnabledElement.Value = value; }
        }

        public int ProbeCleanCount
        {
            get { return probeCleanCountElement.Value; }
            set { probeCleanCountElement.Value = value; }
        }

        public bool IsProbeXyScrub
        {
            get { return isProbeXyScrubElement.Value; }
            set { isProbeXyScrubElement.Value = value; }
        }

        #endregion
    }
}
