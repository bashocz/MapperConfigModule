using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class KelvinDieConfigData : BaseConfigData<KelvinDieConfigData>
    {
        #region private fields

        private bool enabled;
        private bool reprobeFirst;
        private List<int> binList;

        #endregion

        #region constructors

        public KelvinDieConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region private method

        private void SetBinList(string binStr)
        {
            List<int> binList = new List<int>();
            string[] binStrings = binStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string binString in binStrings)
                binList.Add(Convert.ToInt32(binString));

            ClearBinList();
            AddRangeToBinList(binList);
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            reprobeFirst = false;
            binList = new List<Int32>();
        }

        public void ClearBinList()
        {
            ClearList(binList);
        }

        public void AddToBinList(Int32 binValue)
        {
            AddToList(binList, binValue);
        }

        public void AddRangeToBinList(List<Int32> binValueList)
        {
            AddRangeToList(binList, binValueList);
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public bool ReprobeFirst
        {
            get { return reprobeFirst; }
            set { SetValue(ref reprobeFirst, value); }
        }

        public IList<int> BinList
        {
            get { return binList.AsReadOnly(); }
        }

        public string BinString
        {
            get
            {
                string result = string.Empty;
                for (int idx = 0; idx < binList.Count; idx++)
                {
                    if (idx > 0)
                        result += ",";
                    result += binList[idx].ToString();
                }
                return result;
            }
            set { SetBinList(value); }
        }

        #endregion
    }
}
