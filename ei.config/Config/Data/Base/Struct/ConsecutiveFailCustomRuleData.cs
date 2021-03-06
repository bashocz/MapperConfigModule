using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class ConsecutiveFailCustomRuleData : StructData
    {
        #region private fields

        private BooleanData enabled;
        private IntegerData threshold;
        private StringData message;
        private StringData binListStr;

        private List<int> binList;

        #endregion

        #region constructors

        public ConsecutiveFailCustomRuleData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.enabled = new BooleanData(configType, prefix + name, "Enabled", "Enabled", "", false);
            AddChild(enabled);

            this.threshold = new IntegerData(configType, prefix + name, "Threshold", "Threshold", "", 0);
            AddChild(threshold);

            this.message = new StringData(configType, prefix + name, "Message", "Message", "", "");
            AddChild(message);

            this.binListStr = new StringData(configType, prefix + name, "BinList", "Bin list", "", "");
            AddChild(binListStr);

            binList = new List<int>();
            GetBinList(binListStr.Value);
        }

        #endregion

        #region private methods

        private List<int> GetBinList(string strList)
        {
            List<int> binList = new List<int>();

            string[] strArray = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int idx = 0; idx < strArray.Length; idx++)
            {
                int value;
                if ((int.TryParse(strArray[idx], out value)) && (value >= 0) && (value < 256))
                    binList.Add(value);
            }

            return binList;
        }

        private string GetBinStr(List<int> binList)
        {
            string strList = string.Empty;

            for (int idx = 0; idx < binList.Count; idx++)
            {
                if (idx > 0)
                    strList += ",";
                strList += binList[idx].ToString();
            }

            return strList;
        }

        #endregion

        #region public methods

        public void ChangeItem(bool enabled, int threshold, string message, List<int> binList)
        {
            //BeginChange();

            this.enabled.Value = enabled;
            this.threshold.Value = threshold;
            this.message.Value = message;
            this.binList.Clear();
            this.binList.AddRange(binList);
            this.binListStr.Value = GetBinStr(binList);

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabled.Value; }
        }

        public int Threshold
        {
            get { return threshold.Value; }
        }

        public string Message
        {
            get { return message.Value; }
        }

        public IList<int> BinList
        {
            get { return binList.AsReadOnly(); }
        }

        #endregion
    }
}
