using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    internal class XmlOldBase
    {
        #region private fields

        protected SelfManagedXmlElement rootElement;
        protected SelfManagedXmlElement configElement;

        #endregion

        #region constructors

        public XmlOldBase()
        {
            rootElement = new SelfManagedXmlElement("applicationSetting");
        }

        #endregion

        #region public methods

        public void LoadConfig(XmlDocument xmlDoc)
        {
            rootElement.ReadTree(xmlDoc);
        }

        public void SaveConfig(XmlDocument xmlDoc)
        {
            rootElement.WriteTree(xmlDoc);
        }

        #endregion
    }
}
