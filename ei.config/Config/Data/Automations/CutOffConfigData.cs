using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class CutoffConfigData : BaseConfigData<CutoffConfigData>
    {
        #region private fields

        private bool enabled;
        private bool notReachedEnabled;
        private int threshold;

        #endregion

        #region constructors

        public CutoffConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            notReachedEnabled = false;
            threshold = 0;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public bool NotReachedEnabled
        {
            get { return notReachedEnabled; }
            set { SetValue(ref notReachedEnabled, value); }
        }

        public int Threshold
        {
            get { return threshold; }
            set { SetValue(ref threshold, value); }
        }

        #endregion

    }
}
