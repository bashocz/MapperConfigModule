using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class LotInfoConfigData : BaseConfigData<LotInfoConfigData>
    {
        #region private fields

		private string lotId;

        private List<string> parentLotIdList;

		private string deviceId;
		private string maskSet;
		private int pdpw;
		private bool trench2Lot;
		private bool externalLot;
		private bool hasLaserscribe;
        private string laserscribeMask;
        /// <summary>
        /// Representing string, against wich will be read laserscribe compared.
        /// </summary>
        private string laserscribeCheckString;

        private List<WaferInfo> waferInfoList;
        private List<AllowedAction> allowedActions;

        #endregion

        #region constructors

        public LotInfoConfigData()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
		    lotId =
		    deviceId =
		    maskSet = string.Empty;
		    pdpw = 0;
            trench2Lot =
            externalLot =
            hasLaserscribe = false;
            laserscribeMask = string.Empty;
            laserscribeCheckString = string.Empty;

            parentLotIdList = new List<string>();
            waferInfoList = new List<WaferInfo>();
            allowedActions = new List<AllowedAction>();
        }

        public void ClearWaferInfoList()
        {
            ClearList(waferInfoList);
        }

        public void AddToWaferInfoList(WaferInfo waferInfo)
        {
            for (int idx = 0; idx < waferInfoList.Count; idx++)
            {
                if (waferInfo.Index == waferInfoList[idx].Index)
                {
                    LogIt.Error("LotInfoConfigData.AddToWaferInfoList: WaferInfo = " + waferInfo.ToString() +
                        " can't be added to the list. Wafer with same index is already exist.");
                }
                if ((waferInfo.SlotIndex > 0) && (waferInfo.SlotIndex == waferInfoList[idx].SlotIndex))
                {
                    LogIt.Error("LotInfoConfigData.AddToWaferInfoList: WaferInfo = " + waferInfo.ToString() +
                        " can't be added to the list. Wafer with same slot index is already exist.");
                }
            }
            AddToList(waferInfoList, waferInfo);
        }

        public void AddRangeToWaferInfoList(List<WaferInfo> waferInfoRangeList)
        {
            //AddRangeToList(waferInfoList, waferInfoRangeList);
            // adding one by one to protect duplication
            for (int idx = 0; idx < waferInfoRangeList.Count; idx++)
                AddToWaferInfoList(waferInfoRangeList[idx]);
        }

        public void ClearParentLotIdList()
        {
            ClearList(parentLotIdList);
        }

        public void AddToParentLotIdList(string parentLotId)
        {
            AddToList(parentLotIdList, parentLotId);
        }

        public void AddRangeToParentLotIdList(List<string> parentLotIdRangeList)
        {
            AddRangeToList(parentLotIdList, parentLotIdRangeList);
        }

        public void ClearAllowedActionsList()
        {
            ClearList(allowedActions);
        }

        public void AddToAllowedActionsList(AllowedAction action)
        {
            AddToList(allowedActions, action);
        }

        public void AddRangeToAllowedActionsList(List<AllowedAction> allowedActionsRangeList)
        {
            AddRangeToList(allowedActions, allowedActionsRangeList);
        }

        #endregion

        #region properties

        public string LotId
        {
            get { return lotId; }
            set { SetValue(ref lotId, value); }
        }

        public IList<string> ParentLotIdList
        {
            get { return parentLotIdList.AsReadOnly(); }
        }

        public string DeviceId
        {
            get { return deviceId; }
            set { SetValue(ref deviceId, value); }
        }

        public string MaskSet
        {
            get { return maskSet; }
            set { SetValue(ref maskSet, value); }
        }

        public int Pdpw
        {
            get { return pdpw; }
            set { SetValue(ref pdpw, value); }
        }

        public bool Trench2Lot
        {
            get { return trench2Lot; }
            set { SetValue(ref trench2Lot, value); }
        }

        public bool ExternalLot
        {
            get { return externalLot; }
            set { SetValue(ref externalLot, value); }
        }

        public bool HasLaserscribe
        {
            get { return hasLaserscribe; }
            set { SetValue(ref hasLaserscribe, value); }
        }

        public string LaserscribeMask
        {
            get { return laserscribeMask; }
            set { SetValue(ref laserscribeMask, value); }
        }

        public string LaserscribeCheckString
        {
            get { return laserscribeCheckString; }
            set { SetValue(ref laserscribeCheckString, value); }
        }

        public IList<WaferInfo> WaferInfoList
        {
            get { return waferInfoList.AsReadOnly(); }
        }

        public IList<AllowedAction> AllowedActions
        {
            get { return allowedActions; }
            //set { AddRangeToList(allowedActions, value); }
        }

        #endregion
    }
}
