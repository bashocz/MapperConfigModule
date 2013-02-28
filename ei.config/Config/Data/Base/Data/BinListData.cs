using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class BinListData : ValueData
    {
        #region constructors

        public BinListData(ConfigType configType, string prefix, string name, string description, string editor, List<int> defaultValue)
            : base(configType, prefix, name, description, editor, null)
        {
            this.currentValue = new List<int>();
            this.defaultValue = new List<int>();
            if ((defaultValue != null) && (defaultValue.Count > 0))
            {
                (this.currentValue as List<int>).AddRange(defaultValue);
                (this.defaultValue as List<int>).AddRange(defaultValue);
            }
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

        #region protected methods

        protected override object ParseValue(string value)
        {
            return GetBinList(value);
        }

        #endregion

        #region public methods

        public virtual void ClearList()
        {
            (currentValue as List<int>).Clear();
            hasValue = true;
            changed = true;
            DataChanged();
        }

        public virtual void AddToList(int value)
        {
            (currentValue as List<int>).Add(value);
            hasValue = true;
            changed = true;
            DataChanged();
        }

        public virtual void AddRangeToList(List<int> valueList)
        {
            (currentValue as List<int>).AddRange(valueList);
            hasValue = true;
            changed = true;
            DataChanged();
        }

        public virtual void UpdateList(List<int> valueList)
        {
            (currentValue as List<int>).Clear();
            (currentValue as List<int>).AddRange(valueList);
            hasValue = true;
            changed = true;
            DataChanged();
        }

        public override string GetData(string offset, ConfigType configType)
        {
            if (((this.configType & configType) != ConfigType.None) && hasValue)
                return offset + BeginTarget() + GetBinStr(currentValue as List<int>) + EndTarget() + Environment.NewLine;
            return string.Empty;
        }

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "string"; }
        }

        public IList<int> Value
        {
            get { return (currentValue as List<int>).AsReadOnly(); }
        }

        public IList<int> Default
        {
            get { return (defaultValue as List<int>).AsReadOnly(); }
        }

        #endregion
    }
}
