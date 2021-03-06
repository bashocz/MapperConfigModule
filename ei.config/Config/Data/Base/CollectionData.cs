using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public abstract class CollectionData : BaseData
    {
        #region private fields

        private readonly List<BaseData> childList;

        #endregion

        #region constructors

        protected CollectionData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            childList = new List<BaseData>();
        }

        #endregion

        #region public methods

        public void AddChild(BaseData child)
        {
            child.SetDataChanged(dataChangedDelegate);
            childList.Add(child);
        }

        public override void SetDataChanged(DataChangedDelegate dataChanged)
        {
            dataChangedDelegate = dataChanged;
            for (int idx = 0; idx < childList.Count; idx++)
                childList[idx].SetDataChanged(dataChanged);
        }

        public override void BeginUpdate()
        {
            base.BeginUpdate();
            for (int idx = 0; idx < childList.Count; idx++)
                childList[idx].BeginUpdate();
        }

        public override void EndUpdate()
        {
            for (int idx = 0; idx < childList.Count; idx++)
                childList[idx].EndUpdate();
            base.EndUpdate();
        }

        public override string GetTemplate(string offset, ConfigType configType)
        {
            string result = string.Empty;

            if ((this.configType & configType) != ConfigType.None)
            {
                string childResult = string.Empty;
                for (int idx = 0; idx < childList.Count; idx++)
                    childResult += childList[idx].GetTemplate(offset + "  ", configType);

                if (string.IsNullOrEmpty(childResult))
                {
                    result += offset + "<Item name=\"" + FullName + "\" ";
                    result += "datatype=\"" + DataType + "\" ";
                    result += "description=\"" + Description + "\">" + Environment.NewLine;
                    result += childResult;
                    result += offset + "</Item>" + Environment.NewLine;
                }
            }

            return result;
        }

        public override string GetData(string offset, ConfigType configType)
        {
            string result = string.Empty;

            if ((this.configType & configType) != ConfigType.None)
            {
                if (childList.Count > 0)
                {
                    string childResult = string.Empty;
                    for (int idx = 0; idx < childList.Count; idx++)
                        childResult += childList[idx].GetData(offset + "  ", configType);

                    if (string.IsNullOrEmpty(childResult))
                    {
                        result += offset + BeginTarget() + Environment.NewLine;
                        result += childResult;
                        result += offset + EndTarget() + Environment.NewLine;
                    }
                }
                else
                    result += offset + EmptyTarget() + Environment.NewLine;
            }

            return result;
        }

        public override void SetData(XmlDocument xmlDoc)
        {
            for (int idx = 0; idx < childList.Count; idx++)
                childList[idx].SetData(xmlDoc);
        }

        public override void CurrentAsDefault()
        {
            for (int idx = 0; idx < childList.Count; idx++)
                childList[idx].CurrentAsDefault();
        }

        public override void RevertToDefault()
        {
            for (int idx = 0; idx < childList.Count; idx++)
                childList[idx].RevertToDefault();
        }

        #endregion

        #region public properties

        public virtual bool IsList
        {
            get { return false; }
        }

        public virtual bool IsStruct
        {
            get { return false; }
        }

        public virtual bool IsGroup
        {
            get { return false; }
        }

        public override bool Changed
        {
            get
            {
                bool changed = false;
                for (int idx = 0; idx < childList.Count; idx++)
                    changed |= childList[idx].Changed;
                return changed;
            }
            set
            {
                for (int idx = 0; idx < childList.Count; idx++)
                    childList[idx].Changed = value;
            }
        }

        public override bool HasValue
        {
            get { return false; }
        }

        public override bool WasRead
        {
            get
            {
                bool wasRead = false;
                for (int idx = 0; idx < childList.Count; idx++)
                    wasRead |= childList[idx].WasRead;
                return wasRead;
            }
        }

        #endregion
    }
}
