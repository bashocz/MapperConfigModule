using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class LongPauseEventListData
    {
        #region private field

        private string name;
        private bool enabled;
        private int reasonCode;

        #endregion

        #region constructor

        public LongPauseEventListData()
        {
            name = string.Empty;
            enabled = false;
            reasonCode = -1;
        }

        public LongPauseEventListData(string name, bool enabled, int reasonCode)
        {
            this.name = name;
            this.enabled = enabled;
            this.reasonCode = reasonCode;
        }

        #endregion

        #region public methods

        public LongPauseEventListData Copy()
        {
            LongPauseEventListData newData = new LongPauseEventListData();
            newData.Name = this.name;
            newData.Enabled = this.enabled;
            newData.ReasonCode = this.reasonCode;
            return newData;
        }
        #endregion

        #region public properties

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public int ReasonCode
        {
            get { return reasonCode; }
            set { reasonCode = value; }
        }

        #endregion
    }
}
