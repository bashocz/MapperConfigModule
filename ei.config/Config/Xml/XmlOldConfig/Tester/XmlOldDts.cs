using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldDts : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement dtsElement;

        private XmlOldTcpIp tcpIpElement;

        #endregion

        #region constructors

        public XmlOldDts()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            dtsElement = new SelfManagedXmlElement("Dts2");
            dtsElement.ClearAllChildren = true;
            testersElement.AddChild(dtsElement);

            tcpIpElement = new XmlOldTcpIp();
            dtsElement.AddChild(tcpIpElement.XmlNode);
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
