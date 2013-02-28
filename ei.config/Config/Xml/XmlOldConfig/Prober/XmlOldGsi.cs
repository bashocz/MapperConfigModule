using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldGsi : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement proberElement;
        private SelfManagedXmlElement probersElement;
        private SelfManagedXmlElement gsiElement;

        private StringXmlElement waferMapDirElement;
        private XmlOldTcpIp tcpIpElement;

        #endregion

        #region constructors

        public XmlOldGsi()
        {
            proberElement = new SelfManagedXmlElement("Prober");
            rootElement.AddChild(proberElement);

            probersElement = new SelfManagedXmlElement("Probers");
            proberElement.AddChild(probersElement);

            gsiElement = new SelfManagedXmlElement("GSI");
            gsiElement.ClearAllChildren = true;
            probersElement.AddChild(gsiElement);

            waferMapDirElement = new StringXmlElement("WaferMapDir", "/usr/ctrims/wafdata/summary");
            gsiElement.AddChild(waferMapDirElement);

            tcpIpElement = new XmlOldTcpIp();
            gsiElement.AddChild(tcpIpElement.XmlNode);
        }

        #endregion

        #region public properties

        public string GsiWaferMapDir
        {
            get { return waferMapDirElement.Value; }
            set { waferMapDirElement.Value = value; }
        }

        public XmlOldTcpIp TcpIp
        {
            get { return tcpIpElement; }
        }

        #endregion
    }
}
