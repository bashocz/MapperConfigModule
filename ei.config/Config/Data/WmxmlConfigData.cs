using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace EI.Config
{
    public class WmxmlConfigData : BaseConfigData<WmxmlConfigData>
    {
        #region private fields

        private readonly string rootMapperDir;

        private bool alwaysSaveWaferMaps;

        private WmxmlVersion localWmxmlVersion;
        private FileFormat localFileFormat;
        private bool localOutputWmxmlEnabled;
        private bool localInputWmxmlEnabled;
        private string localOutputWmxmlDir;
        private string localInputWmxmlDir;
        private string localTempWmxmlDir;

        private WmxmlVersion serverWmxmlVersion;
        private FileFormat serverFileFormat;
        private bool serverOutputWmxmlEnabled;
        private bool serverInputWmxmlEnabled;
        private string serverOutputWmxmlDir;
        private string serverInputWmxmlDir;
        private string serverUnsentWmxmlDir;

        private WmxmlVersion externalWmxmlVersion;
        private FileFormat externalFileFormat;
        private bool externalOutputEnabled;
        private bool externalInputEnabled;
        private string externalOutputWmxmlDir;
        private string externalInputWmxmlDir;
        private string externalUnsentWmxmlDir;

        private WmxmlVersion vaultWmxmlVersion;
        private FileFormat vaultFileFormat;
        private bool vaultOutputEnabled;
        private bool vaultInputEnabled;
        private string vaultUnsentWmxmlDir;
        private int vaultTimeoutSeconds;
        private List<string> vaultUrlList;

        private bool secsChangePassBin;
        private int secsPassBin;
        private bool localOutputSecsEnabled;
        private string localOutputSecsDir;
        private bool serverOutputSecsEnabled;
        private string serverOutputSecsDir;
        private string serverUnsentSecsDir;

        #endregion

        #region constructors

        public WmxmlConfigData(string rootMapperDir)
            : base()
        {
            this.rootMapperDir = rootMapperDir;
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            alwaysSaveWaferMaps = false;

            localWmxmlVersion = WmxmlVersion.Wmxml1;
            localFileFormat = FileFormat.Zip;
            localInputWmxmlEnabled = true;
            localInputWmxmlDir = Path.Combine(rootMapperDir, "Maps\\Wmxml");
            localOutputWmxmlEnabled = true;
            localOutputWmxmlDir = Path.Combine(rootMapperDir, "Maps\\Wmxml");
            localTempWmxmlDir = Path.Combine(rootMapperDir, "Temp");

            serverWmxmlVersion = WmxmlVersion.Wmxml1;
            serverFileFormat = FileFormat.Zip;
            serverInputWmxmlEnabled = true;
            serverInputWmxmlDir = Path.Combine(rootMapperDir, "Server\\Wmxml");
            serverOutputWmxmlEnabled = true;
            serverOutputWmxmlDir = Path.Combine(rootMapperDir, "Server\\Wmxml");
            serverUnsentWmxmlDir = Path.Combine(rootMapperDir, "UnsentMaps\\Wmxml");

            externalWmxmlVersion = WmxmlVersion.Wmxml1;
            externalFileFormat = FileFormat.Xml;
            externalInputEnabled = false;
            externalInputWmxmlDir = Path.Combine(rootMapperDir, "External\\InputMaps");
            externalOutputEnabled = false;
            externalOutputWmxmlDir = Path.Combine(rootMapperDir, "External\\OutputMaps");
            externalUnsentWmxmlDir = Path.Combine(rootMapperDir, "External\\UnsentMaps");

            vaultWmxmlVersion = WmxmlVersion.Wmxml1;
            vaultFileFormat = FileFormat.Xml;
            vaultOutputEnabled = false;
            vaultInputEnabled = false;
            vaultUnsentWmxmlDir = Path.Combine(rootMapperDir, "UnsentMaps\\WebService");
            vaultTimeoutSeconds = 60;
            vaultUrlList = new List<string>();

            secsChangePassBin = false;
            secsPassBin = 0;
            localOutputSecsEnabled = true;
            localOutputSecsDir = Path.Combine(rootMapperDir, "Maps\\Secs");
            serverOutputSecsEnabled = true;
            serverOutputSecsDir = Path.Combine(rootMapperDir, "Server\\Secs");
            serverUnsentSecsDir = Path.Combine(rootMapperDir, "UnsentMaps\\Secs");
        }

        public void ClearWebServiceUrlList()
        {
            ClearList(vaultUrlList);
        }

        public void AddToWebServiceUrlList(string webServiceUrl)
        {
            AddToList(vaultUrlList, webServiceUrl);
        }

        public void AddRangeToWebServiceUrlList(List<string> webServiceUrlRangeList)
        {
            AddRangeToList(vaultUrlList, webServiceUrlRangeList);
        }

        #endregion

        #region properties

        public bool AlwaysSaveWaferMaps
        {
            get { return alwaysSaveWaferMaps; }
            set { SetValue(ref alwaysSaveWaferMaps, value); }
        }

        public WmxmlVersion LocalWmxmlVersion
        {
            get { return localWmxmlVersion; }
            set { SetEnumValue(ref localWmxmlVersion, value); }
        }

        public FileFormat LocalFileFormat
        {
            get { return localFileFormat; }
            set { SetEnumValue(ref localFileFormat, value); }
        }

        public bool LocalOutputWmxmlEnabled
        {
            get { return localOutputWmxmlEnabled; }
            set { SetValue(ref localOutputWmxmlEnabled, value); }
        }

        public bool LocalInputWmxmlEnabled
        {
            get { return localInputWmxmlEnabled; }
            set { SetValue(ref localInputWmxmlEnabled, value); }
        }

        public string LocalOutputWmxmlDir
        {
            get { return localOutputWmxmlDir; }
            set { SetValue(ref localOutputWmxmlDir, value); }
        }

        public string LocalInputWmxmlDir
        {
            get { return localInputWmxmlDir; }
            set { SetValue(ref localInputWmxmlDir, value); }
        }

        public string LocalTempWmxmlDir
        {
            get { return localTempWmxmlDir; }
            set { SetValue(ref localTempWmxmlDir, value); }
        }

        public WmxmlVersion ServerWmxmlVersion
        {
            get { return serverWmxmlVersion; }
            set { SetEnumValue(ref serverWmxmlVersion, value); }
        }

        public FileFormat ServerFileFormat
        {
            get { return serverFileFormat; }
            set { SetEnumValue(ref serverFileFormat, value); }
        }

        public bool ServerOutputWmxmlEnabled
        {
            get { return serverOutputWmxmlEnabled; }
            set { SetValue(ref serverOutputWmxmlEnabled, value); }
        }

        public bool ServerInputWmxmlEnabled
        {
            get { return serverInputWmxmlEnabled; }
            set { SetValue(ref serverInputWmxmlEnabled, value); }
        }

        public string ServerOutputWmxmlDir
        {
            get { return serverOutputWmxmlDir; }
            set { SetValue(ref serverOutputWmxmlDir, value); }
        }

        public string ServerInputWmxmlDir
        {
            get { return serverInputWmxmlDir; }
            set { SetValue(ref serverInputWmxmlDir, value); }
        }

        public string ServerUnsentWmxmlDir
        {
            get { return serverUnsentWmxmlDir; }
            set { SetValue(ref serverUnsentWmxmlDir, value); }
        }

        public WmxmlVersion ExternalWmxmlVersion
        {
            get { return externalWmxmlVersion; }
            set { SetEnumValue(ref externalWmxmlVersion, value); }
        }

        public FileFormat ExternalFileFormat
        {
            get { return externalFileFormat; }
            set { SetEnumValue(ref externalFileFormat, value); }
        }

        public bool ExternalOutputEnabled
        {
            get { return externalOutputEnabled; }
            set { SetValue(ref externalOutputEnabled, value); }
        }

        public bool ExternalInputEnabled
        {
            get { return externalInputEnabled; }
            set { SetValue(ref externalInputEnabled, value); }
        }

        public string ExternalOutputWmxmlDir
        {
            get { return externalOutputWmxmlDir; }
            set { SetValue(ref externalOutputWmxmlDir, value); }
        }

        public string ExternalInputWmxmlDir
        {
            get { return externalInputWmxmlDir; }
            set { SetValue(ref externalInputWmxmlDir, value); }
        }

        public string ExternalUnsentWmxmlDir
        {
            get { return externalUnsentWmxmlDir; }
            set { SetValue(ref externalUnsentWmxmlDir, value); }
        }

        public WmxmlVersion VaultWmxmlVersion
        {
            get { return vaultWmxmlVersion; }
            set { SetEnumValue(ref vaultWmxmlVersion, value); }
        }

        public FileFormat VaultFileFormat
        {
            get { return vaultFileFormat; }
            set { SetEnumValue(ref vaultFileFormat, value); }
        }

        public bool VaultOutputEnabled
        {
            get { return vaultOutputEnabled; }
            set { SetValue(ref vaultOutputEnabled, value); }
        }

        public bool VaultInputEnabled
        {
            get { return vaultInputEnabled; }
            set { SetValue(ref vaultInputEnabled, value); }
        }

        public string VaultUnsentWmxmlDir
        {
            get { return vaultUnsentWmxmlDir; }
            set { SetValue(ref vaultUnsentWmxmlDir, value); }
        }

        public int VaultTimeoutSeconds
        {
            get { return vaultTimeoutSeconds; }
            set { vaultTimeoutSeconds = value; }
        }

        public IList<string> VaultUrlList
        {
            get { return vaultUrlList.AsReadOnly(); }
        }

        public string WebServicePrimaryUrl
        {
            get
            {
                if (vaultUrlList.Count > 0)
                    return vaultUrlList[0];
                return string.Empty;
            }
        }

        public string WebServiceSecondaryUrl
        {
            get
            {
                if (vaultUrlList.Count > 1)
                    return vaultUrlList[1];
                return string.Empty;
            }
        }

        public bool SecsChangePassBin
        {
            get { return secsChangePassBin; }
            set { SetValue(ref secsChangePassBin, value); }
        }

        public int SecsPassBin
        {
            get { return secsPassBin; }
            set { SetValue(ref secsPassBin, value); }
        }

        public bool LocalOutputSecsEnabled
        {
            get { return localOutputSecsEnabled; }
            set { SetValue(ref localOutputSecsEnabled, value); }
        }

        public string LocalOutputSecsDir
        {
            get { return localOutputSecsDir; }
            set { SetValue(ref localOutputSecsDir, value); }
        }

        public bool ServerOutputSecsEnabled
        {
            get { return serverOutputSecsEnabled; }
            set { SetValue(ref serverOutputSecsEnabled, value); }
        }

        public string ServerOutputSecsDir
        {
            get { return serverOutputSecsDir; }
            set { SetValue(ref serverOutputSecsDir, value); }
        }

        public string ServerUnsentSecsDir
        {
            get { return serverUnsentSecsDir; }
            set { SetValue(ref serverUnsentSecsDir, value); }
        }

        #endregion
    }
}
