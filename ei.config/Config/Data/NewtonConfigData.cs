using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EI.Config
{
    public class NewtonConfigData : BaseConfigData<NewtonConfigData>
    {
        #region private fields

        private readonly string rootMapperDir;

        private WmxmlVersion wmxmlVersion;
        private FileFormat fileFormat;
        private bool enabled;
        private string newtonFile;
        private string wmxmlOutputDir;
        private string statusFile;
        private int timeout;

        #endregion

        #region constructor

        public NewtonConfigData(string rootMapperDir)
            : base()
        {
            this.rootMapperDir = rootMapperDir;
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            wmxmlVersion = WmxmlVersion.Wmxml1;
            fileFormat = FileFormat.Xml;
            enabled = false;
            newtonFile = Path.Combine(rootMapperDir, "Gatekeeper\\NewtUtils.bat");
            wmxmlOutputDir = Path.Combine(rootMapperDir, "Gatekeeper\\Maps");
            statusFile = Path.Combine(rootMapperDir, "Gatekeeper\\Status.txt");
            timeout = 600;
        }

        #endregion

        #region public properties

        public WmxmlVersion WmxmlVersion
        {
            get { return wmxmlVersion; }
            set { SetEnumValue(ref wmxmlVersion, value); }
        }

        public FileFormat FileFormat
        {
            get { return fileFormat; }
            set { SetEnumValue(ref fileFormat, value); }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public string NewtonFile
        {
            get { return newtonFile; }
            set { SetValue(ref newtonFile, value); }
        }

        public string WmxmlOutputDir
        {
            get { return wmxmlOutputDir; }
            set { SetValue(ref wmxmlOutputDir, value); }
        }

        public string StatusFile
        {
            get { return statusFile; }
            set { SetValue(ref statusFile, value); }
        }

        public int Timeout
        {
            get { return timeout; }
            set { SetValue(ref timeout, value); }
        }


        #endregion
    }
}
