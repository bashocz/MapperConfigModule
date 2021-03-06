using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class PassData : StructData
    {
        #region private fields

        private StringData id;
        private StringData previousStr;
        private StringData actualStr;

        private List<int> previousList;
        private List<int> actualList;

        #endregion

        #region constructors

        public PassData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.id = new StringData(configType, prefix + name, "Id", "ID", "", "");
            AddChild(this.id);

            this.previousStr = new StringData(configType, prefix + name, "PreviousList", "Pass's previous bin value list", "", "");
            AddChild(this.previousStr);

            this.actualStr = new StringData(configType, prefix + name, "ActualList", "Pass's actual bin value list", "", "");
            AddChild(this.actualStr);

            previousList = new List<int>();
            actualList = new List<int>();

            NewList();
        }

        #endregion

        #region private methods

        private void NewList()
        {
            previousList.Clear();
            string[] strArray = previousStr.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int idx = 0; idx < strArray.Length; idx++)
            {
                int value;
                if ((int.TryParse(strArray[idx], out value)) && (value >= 0) && (value < 256))
                    previousList.Add(value);
            }

            actualList.Clear();
            strArray = actualStr.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            for (int idx = 0; idx < strArray.Length; idx++)
            {
                int value;
                if ((int.TryParse(strArray[idx], out value)) && (value >= 0) && (value < 256))
                    actualList.Add(value);
            }
        }

        private void NewString()
        {
            previousStr.Value = string.Empty;
            for (int idx = 0; idx < previousList.Count; idx++)
            {
                if (idx > 0)
                    previousStr.Value += ",";
                previousStr.Value += previousList[idx].ToString();
            }

            actualStr.Value = string.Empty;
            for (int idx = 0; idx < actualList.Count; idx++)
            {
                if (idx > 0)
                    actualStr.Value += ",";
                actualStr.Value += actualList[idx].ToString();
            }
        }

        #endregion

        #region public methods

        public void ChangeItem(string id, List<int> previousList, List<int> actualList)
        {
            //BeginChange();

            this.id.Value = id;
            this.previousList.Clear();
            this.previousList.AddRange(previousList);
            this.actualList.Clear();
            this.actualList.AddRange(actualList);

            NewString();

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public string Id
        {
            get { return id.Value; }
        }

        public IList<int> PreviousList
        {
            get { return previousList.AsReadOnly(); }
        }

        public IList<int> ActualList
        {
            get { return actualList.AsReadOnly(); }
        }

        #endregion
    }
}
