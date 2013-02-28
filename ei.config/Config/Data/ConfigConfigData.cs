using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace EI.Config
{
    public class ConfigConfigData : BaseConfigData<ConfigConfigData>
    {
        #region private fields

        private readonly string mapperDir;

        private string mapperId;
        private string proberId;
        private string testerId;

        private bool wsEnabled;
        private bool newConfigEnabled;

        private string startupDir;
        private string mainLocalConfigFile;
        private string mapperConfigFile;
        private string lotConfigFile;

        private int wsTimeoutSeconds;
        private List<string> wsAddressList;
        private int wsOnlineCheckTimeoutSeconds;

        #endregion

        #region constructor

        public ConfigConfigData(string mapperDir)
            : base()
        {
            this.mapperDir = mapperDir;
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            mapperId = proberId = testerId = string.Empty;

            newConfigEnabled = wsEnabled = false;

            startupDir = mapperDir;
            mainLocalConfigFile = Path.Combine(mapperDir, "local.config");
            mapperConfigFile = Path.Combine(mapperDir, "mapper.config");
            lotConfigFile = Path.Combine(mapperDir, "lot.config"); ;

            wsTimeoutSeconds = 60;
            wsOnlineCheckTimeoutSeconds = 3;
            wsAddressList = new List<string>();
        }

        public void ClearWsAddressList()
        {
            ClearList(wsAddressList);
        }

        public void AddToWsAddressList(string wsAddress)
        {
            AddToList(wsAddressList, wsAddress);
        }

        public void AddRangeToWsAddressList(List<string> wsAddressRangeList)
        {
            AddRangeToList(wsAddressList, wsAddressRangeList);
        }

        public void ShakeWsAddressList()
        {
            ShakeList(wsAddressList);
        }

        #endregion

        #region properties

        public string MapperId
        {
            get { return mapperId; }
            set { SetValue(ref mapperId, value); }
        }

        public string ProberId
        {
            get { return proberId; }
            set { SetValue(ref proberId, value); }
        }

        public string TesterId
        {
            get { return testerId; }
            set { SetValue(ref testerId, value); }
        }

        public bool WsEnabled
        {
            get { return wsEnabled; }
            set { SetValue(ref wsEnabled, value); }
        }

        public bool NewConfigEnabled
        {
            get { return newConfigEnabled; }
            set { SetValue(ref newConfigEnabled, value); }
        }

        public string StartupDir
        {
            get { return startupDir; }
            set { SetValue(ref startupDir, value); }
        }

        public string MainLocalConfigFile
        {
            get { return mainLocalConfigFile; }
            set { SetValue(ref mainLocalConfigFile, value); }
        }

        public string MapperConfigFile
        {
            get { return mapperConfigFile; }
            set { SetValue(ref mapperConfigFile, value); }
        }

        public string LotConfigFile
        {
            get { return lotConfigFile; }
            set { SetValue(ref lotConfigFile, value); }
        }

        public int WsTimeoutSeconds
        {
            get { return wsTimeoutSeconds; }
            set { SetValue(ref wsTimeoutSeconds, value); }
        }

        public int WsOnlineCheckTimeoutSeconds
        {
            get { return wsOnlineCheckTimeoutSeconds; }
            set { SetValue(ref wsOnlineCheckTimeoutSeconds, value); }
        }

        public IList<string> WsAddressList
        {
            get { return wsAddressList.AsReadOnly(); }
        }

        #endregion
    }
}
