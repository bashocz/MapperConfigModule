using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldCustomScripts : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private CustomScriptsXmlElement customScriptsElement;

        #endregion

        #region constructors

        public XmlOldCustomScripts()
        {
            configElement = new SelfManagedXmlElement("CustomScripts");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(enabledElement);

            customScriptsElement = new CustomScriptsXmlElement("Scripts");
            configElement.AddChild(customScriptsElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public List<CustomScript> CustomScriptList
        {
            get { return customScriptsElement.Values; }
            set { customScriptsElement.Values = value; }
        }

        #endregion
    }
}
