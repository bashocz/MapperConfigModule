using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldIncompleteProbe : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement _enabledElement;
        private BooleanXmlElement _autoCompleteElement;

        #endregion

        #region constructors

        public XmlOldIncompleteProbe()
        {
            configElement = new SelfManagedXmlElement("IncompleteProbe");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            _enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(_enabledElement);

            _autoCompleteElement = new BooleanXmlElement("AutoComplete", false);
            configElement.AddChild(_autoCompleteElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return _enabledElement.Value; }
            set { _enabledElement.Value = value; }
        }

        public bool AutoComplete
        {
            get { return _autoCompleteElement.Value; }
            set { _autoCompleteElement.Value = value; }
        }

        #endregion
    }
}
