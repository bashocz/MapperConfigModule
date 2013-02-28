using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldHp : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement keithleyElement;

        private XmlOldGpib gpibElement;

        #endregion

        #region constructors

        public XmlOldHp()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            keithleyElement = new SelfManagedXmlElement("Hp4092");
            testersElement.AddChild(keithleyElement);

            gpibElement = new XmlOldGpib();
            keithleyElement.AddChild(gpibElement.XmlNode);
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
