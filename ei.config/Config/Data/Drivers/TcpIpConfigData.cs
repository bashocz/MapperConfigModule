using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Universal config data for TCP-IP settings. It is usually used as part of another config data.
    /// </summary>
    public class TcpIpConfigData : BaseConfigData<TcpIpConfigData>
    {
        #region private fields

        private string hostName;
        private int port;
        //private readonly StringData hostName;
        //private readonly IntegerData port;

        #endregion

        #region constructors

        public TcpIpConfigData()
            : base()
        {
            hostName = "127.0.0.1";
            port = 4000;
            //hostName = new StringData("Hostname", "TCP/IP host name", "127.0.0.1");
            //port = new IntegerData("Port", "TCP/IP port", 4000);
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
        }

        #endregion

        #region properties

        public string HostName
        {
            get { return hostName; }
            set { SetValue(ref hostName, value); }
            //get { return hostName.Value; }
            //set
            //{
            //    string refHostName = hostName.Value;
            //    SetValue(ref refHostName, value);
            //    hostName.Value = refHostName;
            //}
        }

        public int Port
        {
            get { return port; }
            set { SetValue(ref port, value); }
            //get { return port.Value; }
            //set
            //{
            //    int refPort = port.Value;
            //    SetValue(ref refPort, value);
            //    port.Value = refPort;
            //}
        }

        #endregion
    }
}
