using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace EI.Config
{
    public class EventConfigData : BaseConfigData<EventConfigData>
    {
        #region private fields

        private readonly string rootMapperDir;

        private bool enabled;

        private int sendingCount;
        private int writeVerificationCount;

        private string eventDir;
        private string rejectedEventDir;

        private LongPauseEventConfigData lpEventConfigData;

        #endregion

        #region constructor

        public EventConfigData(string rootMapperDir)
            : base() 
        {
            this.rootMapperDir = rootMapperDir;

            lpEventConfigData = new LongPauseEventConfigData();
            childList.Add(lpEventConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = true;
            sendingCount = 50;
            writeVerificationCount = 3;
            eventDir = Path.Combine(rootMapperDir, "Events");
            rejectedEventDir = Path.Combine(rootMapperDir, "Events\\Rejected");

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public int WriteVerificationCount
        {
            get { return writeVerificationCount; }
            set { SetValue(ref writeVerificationCount, value); }
        }

        public int SendingCount
        {
            get { return sendingCount; }
            set { SetValue(ref sendingCount, value); }
        }

        public string EventDir
        {
            get { return eventDir; }
            set { SetValue(ref eventDir, value); }
        }

        public string RejectedEventDir
        {
            get { return rejectedEventDir; }
            set { SetValue(ref rejectedEventDir, value); }
        }

        public LongPauseEventConfigData LpEventConfigData
        {
            get { return lpEventConfigData; }
        }

        #endregion
    }
}
