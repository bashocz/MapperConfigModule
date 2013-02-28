using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class MeConfigData : BaseConfigData<MeConfigData>
    {
        #region private fields

        private bool enabled;
        private int replaceBinValue;

        #endregion

        #region constructor

        public MeConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            replaceBinValue = 100;
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public int ReplaceBinValue
        {
            get { return replaceBinValue; }
            set { SetValue(ref replaceBinValue, value); }
        }

        public Bin ReplaceBin
        {
            get { return new Bin(replaceBinValue, false, true, false); }
        }

        #endregion
    }
}
