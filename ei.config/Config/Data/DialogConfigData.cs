using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class DialogConfigData : BaseConfigData<DialogConfigData>
    {
        #region private fields

        private bool errorDialogContinueEnabled;

        private bool pauseDialogAfterWaferEnabled;
        private bool pauseDialogAfterWaferAutoRelease;

        #endregion

        #region constructor

        public DialogConfigData()
            : base() 
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            errorDialogContinueEnabled = false;

            pauseDialogAfterWaferEnabled = true;
            pauseDialogAfterWaferAutoRelease = true;
        }

        #endregion

        #region properties

        public bool ErrorDialogContinueEnabled
        {
            get { return errorDialogContinueEnabled; }
            set { SetValue(ref errorDialogContinueEnabled, value); }
        }

        public bool PauseDialogAfterWaferEnabled
        {
            get { return pauseDialogAfterWaferEnabled; }
            set { SetValue(ref pauseDialogAfterWaferEnabled, value); }
        }

        public bool PauseDialogAfterWaferAutoRelease
        {
            get { return pauseDialogAfterWaferAutoRelease; }
            set { SetValue(ref pauseDialogAfterWaferAutoRelease, value); }
        }

        #endregion
    }
}
