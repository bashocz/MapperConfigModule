using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class ListData : CollectionData
    {
        #region private fields

        private BaseData childStruct;

        #endregion

        #region constructors

        public ListData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            childStruct = null;
        }

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "list"; }
        }

        public override bool IsList
        {
            get { return true; }
        }

        public BaseData ChildStruct
        {
            get { return childStruct; }
            set { childStruct = value; }
        }

        #endregion
    }
}
