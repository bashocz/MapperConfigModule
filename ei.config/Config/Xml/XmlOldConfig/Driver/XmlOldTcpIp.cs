using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Universal config data for TCP-IP settings. It is usually used as part of another config data.
    /// </summary>
    public class XmlOldTcpIp
    {
        #region private fields

        private SelfManagedXmlNode xmlNode;

        private StringXmlElement hostNameElement;
        private IntegerXmlElement portElement;

        #endregion

        #region constructors

        public XmlOldTcpIp()
        {
            xmlNode = new SelfManagedXmlElement("TcpIp");

            hostNameElement = new StringXmlElement("Hostname", "localhost");
            xmlNode.AddChild(hostNameElement);

            portElement = new IntegerXmlElement("Port", 4000);
            xmlNode.AddChild(portElement);
        }

        #endregion

        #region properties

        public SelfManagedXmlNode XmlNode
        {
            get { return xmlNode; }
        }

        public string HostName
        {
            get { return hostNameElement.Value; }
            set { hostNameElement.Value = value; }
        }

        public int Port
        {
            get { return portElement.Value; }
            set { portElement.Value = value; }
        }

        #endregion
    }
}
