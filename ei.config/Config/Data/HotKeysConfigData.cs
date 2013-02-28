using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class HotKeysConfigData : BaseConfigData<HotKeysConfigData>
    {
        #region private field

        //Main dialog
        private HotKeysListData showCheckinDialogHK;
        private HotKeysListData showConfigDialogHK;
        private HotKeysListData showMainConfigDialogHK;
        private HotKeysListData pauseHK;
        private HotKeysListData setTowerlightsHK;
        private HotKeysListData manualSotHK;
        private HotKeysListData reprobeSelectedDieHK;
        private HotKeysListData moveLeftHK;
        private HotKeysListData moveRightHK;
        private HotKeysListData moveUpHK;
        private HotKeysListData moveDownHK;

        //pause dialog
        private HotKeysListData continueHK;
        private HotKeysListData stopHK;
        private HotKeysListData skipWaferHK;
        private HotKeysListData savePartialMapHK;

        //manual edit
        private HotKeysListData probe_InkHK;
        private HotKeysListData endManualEditHK;

        private List<HotKeysListData> hotKeysPropertyList;

        #endregion

        #region constructor

        public HotKeysConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            hotKeysPropertyList = new List<HotKeysListData>();
            //Main dialog
            showCheckinDialogHK = new HotKeysListData("Show checkin dialog", "ShowCheckinDialog", "Ctrl+Alt+C");
            hotKeysPropertyList.Add(showCheckinDialogHK);
            showConfigDialogHK = new HotKeysListData("Show configuration dialog", "ShowConfigDialog", "Ctrl+O");
            hotKeysPropertyList.Add(showConfigDialogHK);
            showMainConfigDialogHK = new HotKeysListData("Show main configuration dialog", "ShowMainConfigDialog", "Ctrl+S");
            hotKeysPropertyList.Add(showMainConfigDialogHK);
            pauseHK = new HotKeysListData("Show pause dialog", "ShowPauseDialog", "P");
            hotKeysPropertyList.Add(pauseHK);
            setTowerlightsHK = new HotKeysListData("Set tower lights", "SetTowerLights", "B");
            hotKeysPropertyList.Add(setTowerlightsHK);
            manualSotHK = new HotKeysListData("Manual start of lot", "ManualSot", "M");
            hotKeysPropertyList.Add(manualSotHK);
            reprobeSelectedDieHK = new HotKeysListData("Reprobe selected die", "ReprobeSelected", "R");
            hotKeysPropertyList.Add(reprobeSelectedDieHK);
            moveLeftHK = new HotKeysListData("Move cursor to the left", "MoveLeft", "Left");
            hotKeysPropertyList.Add(moveLeftHK);
            moveRightHK = new HotKeysListData("Move cursor to the right", "MoveRight", "Right");
            hotKeysPropertyList.Add(moveRightHK);
            moveUpHK = new HotKeysListData("Move cursor to the up", "MoveUp", "Up");
            hotKeysPropertyList.Add(moveUpHK);
            moveDownHK = new HotKeysListData("Move cursor to the down", "MoveDown", "Down");
            hotKeysPropertyList.Add(moveDownHK);
            //pause dialog
            continueHK = new HotKeysListData("Continue", "Continue", "Ctrl+G");
            hotKeysPropertyList.Add(continueHK);
            stopHK = new HotKeysListData("Stop process", "StopProcess", "Ctrl+Shift+Q");
            hotKeysPropertyList.Add(stopHK);
            skipWaferHK = new HotKeysListData("Skip wafer", "SkipWafer", "Ctrl+Shift+S");
            hotKeysPropertyList.Add(skipWaferHK);
            savePartialMapHK = new HotKeysListData("Save partial map", "SavePartialMap", "Ctrl+Shift+P");
            hotKeysPropertyList.Add(savePartialMapHK);
            //Manual edit
            probe_InkHK = new HotKeysListData("Manual probe/ink die", "Probe_InkDie", "Space");
            hotKeysPropertyList.Add(probe_InkHK);
            endManualEditHK = new HotKeysListData("End manual edit", "EndManualEdit", "E");
            hotKeysPropertyList.Add(endManualEditHK);

        }

        public void UpdateHotKeysList(List<HotKeysListData> hotKeyPropertyRangeList)
        {
            for (int newIdx = 0; newIdx < hotKeyPropertyRangeList.Count; newIdx++)
            {
                string newName = hotKeyPropertyRangeList[newIdx].HotKeyVariableName;
                for (int idx = 0; idx < hotKeysPropertyList.Count; idx++)
                {
                    string name = hotKeysPropertyList[idx].HotKeyVariableName;
                    if (string.Compare(newName, name) == 0)
                    {
                        if ((string.Compare(hotKeyPropertyRangeList[newIdx].HotKeyName, hotKeysPropertyList[idx].HotKeyName, true) != 0) ||
                            (string.Compare(hotKeyPropertyRangeList[newIdx].HotKeyVariableName, hotKeysPropertyList[idx].HotKeyVariableName, true) != 0) ||
                            (string.Compare(hotKeyPropertyRangeList[newIdx].HotKeyValue, hotKeysPropertyList[idx].HotKeyValue, true) != 0))
                        {
                            hotKeysPropertyList[idx].HotKeyName = hotKeyPropertyRangeList[newIdx].HotKeyName;
                            hotKeysPropertyList[idx].HotKeyVariableName = hotKeyPropertyRangeList[newIdx].HotKeyVariableName;
                            hotKeysPropertyList[idx].HotKeyValue = hotKeyPropertyRangeList[newIdx].HotKeyValue;
                        }
                    }
                }
            }
        }

        #endregion

        #region properties

        public string PauseHK
        {
            get { return pauseHK.HotKeyValue; }
        }

        public string SetTowerlightsHK
        {
            get { return setTowerlightsHK.HotKeyValue; }
        }

        public string ManualSotHK
        {
            get { return manualSotHK.HotKeyValue; }
        }

        public string ReprobeSelectedDieHK
        {
            get { return reprobeSelectedDieHK.HotKeyValue; }
        }

        public string ShowCheckinDialogHK
        {
            get { return showCheckinDialogHK.HotKeyValue; }
        }

        public string ShowConfigDialogHK
        {
            get { return showConfigDialogHK.HotKeyValue; }
        }

        public string ShowMainConfigDialogHK
        {
            get { return showMainConfigDialogHK.HotKeyValue; }
        }

        public string MoveLeftHK
        {
            get { return moveLeftHK.HotKeyValue; }
        }

        public string MoveRightHK
        {
            get { return moveRightHK.HotKeyValue; }
        }

        public string MoveUpHK
        {
            get { return moveUpHK.HotKeyValue; }
        }

        public string MoveDownHK
        {
            get { return moveDownHK.HotKeyValue; }
        }

        public string ContinueHK
        {
            get { return continueHK.HotKeyValue; }
        }

        public string StopHK
        {
            get { return stopHK.HotKeyValue; }
        }

        public string SkipWaferHK
        {
            get { return skipWaferHK.HotKeyValue; }
        }

        public string SavePartialMapHK
        {
            get { return savePartialMapHK.HotKeyValue; }
        }

        public string Probe_InkHK
        {
            get { return probe_InkHK.HotKeyValue; }
        }

        public string EndManualEditHK
        {
            get { return endManualEditHK.HotKeyValue; }
        }

        public IList<HotKeysListData> MainHotKeysPropertyList
        {
            get { return hotKeysPropertyList.AsReadOnly(); }
        }

        #endregion
    }
}
