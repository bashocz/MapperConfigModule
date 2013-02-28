using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldKla1007 : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement proberElement;
        private SelfManagedXmlElement probersElement;
        private SelfManagedXmlElement klaElement;

        private XmlOldGpib gpibElement;

        #endregion

        #region constructors

        public XmlOldKla1007()
        {
            proberElement = new SelfManagedXmlElement("Prober");
            rootElement.AddChild(proberElement);

            probersElement = new SelfManagedXmlElement("Probers");
            proberElement.AddChild(probersElement);

            klaElement = new SelfManagedXmlElement("Kla1007");
            klaElement.ClearAllChildren = true;
            probersElement.AddChild(klaElement);

            gpibElement = new XmlOldGpib();
            klaElement.AddChild(gpibElement.XmlNode);
        }

        #endregion

        #region public properties

        public XmlOldGpib Gpib
        {
            get { return gpibElement; }
        }

        #endregion
    }
}
