using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Universal config data for GPIB settings. It is usually used as part of another config data.
    /// </summary>
    public class GpibConfigData : BaseConfigData<GpibConfigData>
    {
        #region private fields

        private bool isController;
        private int boardIndex;
        private int boardPrimaryAddress;
        private int boardSecondaryAddress;
        private int devicePrimaryAddress;
        private int deviceSecondaryAddress;
        private double timeoutMilliseconds;
        private bool isEOI;
        private bool isEOS;
        private bool eightBitEOS;
        private byte eosChar;

        #endregion

        #region constructors

        public GpibConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            isController = true;
            boardIndex = 0;
            boardPrimaryAddress = 0;
            boardSecondaryAddress = 0;
            devicePrimaryAddress = 1;
            deviceSecondaryAddress = 0;
            timeoutMilliseconds = 100;
            isEOI = true;
            isEOS = false;
            eightBitEOS = false;
            eosChar = 0;
        }

        #endregion

        #region properties

        public bool IsController
        {
            get { return isController; }
            set { SetValue(ref isController, value); }
        }

        public int BoardIndex
        {
            get { return boardIndex; }
            set { SetValue(ref boardIndex, value); }
        }

        public int BoardPrimaryAddress
        {
            get { return boardPrimaryAddress; }
            set { SetValue(ref boardPrimaryAddress, value); }
        }

        public int BoardSecondaryAddress
        {
            get { return boardSecondaryAddress; }
            set { SetValue(ref boardSecondaryAddress, value); }
        }

        public int DevicePrimaryAddress
        {
            get { return devicePrimaryAddress; }
            set { SetValue(ref devicePrimaryAddress, value); }
        }

        public int DeviceSecondaryAddress
        {
            get { return deviceSecondaryAddress; }
            set { SetValue(ref deviceSecondaryAddress, value); }
        }

        public double TimeoutMilliseconds
        {
            get { return timeoutMilliseconds; }
            set { SetValue(ref timeoutMilliseconds, value); }
        }

        public bool IsEOI
        {
            get { return isEOI; }
            set { SetValue(ref isEOI, value); }
        }

        public bool IsEOS
        {
            get { return isEOS; }
            set { SetValue(ref isEOS, value); }
        }

        public bool EightBitEOS
        {
            get { return eightBitEOS; }
            set { SetValue(ref eightBitEOS, value); }
        }

        public byte EosChar
        {
            get { return eosChar; }
            set { SetValue(ref eosChar, value); }
        }

        #endregion
    }
}
