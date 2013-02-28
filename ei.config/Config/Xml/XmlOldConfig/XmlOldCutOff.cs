using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldCutOff : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enableCutOffElement;
        private BooleanXmlElement enableCutOffNotReachedElement;

        #endregion

        #region constructors

        public XmlOldCutOff()
        {
            configElement = new SelfManagedXmlElement("CutOff");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enableCutOffElement = new BooleanXmlElement("EnableCutOff", false);
            configElement.AddChild(enableCutOffElement);

            enableCutOffNotReachedElement = new BooleanXmlElement("EnableCutOffNotReached", false);
            configElement.AddChild(enableCutOffNotReachedElement);
        }

        #endregion

        #region public properties

        public bool EnableCutOff
        {
            get { return enableCutOffElement.Value; }
            set { enableCutOffElement.Value = value; }
        }

        public bool EnableCutOffNotReached
        {
            get { return enableCutOffNotReachedElement.Value; }
            set { enableCutOffNotReachedElement.Value = value; }
        }

        #endregion
    }
}
