using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace EI.Config
{
    public class RtmConfigData : BaseConfigData<RtmConfigData>
    {
        #region private fields

        private readonly string rootMapperDir;

        private bool enabled;
        private string rtmDir;
        private string agentName;
        private string agentCmd;
        private int watchPeriod;

        #endregion

        #region constructors

        public RtmConfigData(string rootMapperDir)
            : base()
        {
            this.rootMapperDir = rootMapperDir;
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            rtmDir = Path.Combine(rootMapperDir, "Program");
            agentName = "FileWatcher";
            agentCmd = Path.Combine(rootMapperDir, "Program\\FileWatcher.exe");
            watchPeriod = 0;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public string RtmDir
        {
            get { return rtmDir; }
            set { SetValue(ref rtmDir, value); }
        }

        public string AgentName
        {
            get { return agentName; }
            set { SetValue(ref agentName, value); }
        }

        public string AgentCmd
        {
            get { return agentCmd; }
            set { SetValue(ref agentCmd, value); }
        }

        public int WatchPeriod
        {
            get { return watchPeriod; }
            set { SetValue(ref watchPeriod, value); }
        }

        #endregion
    }
}
