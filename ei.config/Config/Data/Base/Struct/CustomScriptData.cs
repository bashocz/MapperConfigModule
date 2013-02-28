using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class CustomScriptData : StructData
    {
        #region private fields

        private StringData scriptName;
        private BooleanData enabled;
        private StringData command;
        private BooleanData waitToComplete;
        private BooleanData openInConsole;

        private ProcessEvent processEvent;

        #endregion

        #region constructors

        public CustomScriptData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.scriptName = new StringData(configType, prefix + name, "Name", "Script name", "", "");
            AddChild(this.scriptName);

            this.enabled = new BooleanData(configType, prefix + name, "Enabled", "Enabled", "", false);
            AddChild(this.enabled);

            this.command = new StringData(configType, prefix + name, "Command", "Command", "", "");
            AddChild(this.command);

            this.waitToComplete = new BooleanData(configType, prefix + name, "WaitToComplete", "Wait to complete", "", false);
            AddChild(this.waitToComplete);

            this.openInConsole = new BooleanData(configType, prefix + name, "OpenInConsole", "Open in console", "", false);
            AddChild(this.openInConsole);

            NewScript();
        }

        #endregion

        #region private methods

        private void NewScript()
        {
            processEvent = ProcessEvent.NoAction;
            try
            {
                processEvent = (ProcessEvent)Enum.Parse(typeof(ProcessEvent), scriptName.Value, true);
            }
            catch { }
        }

        private void NewEvent()
        {
            scriptName.Value = processEvent.ToString();
        }

        #endregion

        #region public methods

        public void ChangeItem(string scriptName, bool enabled, string command, bool waitToComplete, bool openInConsole)
        {
            //BeginChange();

            this.scriptName.Value = scriptName;
            this.enabled.Value = enabled;
            this.command.Value = command;
            this.waitToComplete.Value = waitToComplete;
            this.openInConsole.Value = openInConsole;

            NewScript();

            //EndChange();
            DataChanged();
        }

        public void ChangeItem(ProcessEvent processEvent, bool enabled, string command, bool waitToComplete, bool openInConsole)
        {
            //BeginChange();

            this.processEvent = processEvent;
            this.enabled.Value = enabled;
            this.command.Value = command;
            this.waitToComplete.Value = waitToComplete;
            this.openInConsole.Value = openInConsole;

            NewEvent();

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public ProcessEvent ProcessEvent
        {
            get { return processEvent; }
        }

        public bool Enabled
        {
            get { return enabled.Value; }
        }

        public string Command
        {
            get { return command.Value; }
        }

        public bool WaitToComplete
        {
            get { return waitToComplete.Value; }
        }

        public bool OpenInConsole
        {
            get { return openInConsole.Value; }
        }

        #endregion
    }
}
