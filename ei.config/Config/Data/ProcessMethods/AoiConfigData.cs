using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class AoiConfigData : BaseConfigData<AoiConfigData>
    {
        #region private fields

        private bool goodDieCounterEnabled;

        #endregion

        #region constructor

        public AoiConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            goodDieCounterEnabled = false;
        }

        #endregion

        #region public properties

        public bool GoodDieCounterEnabled
        {
            get { return goodDieCounterEnabled; }
            set { SetValue(ref goodDieCounterEnabled, value); }
        }

        #endregion
    }
}
