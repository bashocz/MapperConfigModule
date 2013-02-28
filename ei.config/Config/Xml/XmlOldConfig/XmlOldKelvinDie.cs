using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldKelvinDie : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private StringXmlElement kelvinDieBinsElement;
        private BooleanXmlElement reprobeFirstElement;

        #endregion

        #region constructors

        public XmlOldKelvinDie()
        {
            configElement = new SelfManagedXmlElement("KelvinDie");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enable", false);
            configElement.AddChild(enabledElement);

            kelvinDieBinsElement = new StringXmlElement("KelvinDieBins", "22");
            configElement.AddChild(kelvinDieBinsElement);

            reprobeFirstElement = new BooleanXmlElement("ReprobeFirst", false);
            configElement.AddChild(reprobeFirstElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public string KelvinDieBins
        {
            get { return kelvinDieBinsElement.Value; }
            set { kelvinDieBinsElement.Value = value; }
        }

        public bool ReprobeFirst
        {
            get { return reprobeFirstElement.Value; }
            set { reprobeFirstElement.Value = value; }
        }

        #endregion
    }
}
