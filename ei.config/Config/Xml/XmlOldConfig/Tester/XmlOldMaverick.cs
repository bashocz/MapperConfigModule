using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldMaverick : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement maverickElement;

        private XmlOldTcpIp tcpIpElement;

        #endregion

        #region constructors

        public XmlOldMaverick()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            maverickElement = new SelfManagedXmlElement("Maverick");
            maverickElement.ClearAllChildren = true;
            testersElement.AddChild(maverickElement);

            tcpIpElement = new XmlOldTcpIp();
            maverickElement.AddChild(tcpIpElement.XmlNode);
        }

        #endregion

        #region public properties

        public XmlOldTcpIp TcpIp
        {
            get { return tcpIpElement; }
        }

        #endregion
    }
}
