using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class EpConfigData : BaseConfigData<EpConfigData>
    {
        #region private fields

        private bool enabled;
        private bool waferEdgeEnabled;
        private bool pcMarkEdgeEnabled;

        #endregion

        #region constructors

        public EpConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            waferEdgeEnabled = false;
            pcMarkEdgeEnabled = false;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public bool WaferEdgeEnabled
        {
            get { return waferEdgeEnabled; }
            set { SetValue(ref waferEdgeEnabled, value); }
        }

        public bool PcMarkEdgeEnabled
        {
            get { return pcMarkEdgeEnabled; }
            set { SetValue(ref pcMarkEdgeEnabled, value); }
        }

        #endregion
    }
}
