using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldReprobe : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private IntegerXmlElement numberOfReprobesElement;
        private BooleanXmlElement reprobeOnTheFlyElement;

        #endregion

        #region constructors

        public XmlOldReprobe()
        {
            configElement = new SelfManagedXmlElement("Reprobe");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(enabledElement);

            numberOfReprobesElement = new IntegerXmlElement("AutomaticReprobeNumberOfReprobes", 1);
            configElement.AddChild(numberOfReprobesElement);

            reprobeOnTheFlyElement = new BooleanXmlElement("ReprobeOnTheFly", false);
            configElement.AddChild(reprobeOnTheFlyElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public int NumberOfReprobes
        {
            get { return numberOfReprobesElement.Value; }
            set { numberOfReprobesElement.Value = value; }
        }

        public bool ReprobeOnTheFly
        {
            get { return reprobeOnTheFlyElement.Value; }
            set { reprobeOnTheFlyElement.Value = value; }
        }

        #endregion
    }
}
