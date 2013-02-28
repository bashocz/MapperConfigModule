using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldPft : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement pftElement;

        private XmlOldTcpIp tcpIpElement;

        #endregion

        #region constructors

        public XmlOldPft()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            pftElement = new SelfManagedXmlElement("PFT");
            pftElement.ClearAllChildren = true;
            testersElement.AddChild(pftElement);

            tcpIpElement = new XmlOldTcpIp();
            pftElement.AddChild(tcpIpElement.XmlNode);
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
