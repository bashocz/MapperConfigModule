using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldGenesis : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private StringXmlElement linkQueryElement;
        private IntegerXmlElement timeoutElement;

        #endregion

        #region constructors

        public XmlOldGenesis()
        {
            configElement = new SelfManagedXmlElement("Genesis");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("CheckinThroughGenesis", false);
            configElement.AddChild(enabledElement);

            linkQueryElement = new StringXmlElement("LinkQuery", string.Empty);
            configElement.AddChild(linkQueryElement);

            timeoutElement = new IntegerXmlElement("Timeout", 100);
            configElement.AddChild(timeoutElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public string LinkQuery
        {
            get { return linkQueryElement.Value; }
            set { linkQueryElement.Value = value; }
        }

        public int Timeout
        {
            get { return timeoutElement.Value; }
            set { timeoutElement.Value = value; }
        }

        #endregion
    }
}
