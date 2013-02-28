using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldRtm : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private StringXmlElement rtmDirElement;
        private StringXmlElement agentNameElement;
        private StringXmlElement agentCmdElement;
        private IntegerXmlElement watchPeriodElement;

        #endregion

        #region constructors

        public XmlOldRtm()
        {
            configElement = new SelfManagedXmlElement("Rtm");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(enabledElement);

            rtmDirElement = new StringXmlElement("RtmDir", "C:\\Mapper\\Program");
            configElement.AddChild(rtmDirElement);

            agentNameElement = new StringXmlElement("AgentName", "FileWatcher");
            configElement.AddChild(agentNameElement);

            agentCmdElement = new StringXmlElement("AgentCmd", "C:\\Mapper\\Program\\FileWatcher.exe");
            configElement.AddChild(agentCmdElement);

            watchPeriodElement = new IntegerXmlElement("WatchPeriod", 0);
            configElement.AddChild(watchPeriodElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public string RtmDir
        {
            get { return rtmDirElement.Value; }
            set { rtmDirElement.Value = value; }
        }

        public string AgentName
        {
            get { return agentNameElement.Value; }
            set { agentNameElement.Value = value; }
        }

        public string AgentCmd
        {
            get { return agentCmdElement.Value; }
            set { agentCmdElement.Value = value; }
        }

        public int WatchPeriod
        {
            get { return watchPeriodElement.Value; }
            set { watchPeriodElement.Value = value; }
        }

        #endregion
    }
}
