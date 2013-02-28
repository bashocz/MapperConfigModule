using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class GroupData<T> : CollectionData where T : class
    {
        #region constructors

        public GroupData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            dataChangedDelegate = DataChanged;
        }

        #endregion

        #region private methods

        private void FireEvent()
        {
            ConfigChangedDelegate configChanged = ConfigChanged;
            if (configChanged != null)
                configChanged(this as T);
            Changed = false;
        }

        protected override void DataChanged()
        {
            if ((fireEvent == 0) && (Changed))
                FireEvent();
        }

        #endregion

        #region public event

        public delegate void ConfigChangedDelegate(T configData);
        public event ConfigChangedDelegate ConfigChanged;

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "struct"; }
        }

        public override bool IsGroup
        {
            get { return true; }
        }

        #endregion
    }
}
