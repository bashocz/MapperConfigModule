using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldProbeInTemp : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement askForTemperatureElement;
        private DoubleXmlElement defaultTemperatureElement;
        private BooleanXmlElement probeInTemperaturesElement;
        private BooleanXmlElement engineerModeElement;
        private IntegerXmlElement replaceBinElement;

        #endregion

        #region constructors

        public XmlOldProbeInTemp()
        {
            configElement = new SelfManagedXmlElement("ProbeInTemperatures");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            askForTemperatureElement = new BooleanXmlElement("AskForTemperature", false);
            configElement.AddChild(askForTemperatureElement);

            defaultTemperatureElement = new DoubleXmlElement("DefaultTemperature", 25);
            configElement.AddChild(defaultTemperatureElement);

            probeInTemperaturesElement = new BooleanXmlElement("ProbeInTemperatures", false);
            configElement.AddChild(probeInTemperaturesElement);

            engineerModeElement = new BooleanXmlElement("EngineerMode", false);
            configElement.AddChild(engineerModeElement);

            replaceBinElement = new IntegerXmlElement("ReplaceBin", 100);
            configElement.AddChild(replaceBinElement);
        }

        #endregion

        #region public properties

        public bool AskForTemperature
        {
            get { return askForTemperatureElement.Value; }
            set { askForTemperatureElement.Value = value; }
        }

        public double DefaultTemperature
        {
            get { return defaultTemperatureElement.Value; }
            set { defaultTemperatureElement.Value = value; }
        }

        public bool ProbeInTemperatures
        {
            get { return probeInTemperaturesElement.Value; }
            set { probeInTemperaturesElement.Value = value; }
        }

        public bool EngineerMode
        {
            get { return engineerModeElement.Value; }
            set { engineerModeElement.Value = value; }
        }

        public int ReplaceBinValue
        {
            get { return replaceBinElement.Value; }
            set { replaceBinElement.Value = value; }
        }

        #endregion
    }
}
