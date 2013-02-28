using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldEvent : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private IntegerXmlElement writeVerificationCountElement;
        private IntegerXmlElement sendingCountElement;
        private StringXmlElement eventDirElement;
        private StringXmlElement rejectedEventDirElement;
        private LongPauseEventXmlElement longPauseEventElement;

        #endregion

        #region constructors

        public XmlOldEvent()
        {
            configElement = new SelfManagedXmlElement("Event");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", true);
            configElement.AddChild(enabledElement);

            writeVerificationCountElement = new IntegerXmlElement("WriteVerificationCount", 3);
            configElement.AddChild(writeVerificationCountElement);

            sendingCountElement = new IntegerXmlElement("SendingCount", 50);
            configElement.AddChild(sendingCountElement);

            eventDirElement = new StringXmlElement("EventDir", "C:\\Mapper\\Events");
            configElement.AddChild(eventDirElement);

            rejectedEventDirElement = new StringXmlElement("EventRejectedDir", "C:\\Mapper\\Events\\Rejected");
            configElement.AddChild(rejectedEventDirElement);

            longPauseEventElement = new LongPauseEventXmlElement("LongPauseEvents");
            configElement.AddChild(longPauseEventElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public int WriteVerificationCount
        {
            get { return writeVerificationCountElement.Value; }
            set { writeVerificationCountElement.Value = value; }
        }

        public int SendingCount
        {
            get { return sendingCountElement.Value; }
            set { sendingCountElement.Value = value; }
        }

        public string EventDir
        {
            get { return eventDirElement.Value; }
            set { eventDirElement.Value = value; }
        }

        public string RejectedEventDir
        {
            get { return rejectedEventDirElement.Value; }
            set { rejectedEventDirElement.Value = value; }
        }

        public List<LongPauseEventListData> LongPauseEvents
        {
            get { return longPauseEventElement.Values; }
            set { longPauseEventElement.Values = value; }
        }

        #endregion
    }
}
