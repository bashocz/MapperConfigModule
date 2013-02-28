using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class GenesisConfigData : BaseConfigData<GenesisConfigData>
    {
        #region private fields

        private bool enabled;

        #endregion

        #region constructor

        public GenesisConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        #endregion
    }
}
