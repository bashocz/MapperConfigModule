using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class DtsConfigData : BaseConfigData<DtsConfigData>
    {
        #region private fields

        private TcpIpConfigData tcpIp;

        #endregion

        #region constructors

        public DtsConfigData()
            : base()
        {
            tcpIp = new TcpIpConfigData();

            childList.Add(tcpIp as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methdos

        public override void SetDefault()
        {
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
        }

        #endregion
    }
}
