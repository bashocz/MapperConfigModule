using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldDir : XmlOldBase
    {
        #region private fields

        private StringXmlElement setupDirElement;
        private StringXmlElement loggingDirElement;
        private StringXmlElement cacheDirElement;

        private EnumXmlElement<WmxmlVersion> wmxmlVersionElement;

        private EnumXmlElement<FileFormat> localFileFormatElement;
        private BooleanXmlElement localOutputWmxmlEnabledElement;
        private StringXmlElement localWmxmlDirElement;
        private StringXmlElement localTempWmxmlDirElement;
        private BooleanXmlElement localInputWmxmlEnabledElement;
        private StringXmlElement localInputWmxmlDirElement;
        private BooleanXmlElement secsChangePassBinElement;
        private IntegerXmlElement secsPassBinElement;
        private BooleanXmlElement localOutputSecsEnabledElement;
        private StringXmlElement localSecsDirElement;

        private EnumXmlElement<FileFormat> serverFileFormatElement;
        private BooleanXmlElement serverOutputWmxmlEnabledElement;
        private StringXmlElement serverOutputWmxmlDirElement;
        private StringXmlElement serverUnsentWmxmlDirElement;
        private BooleanXmlElement serverInputWmxmlEnabledElement;
        private StringXmlElement serverInputWmxmlDirElement;
        private BooleanXmlElement serverOutputSecsEnabledElement;
        private StringXmlElement serverOutputSecsDirElement;
        private StringXmlElement serverUnsentSecsDirElement;

        private EnumXmlElement<FileFormat> externalFileFormatElement;
        private BooleanXmlElement externalInputEnabledElement;
        private StringXmlElement externalInputWmxmlDirElement;
        private BooleanXmlElement externalOutputEnabledElement;
        private StringXmlElement externalOutputWmxmlDirElement;
        private StringXmlElement externalUnsentWmxmlDirElement;

        private EnumXmlElement<FileFormat> webServiceFileFormatElement;
        private BooleanXmlElement webServiceOutputEnabledElement;
        private BooleanXmlElement webServiceInputEnabledElement;
        private StringXmlElement webServicePrimaryUrlElement;
        private StringXmlElement webServiceSecondaryUrlElement;
        private StringXmlElement webServiceUnsentWmxmlDirElement;

        private StringXmlElement manualCheckFileNameElement;
        private StringXmlElement manualCheckLocalDirElement;
        private StringXmlElement manualCheckServerDirElement;

        #endregion

        #region constructors

        public XmlOldDir()
        {
            configElement = new SelfManagedXmlElement("Paths");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            setupDirElement = new StringXmlElement("Setup", "C:\\Mapper\\Setup");
            configElement.AddChild(setupDirElement);

            loggingDirElement = new StringXmlElement("Logging", "C:\\Mapper\\Log");
            configElement.AddChild(loggingDirElement);

            cacheDirElement = new StringXmlElement("Cache", "C:\\Mapper\\Cache"); // for DB events
            configElement.AddChild(cacheDirElement);


            wmxmlVersionElement = new EnumXmlElement<WmxmlVersion>("WmxmlVersion", WmxmlVersion.Wmxml1);
            configElement.AddChild(wmxmlVersionElement);


            localFileFormatElement = new EnumXmlElement<FileFormat>("LocalFileFormat", FileFormat.Zip);
            configElement.AddChild(localFileFormatElement);

            localOutputWmxmlEnabledElement = new BooleanXmlElement("LocalSaveXmlEnabled", true);
            configElement.AddChild(localOutputWmxmlEnabledElement);

            localWmxmlDirElement = new StringXmlElement("LocalXmlWaferMap", "C:\\Mapper\\Maps\\Wmxml");
            configElement.AddChild(localWmxmlDirElement);

            localTempWmxmlDirElement = new StringXmlElement("LocalTempXmlWaferMap", "C:\\Mapper\\Temp");
            configElement.AddChild(localTempWmxmlDirElement);

            localInputWmxmlEnabledElement = new BooleanXmlElement("LocalLoadXmlEnabled", true);
            configElement.AddChild(localInputWmxmlEnabledElement);

            localInputWmxmlDirElement = new StringXmlElement("LocalLoadXmlWaferMap", "C:\\Mapper\\Maps\\Wmxml");
            configElement.AddChild(localInputWmxmlDirElement);

            secsChangePassBinElement = new BooleanXmlElement("SecsChangePassBin", false);
            configElement.AddChild(secsChangePassBinElement);

            secsPassBinElement = new IntegerXmlElement("SecsPassBin", 0);
            configElement.AddChild(secsPassBinElement);

            localOutputSecsEnabledElement = new BooleanXmlElement("LocalSaveSecsEnabled", true);
            configElement.AddChild(localOutputSecsEnabledElement);

            localSecsDirElement = new StringXmlElement("LocalSecsWaferMap", "C:\\Mapper\\Maps");
            configElement.AddChild(localSecsDirElement);


            serverFileFormatElement = new EnumXmlElement<FileFormat>("ServerFileFormat", FileFormat.Zip);
            configElement.AddChild(serverFileFormatElement);

            serverOutputWmxmlEnabledElement = new BooleanXmlElement("ServerSaveXmlEnabled", true);
            configElement.AddChild(serverOutputWmxmlEnabledElement);

            serverOutputWmxmlDirElement = new StringXmlElement("ServerSaveXmlWaferMap", "C:\\Mapper\\Server");
            configElement.AddChild(serverOutputWmxmlDirElement);

            serverUnsentWmxmlDirElement = new StringXmlElement("LocalUnsentXmlWaferMap", "C:\\Mapper\\UnsentMaps\\Wmxml");
            configElement.AddChild(serverUnsentWmxmlDirElement);

            serverInputWmxmlEnabledElement = new BooleanXmlElement("ServerLoadXmlEnabled", true);
            configElement.AddChild(serverInputWmxmlEnabledElement);

            serverInputWmxmlDirElement = new StringXmlElement("ServerLoadXmlWaferMap", "C:\\Mapper\\Server");
            configElement.AddChild(serverInputWmxmlDirElement);

            serverOutputSecsEnabledElement = new BooleanXmlElement("ServerSaveSecsEnabled", true);
            configElement.AddChild(serverOutputSecsEnabledElement);

            serverOutputSecsDirElement = new StringXmlElement("ServerSaveSecsWaferMap", "C:\\Mapper\\Server");
            configElement.AddChild(serverOutputSecsDirElement);

            serverUnsentSecsDirElement = new StringXmlElement("LocalUnsentSecsWaferMap", "C:\\Mapper\\UnsentMaps");
            configElement.AddChild(serverUnsentSecsDirElement);


            webServiceFileFormatElement = new EnumXmlElement<FileFormat>("WebServiceFileFormat", FileFormat.Zip);
            configElement.AddChild(webServiceFileFormatElement);

            webServiceOutputEnabledElement = new BooleanXmlElement("WebServiceEnabled", false);
            configElement.AddChild(webServiceOutputEnabledElement);

            webServiceInputEnabledElement = new BooleanXmlElement("WebServiceInputEnabled", false);
            configElement.AddChild(webServiceInputEnabledElement);

            webServicePrimaryUrlElement = new StringXmlElement("WebServicePrimaryUrl", "");
            configElement.AddChild(webServicePrimaryUrlElement);

            webServiceSecondaryUrlElement = new StringXmlElement("WebServiceSecondaryUrl", "");
            configElement.AddChild(webServiceSecondaryUrlElement);

            webServiceUnsentWmxmlDirElement = new StringXmlElement("WebServiceUnsentWmxmlWaferMap", "C:\\Mapper\\UnsentMaps\\WebService");
            configElement.AddChild(webServiceUnsentWmxmlDirElement);


            externalFileFormatElement = new EnumXmlElement<FileFormat>("ExternalFileFormat", FileFormat.Xml);
            configElement.AddChild(externalFileFormatElement);

            externalInputEnabledElement = new BooleanXmlElement("ExternalLoadEnabled", false);
            configElement.AddChild(externalInputEnabledElement);

            externalInputWmxmlDirElement = new StringXmlElement("ExternalLoadXmlWaferMap", "C:\\Mapper\\ExternalMaps");
            configElement.AddChild(externalInputWmxmlDirElement);

            externalOutputEnabledElement = new BooleanXmlElement("ExternalSaveEnabled", false);
            configElement.AddChild(externalOutputEnabledElement);

            externalOutputWmxmlDirElement = new StringXmlElement("ExternalSaveXmlWaferMap", "C:\\Mapper\\ExternalMaps");
            configElement.AddChild(externalOutputWmxmlDirElement);

            externalUnsentWmxmlDirElement = new StringXmlElement("ExternalUnsentXmlWaferMap", "C:\\Mapper\\ExternalUnsentMaps");
            configElement.AddChild(externalUnsentWmxmlDirElement);


            manualCheckFileNameElement = new StringXmlElement("ManualCheckFileName", "lotlist.txt");
            configElement.AddChild(manualCheckFileNameElement);

            manualCheckLocalDirElement = new StringXmlElement("ManualCheckLocal", "C:\\Mapper\\CheckManual");
            configElement.AddChild(manualCheckLocalDirElement);

            manualCheckServerDirElement = new StringXmlElement("ManualCheckServer", "C:\\Mapper\\CheckManual");
            configElement.AddChild(manualCheckServerDirElement);
        }

        #endregion

        #region public properties

        public string SetupDir
        {
            get { return setupDirElement.Value; }
            set { setupDirElement.Value = value; }
        }

        public string LoggingDir
        {
            get { return loggingDirElement.Value; }
            set { loggingDirElement.Value = value; }
        }

        public string CacheDir
        {
            get { return cacheDirElement.Value; }
            set { cacheDirElement.Value = value; }
        }

        public WmxmlVersion WmxmlVersion
        {
            get { return wmxmlVersionElement.Value; }
            set { wmxmlVersionElement.Value = value; }
        }

        public FileFormat LocalFileFormat
        {
            get { return localFileFormatElement.Value; }
            set { localFileFormatElement.Value = value; }
        }

        public bool LocalOutputWmxmlEnabled
        {
            get { return localOutputWmxmlEnabledElement.Value; }
            set { localOutputWmxmlEnabledElement.Value = value; }
        }

        public string LocalWmxmlDir
        {
            get { return localWmxmlDirElement.Value; }
            set { localWmxmlDirElement.Value = value; }
        }

        public string LocalTempWmxmlDir
        {
            get { return localTempWmxmlDirElement.Value; }
            set { localTempWmxmlDirElement.Value = value; }
        }

        public bool LocalInputWmxmlEnabled
        {
            get { return localInputWmxmlEnabledElement.Value; }
            set { localInputWmxmlEnabledElement.Value = value; }
        }

        public string LocalInputWmxmlDir
        {
            get { return localInputWmxmlDirElement.Value; }
            set { localInputWmxmlDirElement.Value = value; }
        }

        public bool SecsChangePassBin
        {
            get { return secsChangePassBinElement.Value; }
            set { secsChangePassBinElement.Value = value; }
        }

        public int SecsPassBin
        {
            get { return secsPassBinElement.Value; }
            set { secsPassBinElement.Value = value; }
        }

        public bool LocalOutputSecsEnabled
        {
            get { return localOutputSecsEnabledElement.Value; }
            set { localOutputSecsEnabledElement.Value = value; }
        }

        public string LocalSecsDir
        {
            get { return localSecsDirElement.Value; }
            set { localSecsDirElement.Value = value; }
        }

        public FileFormat ServerFileFormat
        {
            get { return serverFileFormatElement.Value; }
            set { serverFileFormatElement.Value = value; }
        }

        public bool ServerOutputWmxmlEnabled
        {
            get { return serverOutputWmxmlEnabledElement.Value; }
            set { serverOutputWmxmlEnabledElement.Value = value; }
        }

        public string ServerOutputWmxmlDir
        {
            get { return serverOutputWmxmlDirElement.Value; }
            set { serverOutputWmxmlDirElement.Value = value; }
        }

        public string ServerUnsentWmxmlDir
        {
            get { return serverUnsentWmxmlDirElement.Value; }
            set { serverUnsentWmxmlDirElement.Value = value; }
        }

        public bool ServerInputWmxmlEnabled
        {
            get { return serverInputWmxmlEnabledElement.Value; }
            set { serverInputWmxmlEnabledElement.Value = value; }
        }

        public string ServerInputWmxmlDir
        {
            get { return serverInputWmxmlDirElement.Value; }
            set { serverInputWmxmlDirElement.Value = value; }
        }

        public bool ServerOutputSecsEnabled
        {
            get { return serverOutputSecsEnabledElement.Value; }
            set { serverOutputSecsEnabledElement.Value = value; }
        }

        public string ServerOutputSecsDir
        {
            get { return serverOutputSecsDirElement.Value; }
            set { serverOutputSecsDirElement.Value = value; }
        }

        public string ServerUnsentSecsDir
        {
            get { return serverUnsentSecsDirElement.Value; }
            set { serverUnsentSecsDirElement.Value = value; }
        }

        public FileFormat WebServiceFileFormat
        {
            get { return webServiceFileFormatElement.Value; }
            set { webServiceFileFormatElement.Value = value; }
        }

        public bool WebServiceOutputEnabled
        {
            get { return webServiceOutputEnabledElement.Value; }
            set { webServiceOutputEnabledElement.Value = value; }
        }

        public bool WebServiceInputEnabled
        {
            get { return webServiceInputEnabledElement.Value; }
            set { webServiceInputEnabledElement.Value = value; }
        }

        public string WebServicePrimaryUrl
        {
            get { return webServicePrimaryUrlElement.Value; }
            set { webServicePrimaryUrlElement.Value = value; }
        }

        public string WebServiceSecondaryUrl
        {
            get { return webServiceSecondaryUrlElement.Value; }
            set { webServiceSecondaryUrlElement.Value = value; }
        }

        public string WebServiceUnsentWmxmlDir
        {
            get { return webServiceUnsentWmxmlDirElement.Value; }
            set { webServiceUnsentWmxmlDirElement.Value = value; }
        }

        public FileFormat ExternalFileFormat
        {
            get { return externalFileFormatElement.Value; }
            set { externalFileFormatElement.Value = value; }
        }

        public bool ExternalInputEnabled
        {
            get { return externalInputEnabledElement.Value; }
            set { externalInputEnabledElement.Value = value; }
        }

        public string ExternalInputWmxmlDir
        {
            get { return externalInputWmxmlDirElement.Value; }
            set { externalInputWmxmlDirElement.Value = value; }
        }

        public bool ExternalOutputEnabled
        {
            get { return externalOutputEnabledElement.Value; }
            set { externalOutputEnabledElement.Value = value; }
        }

        public string ExternalOutputWmxmlDir
        {
            get { return externalOutputWmxmlDirElement.Value; }
            set { externalOutputWmxmlDirElement.Value = value; }
        }

        public string ExternalUnsentWmxmlDir
        {
            get { return externalUnsentWmxmlDirElement.Value; }
            set { externalUnsentWmxmlDirElement.Value = value; }
        }

        public string ManualCheckFileName
        {
            get { return manualCheckFileNameElement.Value; }
            set { manualCheckFileNameElement.Value = value; }
        }

        public string ManualCheckLocalDir
        {
            get { return manualCheckLocalDirElement.Value; }
            set { manualCheckLocalDirElement.Value = value; }
        }

        public string ManualCheckServerDir
        {
            get { return manualCheckServerDirElement.Value; }
            set { manualCheckServerDirElement.Value = value; }
        }

        #endregion
    }
}
