using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class ProbeInTempConfigData : BaseConfigData<ProbeInTempConfigData>
    {
        #region private fields

        private bool askForTemperature;
        private double defaultTemperature;
        private bool probeInTemperatures;
        private bool engineerMode;
        private int replaceBinValue;

        #endregion

        #region constructor

        public ProbeInTempConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            askForTemperature = false;
            defaultTemperature = 25;
            probeInTemperatures = false;
            engineerMode = false;
            replaceBinValue = 100;
        }

        #endregion

        #region public properties

        public bool AskForTemperature
        {
            get { return askForTemperature; }
            set { SetValue(ref askForTemperature, value); }
        }

        public double DefaultTemperature
        {
            get { return defaultTemperature; }
            set { SetValue(ref defaultTemperature, value); }
        }

        public bool ProbeInTemperatures
        {
            get { return probeInTemperatures; }
            set { SetValue(ref probeInTemperatures, value); }
        }

        public bool EngineerMode
        {
            get { return engineerMode; }
            set { SetValue(ref engineerMode, value); }
        }

        public int ReplaceBinValue
        {
            get { return replaceBinValue; }
            set { SetValue(ref replaceBinValue, value); }
        }

        public Bin ReplaceBin
        {
            get { return new Bin(replaceBinValue, false, false, true); }
        }

        #endregion
    }
}
