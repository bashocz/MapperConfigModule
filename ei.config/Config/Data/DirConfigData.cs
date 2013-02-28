using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace EI.Config
{
    public class DirConfigData : BaseConfigData<DirConfigData>
    {
        #region private fields

        private readonly string rootMapperDir;

        private string setupDir;
        private string loggingDir;
        private string cacheDir;
        private string offlineLotConfigCacheDir;

        
        private string manualCheckFileName;
        private string manualCheckLocalDir;
        private string manualCheckServerDir;

        #endregion

        #region constructors

        public DirConfigData(string rootMapperDir)
            : base()
        {
            this.rootMapperDir = rootMapperDir;
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            setupDir = Path.Combine(rootMapperDir, "Setup");
            loggingDir = Path.Combine(rootMapperDir, "Log");
            cacheDir = Path.Combine(rootMapperDir, "Cache");
            offlineLotConfigCacheDir=Path.Combine(rootMapperDir,"Cache\\LotConfig");
            manualCheckFileName = "lotlist.txt";
            manualCheckLocalDir = Path.Combine(rootMapperDir, "CheckManual");
            manualCheckServerDir = Path.Combine(rootMapperDir, "CheckManual");
        }

        #endregion

        #region properties

        public string SetupDir
        {
            get { return setupDir; }
            set { SetValue(ref setupDir, value); }
        }

        public string LoggingDir
        {
            get { return loggingDir; }
            set { SetValue(ref loggingDir, value); }
        }

        public string CacheDir
        {
            get { return cacheDir; }
            set { SetValue(ref cacheDir, value); }
        }

        public string ManualCheckFileName
        {
            get { return manualCheckFileName; }
            set { SetValue(ref manualCheckFileName, value); }
        }

        public string ManualCheckLocalDir
        {
            get { return manualCheckLocalDir; }
            set { SetValue(ref manualCheckLocalDir, value); }
        }

        public string ManualCheckServerDir
        {
            get { return manualCheckServerDir; }
            set { SetValue(ref manualCheckServerDir, value); }
        }

        public string DtdFileName
        {
            get { return Constants.FileNameDtdControlMap; }
        }

        public string ControlMapFileName
        {
            get { return Constants.FileNameXmlControlMap; }
        }

        public string CacheFileName
        {
            get { return Constants.FileNameCache; }
        }

        public string AuthorizationCacheFileName
        {
            get { return Constants.FileNameAuthorizationCache; }
        }

        public string OfflineLotConfigCacheDir
        {
            get { return offlineLotConfigCacheDir; }
            set { offlineLotConfigCacheDir = value; }
        }
        #endregion
    }
}
