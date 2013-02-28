using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace EI.Config
{
    internal class OldConfigXmlBinder
    {
        #region save private methods

        private void SaveGeneral(XmlDocument xmlDoc, GeneralConfigData generalConfigData, WmxmlConfigData wmxmlConfigData, DialogConfigData dialogConfigData)
        {
            XmlOldGeneral xmlGeneral = new XmlOldGeneral();

            xmlGeneral.LoginEnabled = generalConfigData.LoginEnabled;
            xmlGeneral.SystemType = generalConfigData.SystemType;
            xmlGeneral.LogLevel = generalConfigData.LogLevel;
            xmlGeneral.LongPauseEnabled = generalConfigData.LongPauseEnabled;
            xmlGeneral.LongPauseDelayTime = generalConfigData.LongPauseDelayTime;
            xmlGeneral.TowerLightEnabled = generalConfigData.TowerLightEnabled;
            xmlGeneral.TowerLightPort = generalConfigData.TowerLightPort;
            xmlGeneral.AlwaysSaveWaferMaps = wmxmlConfigData.AlwaysSaveWaferMaps;
            xmlGeneral.ErrorDialogContinueEnabled = dialogConfigData.ErrorDialogContinueEnabled;
            xmlGeneral.PauseDialogAfterWaferEnabled = dialogConfigData.PauseDialogAfterWaferEnabled;
            xmlGeneral.PauseDialogAfterWaferAutoRelease = dialogConfigData.PauseDialogAfterWaferAutoRelease;

            xmlGeneral.SaveConfig(xmlDoc);

            XmlOldDb xmlDb = new XmlOldDb();

            xmlDb.UseTrakLot = generalConfigData.UseTrakLot;

            xmlDb.SaveConfig(xmlDoc);
        }

        private void SaveEnvGeneral(XmlDocument xmlDoc, EnvGeneralConfigData configData)
        {
            XmlOldEnvGeneral xmlEnvGeneral = new XmlOldEnvGeneral();

            xmlEnvGeneral.AutoCenter = configData.AutoCenter;
            xmlEnvGeneral.DrawCircle = configData.DrawCircle;
            xmlEnvGeneral.DrawGrid = configData.DrawGrid;
            xmlEnvGeneral.RecoveryYield = configData.RecoveryYield;
            xmlEnvGeneral.CultureName = configData.CultureName;
            xmlEnvGeneral.CultureList = new List<Culture>(configData.CultureList);

            xmlEnvGeneral.SaveConfig(xmlDoc);
        }

        private void SaveColor(XmlDocument xmlDoc, ColorConfigData configData)
        {
            XmlOldColor xmlColor = new XmlOldColor();

            xmlColor.DrawPropertyList = new List<DrawProperty>(configData.DrawPropertyList);

            xmlColor.SaveConfig(xmlDoc);
        }

        private void SaveEvent(XmlDocument xmlDoc, EventConfigData configData)
        {
            XmlOldEvent xmlEvent = new XmlOldEvent();

            xmlEvent.Enabled = configData.Enabled;
            xmlEvent.WriteVerificationCount = configData.WriteVerificationCount;
            xmlEvent.SendingCount = configData.SendingCount;
            xmlEvent.EventDir = configData.EventDir;
            xmlEvent.RejectedEventDir = configData.RejectedEventDir;
            xmlEvent.LongPauseEvents = new List<LongPauseEventListData>(configData.LpEventConfigData.LongPauseEventPropertyList); 

            xmlEvent.SaveConfig(xmlDoc);
        }

        private void SaveDir(XmlDocument xmlDoc, DirConfigData dirConfigData, WmxmlConfigData wmxmlConfigData)
        {
            XmlOldDir xmlDir = new XmlOldDir();

            xmlDir.SetupDir = dirConfigData.SetupDir;
            xmlDir.LoggingDir = dirConfigData.LoggingDir;
            xmlDir.CacheDir = dirConfigData.CacheDir;
            xmlDir.WmxmlVersion = wmxmlConfigData.LocalWmxmlVersion;
            xmlDir.LocalFileFormat = wmxmlConfigData.LocalFileFormat;
            xmlDir.LocalOutputWmxmlEnabled = wmxmlConfigData.LocalOutputWmxmlEnabled;
            xmlDir.LocalWmxmlDir = wmxmlConfigData.LocalOutputWmxmlDir;
            xmlDir.LocalTempWmxmlDir = wmxmlConfigData.LocalTempWmxmlDir;
            xmlDir.LocalInputWmxmlEnabled = wmxmlConfigData.LocalInputWmxmlEnabled;
            xmlDir.LocalInputWmxmlDir = wmxmlConfigData.LocalInputWmxmlDir;
            xmlDir.SecsChangePassBin = wmxmlConfigData.SecsChangePassBin;
            xmlDir.SecsPassBin = wmxmlConfigData.SecsPassBin;
            xmlDir.LocalOutputSecsEnabled = wmxmlConfigData.LocalOutputSecsEnabled;
            xmlDir.LocalSecsDir = wmxmlConfigData.LocalOutputSecsDir;
            xmlDir.ServerFileFormat = wmxmlConfigData.ServerFileFormat;
            xmlDir.ServerOutputWmxmlEnabled = wmxmlConfigData.ServerOutputWmxmlEnabled;
            xmlDir.ServerOutputWmxmlDir = wmxmlConfigData.ServerOutputWmxmlDir;
            xmlDir.ServerUnsentWmxmlDir = wmxmlConfigData.ServerUnsentWmxmlDir;
            xmlDir.ServerInputWmxmlEnabled = wmxmlConfigData.ServerInputWmxmlEnabled;
            xmlDir.ServerInputWmxmlDir = wmxmlConfigData.ServerInputWmxmlDir;
            xmlDir.ServerOutputSecsEnabled = wmxmlConfigData.ServerOutputSecsEnabled;
            xmlDir.ServerOutputSecsDir = wmxmlConfigData.ServerOutputSecsDir;
            xmlDir.ServerUnsentSecsDir = wmxmlConfigData.ServerUnsentSecsDir;
            xmlDir.WebServiceFileFormat = wmxmlConfigData.VaultFileFormat;
            xmlDir.WebServiceOutputEnabled = wmxmlConfigData.VaultOutputEnabled;
            xmlDir.WebServiceInputEnabled = wmxmlConfigData.VaultInputEnabled;
            xmlDir.WebServicePrimaryUrl = wmxmlConfigData.WebServicePrimaryUrl;
            xmlDir.WebServiceSecondaryUrl = wmxmlConfigData.WebServiceSecondaryUrl;
            xmlDir.WebServiceUnsentWmxmlDir = wmxmlConfigData.VaultUnsentWmxmlDir;
            xmlDir.ExternalFileFormat = wmxmlConfigData.ExternalFileFormat;
            xmlDir.ExternalInputEnabled = wmxmlConfigData.ExternalInputEnabled;
            xmlDir.ExternalInputWmxmlDir = wmxmlConfigData.ExternalInputWmxmlDir;
            xmlDir.ExternalOutputEnabled = wmxmlConfigData.ExternalOutputEnabled;
            xmlDir.ExternalOutputWmxmlDir = wmxmlConfigData.ExternalOutputWmxmlDir;
            xmlDir.ExternalUnsentWmxmlDir = wmxmlConfigData.ExternalUnsentWmxmlDir;
            xmlDir.ManualCheckFileName = dirConfigData.ManualCheckFileName;
            xmlDir.ManualCheckLocalDir = dirConfigData.ManualCheckLocalDir;
            xmlDir.ManualCheckServerDir = dirConfigData.ManualCheckServerDir;

            xmlDir.SaveConfig(xmlDoc);
        }

        private void SaveGenesis(XmlDocument xmlDoc, GenesisConfigData configData)
        {
            XmlOldGenesis xmlGenesis = new XmlOldGenesis();

            xmlGenesis.Enabled = configData.Enabled;

            xmlGenesis.SaveConfig(xmlDoc);
        }

        private void SaveCheckin(XmlDocument xmlDoc, CheckinConfigData configData)
        {
            XmlOldCheckin xmlCheckin = new XmlOldCheckin();

            xmlCheckin.CanDisableSsp = configData.CanDisableSsp;
            xmlCheckin.ReverseOrder = configData.ReverseOrder;
            xmlCheckin.UncheckWafers = configData.UncheckWafers;
            xmlCheckin.OperatorIdEnable = configData.OperatorIdEnabled;
            xmlCheckin.CheckSetup = configData.CheckSetupEnabled;
            xmlCheckin.SetupMinMatchLength = configData.SetupMinMatchLength;

            xmlCheckin.SaveConfig(xmlDoc);
        }

        private void SaveLotSearch(XmlDocument xmlDoc, LotSearchConfigData configData)
        {
            XmlOldLotSearch xmlLotSearch = new XmlOldLotSearch();

            xmlLotSearch.UseLimitedLotSearch = configData.UseLimitedLotSearch;
            xmlLotSearch.DaysBackward = configData.DaysBackward;

            xmlLotSearch.SaveConfig(xmlDoc);
        }

        private void SaveMethods(XmlDocument xmlDoc, ProcessMethodConfigData configData)
        {
            XmlOldMethods xmlMethods = new XmlOldMethods();

            xmlMethods.IsSupNeverTouchOutsideWafer = configData.SmartUnitProbe.NeverTouchOutsideWafer;
            xmlMethods.SupMaxTouchdownsOnDie = configData.SmartUnitProbe.MaxTouchdownsOnDie;
            xmlMethods.IsAutoSpToUp = configData.SampleProbe.SpToUpEnabled;
            xmlMethods.IsEpWafer = configData.EdgeProbe.WaferEdgeEnabled;
            xmlMethods.IsEpPcMark = configData.EdgeProbe.PcMarkEdgeEnabled;
            xmlMethods.SspMode = configData.SmartSampleProbe.Mode;
            xmlMethods.IsSspSingleFirstRow = configData.SmartSampleProbe.SingleFirstRowEnabled;
            xmlMethods.IsCpSingleChessboard = configData.ClassProbe.SingleChessboardEnabled;
            xmlMethods.IsSspSingleChessboard = configData.SmartSampleProbe.SingleChessboardEnabled;
            xmlMethods.IsSspMultiFirstRow = configData.SmartSampleProbe.MultiFirstRowEnabled;
            xmlMethods.IsCpMultiChessboard = configData.ClassProbe.MultiChessboardEnabled;
            xmlMethods.IsSspMultiChessboard = configData.SmartSampleProbe.MultiChessboardEnabled;

            xmlMethods.IsAoiGoodDieCounter = configData.Aoi.GoodDieCounterEnabled;

            xmlMethods.SaveConfig(xmlDoc);

            XmlOldMapEdit xmlMapEdit = new XmlOldMapEdit();

            xmlMapEdit.EnableMapEdit = configData.MapEdit.Enabled;
            xmlMapEdit.ReplaceBinValue = configData.MapEdit.ReplaceBinValue;

            xmlMapEdit.SaveConfig(xmlDoc);

            XmlOldFpMethods xmlFpMethods = new XmlOldFpMethods();

            xmlFpMethods.Enabled = configData.FlexibleProbe.Enabled;
            xmlFpMethods.StartProcessMethodsList = new List<ProcessMethod>(configData.FlexibleProbe.StartMethods);
            xmlFpMethods.EndProcessMethodsList = new List<ThresholdYield>(configData.FlexibleProbe.EndMethods);

            xmlFpMethods.SaveConfig(xmlDoc);

        }

        private void SaveCustomScripts(XmlDocument xmlDoc, CustomScriptConfigData configData)
        {
            XmlOldCustomScripts xmlCustomScripts = new XmlOldCustomScripts();

            xmlCustomScripts.Enabled = configData.Enabled;
            xmlCustomScripts.CustomScriptList = new List<CustomScript>(configData.CustomScriptList);

            xmlCustomScripts.SaveConfig(xmlDoc);
        }

        private void SaveNewton(XmlDocument xmlDoc, NewtonConfigData configData)
        {
            XmlOldNewton xmlNewton = new XmlOldNewton();

            xmlNewton.Enabled = configData.Enabled;
            xmlNewton.NewtonFile = configData.NewtonFile;
            xmlNewton.NewtonMapDir = configData.WmxmlOutputDir;
            xmlNewton.StatusFile = configData.StatusFile;
            xmlNewton.Timeout = configData.Timeout;

            xmlNewton.SaveConfig(xmlDoc);
        }

        private void SaveRtm(XmlDocument xmlDoc, RtmConfigData configData)
        {
            XmlOldRtm xmlRtm = new XmlOldRtm();

            xmlRtm.Enabled = configData.Enabled;
            xmlRtm.RtmDir = configData.RtmDir;
            xmlRtm.AgentName = configData.AgentName;
            xmlRtm.AgentCmd = configData.AgentCmd;
            xmlRtm.WatchPeriod = configData.WatchPeriod;

            xmlRtm.SaveConfig(xmlDoc);
        }

        private void SaveProbeInTemp(XmlDocument xmlDoc, ProbeInTempConfigData configData)
        {
            XmlOldProbeInTemp xmlProbeInTemp = new XmlOldProbeInTemp();

            xmlProbeInTemp.AskForTemperature = configData.AskForTemperature;
            xmlProbeInTemp.DefaultTemperature = configData.DefaultTemperature;
            xmlProbeInTemp.ProbeInTemperatures = configData.ProbeInTemperatures;
            xmlProbeInTemp.EngineerMode = configData.EngineerMode;
            xmlProbeInTemp.ReplaceBinValue = configData.ReplaceBinValue;

            xmlProbeInTemp.SaveConfig(xmlDoc);
        }

        private void SaveConsecutiveFail(XmlDocument xmlDoc, ConsecutiveFailConfigData configData)
        {
            XmlOldConsecutiveFail xmlConsecutiveFail = new XmlOldConsecutiveFail();

            xmlConsecutiveFail.Enabled = configData.Enabled;
            xmlConsecutiveFail.Limit = configData.Threshold;
            xmlConsecutiveFail.ResetCounterOnEachRow = configData.ResetCounterOnEachRow;
            xmlConsecutiveFail.CustomRules = new List<ConsecutiveFailCustomRule>(configData.CustomRuleList);

            xmlConsecutiveFail.SaveConfig(xmlDoc);
        }

        private void SaveCutOff(XmlDocument xmlDoc, CutoffConfigData configData)
        {
            XmlOldCutOff xmlCutOff = new XmlOldCutOff();

            xmlCutOff.EnableCutOff = configData.Enabled;
            xmlCutOff.EnableCutOffNotReached = configData.NotReachedEnabled;

            xmlCutOff.SaveConfig(xmlDoc);
        }

        private void SaveKelvinDie(XmlDocument xmlDoc, KelvinDieConfigData configData)
        {
            XmlOldKelvinDie xmlKelvinDie = new XmlOldKelvinDie();

            xmlKelvinDie.Enabled = configData.Enabled;
            xmlKelvinDie.KelvinDieBins = configData.BinString;
            xmlKelvinDie.ReprobeFirst = configData.ReprobeFirst;

            xmlKelvinDie.SaveConfig(xmlDoc);
        }

        private void SaveLaserscribe(XmlDocument xmlDoc, LaserscribeConfigData configData)
        {
            XmlOldLaserscribe xmlLaserscribe = new XmlOldLaserscribe();

            xmlLaserscribe.Enabled = configData.Enabled;
            xmlLaserscribe.LaserscribeMatchingEnabled = configData.LaserscribeMatchingEnabled;
            xmlLaserscribe.LaserscribeFormats = new List<LaserscribeFormat>(configData.LaserscribeFormatList);
            xmlLaserscribe.LotsWithLaserscribesInDb = new List<LotFilter>(configData.LotFilterList);
            xmlLaserscribe.EnableUsingLaserscribeFromDB = configData.UsingLaserscribeFromDB;

            xmlLaserscribe.SaveConfig(xmlDoc);
        }

        private void SaveIncompleteProbe(XmlDocument xmlDoc, IncompleteProbeConfigData configData)
        {
            XmlOldIncompleteProbe xmlIncompleteProbe = new XmlOldIncompleteProbe();

            xmlIncompleteProbe.Enabled = configData.Enabled;
            xmlIncompleteProbe.AutoComplete = configData.AutoComplete;

            xmlIncompleteProbe.SaveConfig(xmlDoc);
        }

        private void SaveReprobe(XmlDocument xmlDoc, ReprobeConfigData configData)
        {
            XmlOldReprobe xmlReprobe = new XmlOldReprobe();

            xmlReprobe.Enabled = configData.Enabled;
            xmlReprobe.NumberOfReprobes = configData.NumberOfReprobes;
            xmlReprobe.ReprobeOnTheFly = configData.ReprobeOnTheFly;

            xmlReprobe.SaveConfig(xmlDoc);
        }

        private void SaveEg2001(XmlDocument xmlDoc, Eg2001ConfigData configData)
        {
            XmlOldEg2001 xmlEg2001 = new XmlOldEg2001();

            xmlEg2001.EnableManualMicroCoordsChange = configData.EnableManualMicroCoordsChange;
            
            xmlEg2001.Serial.PortName = configData.Serial.PortName;
            xmlEg2001.Serial.BaudRate = configData.Serial.BaudRate;
            xmlEg2001.Serial.Parity = configData.Serial.Parity;
            xmlEg2001.Serial.DataBits = configData.Serial.DataBits;
            xmlEg2001.Serial.StopBits = configData.Serial.StopBits;
            xmlEg2001.Serial.Separator = configData.Serial.Separator;

            xmlEg2001.SaveConfig(xmlDoc);
        }

        private void SaveEg4090(XmlDocument xmlDoc, Eg4090ConfigData configData)
        {
            XmlOldEg4090 xmlEg4090 = new XmlOldEg4090();

            xmlEg4090.SendProfileData = configData.SendProfileData;
            xmlEg4090.CommunicationType = configData.CommunicationType;
            
            xmlEg4090.Gpib.SystemController = configData.Gpib.IsController;
            xmlEg4090.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlEg4090.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlEg4090.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlEg4090.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlEg4090.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlEg4090.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlEg4090.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlEg4090.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlEg4090.Gpib.EosChar = configData.Gpib.EosChar;
            
            xmlEg4090.Serial.PortName = configData.Serial.PortName;
            xmlEg4090.Serial.BaudRate = configData.Serial.BaudRate;
            xmlEg4090.Serial.Parity = configData.Serial.Parity;
            xmlEg4090.Serial.DataBits = configData.Serial.DataBits;
            xmlEg4090.Serial.StopBits = configData.Serial.StopBits;
            xmlEg4090.Serial.Separator = configData.Serial.Separator;

            xmlEg4090.SaveConfig(xmlDoc);
        }

        private void SaveGsi(XmlDocument xmlDoc, GsiConfigData configData)
        {
            XmlOldGsi xmlGsi = new XmlOldGsi();

            xmlGsi.GsiWaferMapDir = configData.GsiWaferMapDir;
            xmlGsi.TcpIp.HostName = configData.TcpIp.HostName;
            xmlGsi.TcpIp.Port = configData.TcpIp.Port;

            xmlGsi.SaveConfig(xmlDoc);
        }

        private void SaveKla1007(XmlDocument xmlDoc, Kla1007ConfigData configData)
        {
            XmlOldKla1007 xmlKla1007 = new XmlOldKla1007();

            xmlKla1007.Gpib.SystemController = configData.Gpib.IsController;
            xmlKla1007.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlKla1007.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlKla1007.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlKla1007.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlKla1007.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlKla1007.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlKla1007.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlKla1007.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlKla1007.Gpib.EosChar = configData.Gpib.EosChar;

            xmlKla1007.SaveConfig(xmlDoc);
        }

        private void SaveTelp8(XmlDocument xmlDoc, Telp8ConfigData configData)
        {
            XmlOldTelp8 xmlTelp8 = new XmlOldTelp8();

            xmlTelp8.Gpib.SystemController = configData.Gpib.IsController;
            xmlTelp8.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlTelp8.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlTelp8.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlTelp8.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlTelp8.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlTelp8.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlTelp8.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlTelp8.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlTelp8.Gpib.EosChar = configData.Gpib.EosChar;

            xmlTelp8.SaveConfig(xmlDoc);
        }

        private void SaveUf2000(XmlDocument xmlDoc, Uf2000ConfigData configData)
        {
            XmlOldUf2000 xmlUf2000 = new XmlOldUf2000();

            xmlUf2000.Gpib.SystemController = configData.Gpib.IsController;
            xmlUf2000.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlUf2000.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlUf2000.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlUf2000.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlUf2000.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlUf2000.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlUf2000.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlUf2000.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlUf2000.Gpib.EosChar = configData.Gpib.EosChar;

            xmlUf2000.SaveConfig(xmlDoc);
        }

        private void SaveVirtualProber(XmlDocument xmlDoc, VirtualProberConfigData configData)
        {
            XmlOldVirtualProber xmlVirtual = new XmlOldVirtualProber();

            xmlVirtual.ConnectDelay = configData.ConnectDelay;
            xmlVirtual.DisconnectDelay = configData.DisconnectDelay;
            xmlVirtual.InitDelay = configData.InitDelay;
            xmlVirtual.WriteSettingDelay = configData.WriteSettingDelay;
            xmlVirtual.ReadSettingDelay = configData.ReadSettingDelay;
            xmlVirtual.WriteAlignmentDelay = configData.WriteAlignmentDelay;
            xmlVirtual.ReadAlignmentDelay = configData.ReadAlignmentDelay;
            xmlVirtual.StartLotDelay = configData.StartLotDelay;
            xmlVirtual.EndLotDelay = configData.EndLotDelay;
            xmlVirtual.LoadWaferDelay = configData.LoadWaferDelay;
            xmlVirtual.UnloadWaferDelay = configData.UnloadWaferDelay;
            xmlVirtual.StartWaferDelay = configData.StartWaferDelay;
            xmlVirtual.EndWaferDelay = configData.EndWaferDelay;
            xmlVirtual.GetWaferIdDelay = configData.GetWaferIdDelay;
            xmlVirtual.MoveToDelay = configData.MoveToDelay;
            xmlVirtual.InkDieDelay = configData.InkDieDelay;
            xmlVirtual.ContactDelay = configData.ContactDelay;
            xmlVirtual.UncontactDelay = configData.UncontactDelay;
            xmlVirtual.RecontactDelay = configData.RecontactDelay;
            xmlVirtual.TestCompleteDelay = configData.TestCompleteDelay;
            xmlVirtual.PauseDelay = configData.PauseDelay;
            xmlVirtual.ContinueDelay = configData.ContinueDelay;
            xmlVirtual.AbortDelay = configData.AbortDelay;
            xmlVirtual.ShowMessageDelay = configData.ShowMessageDelay;
            xmlVirtual.ClearMessageDelay = configData.ClearMessageDelay;
            xmlVirtual.BuzzerOnDelay = configData.BuzzerOnDelay;
            xmlVirtual.BuzzerOffDelay = configData.BuzzerOffDelay;
            xmlVirtual.ForwardCommandDelay = configData.ForwardCommandDelay;

            xmlVirtual.SaveConfig(xmlDoc);
        }

        private void SaveProber(XmlDocument xmlDoc, ProberConfigData configData)
        {
            XmlOldProber xmlProber = new XmlOldProber();

            xmlProber.ActiveProber = configData.ActiveProber;
            xmlProber.Timeout = configData.Timeout;
            xmlProber.SimulatorEnabled = configData.SimulatorEnabled;

            xmlProber.IsProbeCleanEnabled = configData.IsProbeCleanEnabled;
            xmlProber.ProbeCleanCount = configData.ProbeCleanCount;
            xmlProber.IsProbeXyScrub = configData.IsProbeXyScrub;

            SaveEg2001(xmlDoc, configData.Eg2001);
            SaveEg4090(xmlDoc, configData.Eg4090);
            SaveGsi(xmlDoc, configData.Gsi);
            SaveKla1007(xmlDoc, configData.Kla1007);
            SaveTelp8(xmlDoc, configData.Telp8);
            SaveUf2000(xmlDoc, configData.Uf2000);
            SaveVirtualProber(xmlDoc, configData.Virtual);

            xmlProber.SaveConfig(xmlDoc);
        }

        private void SaveDts(XmlDocument xmlDoc, DtsConfigData configData)
        {
            XmlOldDts xmlDts = new XmlOldDts();

            xmlDts.TcpIp.HostName = configData.TcpIp.HostName;
            xmlDts.TcpIp.Port = configData.TcpIp.Port;

            xmlDts.SaveConfig(xmlDoc);
        }

        private void SaveEagle(XmlDocument xmlDoc, EagleConfigData configData)
        {
            XmlOldEagle xmlEagle = new XmlOldEagle();

            xmlEagle.CommunicationType = configData.CommunicationType;
            xmlEagle.CommandSet = configData.CommandSet;
            xmlEagle.ProberId = configData.ProberId;
            xmlEagle.Serial.PortName = configData.Serial.PortName;
            xmlEagle.Serial.BaudRate = configData.Serial.BaudRate;
            xmlEagle.Serial.Parity = configData.Serial.Parity;
            xmlEagle.Serial.DataBits = configData.Serial.DataBits;
            xmlEagle.Serial.StopBits = configData.Serial.StopBits;
            xmlEagle.Serial.Separator = configData.Serial.Separator;
            xmlEagle.Gpib.SystemController = configData.Gpib.IsController;
            xmlEagle.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlEagle.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlEagle.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlEagle.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlEagle.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlEagle.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlEagle.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlEagle.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlEagle.Gpib.EosChar = configData.Gpib.EosChar;
            xmlEagle.TcpIp.HostName = configData.TcpIp.HostName;
            xmlEagle.TcpIp.Port = configData.TcpIp.Port;

            xmlEagle.NewtonEnabled = configData.NewtonEnabled;
            xmlEagle.NewtonSerial.PortName = configData.NewtonSerial.PortName;
            xmlEagle.NewtonSerial.BaudRate = configData.NewtonSerial.BaudRate;
            xmlEagle.NewtonSerial.Parity = configData.NewtonSerial.Parity;
            xmlEagle.NewtonSerial.DataBits = configData.NewtonSerial.DataBits;
            xmlEagle.NewtonSerial.StopBits = configData.NewtonSerial.StopBits;
            xmlEagle.NewtonSerial.Separator = configData.NewtonSerial.Separator;
            xmlEagle.NewtonCacheFileName = configData.NewtonCacheFileName;

            xmlEagle.SaveConfig(xmlDoc);
        }

        private void SaveFet(XmlDocument xmlDoc, FetConfigData configData)
        {
            XmlOldFet xmlFet = new XmlOldFet();

            xmlFet.BoardNo = configData.BoardNo;
            xmlFet.EnableSendingXyCoords = configData.EnableSendingXYCoords;
            xmlFet.Gpib.SystemController = configData.Gpib.IsController;
            xmlFet.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlFet.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlFet.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlFet.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlFet.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlFet.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlFet.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlFet.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlFet.Gpib.EosChar = configData.Gpib.EosChar;

            xmlFet.SaveConfig(xmlDoc);
        }

        private void SavePft(XmlDocument xmlDoc, PftConfigData configData)
        {
            XmlOldPft xmlPft = new XmlOldPft();

            xmlPft.TcpIp.HostName = configData.TcpIp.HostName;
            xmlPft.TcpIp.Port = configData.TcpIp.Port;

            xmlPft.SaveConfig(xmlDoc);
        }

        private void SaveTmt(XmlDocument xmlDoc, TmtConfigData configData)
        {
            XmlOldTmt xmlTmt = new XmlOldTmt();

            xmlTmt.CommandSet = configData.CommandSet;
            xmlTmt.CommunicationType = configData.CommunicationType;                    
            xmlTmt.TcpIp.HostName = configData.TcpIp.HostName;
            xmlTmt.TcpIp.Port = configData.TcpIp.Port;
            xmlTmt.Serial.PortName = configData.Serial.PortName;
            xmlTmt.Serial.BaudRate = configData.Serial.BaudRate;
            xmlTmt.Serial.Parity = configData.Serial.Parity;
            xmlTmt.Serial.DataBits = configData.Serial.DataBits;
            xmlTmt.Serial.StopBits = configData.Serial.StopBits;
            xmlTmt.Serial.Separator = configData.Serial.Separator;
            xmlTmt.SaveConfig(xmlDoc);
        }

        private void SaveKeithley(XmlDocument xmlDoc, KeithleyConfigData configData)
        {
            XmlOldKeithley xmlKeithley = new XmlOldKeithley();

            xmlKeithley.ScriptFileName = configData.ScriptFileName;
            xmlKeithley.CsvOutputDir = configData.CsvOutputDir;
            xmlKeithley.Gpib.SystemController = configData.Gpib.IsController;
            xmlKeithley.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlKeithley.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlKeithley.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlKeithley.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlKeithley.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlKeithley.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlKeithley.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlKeithley.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlKeithley.Gpib.EosChar = configData.Gpib.EosChar;

            xmlKeithley.SaveConfig(xmlDoc);
        }

        private void SaveHp(XmlDocument xmlDoc, HpConfigData configData)
        {
            XmlOldHp xmlHp = new XmlOldHp();

            xmlHp.Gpib.SystemController = configData.Gpib.IsController;
            xmlHp.Gpib.BoardIndex = configData.Gpib.BoardIndex;
            xmlHp.Gpib.BoardPrimaryAddress = configData.Gpib.BoardPrimaryAddress;
            xmlHp.Gpib.BoardSecondaryAddress = configData.Gpib.BoardSecondaryAddress;
            xmlHp.Gpib.DevicePrimaryAddress = configData.Gpib.DevicePrimaryAddress;
            xmlHp.Gpib.DeviceSecondaryAddress = configData.Gpib.DeviceSecondaryAddress;
            xmlHp.Gpib.IsEoi = configData.Gpib.IsEOI;
            xmlHp.Gpib.IsEos = configData.Gpib.IsEOS;
            xmlHp.Gpib.EightBitEos = configData.Gpib.EightBitEOS;
            xmlHp.Gpib.EosChar = configData.Gpib.EosChar;

            xmlHp.SaveConfig(xmlDoc);
        }

        private void SaveMaverick(XmlDocument xmlDoc, MaverickConfigData configData)
        {
            XmlOldMaverick xmlMaverick = new XmlOldMaverick();

            xmlMaverick.TcpIp.HostName = configData.TcpIp.HostName;
            xmlMaverick.TcpIp.Port = configData.TcpIp.Port;

            xmlMaverick.SaveConfig(xmlDoc);
        }

        private void SavePei(XmlDocument xmlDoc, PeiConfigData configData)
        {
            XmlOldPei xmlPei = new XmlOldPei();

            xmlPei.Serial.PortName = configData.Serial.PortName;
            xmlPei.Serial.BaudRate = configData.Serial.BaudRate;
            xmlPei.Serial.Parity = configData.Serial.Parity;
            xmlPei.Serial.DataBits = configData.Serial.DataBits;
            xmlPei.Serial.StopBits = configData.Serial.StopBits;
            xmlPei.Serial.Separator = configData.Serial.Separator;

            xmlPei.SaveConfig(xmlDoc);
        }
        private void SavePowertech(XmlDocument xmlDoc, PowertechConfigData configData)
        {
            XmlOldPowertech xmlPowertech = new XmlOldPowertech();

            xmlPowertech.Serial.PortName = configData.Serial.PortName;
            xmlPowertech.Serial.BaudRate = configData.Serial.BaudRate;
            xmlPowertech.Serial.Parity = configData.Serial.Parity;
            xmlPowertech.Serial.DataBits = configData.Serial.DataBits;
            xmlPowertech.Serial.StopBits = configData.Serial.StopBits;
            xmlPowertech.Serial.Separator = configData.Serial.Separator;

            xmlPowertech.SaveConfig(xmlDoc);
        }

        private void SaveVirtualTester(XmlDocument xmlDoc, VirtualTesterConfigData configData)
        {
            XmlOldVirtualTester xmlVirtual = new XmlOldVirtualTester();

            xmlVirtual.ConnectDelay = configData.ConnectDelay;
            xmlVirtual.DisconnectDelay = configData.DisconnectDelay;
            xmlVirtual.InitDelay = configData.InitDelay;
            xmlVirtual.StartLotDelay = configData.StartLotDelay;
            xmlVirtual.EndLotDelay = configData.EndLotDelay;
            xmlVirtual.StartWaferDelay = configData.StartWaferDelay;
            xmlVirtual.EndWaferDelay = configData.EndWaferDelay;
            xmlVirtual.ProbeDieDelay = configData.ProbeDieDelay;
            xmlVirtual.ProbeDieFinishedDelay = configData.ProbeDieFinishedDelay;
            xmlVirtual.GetTestProgramNameDelay = configData.GetTestProgramNameDelay;
            xmlVirtual.GetTemperatureDelay = configData.GetTemperatureDelay;
            xmlVirtual.IsRandom = configData.IsRandom;
            xmlVirtual.Yield = (int)configData.Yield;
            xmlVirtual.IsGrowing = configData.IsGrowing;
            xmlVirtual.InputWmxmlPath = configData.InputWmxmlPath;

            xmlVirtual.SaveConfig(xmlDoc);
        }

        private void SaveTester(XmlDocument xmlDoc, TesterConfigData configData)
        {
            XmlOldTester xmlTester = new XmlOldTester();

            xmlTester.ActiveTester = configData.ActiveTester;
            xmlTester.Timeout = configData.Timeout;
            xmlTester.SimulatorEnabled = configData.SimulatorEnabled;

            SaveDts(xmlDoc, configData.Dts);
            SaveEagle(xmlDoc, configData.Eagle);
            SaveFet(xmlDoc, configData.Fet);
            SavePft(xmlDoc, configData.Pft);
            SaveTmt(xmlDoc, configData.Tmt);
            SaveKeithley(xmlDoc, configData.Keithley);
            SaveHp(xmlDoc, configData.Hp);
            SaveMaverick(xmlDoc, configData.Maverick);
            SavePei(xmlDoc, configData.Pei);
            SaveVirtualTester(xmlDoc, configData.Virtual);

            xmlTester.SaveConfig(xmlDoc);
        }

        #endregion

        #region load private methods

        private void LoadGeneral(XmlDocument xmlDoc, GeneralConfigData generalConfigData, WmxmlConfigData wmxmlConfigData, DialogConfigData dialogConfigData)
        {
            XmlOldGeneral xmlGeneral = new XmlOldGeneral();
            xmlGeneral.LoadConfig(xmlDoc);

            generalConfigData.LoginEnabled = xmlGeneral.LoginEnabled;
            generalConfigData.SystemType = xmlGeneral.SystemType;
            generalConfigData.LogLevel = xmlGeneral.LogLevel;
            generalConfigData.LongPauseEnabled = xmlGeneral.LongPauseEnabled;
            generalConfigData.LongPauseDelayTime = xmlGeneral.LongPauseDelayTime;
            generalConfigData.TowerLightEnabled = xmlGeneral.TowerLightEnabled;
            generalConfigData.TowerLightPort = xmlGeneral.TowerLightPort;
            wmxmlConfigData.AlwaysSaveWaferMaps = xmlGeneral.AlwaysSaveWaferMaps;
            dialogConfigData.ErrorDialogContinueEnabled = xmlGeneral.ErrorDialogContinueEnabled;
            dialogConfigData.PauseDialogAfterWaferEnabled = xmlGeneral.PauseDialogAfterWaferEnabled;
            dialogConfigData.PauseDialogAfterWaferAutoRelease = xmlGeneral.PauseDialogAfterWaferAutoRelease;

            XmlOldDb xmlDb = new XmlOldDb();
            xmlDb.LoadConfig(xmlDoc);

            generalConfigData.UseTrakLot = xmlDb.UseTrakLot;
        }

        private void LoadEnvGeneral(XmlDocument xmlDoc, EnvGeneralConfigData configData)
        {
            XmlOldEnvGeneral xmlEnvGeneral = new XmlOldEnvGeneral();
            xmlEnvGeneral.LoadConfig(xmlDoc);

            configData.AutoCenter = xmlEnvGeneral.AutoCenter;
            configData.DrawCircle = xmlEnvGeneral.DrawCircle;
            configData.DrawGrid = xmlEnvGeneral.DrawGrid;
            configData.RecoveryYield = xmlEnvGeneral.RecoveryYield;
            configData.CultureName = xmlEnvGeneral.CultureName;
            if (xmlEnvGeneral.CultureList.Count > 0)
            {
                configData.ClearCutureList();
                configData.AddRangeToCultureList(xmlEnvGeneral.CultureList);
            }
        }

        private void LoadColor(XmlDocument xmlDoc, ColorConfigData configData)
        {
            XmlOldColor xmlColor = new XmlOldColor();
            xmlColor.LoadConfig(xmlDoc);

            if (xmlColor.DrawPropertyList.Count > 0)
            {
                configData.UpdateDrawPropertyList(xmlColor.DrawPropertyList);
            }
        }

        private void LoadEvent(XmlDocument xmlDoc, EventConfigData configData)
        {
            XmlOldEvent xmlEvent = new XmlOldEvent();
            xmlEvent.LoadConfig(xmlDoc);

            configData.Enabled = xmlEvent.Enabled;
            configData.WriteVerificationCount = xmlEvent.WriteVerificationCount;
            configData.SendingCount = xmlEvent.SendingCount;
            configData.EventDir = xmlEvent.EventDir;
            configData.RejectedEventDir = xmlEvent.RejectedEventDir;

            configData.LpEventConfigData.UpdateLongPauseEventList(xmlEvent.LongPauseEvents);

        }

        private void LoadDir(XmlDocument xmlDoc, DirConfigData dirConfigData, WmxmlConfigData wmxmlConfigData)
        {
            XmlOldDir xmlDir = new XmlOldDir();
            xmlDir.LoadConfig(xmlDoc);

            dirConfigData.SetupDir = xmlDir.SetupDir;
            dirConfigData.LoggingDir = xmlDir.LoggingDir;
            dirConfigData.CacheDir = xmlDir.CacheDir;
            wmxmlConfigData.LocalWmxmlVersion = xmlDir.WmxmlVersion;
            wmxmlConfigData.LocalFileFormat = xmlDir.LocalFileFormat;
            wmxmlConfigData.LocalOutputWmxmlEnabled = xmlDir.LocalOutputWmxmlEnabled;
            wmxmlConfigData.LocalOutputWmxmlDir = xmlDir.LocalWmxmlDir;
            wmxmlConfigData.LocalTempWmxmlDir = xmlDir.LocalTempWmxmlDir;
            wmxmlConfigData.LocalInputWmxmlEnabled = xmlDir.LocalInputWmxmlEnabled;
            wmxmlConfigData.LocalInputWmxmlDir = xmlDir.LocalInputWmxmlDir;
            wmxmlConfigData.SecsChangePassBin = xmlDir.SecsChangePassBin;
            wmxmlConfigData.SecsPassBin = xmlDir.SecsPassBin;
            wmxmlConfigData.LocalOutputSecsEnabled = xmlDir.LocalOutputSecsEnabled;
            wmxmlConfigData.LocalOutputSecsDir = xmlDir.LocalSecsDir;
            wmxmlConfigData.ServerWmxmlVersion = xmlDir.WmxmlVersion;
            wmxmlConfigData.ServerFileFormat = xmlDir.ServerFileFormat;
            wmxmlConfigData.ServerOutputWmxmlEnabled = xmlDir.ServerOutputWmxmlEnabled;
            wmxmlConfigData.ServerOutputWmxmlDir = xmlDir.ServerOutputWmxmlDir;
            wmxmlConfigData.ServerUnsentWmxmlDir = xmlDir.ServerUnsentWmxmlDir;
            wmxmlConfigData.ServerInputWmxmlEnabled = xmlDir.ServerInputWmxmlEnabled;
            wmxmlConfigData.ServerInputWmxmlDir = xmlDir.ServerInputWmxmlDir;
            wmxmlConfigData.ServerOutputSecsEnabled = xmlDir.ServerOutputSecsEnabled;
            wmxmlConfigData.ServerOutputSecsDir = xmlDir.ServerOutputSecsDir;
            wmxmlConfigData.ServerUnsentSecsDir = xmlDir.ServerUnsentSecsDir;
            wmxmlConfigData.VaultWmxmlVersion = xmlDir.WmxmlVersion;
            wmxmlConfigData.VaultFileFormat = xmlDir.WebServiceFileFormat;
            wmxmlConfigData.VaultOutputEnabled = xmlDir.WebServiceOutputEnabled;
            wmxmlConfigData.VaultInputEnabled = xmlDir.WebServiceInputEnabled;
            wmxmlConfigData.ClearWebServiceUrlList();
            wmxmlConfigData.AddToWebServiceUrlList(xmlDir.WebServicePrimaryUrl);
            wmxmlConfigData.AddToWebServiceUrlList(xmlDir.WebServiceSecondaryUrl);
            wmxmlConfigData.VaultUnsentWmxmlDir = xmlDir.WebServiceUnsentWmxmlDir;
            wmxmlConfigData.ExternalWmxmlVersion = xmlDir.WmxmlVersion;
            wmxmlConfigData.ExternalFileFormat = xmlDir.ExternalFileFormat;
            wmxmlConfigData.ExternalInputEnabled = xmlDir.ExternalInputEnabled;
            wmxmlConfigData.ExternalInputWmxmlDir = xmlDir.ExternalInputWmxmlDir;
            wmxmlConfigData.ExternalOutputEnabled = xmlDir.ExternalOutputEnabled;
            wmxmlConfigData.ExternalOutputWmxmlDir = xmlDir.ExternalOutputWmxmlDir;
            wmxmlConfigData.ExternalUnsentWmxmlDir = xmlDir.ExternalUnsentWmxmlDir;
            dirConfigData.ManualCheckFileName = xmlDir.ManualCheckFileName;
            dirConfigData.ManualCheckLocalDir = xmlDir.ManualCheckLocalDir;
            dirConfigData.ManualCheckServerDir = xmlDir.ManualCheckServerDir;
        }

        private void LoadGenesis(XmlDocument xmlDoc, GenesisConfigData configData)
        {
            XmlOldGenesis xmlGenesis = new XmlOldGenesis();
            xmlGenesis.LoadConfig(xmlDoc);

            configData.Enabled = xmlGenesis.Enabled;
        }

        private void LoadCheckin(XmlDocument xmlDoc, CheckinConfigData configData)
        {
            XmlOldCheckin xmlCheckin = new XmlOldCheckin();
            xmlCheckin.LoadConfig(xmlDoc);

            configData.CanDisableSsp = xmlCheckin.CanDisableSsp;
            configData.ReverseOrder = xmlCheckin.ReverseOrder;
            configData.UncheckWafers = xmlCheckin.UncheckWafers;
            configData.OperatorIdEnabled = xmlCheckin.OperatorIdEnable;
            configData.CheckSetupEnabled = xmlCheckin.CheckSetup;
            configData.SetupMinMatchLength = xmlCheckin.SetupMinMatchLength;

        }

        private void LoadLotSearch(XmlDocument xmlDoc, LotSearchConfigData configData)
        {
            XmlOldLotSearch xmlLotSearch = new XmlOldLotSearch();
            xmlLotSearch.LoadConfig(xmlDoc);

            configData.UseLimitedLotSearch = xmlLotSearch.UseLimitedLotSearch;
            configData.DaysBackward = xmlLotSearch.DaysBackward;
        }

        private void LoadMethods(XmlDocument xmlDoc, ProcessMethodConfigData configData)
        {
            XmlOldMethods xmlMethods = new XmlOldMethods();
            xmlMethods.LoadConfig(xmlDoc);

            configData.SmartUnitProbe.NeverTouchOutsideWafer = xmlMethods.IsSupNeverTouchOutsideWafer;
            configData.SmartUnitProbe.MaxTouchdownsOnDie = xmlMethods.SupMaxTouchdownsOnDie;
            configData.SampleProbe.SpToUpEnabled = xmlMethods.IsAutoSpToUp;
            configData.EdgeProbe.WaferEdgeEnabled = xmlMethods.IsEpWafer;
            configData.EdgeProbe.PcMarkEdgeEnabled = xmlMethods.IsEpPcMark;
            configData.SmartSampleProbe.Mode = xmlMethods.SspMode;
            configData.ClassProbe.SingleFirstRowEnabled =
            configData.SmartSampleProbe.SingleFirstRowEnabled = xmlMethods.IsSspSingleFirstRow;
            configData.ClassProbe.SingleChessboardEnabled = xmlMethods.IsCpSingleChessboard;
            configData.SmartSampleProbe.SingleChessboardEnabled = xmlMethods.IsSspSingleChessboard;
            configData.ClassProbe.MultiFirstRowEnabled =
            configData.SmartSampleProbe.MultiFirstRowEnabled = xmlMethods.IsSspMultiFirstRow;
            configData.ClassProbe.MultiChessboardEnabled = xmlMethods.IsCpMultiChessboard;
            configData.SmartSampleProbe.MultiChessboardEnabled = xmlMethods.IsSspMultiChessboard;

            configData.Aoi.GoodDieCounterEnabled = xmlMethods.IsAoiGoodDieCounter;

            XmlOldMapEdit xmlMapEdit = new XmlOldMapEdit();
            xmlMapEdit.LoadConfig(xmlDoc);

            configData.MapEdit.Enabled = xmlMapEdit.EnableMapEdit;
            configData.MapEdit.ReplaceBinValue = xmlMapEdit.ReplaceBinValue;

            XmlOldFpMethods xmlFpMethods = new XmlOldFpMethods();
            xmlFpMethods.LoadConfig(xmlDoc);

            configData.FlexibleProbe.Enabled = xmlFpMethods.Enabled;
            configData.FlexibleProbe.ClearStartMethodsList();
            configData.FlexibleProbe.AddRangeStartMethodsList(xmlFpMethods.StartProcessMethodsList);
            configData.FlexibleProbe.ClearEndMethodsList();
            configData.FlexibleProbe.AddRangeEndMethodsList(xmlFpMethods.EndProcessMethodsList);
        }

        private void LoadCustomScripts(XmlDocument xmlDoc, CustomScriptConfigData configData)
        {
            XmlOldCustomScripts xmlCustomScripts = new XmlOldCustomScripts();
            xmlCustomScripts.LoadConfig(xmlDoc);

            configData.Enabled = xmlCustomScripts.Enabled;
            configData.ClearCustomScriptList();
            configData.AddRangeToCustomScriptList(xmlCustomScripts.CustomScriptList);
        }

        private void LoadNewton(XmlDocument xmlDoc, NewtonConfigData configData)
        {
            XmlOldNewton xmlNewton = new XmlOldNewton();
            xmlNewton.LoadConfig(xmlDoc);

            configData.Enabled = xmlNewton.Enabled;
            configData.NewtonFile = xmlNewton.NewtonFile;
            configData.WmxmlOutputDir = xmlNewton.NewtonMapDir;
            configData.StatusFile = xmlNewton.StatusFile;
            configData.Timeout = xmlNewton.Timeout;
        }

        private void LoadRtm(XmlDocument xmlDoc, RtmConfigData configData)
        {
            XmlOldRtm xmlRtm = new XmlOldRtm();
            xmlRtm.LoadConfig(xmlDoc);

            configData.Enabled = xmlRtm.Enabled;
            configData.RtmDir = xmlRtm.RtmDir;
            configData.AgentName = xmlRtm.AgentName;
            configData.AgentCmd = xmlRtm.AgentCmd;
            configData.WatchPeriod = xmlRtm.WatchPeriod;
        }

        private void LoadProbeInTemp(XmlDocument xmlDoc, ProbeInTempConfigData configData)
        {
            XmlOldProbeInTemp xmlProbeInTemp = new XmlOldProbeInTemp();
            xmlProbeInTemp.LoadConfig(xmlDoc);

            configData.AskForTemperature = xmlProbeInTemp.AskForTemperature;
            configData.DefaultTemperature = xmlProbeInTemp.DefaultTemperature;
            configData.ProbeInTemperatures = xmlProbeInTemp.ProbeInTemperatures;
            configData.EngineerMode = xmlProbeInTemp.EngineerMode;
            configData.ReplaceBinValue = xmlProbeInTemp.ReplaceBinValue;
        }

        private void LoadConsecutiveFail(XmlDocument xmlDoc, ConsecutiveFailConfigData configData)
        {
            XmlOldConsecutiveFail xmlConsecutiveFail = new XmlOldConsecutiveFail();
            xmlConsecutiveFail.LoadConfig(xmlDoc);

            configData.Enabled = xmlConsecutiveFail.Enabled;
            configData.Threshold = xmlConsecutiveFail.Limit;
            configData.ResetCounterOnEachRow = xmlConsecutiveFail.ResetCounterOnEachRow;
            configData.ClearCustomRuleList();
            configData.AddRangeToCustomRuleList(xmlConsecutiveFail.CustomRules);
        }

        private void LoadCutOff(XmlDocument xmlDoc, CutoffConfigData configData)
        {
            XmlOldCutOff xmlCutOff = new XmlOldCutOff();
            xmlCutOff.LoadConfig(xmlDoc);

            configData.Enabled = xmlCutOff.EnableCutOff;
            configData.NotReachedEnabled = xmlCutOff.EnableCutOffNotReached;
        }

        private void LoadKelvinDie(XmlDocument xmlDoc, KelvinDieConfigData configData)
        {
            XmlOldKelvinDie xmlKelvinDie = new XmlOldKelvinDie();
            xmlKelvinDie.LoadConfig(xmlDoc);

            configData.Enabled = xmlKelvinDie.Enabled;
            configData.BinString = xmlKelvinDie.KelvinDieBins;
            configData.ReprobeFirst = xmlKelvinDie.ReprobeFirst;
        }

        private void LoadLaserscribe(XmlDocument xmlDoc, LaserscribeConfigData configData)
        {
            XmlOldLaserscribe xmlLaserscribe = new XmlOldLaserscribe();
            xmlLaserscribe.LoadConfig(xmlDoc);

            configData.Enabled = xmlLaserscribe.Enabled;
            configData.LaserscribeMatchingEnabled = xmlLaserscribe.LaserscribeMatchingEnabled;
            configData.ClearLaserscribeFormatList();
            configData.AddRangeToLaserscribeFormatList(xmlLaserscribe.LaserscribeFormats);
            configData.ClearLotFilterList();
            configData.AddRangeToLotFilterList(xmlLaserscribe.LotsWithLaserscribesInDb);
            configData.UsingLaserscribeFromDB = xmlLaserscribe.EnableUsingLaserscribeFromDB;
        }

        private void LoadIncompleteProbe(XmlDocument xmlDoc, IncompleteProbeConfigData configData)
        {
            XmlOldIncompleteProbe xmlIncompleteProbe = new XmlOldIncompleteProbe();
            xmlIncompleteProbe.LoadConfig(xmlDoc);

            configData.Enabled = xmlIncompleteProbe.Enabled;
            configData.AutoComplete = xmlIncompleteProbe.AutoComplete;
        }

        private void LoadReprobe(XmlDocument xmlDoc, ReprobeConfigData configData)
        {
            XmlOldReprobe xmlReprobe = new XmlOldReprobe();
            xmlReprobe.LoadConfig(xmlDoc);

            configData.Enabled = xmlReprobe.Enabled;
            configData.NumberOfReprobes = xmlReprobe.NumberOfReprobes;
            configData.ReprobeOnTheFly = xmlReprobe.ReprobeOnTheFly;
        }

        private void LoadEg2001(XmlDocument xmlDoc, Eg2001ConfigData configData)
        {
            XmlOldEg2001 xmlEg2001 = new XmlOldEg2001();
            xmlEg2001.LoadConfig(xmlDoc);

            configData.EnableManualMicroCoordsChange = xmlEg2001.EnableManualMicroCoordsChange;
            configData.Serial.PortName = xmlEg2001.Serial.PortName;
            configData.Serial.BaudRate = xmlEg2001.Serial.BaudRate;
            configData.Serial.Parity = xmlEg2001.Serial.Parity;
            configData.Serial.DataBits = xmlEg2001.Serial.DataBits;
            configData.Serial.StopBits = xmlEg2001.Serial.StopBits;
            configData.Serial.Separator = xmlEg2001.Serial.Separator;
        }

        private void LoadEg4090(XmlDocument xmlDoc, Eg4090ConfigData configData)
        {
            XmlOldEg4090 xmlEg4090 = new XmlOldEg4090();
            xmlEg4090.LoadConfig(xmlDoc);

            configData.SendProfileData = xmlEg4090.SendProfileData;
            configData.CommunicationType = xmlEg4090.CommunicationType;

            configData.Gpib.IsController = xmlEg4090.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlEg4090.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlEg4090.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlEg4090.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlEg4090.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlEg4090.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlEg4090.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlEg4090.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlEg4090.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlEg4090.Gpib.EosChar;

            configData.Serial.PortName = xmlEg4090.Serial.PortName;
            configData.Serial.BaudRate = xmlEg4090.Serial.BaudRate;
            configData.Serial.Parity = xmlEg4090.Serial.Parity;
            configData.Serial.DataBits = xmlEg4090.Serial.DataBits;
            configData.Serial.StopBits = xmlEg4090.Serial.StopBits;
            configData.Serial.Separator = xmlEg4090.Serial.Separator;
        }

        private void LoadGsi(XmlDocument xmlDoc, GsiConfigData configData)
        {
            XmlOldGsi xmlGsi = new XmlOldGsi();
            xmlGsi.LoadConfig(xmlDoc);

            configData.GsiWaferMapDir = xmlGsi.GsiWaferMapDir;
            configData.TcpIp.HostName = xmlGsi.TcpIp.HostName;
            configData.TcpIp.Port = xmlGsi.TcpIp.Port;
        }

        private void LoadKla1007(XmlDocument xmlDoc, Kla1007ConfigData configData)
        {
            XmlOldKla1007 xmlKla1007 = new XmlOldKla1007();
            xmlKla1007.LoadConfig(xmlDoc);

            configData.Gpib.IsController = xmlKla1007.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlKla1007.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlKla1007.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlKla1007.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlKla1007.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlKla1007.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlKla1007.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlKla1007.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlKla1007.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlKla1007.Gpib.EosChar;
        }

        private void LoadTelp8(XmlDocument xmlDoc, Telp8ConfigData configData)
        {
            XmlOldTelp8 xmlTelp8 = new XmlOldTelp8();
            xmlTelp8.LoadConfig(xmlDoc);

            configData.Gpib.IsController = xmlTelp8.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlTelp8.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlTelp8.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlTelp8.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlTelp8.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlTelp8.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlTelp8.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlTelp8.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlTelp8.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlTelp8.Gpib.EosChar;
        }

        private void LoadUf2000(XmlDocument xmlDoc, Uf2000ConfigData configData)
        {
            XmlOldUf2000 xmlUf2000 = new XmlOldUf2000();
            xmlUf2000.LoadConfig(xmlDoc);

            configData.Gpib.IsController = xmlUf2000.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlUf2000.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlUf2000.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlUf2000.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlUf2000.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlUf2000.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlUf2000.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlUf2000.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlUf2000.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlUf2000.Gpib.EosChar;
        }

        private void LoadVirtualProber(XmlDocument xmlDoc, VirtualProberConfigData configData)
        {
            XmlOldVirtualProber xmlVirtual = new XmlOldVirtualProber();
            xmlVirtual.LoadConfig(xmlDoc);

            configData.ConnectDelay = xmlVirtual.ConnectDelay;
            configData.DisconnectDelay = xmlVirtual.DisconnectDelay;
            configData.InitDelay = xmlVirtual.InitDelay;
            configData.WriteSettingDelay = xmlVirtual.WriteSettingDelay;
            configData.ReadSettingDelay = xmlVirtual.ReadSettingDelay;
            configData.WriteAlignmentDelay = xmlVirtual.WriteAlignmentDelay;
            configData.ReadAlignmentDelay = xmlVirtual.ReadAlignmentDelay;
            configData.StartLotDelay = xmlVirtual.StartLotDelay;
            configData.EndLotDelay = xmlVirtual.EndLotDelay;
            configData.LoadWaferDelay = xmlVirtual.LoadWaferDelay;
            configData.UnloadWaferDelay = xmlVirtual.UnloadWaferDelay;
            configData.StartWaferDelay = xmlVirtual.StartWaferDelay;
            configData.EndWaferDelay = xmlVirtual.EndWaferDelay;
            configData.GetWaferIdDelay = xmlVirtual.GetWaferIdDelay;
            configData.MoveToDelay = xmlVirtual.MoveToDelay;
            configData.InkDieDelay = xmlVirtual.InkDieDelay;
            configData.ContactDelay = xmlVirtual.ContactDelay;
            configData.UncontactDelay = xmlVirtual.UncontactDelay;
            configData.RecontactDelay = xmlVirtual.RecontactDelay;
            configData.TestCompleteDelay = xmlVirtual.TestCompleteDelay;
            configData.PauseDelay = xmlVirtual.PauseDelay;
            configData.ContinueDelay = xmlVirtual.ContinueDelay;
            configData.AbortDelay = xmlVirtual.AbortDelay;
            configData.ShowMessageDelay = xmlVirtual.ShowMessageDelay;
            configData.ClearMessageDelay = xmlVirtual.ClearMessageDelay;
            configData.BuzzerOnDelay = xmlVirtual.BuzzerOnDelay;
            configData.BuzzerOffDelay = xmlVirtual.BuzzerOffDelay;
            configData.ForwardCommandDelay = xmlVirtual.ForwardCommandDelay;
        }

        private void LoadProber(XmlDocument xmlDoc, ProberConfigData configData)
        {
            XmlOldProber xmlProber = new XmlOldProber();
            xmlProber.LoadConfig(xmlDoc);

            configData.ActiveProber = xmlProber.ActiveProber;
            configData.Timeout = xmlProber.Timeout;
            configData.SimulatorEnabled = xmlProber.SimulatorEnabled;

            configData.IsProbeCleanEnabled = xmlProber.IsProbeCleanEnabled;
            configData.ProbeCleanCount = xmlProber.ProbeCleanCount;
            configData.IsProbeXyScrub = xmlProber.IsProbeXyScrub;

            LoadEg2001(xmlDoc, configData.Eg2001);
            LoadEg4090(xmlDoc, configData.Eg4090);
            LoadGsi(xmlDoc, configData.Gsi);
            LoadKla1007(xmlDoc, configData.Kla1007);
            LoadTelp8(xmlDoc, configData.Telp8);
            LoadUf2000(xmlDoc, configData.Uf2000);
            LoadVirtualProber(xmlDoc, configData.Virtual);
        }

        private void LoadDts(XmlDocument xmlDoc, DtsConfigData configData)
        {
            XmlOldDts xmlDts = new XmlOldDts();
            xmlDts.LoadConfig(xmlDoc);

            configData.TcpIp.HostName = xmlDts.TcpIp.HostName;
            configData.TcpIp.Port = xmlDts.TcpIp.Port;
        }

        private void LoadEagle(XmlDocument xmlDoc, EagleConfigData configData)
        {
            XmlOldEagle xmlEagle = new XmlOldEagle();
            xmlEagle.LoadConfig(xmlDoc);

            configData.CommunicationType = xmlEagle.CommunicationType;
            configData.CommandSet = xmlEagle.CommandSet;
            configData.ProberId = xmlEagle.ProberId;
            configData.Serial.PortName = xmlEagle.Serial.PortName;
            configData.Serial.BaudRate = xmlEagle.Serial.BaudRate;
            configData.Serial.Parity = xmlEagle.Serial.Parity;
            configData.Serial.DataBits = xmlEagle.Serial.DataBits;
            configData.Serial.StopBits = xmlEagle.Serial.StopBits;
            configData.Serial.Separator = xmlEagle.Serial.Separator;
            configData.Gpib.IsController = xmlEagle.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlEagle.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlEagle.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlEagle.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlEagle.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlEagle.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlEagle.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlEagle.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlEagle.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlEagle.Gpib.EosChar;
            configData.TcpIp.HostName = xmlEagle.TcpIp.HostName;
            configData.TcpIp.Port = xmlEagle.TcpIp.Port;

            configData.NewtonEnabled = xmlEagle.NewtonEnabled;
            configData.NewtonSerial.PortName = xmlEagle.NewtonSerial.PortName;
            configData.NewtonSerial.BaudRate = xmlEagle.NewtonSerial.BaudRate;
            configData.NewtonSerial.Parity = xmlEagle.NewtonSerial.Parity;
            configData.NewtonSerial.DataBits = xmlEagle.NewtonSerial.DataBits;
            configData.NewtonSerial.StopBits = xmlEagle.NewtonSerial.StopBits;
            configData.NewtonSerial.Separator = xmlEagle.NewtonSerial.Separator;
            configData.NewtonCacheFileName = xmlEagle.NewtonCacheFileName;
        }

        private void LoadFet(XmlDocument xmlDoc, FetConfigData configData)
        {
            XmlOldFet xmlFet = new XmlOldFet();
            xmlFet.LoadConfig(xmlDoc);

            configData.BoardNo = xmlFet.BoardNo;
            configData.EnableSendingXYCoords = xmlFet.EnableSendingXyCoords;
            configData.Gpib.IsController = xmlFet.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlFet.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlFet.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlFet.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlFet.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlFet.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlFet.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlFet.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlFet.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlFet.Gpib.EosChar;
        }

        private void LoadPft(XmlDocument xmlDoc, PftConfigData configData)
        {
            XmlOldPft xmlPft = new XmlOldPft();
            xmlPft.LoadConfig(xmlDoc);

            configData.TcpIp.HostName = xmlPft.TcpIp.HostName;
            configData.TcpIp.Port = xmlPft.TcpIp.Port;
        }

        private void LoadTmt(XmlDocument xmlDoc, TmtConfigData configData)
        {
            XmlOldTmt xmlTmt = new XmlOldTmt();
            xmlTmt.LoadConfig(xmlDoc);
            configData.CommandSet = xmlTmt.CommandSet;
            configData.CommunicationType = xmlTmt.CommunicationType;            
            
            configData.TcpIp.HostName = xmlTmt.TcpIp.HostName;
            configData.TcpIp.Port = xmlTmt.TcpIp.Port;

            configData.Serial.PortName = xmlTmt.Serial.PortName;
            configData.Serial.BaudRate = xmlTmt.Serial.BaudRate;
            configData.Serial.Parity = xmlTmt.Serial.Parity;
            configData.Serial.DataBits = xmlTmt.Serial.DataBits;
            configData.Serial.StopBits = xmlTmt.Serial.StopBits;
            configData.Serial.Separator = xmlTmt.Serial.Separator;
        }

        private void LoadKeithley(XmlDocument xmlDoc, KeithleyConfigData configData)
        {
            XmlOldKeithley xmlKeithley = new XmlOldKeithley();
            xmlKeithley.LoadConfig(xmlDoc);

            configData.ScriptFileName = xmlKeithley.ScriptFileName;
            configData.CsvOutputDir = xmlKeithley.CsvOutputDir;
            configData.Gpib.IsController = xmlKeithley.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlKeithley.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlKeithley.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlKeithley.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlKeithley.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlKeithley.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlKeithley.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlKeithley.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlKeithley.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlKeithley.Gpib.EosChar;
        }

        private void LoadHp(XmlDocument xmlDoc, HpConfigData configData)
        {
            XmlOldHp xmlHp = new XmlOldHp();
            xmlHp.LoadConfig(xmlDoc);

            configData.Gpib.IsController = xmlHp.Gpib.SystemController;
            configData.Gpib.BoardIndex = xmlHp.Gpib.BoardIndex;
            configData.Gpib.BoardPrimaryAddress = xmlHp.Gpib.BoardPrimaryAddress;
            configData.Gpib.BoardSecondaryAddress = xmlHp.Gpib.BoardSecondaryAddress;
            configData.Gpib.DevicePrimaryAddress = xmlHp.Gpib.DevicePrimaryAddress;
            configData.Gpib.DeviceSecondaryAddress = xmlHp.Gpib.DeviceSecondaryAddress;
            configData.Gpib.IsEOI = xmlHp.Gpib.IsEoi;
            configData.Gpib.IsEOS = xmlHp.Gpib.IsEos;
            configData.Gpib.EightBitEOS = xmlHp.Gpib.EightBitEos;
            configData.Gpib.EosChar = xmlHp.Gpib.EosChar;
        }

        private void LoadMaverick(XmlDocument xmlDoc, MaverickConfigData configData)
        {
            XmlOldMaverick xmlMaverick = new XmlOldMaverick();
            xmlMaverick.LoadConfig(xmlDoc);

            configData.TcpIp.HostName = xmlMaverick.TcpIp.HostName;
            configData.TcpIp.Port = xmlMaverick.TcpIp.Port;
        }

        private void LoadPei(XmlDocument xmlDoc, PeiConfigData configData)
        {
            XmlOldPei xmlPei = new XmlOldPei();
            xmlPei.LoadConfig(xmlDoc);

            configData.Serial.PortName = xmlPei.Serial.PortName;
            configData.Serial.BaudRate = xmlPei.Serial.BaudRate;
            configData.Serial.Parity = xmlPei.Serial.Parity;
            configData.Serial.DataBits = xmlPei.Serial.DataBits;
            configData.Serial.StopBits = xmlPei.Serial.StopBits;
            configData.Serial.Separator = xmlPei.Serial.Separator;
        }

        private void LoadVirtualTester(XmlDocument xmlDoc, VirtualTesterConfigData configData)
        {
            XmlOldVirtualTester xmlVirtual = new XmlOldVirtualTester();
            xmlVirtual.LoadConfig(xmlDoc);

            configData.ConnectDelay = xmlVirtual.ConnectDelay;
            configData.DisconnectDelay = xmlVirtual.DisconnectDelay;
            configData.InitDelay = xmlVirtual.InitDelay;
            configData.StartLotDelay = xmlVirtual.StartLotDelay;
            configData.EndLotDelay = xmlVirtual.EndLotDelay;
            configData.StartWaferDelay = xmlVirtual.StartWaferDelay;
            configData.EndWaferDelay = xmlVirtual.EndWaferDelay;
            configData.ProbeDieDelay = xmlVirtual.ProbeDieDelay;
            configData.ProbeDieFinishedDelay = xmlVirtual.ProbeDieFinishedDelay;
            configData.GetTestProgramNameDelay = xmlVirtual.GetTestProgramNameDelay;
            configData.GetTemperatureDelay = xmlVirtual.GetTemperatureDelay;
            configData.IsRandom = xmlVirtual.IsRandom;
            configData.Yield = xmlVirtual.Yield;
            configData.IsGrowing = xmlVirtual.IsGrowing;
            configData.IsInputWmxmlPath = !string.IsNullOrEmpty(xmlVirtual.InputWmxmlPath);
            configData.InputWmxmlPath = xmlVirtual.InputWmxmlPath;
        }

        private void LoadTester(XmlDocument xmlDoc, TesterConfigData configData)
        {
            XmlOldTester xmlTester = new XmlOldTester();
            xmlTester.LoadConfig(xmlDoc);

            configData.ActiveTester = xmlTester.ActiveTester;
            configData.Timeout = xmlTester.Timeout;
            configData.SimulatorEnabled = xmlTester.SimulatorEnabled;

            LoadDts(xmlDoc, configData.Dts);
            LoadEagle(xmlDoc, configData.Eagle);
            LoadFet(xmlDoc, configData.Fet);
            LoadPft(xmlDoc, configData.Pft);
            LoadTmt(xmlDoc, configData.Tmt);
            LoadKeithley(xmlDoc, configData.Keithley);
            LoadHp(xmlDoc, configData.Hp);
            LoadMaverick(xmlDoc, configData.Maverick);
            LoadPei(xmlDoc, configData.Pei);
            LoadVirtualTester(xmlDoc, configData.Virtual);
        }

        #endregion

        #region public methods

        public void Load(ConfigData configData)
        {
            if (File.Exists(configData.Config.MapperConfigFile))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(configData.Config.MapperConfigFile);

                    LoadGeneral(xmlDoc, configData.General, configData.Wmxml, configData.Dialog);
                    LoadEnvGeneral(xmlDoc, configData.EnvGeneral);
                    LoadColor(xmlDoc, configData.Color);
                    LoadEvent(xmlDoc, configData.Event);
                    LoadDir(xmlDoc, configData.Dir, configData.Wmxml);
                    LoadGenesis(xmlDoc, configData.Genesis);
                    LoadCheckin(xmlDoc, configData.Checkin);
                    LoadLotSearch(xmlDoc, configData.LotSearch);
                    LoadMethods(xmlDoc, configData.ProcessMethod);
                    LoadCustomScripts(xmlDoc, configData.CustomScript);
                    LoadNewton(xmlDoc, configData.Newton);
                    LoadRtm(xmlDoc, configData.Rtm);
                    LoadProbeInTemp(xmlDoc, configData.ProbeInTemp);

                    LoadConsecutiveFail(xmlDoc, configData.ConsecutiveFail);
                    LoadCutOff(xmlDoc, configData.Cutoff);
                    LoadKelvinDie(xmlDoc, configData.KelvinDie);
                    LoadLaserscribe(xmlDoc, configData.Laserscribe);
                    LoadIncompleteProbe(xmlDoc, configData.IncompleteProbe);
                    LoadReprobe(xmlDoc, configData.Reprobe);

                    LoadProber(xmlDoc, configData.Prober);
                    LoadTester(xmlDoc, configData.Tester);
                }
                catch (Exception ex)
                {
                    LogIt.Error("Exception in OldConfigXmlBinder.Load method:", ex);
                }
            }
        }

        public void Save(ConfigData configData)
        {
            if (File.Exists(configData.Config.MapperConfigFile))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();

                    SaveGeneral(xmlDoc, configData.General, configData.Wmxml, configData.Dialog);
                    SaveEnvGeneral(xmlDoc, configData.EnvGeneral);
                    SaveColor(xmlDoc, configData.Color);
                    SaveEvent(xmlDoc, configData.Event);
                    SaveDir(xmlDoc, configData.Dir, configData.Wmxml);
                    SaveGenesis(xmlDoc, configData.Genesis);
                    SaveCheckin(xmlDoc, configData.Checkin);
                    SaveLotSearch(xmlDoc, configData.LotSearch);
                    SaveMethods(xmlDoc, configData.ProcessMethod);
                    SaveCustomScripts(xmlDoc, configData.CustomScript);
                    SaveNewton(xmlDoc, configData.Newton);
                    SaveRtm(xmlDoc, configData.Rtm);
                    SaveProbeInTemp(xmlDoc, configData.ProbeInTemp);

                    SaveConsecutiveFail(xmlDoc, configData.ConsecutiveFail);
                    SaveCutOff(xmlDoc, configData.Cutoff);
                    SaveKelvinDie(xmlDoc, configData.KelvinDie);
                    SaveLaserscribe(xmlDoc, configData.Laserscribe);
                    SaveIncompleteProbe(xmlDoc, configData.IncompleteProbe);
                    SaveReprobe(xmlDoc, configData.Reprobe);

                    SaveProber(xmlDoc, configData.Prober);
                    SaveTester(xmlDoc, configData.Tester);

                    xmlDoc.Save(configData.Config.MapperConfigFile);
                }
                catch (Exception ex)
                {
                    LogIt.Error("Exception in OldConfigXmlBinder.Save method:", ex);
                }
            }
        }

        #endregion
    }
}
