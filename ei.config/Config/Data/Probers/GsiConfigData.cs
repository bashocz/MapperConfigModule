using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class GsiConfigData : BaseConfigData<GsiConfigData>
    {
        #region private fields

        private string gsiWaferMapDir;
        private TcpIpConfigData tcpIp;

        #endregion

        #region constructors

        public GsiConfigData()
            : base()
        {
            tcpIp = new TcpIpConfigData();

            childList.Add(tcpIp as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            gsiWaferMapDir = "/usr/ctrims/wafdata/summary";

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        public string GsiWaferMapDir
        {
            get { return gsiWaferMapDir; }
            set { SetValue(ref gsiWaferMapDir, value); }
        }

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
