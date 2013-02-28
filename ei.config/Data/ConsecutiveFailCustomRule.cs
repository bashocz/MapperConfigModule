using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class ConsecutiveFailCustomRule
    {
        #region private fields

        private readonly bool enabled;
        private readonly int threshold;
        private readonly string message;
        private readonly List<int> binList;

        #endregion

        #region constructors

        public ConsecutiveFailCustomRule(bool enabled, int threshold, string message, List<int> binList)
        {
            this.enabled = enabled;
            this.threshold = threshold;
            this.message = message;
            this.binList = new List<int>(binList);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabled; }
        }

        public int Threshold
        {
            get { return threshold; }
        }

        public string Message
        {
            get { return message; }
        }

        public List<int> BinList
        {
            get { return binList; }
        }

        #endregion
    }
}
