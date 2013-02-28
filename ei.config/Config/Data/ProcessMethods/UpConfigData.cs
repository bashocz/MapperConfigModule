using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class UpConfigData : BaseConfigData<UpConfigData>
    {
        #region private fields

        private bool enabled;

        #endregion

        #region constructors

        public UpConfigData()
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
