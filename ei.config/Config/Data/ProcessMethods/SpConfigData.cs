using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class SpConfigData : BaseConfigData<SpConfigData>
    {
        #region private fields

        private bool enabled;
        private bool spToUpEnabled;
        private int spToUpThreshold;

        #endregion

        #region constructors

        public SpConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            spToUpEnabled = false;
            spToUpThreshold = 0;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public bool SpToUpEnabled
        {
            get { return spToUpEnabled; }
            set { SetValue(ref spToUpEnabled, value); }
        }

        public int SpToUpThreshold
        {
            get { return spToUpThreshold; }
            set { SetValue(ref spToUpThreshold, value); }
        }

        #endregion
    }
}
