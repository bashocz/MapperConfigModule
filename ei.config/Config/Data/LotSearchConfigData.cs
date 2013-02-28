using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class LotSearchConfigData : BaseConfigData<LotSearchConfigData>
    {
        #region private fields

        private bool useLimitedLotSearch;
        private int daysBackward;

        #endregion

        #region constructor

        public LotSearchConfigData()
            : base() 
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            useLimitedLotSearch = false;
            daysBackward = 365;
        }

        #endregion

        #region properties

        public bool UseLimitedLotSearch
        {
            get { return useLimitedLotSearch; }
            set { SetValue(ref useLimitedLotSearch, value); }
        }

        public int DaysBackward
        {
            get { return daysBackward; }
            set { SetValue(ref daysBackward, value); }
        }

        #endregion
    }
}
