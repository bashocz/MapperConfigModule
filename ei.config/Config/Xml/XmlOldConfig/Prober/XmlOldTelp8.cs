using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldTelp8 : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement proberElement;
        private SelfManagedXmlElement probersElement;
        private SelfManagedXmlElement egElement;

        private XmlOldGpib gpibElement;

        #endregion

        #region constructors

        public XmlOldTelp8()
        {
            proberElement = new SelfManagedXmlElement("Prober");
            rootElement.AddChild(proberElement);

            probersElement = new SelfManagedXmlElement("Probers");
            proberElement.AddChild(probersElement);

            egElement = new SelfManagedXmlElement("TELP8");
            egElement.ClearAllChildren = true;
            probersElement.AddChild(egElement);

            gpibElement = new XmlOldGpib();
            egElement.AddChild(gpibElement.XmlNode);
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
