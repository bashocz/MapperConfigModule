using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    internal class XmlBase
    {
        #region private fields

        protected SelfManagedXmlElement rootElement;

        #endregion

        #region constructors

        public XmlBase(string rootName)
        {
            rootElement = new SelfManagedXmlElement(rootName);
        }

        #endregion

        #region public methods

        public bool LoadConfig(XmlDocument xmlDoc)
        {
            rootElement.ReadTree(xmlDoc);
            return !rootElement.IsTreeOutOfSync();
        }

        public void SaveConfig(XmlDocument xmlDoc)
        {
            rootElement.WriteTree(xmlDoc);
        }

        #endregion
    }
}
