using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldEnvGeneral : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement autoCenterElement;
        private BooleanXmlElement drawCircleElement;
        private BooleanXmlElement drawGridElement;

        private BooleanXmlElement recoveryYieldElement;

        private StringXmlElement cultureNameElement;
        private CulturesXmlElement culturesElement;

        #endregion

        #region constructors

        public XmlOldEnvGeneral()
        {
            configElement = new SelfManagedXmlElement("EnvironmentGeneral");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            autoCenterElement = new BooleanXmlElement("AutoCenter", true);
            configElement.AddChild(autoCenterElement);

            drawCircleElement = new BooleanXmlElement("DrawCircle", true);
            configElement.AddChild(drawCircleElement);

            drawGridElement = new BooleanXmlElement("DrawGrid", true);
            configElement.AddChild(drawGridElement);

            recoveryYieldElement = new BooleanXmlElement("RecoveryYield", true);
            configElement.AddChild(recoveryYieldElement);

            cultureNameElement = new StringXmlElement("CultureName", "English");
            configElement.AddChild(cultureNameElement);

            culturesElement = new CulturesXmlElement("CultureList");
            configElement.AddChild(culturesElement);
        }

        #endregion

        #region public properties

        public bool AutoCenter
        {
            get { return autoCenterElement.Value; }
            set { autoCenterElement.Value = value; }
        }

        public bool DrawCircle
        {
            get { return drawCircleElement.Value; }
            set { drawCircleElement.Value = value; }
        }

        public bool DrawGrid
        {
            get { return drawGridElement.Value; }
            set { drawGridElement.Value = value; }
        }

        public bool RecoveryYield
        {
            get { return recoveryYieldElement.Value; }
            set { recoveryYieldElement.Value = value; }
        }

        public string CultureName
        {
            get { return cultureNameElement.Value; }
            set { cultureNameElement.Value = value; }
        }

        public List<Culture> CultureList
        {
            get { return culturesElement.Values; }
            set { culturesElement.Values = value; }
        }

        #endregion
    }
}
