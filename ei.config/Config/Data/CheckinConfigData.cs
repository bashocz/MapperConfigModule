using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class CheckinConfigData : BaseConfigData<CheckinConfigData>
    {
        #region private fields

        private bool canDisableSsp;

        private bool canEditUp;
        private bool canEditSup;
        private bool canEditSp;        
        private bool canEditFp;
        private bool canEditSsp;

       

        private bool reverseOrder;
        private bool uncheckAllWafers;
        private bool loadBoardEnabled;
        private bool canEditFields;
        private bool operatorIdEnabled;
        private bool checkSetupEnabled;
        private int setupMinMatchLength;

        private bool probingEnabled;
        private bool reprobingEnabled;
        private bool inkingEnabled;
        private bool standardInkingEnabled;
        private bool controlMapInkingEnabled;
        private bool manualInkingEnabled;
        private bool externalInkingEnabled;
        private bool mapEditEnabled;
        private bool aoiEnabled;

        //
        

        #endregion

        #region constructor

        public CheckinConfigData()
            : base() 
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            canEditUp=false;
            canEditSup=false;
            canEditSp=false;
            canEditFp = false;
            canEditSsp = false;


            canDisableSsp=false;            
            reverseOrder = false;
            loadBoardEnabled = false;
            canEditFields = false;
            operatorIdEnabled = false;
            uncheckAllWafers = false;
            checkSetupEnabled = false;
            setupMinMatchLength = 4;

            probingEnabled = true;
            reprobingEnabled = true;
            inkingEnabled = true;
            standardInkingEnabled = true;
            controlMapInkingEnabled = true;
            manualInkingEnabled = false;
            externalInkingEnabled = false;
            mapEditEnabled = false;
            aoiEnabled = false;
            
            canEditUp=true;
            canEditSup=true;
            canEditSp=true;        
            canEditFp=true;
            canEditSsp=true;
        }

        public override void CheckSetting(ConfigData configData)
        {
            base.CheckSetting(configData);

            // temporary changing the configuration
            probingEnabled = configData.General.SystemType == SystemType.Prober;
            reprobingEnabled = configData.General.SystemType == SystemType.Prober;

            inkingEnabled =
            standardInkingEnabled =
            controlMapInkingEnabled =
            manualInkingEnabled =
            externalInkingEnabled =
            mapEditEnabled =
            aoiEnabled = false;

            if ((configData.ProcessMethod.MapEdit.Enabled) || (configData.ProcessMethod.Aoi.GoodDieCounterEnabled))
            {
                mapEditEnabled = configData.ProcessMethod.MapEdit.Enabled;
                aoiEnabled = configData.ProcessMethod.Aoi.GoodDieCounterEnabled;
            }
            else
            {
                inkingEnabled = true;
                standardInkingEnabled = true;
                controlMapInkingEnabled = true;

            }
            // temporary changing the configuration
        }

        #endregion

        #region properties

        public bool CanDisableSsp
        {
            get { return canDisableSsp; }
            set { SetValue(ref canDisableSsp, value); }
        }

        public bool ReverseOrder
        {
            get { return reverseOrder; }
            set { SetValue(ref reverseOrder, value); }
        }

        public bool UncheckWafers
        {
            get { return uncheckAllWafers; }
            set { SetValue(ref uncheckAllWafers, value); }
        }

        public bool LoadBoardEnabled
        {
            get { return loadBoardEnabled; }
            set { SetValue(ref loadBoardEnabled, value); }
        }

        public bool CanEdit
        {
            get { return canEditFields; }
            set { SetValue(ref canEditFields, value); }
        }

        public bool OperatorIdEnabled
        {
            get { return operatorIdEnabled; }
            set { SetValue(ref operatorIdEnabled, value); }
        }

        public bool CheckSetupEnabled
        {
            get { return checkSetupEnabled; }
            set { SetValue(ref checkSetupEnabled, value); }
        }

        public int SetupMinMatchLength
        {
            get { return setupMinMatchLength; }
            set { SetValue(ref setupMinMatchLength, value); }
        }

        public bool ProbingEnabled
        {
            get { return probingEnabled; }
            set { SetValue(ref probingEnabled, value); }
        }

        public bool ReprobingEnabled
        {
            get { return reprobingEnabled; }
            set { SetValue(ref reprobingEnabled, value); }
        }

        public bool InkingEnabled
        {
            get { return inkingEnabled; }
            set { SetValue(ref inkingEnabled, value); }
        }

        public bool StandardInkingEnabled
        {
            get { return standardInkingEnabled; }
            set { SetValue(ref standardInkingEnabled, value); }
        }

        public bool ControlMapInkingEnabled
        {
            get { return controlMapInkingEnabled; }
            set { SetValue(ref controlMapInkingEnabled, value); }
        }

        public bool ManualInkingEnabled
        {
            get { return manualInkingEnabled; }
            set { SetValue(ref manualInkingEnabled, value); }
        }

        public bool ExternalInkingEnabled
        {
            get { return externalInkingEnabled; }
            set { SetValue(ref externalInkingEnabled, value); }
        }

        public bool MapEditEnabled
        {
            get { return mapEditEnabled; }
            set { SetValue(ref mapEditEnabled, value); }
        }

        public bool AoiEnabled
        {
            get { return aoiEnabled; }
            set { SetValue(ref aoiEnabled, value); }
        }
        public bool CanEditUp
        {
            get { return canEditUp; }
            set { SetValue(ref canEditUp, value); }
        }
        public bool CanEditSup
        {
            get { return canEditSup; }
            set { SetValue(ref canEditSup, value); }
        }
        public bool CanEditSp
        {
            get { return canEditSp; }
            set { SetValue(ref canEditSp, value); }
        }
        public bool CanEditFp
        {
            get { return canEditFp; }
            set { SetValue(ref canEditFp, value); }
        }
        public bool CanEditSsp
        {
            get { return canEditSsp; }
            set { SetValue(ref canEditSsp, value); }
        }
             
        #endregion
    }
}
