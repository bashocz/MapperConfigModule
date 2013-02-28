using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class PftConfigData : BaseConfigData<PftConfigData>
    {
        #region private fields

        private TcpIpConfigData tcpIp;

        #endregion

        #region constructors

        public PftConfigData()
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
            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        public TcpIpConfigData TcpIp
        {
            get { return tcpIp; }
        }

        #endregion
    }
}
