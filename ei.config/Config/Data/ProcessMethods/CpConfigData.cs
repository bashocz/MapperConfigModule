using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class CpConfigData : BaseConfigData<CpConfigData>
    {
        #region private fields

        private bool enabled;
        private int stepX;
        private int stepY;
        private bool firstRowEnabled;
        private bool chessboardEnabled;

        // obsolete
        private bool singleFirstRowEnabled;
        private bool singleChessboardEnabled;
        private bool multiFirstRowEnabled;
        private bool multiChessboardEnabled;

        #endregion

        #region constructors

        public CpConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            stepX =
            stepY = 0;
            firstRowEnabled =
            chessboardEnabled = false;

            singleFirstRowEnabled =
            singleChessboardEnabled =
            multiFirstRowEnabled =
            multiChessboardEnabled = false;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public int StepX
        {
            get { return stepX; }
            set { SetValue(ref stepX, value); }
        }

        public int StepY
        {
            get { return stepY; }
            set { SetValue(ref stepY, value); }
        }

        public bool FirstRowEnabled
        {
            get { return firstRowEnabled; }
            set { SetValue(ref firstRowEnabled, value); }
        }

        public bool ChessboardEnabled
        {
            get { return chessboardEnabled; }
            set { SetValue(ref chessboardEnabled, value); }
        }

        public bool SingleFirstRowEnabled
        {
            get { return singleFirstRowEnabled; }
            set { SetValue(ref singleFirstRowEnabled, value); }
        }

        public bool SingleChessboardEnabled
        {
            get { return singleChessboardEnabled; }
            set { SetValue(ref singleChessboardEnabled, value); }
        }

        public bool MultiFirstRowEnabled
        {
            get { return multiFirstRowEnabled; }
            set { SetValue(ref multiFirstRowEnabled, value); }
        }

        public bool MultiChessboardEnabled
        {
            get { return multiChessboardEnabled; }
            set { SetValue(ref multiChessboardEnabled, value); }
        }

        #endregion
    }
}
