using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class SupConfigData : BaseConfigData<SupConfigData>
    {
        #region private fields

        private bool _enabled;
        private bool _neverTouchOutsideWafer;
        private int _maxTouchdownsOnDie;

        #endregion

        #region constructors

        public SupConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            _enabled = false;
            _neverTouchOutsideWafer = true;
            _maxTouchdownsOnDie = 3;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return _enabled; }
            set { SetValue(ref _enabled, value); }
        }

        public bool NeverTouchOutsideWafer
        {
            get { return _neverTouchOutsideWafer; }
            set { SetValue(ref _neverTouchOutsideWafer, value); }
        }

        public int MaxTouchdownsOnDie
        {
            get { return _maxTouchdownsOnDie; }
            set { SetValue(ref _maxTouchdownsOnDie, value); }
        }

        #endregion
    }
}
