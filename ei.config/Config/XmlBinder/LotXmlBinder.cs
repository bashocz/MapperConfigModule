using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    internal class LotXmlBinder : BaseXmlBinder
    {
        #region private methods

        private List<int> GetBinList(string binString)
        {
            List<int> binList = new List<int>();

            string[] binArray = binString.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string bin in binArray)
            {
                int binValue;
                if (int.TryParse(bin, out binValue))
                    binList.Add(binValue);
            }

            return binList;
        }

        private List<int> GetKelvinBinList(XmlDocument xmlDoc, string elementName)
        {
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName(elementName);
            List<int> binList = new List<int>();
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                binList = GetBinList((xmlNodeList.Item(0) as XmlElement).InnerText);
            return binList;
        }

        private LaserscribeFormat GetLaserscribeFormat(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Enabled");
            bool enabled = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                enabled = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Mask");
            string mask = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                mask = (xmlNodeList.Item(0) as XmlElement).InnerText;

            return new LaserscribeFormat(mask, enabled);
        }

        private List<LaserscribeFormat> GetLaserscribeFormatList(XmlDocument xmlDoc, string elementName)
        {
            List<LaserscribeFormat> laserscribeFormatList = new List<LaserscribeFormat>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement laserscribeFormatElement = node as XmlElement;
                    laserscribeFormatList.Add(GetLaserscribeFormat(laserscribeFormatElement, elementName));
                }
            }

            return laserscribeFormatList;
        }

        private LotFilter GetLotFilter(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Mask");
            string mask = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                mask = (xmlNodeList.Item(0) as XmlElement).InnerText;

            LotFilter lotFilter = new LotFilter(mask);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Checksum");
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                lotFilter.LaserscribesHaveSemiChecksum = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            return lotFilter;
        }

        private List<LotFilter> GetLotFilterList(XmlDocument xmlDoc, string elementName)
        {
            List<LotFilter> lotFilterList = new List<LotFilter>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement lotFilterElement = node as XmlElement;
                    lotFilterList.Add(GetLotFilter(lotFilterElement, elementName));
                }
            }

            return lotFilterList;
        }

        private MaskFormat GetMaskFormat(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Enabled");
            bool enabled = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                enabled = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Mask");
            string mask = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                mask = (xmlNodeList.Item(0) as XmlElement).InnerText;

            return new MaskFormat(mask, enabled);
        }

        private List<MaskFormat> GetMaskFormatList(XmlDocument xmlDoc, string elementName)
        {
            List<MaskFormat> maskFormatList = new List<MaskFormat>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement maskFormatElement = node as XmlElement;
                    maskFormatList.Add(GetMaskFormat(maskFormatElement, elementName));
                }
            }

            return maskFormatList;
        }

        private ConsecutiveFailCustomRule GetCustomRule(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Enabled");
            bool enabled = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                enabled = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Threshold");
            int threshold = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                threshold = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Message");
            string message = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                message = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "BinList");
            List<int> binList = null;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                binList = GetBinList((xmlNodeList.Item(0) as XmlElement).InnerText);

            if ((threshold > 0) && (binList != null) && (binList.Count > 0))
                return new ConsecutiveFailCustomRule(enabled, threshold, message, binList);

            return null;
        }

        private List<ConsecutiveFailCustomRule> GetCustomRuleList(XmlDocument xmlDoc, string elementName)
        {
            List<ConsecutiveFailCustomRule> customRuleList = new List<ConsecutiveFailCustomRule>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement customRuleElement = node as XmlElement;
                    customRuleList.Add(GetCustomRule(customRuleElement, elementName));
                }
            }

            return customRuleList;
        }

        private Pass GetPass(XmlElement xmlElement)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName("PassItemId");
            string id = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                id = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName("PassItemPreviousList");
            List<int> previousBinList = null;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                previousBinList = GetBinList((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName("PassItemActualList");
            List<int> actualBinList = null;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                actualBinList = GetBinList((xmlNodeList.Item(0) as XmlElement).InnerText);

            if (!string.IsNullOrEmpty(id))
                return new Pass(id, previousBinList, actualBinList);
            return null;
        }

        private List<Pass> GetPassList(XmlDocument xmlDoc, string elementName)
        {
            List<Pass> passList = new List<Pass>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement passElement = node as XmlElement;
                    Pass pass = GetPass(passElement);
                    if (pass != null)
                        passList.Add(pass);
                }
            }

            return passList;
        }

        private WaferInfo GetWaferInfo(XmlElement xmlElement, string prefix, int defaultIndex)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Index");
            int index = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                index = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);
            if (index == 0)
                index = defaultIndex;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "SlotIndex");
            int slotIndex = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                slotIndex = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ParentLotId");
            string parentLotId = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                parentLotId = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ParentLotIdList");
            List<string> parentLotIdList = new List<string>();
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                parentLotIdList.AddRange(((xmlNodeList.Item(0) as XmlElement).InnerText).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ProbedCount");
            int probedCount = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                probedCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ReprobedCount");
            int reprobedCount = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                reprobedCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "SampledCount");
            int sampledCount = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                sampledCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "InkedCount");
            int inkedCount = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                inkedCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Laserscribe");
            string laserscribe = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                laserscribe = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Scrap");
            bool scrap = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                scrap = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            if (index > 0)
                return new WaferInfo(index, slotIndex, parentLotId, parentLotIdList, probedCount, reprobedCount, sampledCount, inkedCount, laserscribe, scrap);
            return null;
        }

        private List<WaferInfo> GetWaferInfoList(XmlDocument xmlDoc, string elementName)
        {
            List<WaferInfo> waferInfoList = new List<WaferInfo>();

            int defIdx = 1;

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement waferInfoElement = node as XmlElement;
                    WaferInfo waferInfo = GetWaferInfo(waferInfoElement, elementName, defIdx);
                    if (waferInfo != null)
                    {
                        waferInfoList.Add(waferInfo);
                        defIdx++;
                    }
                }
            }

            return waferInfoList;
        }

        private AllowedAction GetAllowedActions(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ActionType");
            AllowedActionType actionType = AllowedActionType.None;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                actionType = (AllowedActionType)Enum.Parse(typeof(AllowedActionType), (xmlNodeList.Item(0) as XmlElement).InnerText, true);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ActionAllowed");
            //Needs to be allowed if it is not into configuration
            bool allowed = true;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                allowed = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Reason");
            string reason = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                reason = (xmlNodeList.Item(0) as XmlElement).InnerText;

            return new AllowedAction(actionType, allowed, reason);
        }

        private List<AllowedAction> GetAllowedActionsList(XmlDocument xmlDoc, string elementName)
        {
            List<AllowedAction> allowedActionsList = new List<AllowedAction>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement allowedActionElement = node as XmlElement;
                    AllowedAction alowedAction = GetAllowedActions(allowedActionElement, elementName);
                    allowedActionsList.Add(alowedAction);
                }
            }

            return allowedActionsList;
        }

        private ProcessMethod GetStartMethod(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Sequence");
            int sequence = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                sequence = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Name");

            string name = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                name = (xmlNodeList.Item(0) as XmlElement).InnerText;

            return new ProcessMethod(sequence, name);
        }

        private List<ProcessMethod> GetStartMethodList(XmlDocument xmlDoc, string elementName)
        {
            List<ProcessMethod> startMethodList = new List<ProcessMethod>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement startMethodElement = node as XmlElement;
                    ProcessMethod startMethod = GetStartMethod(startMethodElement, elementName);
                    startMethodList.Add(startMethod);
                }
            }

            return startMethodList;
        }

        private ThresholdYield GetThresholdYield(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Yield");
            int yield = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                yield = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Methods");

            string methodsStr = string.Empty;
            List<ProcessMethod> methods = new List<ProcessMethod>();
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
            {
                methodsStr = (xmlNodeList.Item(0) as XmlElement).InnerText;
                //Each method is separated by ';'
                string[] methodNames = methodsStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string method in methodNames)
                {
                    //Each method contains "sequence" and "method name". These properties are separated by ','.
                    string[] methodAttributes = method.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    int sequence = 0;
                    int.TryParse(methodAttributes[0], out sequence);
                    methods.Add(new ProcessMethod(sequence, methodAttributes[1]));
                }
            }

            return new ThresholdYield(yield, methods);
        }

        private List<ThresholdYield> GetThresholdYieldList(XmlDocument xmlDoc, string elementName)
        {
            List<ThresholdYield> thresholdYieldList = new List<ThresholdYield>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement thresholdYieldElement = node as XmlElement;
                    ThresholdYield ty = GetThresholdYield(thresholdYieldElement, elementName);
                    thresholdYieldList.Add(ty);
                }
            }

            return thresholdYieldList;
        }

        private void LoadPass(XmlDocument xmlDoc, PassConfigData configData)
        {
            configData.ClearPassList();
            configData.AddRangeToPassList(GetPassList(xmlDoc, "PassItem"));
        }

        private void LoadUp(XmlDocument xmlDoc, UpConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "UpEnabled", configData.Enabled);
        }

        private void LoadSup(XmlDocument xmlDoc, SupConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "SupEnabled", configData.Enabled);
            configData.NeverTouchOutsideWafer = GetBool(xmlDoc, "SupNeverTouchOutsideWafer", configData.NeverTouchOutsideWafer);
            configData.MaxTouchdownsOnDie = GetInt(xmlDoc, "SupMaxTouchdownsOnDie", configData.MaxTouchdownsOnDie);
        }

        private void LoadSp(XmlDocument xmlDoc, SpConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "SpEnabled", configData.Enabled);
            configData.SpToUpEnabled = GetBool(xmlDoc, "SpToUpEnabled", configData.SpToUpEnabled);
            configData.SpToUpThreshold = GetInt(xmlDoc, "SpToUpThreshold", configData.SpToUpThreshold);
        }

        private void LoadCp(XmlDocument xmlDoc, CpConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "CpEnabled", configData.Enabled);
            configData.StepX = GetInt(xmlDoc, "CpStepX", configData.StepX);
            configData.StepY = GetInt(xmlDoc, "CpStepY", configData.StepY);
            configData.FirstRowEnabled = GetBool(xmlDoc, "CpFirstRowEnabled", configData.FirstRowEnabled);
            // temporary - load the value again from smart sampling to match with it
            configData.FirstRowEnabled = GetBool(xmlDoc, "SspFirstRowEnabled", configData.FirstRowEnabled);
            configData.ChessboardEnabled = GetBool(xmlDoc, "CpChessboardEnabled", configData.ChessboardEnabled);
            // temporary - load the value again from smart sampling to match with it
            configData.ChessboardEnabled = GetBool(xmlDoc, "SspChessboardEnabled", configData.ChessboardEnabled);
        }

        private void LoadEp(XmlDocument xmlDoc, EpConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "EpEnabled", configData.Enabled);
            configData.WaferEdgeEnabled = GetBool(xmlDoc, "EpWaferEdgeEnabled", configData.WaferEdgeEnabled);
            configData.PcMarkEdgeEnabled = GetBool(xmlDoc, "EpPcMarkEdgeEnabled", configData.PcMarkEdgeEnabled);
        }

        private void LoadSsp(XmlDocument xmlDoc, SspConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "SspEnabled", configData.Enabled);
            configData.Mode = GetEnum(xmlDoc, "SspMode", configData.Mode);
            configData.Threshold = GetDouble(xmlDoc, "SspThreshold", configData.Threshold);
            configData.ThresholdLow = GetDouble(xmlDoc, "SspThresholdLow", configData.ThresholdLow);
            configData.ThresholdHigh = GetDouble(xmlDoc, "SspThresholdHigh", configData.ThresholdHigh);
            configData.StepX = GetInt(xmlDoc, "SspStepX", configData.StepX);
            configData.StepY = GetInt(xmlDoc, "SspStepY", configData.StepY);
            configData.FirstRowEnabled = GetBool(xmlDoc, "SspFirstRowEnabled", configData.FirstRowEnabled);
            configData.ChessboardEnabled = GetBool(xmlDoc, "SspChessboardEnabled", configData.ChessboardEnabled);
        }

        private void LoadFp(XmlDocument xmlDoc, FpConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "FpEnabled", configData.Enabled);
            configData.ClearStartMethodsList();
            configData.AddRangeStartMethodsList(GetStartMethodList(xmlDoc, "FlexibleProbeStartMethodItem"));
            configData.ClearEndMethodsList();
            configData.AddRangeEndMethodsList(GetThresholdYieldList(xmlDoc, "FlexibleProbeThresholdYieldItem"));
        }

        private void LoadMapEdit(XmlDocument xmlDoc, MeConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "MapEditProcessEnabled", configData.Enabled);
            configData.ReplaceBinValue = GetInt(xmlDoc, "MapEditProcessReplaceBin", configData.ReplaceBinValue);
        }

        private void LoadAoi(XmlDocument xmlDoc, AoiConfigData configData)
        {
            configData.GoodDieCounterEnabled = GetBool(xmlDoc, "AoiGoodDieCounterProcessEnabled", configData.GoodDieCounterEnabled);
        }

        private void LoadSi(XmlDocument xmlDoc, SiConfigData configData)
        {
            configData.Mode = GetEnum(xmlDoc, "InkingMode", configData.Mode);
            configData.ManualMode = GetEnum(xmlDoc, "ManualInkingMode", configData.ManualMode);
        }

        private void LoadEi(XmlDocument xmlDoc, EiConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "EiEnabled", configData.Enabled);
            configData.Mode = GetEnum(xmlDoc, "EiMode", configData.Mode);
            configData.NumberOfDie = GetInt(xmlDoc, "EiNumberOfDie", configData.NumberOfDie);
        }

        #endregion

        #region public methods

        public void LoadDialog(XmlDocument xmlDoc, DialogConfigData configData)
        {
            configData.ErrorDialogContinueEnabled = GetBool(xmlDoc, "ErrorDialogContinueEnabled", configData.ErrorDialogContinueEnabled);
            configData.PauseDialogAfterWaferEnabled = GetBool(xmlDoc, "PauseDialogAfterWaferEnabled", configData.PauseDialogAfterWaferEnabled);
            configData.PauseDialogAfterWaferAutoRelease = GetBool(xmlDoc, "PauseDialogAfterWaferAutomaticRelease", configData.PauseDialogAfterWaferAutoRelease);
        }

        public void LoadCheckin(XmlDocument xmlDoc, CheckinConfigData configData)
        {
            configData.CanDisableSsp = GetBool(xmlDoc, "CheckinCanDisableSsp", configData.CanDisableSsp);
            configData.ReverseOrder = GetBool(xmlDoc, "CheckinAutoreverseWaferOrder", configData.ReverseOrder);
            configData.UncheckWafers = GetBool(xmlDoc, "CheckinUncheckWafers", configData.UncheckWafers);
            configData.LoadBoardEnabled = GetBool(xmlDoc, "CheckinLoadBoardEnabled", configData.LoadBoardEnabled);
            configData.CanEdit = GetBool(xmlDoc, "CheckinCanEditFields", configData.CanEdit);

            configData.CanEditUp = GetBool(xmlDoc, "CheckinCanEditUp", configData.CanEditUp);
            configData.CanEditSup = GetBool(xmlDoc, "CheckinCanEditSup", configData.CanEditSup);
            configData.CanEditSp = GetBool(xmlDoc, "CheckinCanEditSp", configData.CanEditSp);
            configData.CanEditFp = GetBool(xmlDoc, "CheckinCanEditFp", configData.CanEditFp);
            configData.CanEditSsp = GetBool(xmlDoc, "CheckinCanEditSsp", configData.CanEditSsp);
                        
            configData.OperatorIdEnabled = GetBool(xmlDoc, "CheckinOperatorIdEnabled", configData.OperatorIdEnabled);
            configData.CheckSetupEnabled = GetBool(xmlDoc, "CheckinCheckSetupName", configData.CheckSetupEnabled);
            configData.SetupMinMatchLength = GetInt(xmlDoc, "CheckinSetupMinMatchLength", configData.SetupMinMatchLength);

            configData.ProbingEnabled = GetBool(xmlDoc, "CheckinProbingEnabled", configData.ProbingEnabled);
            configData.ReprobingEnabled = GetBool(xmlDoc, "CheckinReprobingEnabled", configData.ReprobingEnabled);
            configData.InkingEnabled = GetBool(xmlDoc, "CheckinInkingEnabled", configData.InkingEnabled);
            configData.StandardInkingEnabled = GetBool(xmlDoc, "CheckinStandardInkingEnabled", configData.StandardInkingEnabled);
            configData.ControlMapInkingEnabled = GetBool(xmlDoc, "CheckinControlMapInkingEnabled", configData.ControlMapInkingEnabled);
            configData.ManualInkingEnabled = GetBool(xmlDoc, "CheckinManualInkingEnabled", configData.ManualInkingEnabled);
            configData.ExternalInkingEnabled = GetBool(xmlDoc, "CheckinExternalInkingEnabled", configData.ExternalInkingEnabled);
            configData.MapEditEnabled = GetBool(xmlDoc, "CheckinMapEditEnabled", configData.MapEditEnabled);
            configData.AoiEnabled = GetBool(xmlDoc, "CheckinAoiEnabled", configData.AoiEnabled);
        }

        public void LoadProcessMethod(XmlDocument xmlDoc, ProcessMethodConfigData configData)
        {
            configData.ProcessMode = GetEnum(xmlDoc, "ProcessMode", configData.ProcessMode);
            configData.PauseAfterReprobeSpecific = GetBool(xmlDoc, "ProcessPauseAfterReprobeSpecific", configData.PauseAfterReprobeSpecific);

            LoadPass(xmlDoc, configData.Pass);

            LoadUp(xmlDoc, configData.UnitProbe);
            LoadSup(xmlDoc, configData.SmartUnitProbe);
            LoadSp(xmlDoc, configData.SampleProbe);
            LoadCp(xmlDoc, configData.ClassProbe);
            LoadEp(xmlDoc, configData.EdgeProbe);
            LoadSsp(xmlDoc, configData.SmartSampleProbe);
            LoadFp(xmlDoc, configData.FlexibleProbe);

            LoadMapEdit(xmlDoc, configData.MapEdit);
            LoadAoi(xmlDoc, configData.Aoi);

            LoadEi(xmlDoc, configData.EdgeInk);
            LoadSi(xmlDoc, configData.SmartInk);
        }

        public void LoadProbeInTemp(XmlDocument xmlDoc, ProbeInTempConfigData configData)
        {
            configData.DefaultTemperature = GetDouble(xmlDoc, "RitDefaultTemp", configData.DefaultTemperature);
            configData.AskForTemperature = GetBool(xmlDoc, "RitAskForTemp", configData.AskForTemperature);
            configData.ProbeInTemperatures = GetBool(xmlDoc, "RitProbeInTemp", configData.ProbeInTemperatures);
            configData.EngineerMode = GetBool(xmlDoc, "RitEngineerMode", configData.EngineerMode);
            configData.ReplaceBinValue = GetInt(xmlDoc, "RitReplaceBinValue", configData.ReplaceBinValue);
        }

        public void LoadLaserscribe(XmlDocument xmlDoc, LaserscribeConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoLaserscribeEnabled", configData.Enabled);
            configData.CheckLaserscibeWithDb = GetBool(xmlDoc, "AutoLaserscribeCheckAgainstDb", configData.CheckLaserscibeWithDb);
            configData.ChecksumEnabled = GetBool(xmlDoc, "AutoLaserscribeChecksumEnabled", configData.ChecksumEnabled);
            configData.CheckLotId = GetBool(xmlDoc, "AutoLaserscribeCheckLotId", configData.CheckLotId);
            configData.CheckWaferId = GetBool(xmlDoc, "AutoLaserscribeCheckWaferId", configData.CheckWaferId);
            configData.CheckLocationCode = GetBool(xmlDoc, "AutoLaserscribeCheckLocationCode", configData.CheckLocationCode);
            configData.CheckSerialNumber = GetBool(xmlDoc, "AutoLaserscribeCheckSerialNumber", configData.CheckSerialNumber);
            configData.ClearLaserscribeMaskList();
            configData.AddRangeToLaserscribeMaskList(GetMaskFormatList(xmlDoc, "AutoLaserscribeFormatItem"));
            configData.ClearLotIdMaskList();
            configData.AddRangeToLotIdMaskList(GetMaskFormatList(xmlDoc, "AutoLaserscribeLotIdFormatItem"));
        }

        public void LoadReprobe(XmlDocument xmlDoc, ReprobeConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoReprobeEnabled", configData.Enabled);
            configData.ReprobeOnTheFly = GetBool(xmlDoc, "AutoReprobeOnTheFlyEnabled", configData.ReprobeOnTheFly);
            configData.NumberOfReprobes = GetInt(xmlDoc, "AutoReprobeNumberOfReprobes", configData.NumberOfReprobes);
        }

        public void LoadConsecutiveFail(XmlDocument xmlDoc, ConsecutiveFailConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoConsecutiveFailEnabled", configData.Enabled);
            configData.Threshold = GetInt(xmlDoc, "AutoConsecutiveFailThreshold", configData.Threshold);
            configData.ResetCounterOnEachRow = GetBool(xmlDoc, "AutoConsecutiveFailResetCounter", configData.ResetCounterOnEachRow);
            configData.ClearCustomRuleList();
            configData.AddRangeToCustomRuleList(GetCustomRuleList(xmlDoc, "AutoConsecutiveFailCustomRuleItem"));
        }

        public void LoadCutoff(XmlDocument xmlDoc, CutoffConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoCutoffEnabled", configData.Enabled);
            configData.NotReachedEnabled = GetBool(xmlDoc, "AutoCutoffNotReachEnabled", configData.NotReachedEnabled);
            configData.Threshold = GetInt(xmlDoc, "AutoCutoffThreshold", configData.Threshold);
        }

        public void LoadKelvinDie(XmlDocument xmlDoc, KelvinDieConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoKelvinDieEnabled", configData.Enabled);
            configData.ReprobeFirst = GetBool(xmlDoc, "AutoKelvinDieReprobeFirst", configData.ReprobeFirst);
            configData.ClearBinList();
            configData.AddRangeToBinList(GetKelvinBinList(xmlDoc, "AutoKelvinDieBinList"));
        }

        public void LoadIncompleteProbe(XmlDocument xmlDoc, IncompleteProbeConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoIncompleteProbeEnabled", configData.Enabled);
            configData.AutoComplete = GetBool(xmlDoc, "AutoIncompleteProbeAutocomplete", configData.AutoComplete);
        }

        public void LoadShiftedAlignment(XmlDocument xmlDoc, ShiftedAlignmentConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "AutoShiftAlignmentEnabled", configData.Enabled);
            configData.Tolerance= GetDouble(xmlDoc, "AutoShiftAlignmentTolerance", configData.Tolerance);
        }

        public void LoadLotInfo(XmlDocument xmlDoc, LotInfoConfigData configData)
        {
            configData.LotId = GetString(xmlDoc, "LotInfoLotId", configData.LotId);
            configData.LaserscribeCheckString = GetString(xmlDoc, "LotInfoLaserScribeCheckString", configData.LaserscribeCheckString);
            configData.DeviceId = GetString(xmlDoc, "LotInfoDeviceId", configData.DeviceId);
            configData.MaskSet = GetString(xmlDoc, "LotInfoMaskSet", configData.MaskSet);
            configData.Pdpw = GetInt(xmlDoc, "LotInfoPdpw", configData.Pdpw);
            configData.Trench2Lot = GetBool(xmlDoc, "LotInfoTrench2Lot", configData.Trench2Lot);
            configData.ExternalLot = GetBool(xmlDoc, "LotInfoExternalLot", configData.ExternalLot);
            configData.HasLaserscribe = GetBool(xmlDoc, "LotInfoHasLaserscribe", configData.HasLaserscribe);
            configData.LaserscribeMask = GetString(xmlDoc, "LotInfoLaserscribeMask", configData.LaserscribeMask);
            configData.ClearWaferInfoList();
            configData.AddRangeToWaferInfoList(GetWaferInfoList(xmlDoc, "LotInfoWaferItem"));
            configData.ClearAllowedActionsList();
            configData.AddRangeToAllowedActionsList(GetAllowedActionsList(xmlDoc, "LotInfoAllowedActionItem"));
        }

        #endregion
    }
}
