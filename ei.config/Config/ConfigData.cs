using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EI.Config
{
    public class ConfigData
    {
        #region private fields

        private string wsConfigVersion = "3.2.6"; // only default value... real value is defined in AssemblyInfo.cs

        private readonly List<IBaseConfigData> _childList;

        private readonly ConfigConfigData _configConfigData;
        private readonly GeneralConfigData _generalConfigData;
        private readonly DirConfigData _dirConfigData;
        private readonly EnvGeneralConfigData _envGeneralConfigData;
        private readonly ColorConfigData _colorConfigData;
        private readonly DialogConfigData _dialogConfigData;
        private readonly EventConfigData _eventConfigData;
        private readonly WmxmlConfigData _wmxmlConfigData;
        private readonly GenesisConfigData _genesisConfigData;
        private readonly CheckinConfigData _checkinConfigData;
        private readonly LotSearchConfigData _lotSearchConfigData;
        private readonly ProcessMethodConfigData _processMethodConfigData;
        private readonly CustomScriptConfigData _customScriptConfigData;
        private readonly NewtonConfigData _newtonConfigData;
        private readonly RtmConfigData _rtmConfigData;
        private readonly ProbeInTempConfigData _probeInTempConfigData;
        private readonly HotKeysConfigData _hotKeysConfigData;

        private readonly ConsecutiveFailConfigData _consecutiveFailConfigData;
        private readonly CutoffConfigData _cutoffConfigData;
        private readonly KelvinDieConfigData _kelvinDieConfigData;
        private readonly LaserscribeConfigData _laserscribeConfigData;
        private readonly ReprobeConfigData _reprobeConfigData;
        private readonly IncompleteProbeConfigData _incompleteProbeConfigData;
        private readonly ShiftedAlignmentConfigData _shiftedAlignmentConfigData;

        private readonly ProberConfigData _proberConfigData;
        private readonly TesterConfigData _testerConfigData;

        private readonly LotInfoConfigData _lotInfoConfigData;

        private readonly ConfigCache _configCache;

        #endregion

        #region constructors

        public ConfigData(string startupDir)
        {
            _childList = new List<IBaseConfigData>();

            DirectoryInfo di = new DirectoryInfo(startupDir);
            string rootMapperDir = di.Parent.FullName;

            _configConfigData = new ConfigConfigData(startupDir);
            _generalConfigData = new GeneralConfigData();
            _dirConfigData = new DirConfigData(rootMapperDir);
            _envGeneralConfigData = new EnvGeneralConfigData();
            _colorConfigData = new ColorConfigData();
            _dialogConfigData = new DialogConfigData();
            _eventConfigData = new EventConfigData(rootMapperDir);
            _wmxmlConfigData = new WmxmlConfigData(rootMapperDir);
            _genesisConfigData = new GenesisConfigData();
            _checkinConfigData = new CheckinConfigData();
            _lotSearchConfigData = new LotSearchConfigData();
            _processMethodConfigData = new ProcessMethodConfigData();
            _customScriptConfigData = new CustomScriptConfigData();
            _newtonConfigData = new NewtonConfigData(rootMapperDir);
            _rtmConfigData = new RtmConfigData(rootMapperDir);
            _probeInTempConfigData = new ProbeInTempConfigData();
            _hotKeysConfigData = new HotKeysConfigData();

            _consecutiveFailConfigData = new ConsecutiveFailConfigData();
            _cutoffConfigData = new CutoffConfigData();
            _kelvinDieConfigData = new KelvinDieConfigData();
            _laserscribeConfigData = new LaserscribeConfigData();
            _reprobeConfigData = new ReprobeConfigData();
            _incompleteProbeConfigData = new IncompleteProbeConfigData();
            _shiftedAlignmentConfigData = new ShiftedAlignmentConfigData();

            _proberConfigData = new ProberConfigData();
            _testerConfigData = new TesterConfigData();

            _lotInfoConfigData = new LotInfoConfigData();

            _childList.Add(_configConfigData as IBaseConfigData);
            _childList.Add(_generalConfigData as IBaseConfigData);
            _childList.Add(_wmxmlConfigData as IBaseConfigData);
            _childList.Add(_envGeneralConfigData as IBaseConfigData);
            _childList.Add(_colorConfigData as IBaseConfigData);
            _childList.Add(_dialogConfigData as IBaseConfigData);
            _childList.Add(_eventConfigData as IBaseConfigData);
            _childList.Add(_dirConfigData as IBaseConfigData);
            _childList.Add(_genesisConfigData as IBaseConfigData);
            _childList.Add(_checkinConfigData as IBaseConfigData);
            _childList.Add(_lotSearchConfigData as IBaseConfigData);
            _childList.Add(_processMethodConfigData as IBaseConfigData);
            _childList.Add(_customScriptConfigData as IBaseConfigData);
            _childList.Add(_newtonConfigData as IBaseConfigData);
            _childList.Add(_rtmConfigData as IBaseConfigData);
            _childList.Add(_probeInTempConfigData as IBaseConfigData);
            _childList.Add(_hotKeysConfigData as IBaseConfigData);

            _childList.Add(_consecutiveFailConfigData as IBaseConfigData);
            _childList.Add(_cutoffConfigData as IBaseConfigData);
            _childList.Add(_kelvinDieConfigData as IBaseConfigData);
            _childList.Add(_laserscribeConfigData as IBaseConfigData);
            _childList.Add(_reprobeConfigData as IBaseConfigData);
            _childList.Add(_incompleteProbeConfigData as IBaseConfigData);
            _childList.Add(_shiftedAlignmentConfigData as IBaseConfigData);
            _childList.Add(_proberConfigData as IBaseConfigData);
            _childList.Add(_testerConfigData as IBaseConfigData);

            _childList.Add(_lotInfoConfigData as IBaseConfigData);

            _configCache = new ConfigCache(this);
        }

        #endregion

        #region private methods

        private void LogXmlInfo(XmlDocument xmlDoc)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    xmlDoc.Save(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    using (StreamReader stream = new StreamReader(ms))
                    {
                        while (!stream.EndOfStream)
                            LogIt.Info(stream.ReadLine());
                    }
                }
            }
            catch { }
        }

        private bool LoadConfig(ConfigType configType, XmlDocument xmlDoc)
        {
            string cfgType = "UNKNOWN";
            switch (configType)
            {
                case ConfigType.Mapper:
                    cfgType = "MAPPER";
                    break;
                case ConfigType.Lot:
                    cfgType = "LOT";
                    break;
                case ConfigType.User:
                    cfgType = "USER";
                    break;
            }

            if (xmlDoc != null)
            {
                LogIt.Info("Received '" + cfgType + "' configuration xml stream.");
                LogXmlInfo(xmlDoc);
                LogIt.Info("End of " + cfgType + " configuration xml stream.");

                LogIt.Info("Mapper is starting to parse '" + cfgType + "' configuration...");
                ConfigXmlBinder configReader = new ConfigXmlBinder();
                if ((xmlDoc != null) && (configReader.Load(this, xmlDoc)))
                {
                    LogIt.Info("Mapper successfully parsed '" + cfgType + "' configuration...");
                    return true;
                }
                else
                    LogIt.Error("Mapper didn't successfully parse '" + cfgType + "' configuration...");
            }
            else
                LogIt.Error("Received '" + cfgType + "' configuration xml stream is empty and will not be parsing...");

            CheckSetting();

            return false;
        }

        private void CheckSetting()
        {
            foreach (IBaseConfigData child in _childList)
                child.CheckSetting(this);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Indicates whether main local config file is in startup directory.
        /// </summary>
        public bool IsMain()
        {
            if (File.Exists(_configConfigData.MainLocalConfigFile))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_configConfigData.MainLocalConfigFile);
                    if (xmlDoc.DocumentElement.Name.Equals("localSetting"))
                        return true;
                }
                catch { }
            }
            return false;
        }

        public bool LoadMain()
        {
            MainConfigXmlBinder configReader = new MainConfigXmlBinder();
            return configReader.Load(this);
        }

        public void SaveMain()
        {
            MainConfigXmlBinder configWriter = new MainConfigXmlBinder();
            configWriter.Save(this);
        }

        public bool LoadOldMapper()
        {
            OldConfigXmlBinder configReader = new OldConfigXmlBinder();
            configReader.Load(this);
            CheckSetting();
            // to-do
            return true;
        }

        public void SaveOldMapper()
        {
            OldConfigXmlBinder configWriter = new OldConfigXmlBinder();
            configWriter.Save(this);
        }

        public bool LoadNewMapper(XmlDocument xmlDoc)
        {
            bool configured = false;
            try
            {
                // configurate data structures
                configured = LoadConfig(ConfigType.Mapper, xmlDoc);
                // save to cache file for offline configuration
                _configCache.StoreMapperConfig(xmlDoc);
            }
            catch { }

            return configured;
        }

        public bool LoadCacheMapper()
        {
            try
            {
                // load from cache file for offline configuration
                XmlDocument xmlDoc = _configCache.RestoreMapperConfig();
                // configurate data structures
                if (xmlDoc != null)
                    return LoadConfig(ConfigType.Mapper, xmlDoc);
            }
            catch { }
            return false;
        }

        public bool LoadNewLot(XmlDocument xmlDoc)
        {
            bool configured = false;
            try
            {
                // configurate data structures
                configured = LoadConfig(ConfigType.Lot, xmlDoc);
                // save to cache file for offline configuration
                _configCache.StoreLotConfig(xmlDoc);
            }
            catch { }
            return configured;
        }

        public bool LoadCacheLot(string deviceId)
        {
            try
            {
                // load from cache file for offline configuration
                XmlDocument xmlDoc = _configCache.RestoreLotConfig(deviceId);
                // configurate data structures
                if (xmlDoc != null)
                    return LoadConfig(ConfigType.Lot, xmlDoc);
            }
            catch { }
            return false;
        }

        public IList<string> GetCacheLotList()
        {
            return _configCache.GetLotConfigList();
        }

        public void BeginUpdate()
        {
            for (int idx = 0; idx < _childList.Count; idx++)
                _childList[idx].BeginUpdate();
        }

        public void DiscardUpdate()
        {
            for (int idx = 0; idx < _childList.Count; idx++)
                _childList[idx].DiscardUpdate();
        }

        public void EndUpdate()
        {
            for (int idx = 0; idx < _childList.Count; idx++)
                _childList[idx].EndUpdate(true);
        }

        public void SetDefault()
        {
            for (int idx = 0; idx < _childList.Count; idx++)
                _childList[idx].SetDefault();
        }

        //public void ToLog()
        //{
        //    for (int idx = 0; idx < _childList.Count; idx++)
        //    {
        //        List<string> logInfo = _childList[idx].ToLog("");
        //        for (int line = 0; line < logInfo.Count; line++)
        //            LogIt.Info(logInfo[line]);
        //    }
        //}

        #endregion

        #region public properties

        public string WsConfigVersion
        {
            get { return wsConfigVersion; }
            set { wsConfigVersion = value; }
        }

        public ConfigConfigData Config
        {
            get { return _configConfigData; }
        }

        public GeneralConfigData General
        {
            get { return _generalConfigData; }
        }

        public DirConfigData Dir
        {
            get { return _dirConfigData; }
        }

        public EnvGeneralConfigData EnvGeneral
        {
            get { return _envGeneralConfigData; }
        }

        public ColorConfigData Color
        {
            get { return _colorConfigData; }
        }

        public DialogConfigData Dialog
        {
            get { return _dialogConfigData; }
        }

        public EventConfigData Event
        {
            get { return _eventConfigData; }
        }

        public WmxmlConfigData Wmxml
        {
            get { return _wmxmlConfigData; }
        }

        public GenesisConfigData Genesis
        {
            get { return _genesisConfigData; }
        }

        public CheckinConfigData Checkin
        {
            get { return _checkinConfigData; }
        }

        public LotSearchConfigData LotSearch
        {
            get { return _lotSearchConfigData; }
        }

        public ProcessMethodConfigData ProcessMethod
        {
            get { return _processMethodConfigData; }
        }

        public CustomScriptConfigData CustomScript
        {
            get { return _customScriptConfigData; }
        }

        public NewtonConfigData Newton
        {
            get { return _newtonConfigData; }
        }

        public RtmConfigData Rtm
        {
            get { return _rtmConfigData; }
        }

        public ProbeInTempConfigData ProbeInTemp
        {
            get { return _probeInTempConfigData; }
        }

        public HotKeysConfigData HotKeys
        {
            get { return _hotKeysConfigData; }
        }

        public ProberConfigData Prober
        {
            get { return _proberConfigData; }
        }

        public TesterConfigData Tester
        {
            get { return _testerConfigData; }
        }

        public ConsecutiveFailConfigData ConsecutiveFail
        {
            get { return _consecutiveFailConfigData; }
        }

        public CutoffConfigData Cutoff
        {
            get { return _cutoffConfigData; }
        }

        public KelvinDieConfigData KelvinDie
        {
            get { return _kelvinDieConfigData; }
        }

        public LaserscribeConfigData Laserscribe
        {
            get { return _laserscribeConfigData; }
        }

        public ReprobeConfigData Reprobe
        {
            get { return _reprobeConfigData; }
        }

        public IncompleteProbeConfigData IncompleteProbe
        {
            get { return _incompleteProbeConfigData; }
        }
        public ShiftedAlignmentConfigData ShiftedAlignment
        {
            get { return _shiftedAlignmentConfigData; }
        }

        public LotInfoConfigData LotInfo
        {
            get { return _lotInfoConfigData; }
        }

        public ConfigCache Cache
        {
            get { return _configCache; }
        }

        #endregion
    }
}
