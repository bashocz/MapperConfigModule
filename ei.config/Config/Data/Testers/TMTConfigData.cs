using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class TmtConfigData : BaseConfigData<TmtConfigData>
    {
        #region private fields

        private TcpIpConfigData tcpIp;
        private SerialPortConfigData serial;
        private TmtCommunicationType communicationType;
        private TmtCommandSet commandSet;

        #endregion

        #region constructors

        public TmtConfigData()
            : base()
        {                                 
            tcpIp = new TcpIpConfigData();
            childList.Add(tcpIp as IBaseConfigData);
            serial = new SerialPortConfigData();
            childList.Add(serial as IBaseConfigData);            
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            CommandSet = TmtCommandSet.ETI;
            CommunicationType = TmtCommunicationType.TCPIP;
            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        /// <summary>
        /// Sub configuration data for TCP/IP.
        /// </summary>
        public TcpIpConfigData TcpIp
        {
            get { return tcpIp; }
            set { tcpIp=value; }
        }
        /// <summary>
        /// The type of the communication used to communicate with a prober.
        /// </summary>
        public TmtCommunicationType CommunicationType
        {
            get { return communicationType; }
            set { SetEnumValue(ref communicationType, value); }
        }

        /// <summary>
        /// The set of commands used to control a prober.
        /// </summary>
        public TmtCommandSet CommandSet
        {
            get { return commandSet; }
            set { SetEnumValue(ref commandSet, value); }
        }
        /// <summary>
        /// Sub configuration data for serial port.
        /// </summary>
        public SerialPortConfigData Serial
        {
            get { return serial; }
            set { serial = value; }
        }
        #endregion
    }
}
