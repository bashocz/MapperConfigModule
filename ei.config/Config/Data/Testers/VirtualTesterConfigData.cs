using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class VirtualTesterConfigData : BaseConfigData<VirtualTesterConfigData>
    {
        #region private fields

        private int connectDelay;
        private int disconnectDelay;
        private int initDelay;
        private int startLotDelay;
        private int endLotDelay;
        private int startWaferDelay;
        private int endWaferDelay;
        private int probeDieDelay;
        private int probeDieFinishedDelay;
        private int getTestProgramNameDelay;
        private int getTemperatureDelay;

        private bool isRandom;
        private double yield;
        private bool isGrowing;
        private bool isInputWmxmlPath;
        private string inputWmxmlPath;

        #endregion

        #region constructors

        public VirtualTesterConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            connectDelay = 0;
            disconnectDelay = 0;
            initDelay = 1000;
            startLotDelay = 2000;
            endLotDelay = 0;
            startWaferDelay = 100;
            endWaferDelay = 100;
            probeDieDelay = 1;
            probeDieFinishedDelay = 0;
            getTestProgramNameDelay = 0;
            getTemperatureDelay = 0;

            isRandom = true;
            yield = 100;
            isGrowing = false;
            isInputWmxmlPath = false;
            inputWmxmlPath = "C:\\Mapper\\VirtualTester\\InputMaps";
        }

        #endregion

        #region properties

        public int ConnectDelay
        {
            get { return connectDelay; }
            set { SetValue(ref connectDelay, value); }
        }

        public int DisconnectDelay
        {
            get { return disconnectDelay; }
            set { SetValue(ref disconnectDelay, value); }
        }

        public int InitDelay
        {
            get { return initDelay; }
            set { SetValue(ref initDelay, value); }
        }

        public int StartLotDelay
        {
            get { return startLotDelay; }
            set { SetValue(ref startLotDelay, value); }
        }

        public int EndLotDelay
        {
            get { return endLotDelay; }
            set { SetValue(ref endLotDelay, value); }
        }

        public int StartWaferDelay
        {
            get { return startWaferDelay; }
            set { SetValue(ref startWaferDelay, value); }
        }

        public int EndWaferDelay
        {
            get { return endWaferDelay; }
            set { SetValue(ref endWaferDelay, value); }
        }

        public int ProbeDieDelay
        {
            get { return probeDieDelay; }
            set { SetValue(ref probeDieDelay, value); }
        }

        public int ProbeDieFinishedDelay
        {
            get { return probeDieFinishedDelay; }
            set { SetValue(ref probeDieFinishedDelay, value); }
        }

        public int GetTestProgramNameDelay
        {
            get { return getTestProgramNameDelay; }
            set { SetValue(ref getTestProgramNameDelay, value); }
        }

        public int GetTemperatureDelay
        {
            get { return getTemperatureDelay; }
            set { SetValue(ref getTemperatureDelay, value); }
        }

        public bool IsRandom
        {
            get { return isRandom; }
            set { SetValue(ref isRandom, value); }
        }

        public double Yield
        {
            get { return yield; }
            set { SetValue(ref yield, value); }
        }

        public bool IsGrowing
        {
            get { return isGrowing; }
            set { SetValue(ref isGrowing, value); }
        }

        public bool IsInputWmxmlPath
        {
            get { return isInputWmxmlPath; }
            set { SetValue(ref isInputWmxmlPath, value); }
        }

        public string InputWmxmlPath
        {
            get { return inputWmxmlPath; }
            set { SetValue(ref inputWmxmlPath, value); }
        }

        #endregion
    }
}
