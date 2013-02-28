using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Script to be executed on certain process events.
    /// </summary>
    public class CustomScript
    {
        #region private fields

        private bool enabled;

        private string command;

        private bool waitForCompletion;

        private bool openInConsole;

        private ProcessEvent processEvent;

        #endregion

        #region public properties

        /// <summary>
        /// If execution of this script is enabled or not.
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// The command to execute along with it arguments.
        /// Can contain substitution marks.
        /// </summary>
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        /// <summary>
        /// Whether to suspend Mapper execution until the script is finished.
        /// </summary>
        public bool WaitForCompletion
        {
            get { return waitForCompletion; }
            set { waitForCompletion = value; }
        }

        /// <summary>
        /// Whether to open console window for script execution.
        /// </summary>
        public bool OpenInConsole
        {
            get { return openInConsole; }
            set { openInConsole = value; }
        }

        /// <summary>
        /// The event on which occurence this script should be executed.
        /// </summary>
        public ProcessEvent ProcessEvent
        {
            get { return processEvent; }
            set { processEvent = value; }
        }

        /// <summary>
        /// Extracts executable file name from the command.
        /// </summary>
        public string Filename
        {
            get
            {
                if (command != null)
                {
                    return command.Split(' ')[0];
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion
    }
}
