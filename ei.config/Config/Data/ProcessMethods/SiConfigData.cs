using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    // edge die inking
    public class SiConfigData : BaseConfigData<SiConfigData>
    {
        #region private fields

        private InkingMode mode;
        private ManualInkingMode manualMode;

        #endregion

        #region constructors

        public SiConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            mode = InkingMode.Standard;
            manualMode = ManualInkingMode.AllDice;
        }

        #endregion

        #region properties

        public InkingMode Mode
        {
            get { return mode; }
            set { SetEnumValue(ref mode, value); }
        }

        public ManualInkingMode ManualMode
        {
            get { return manualMode; }
            set { SetEnumValue(ref manualMode, value); }
        }

        #endregion
    }
}
