using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class FetConfigData : BaseConfigData<FetConfigData>
    {
        #region private fields

        private int boardNo;
        private bool enableSendingXYCoords;
        private GpibConfigData gpib;

        #endregion

        #region constructors

        public FetConfigData()
            : base()
        {
            gpib = new GpibConfigData();

            childList.Add(gpib as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            boardNo = 0;
            enableSendingXYCoords = true;

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        /// <summary>
        /// PIO-DIO board number.
        /// </summary>
        public int BoardNo
        {
            get { return boardNo; }
            set { SetValue(ref boardNo, value); }
        }

        /// <summary>
        /// If sending of X-Y coordinates to tester via GPIB is enabled or not.
        /// </summary>
        public bool EnableSendingXYCoords
        {
            get { return enableSendingXYCoords; }
            set { SetValue(ref enableSendingXYCoords, value); }
        }

        /// <summary>
        /// Sub configuration data for GPIB.
        /// </summary>
        public GpibConfigData Gpib
        {
            get { return gpib; }
        }

        #endregion
    }
}
