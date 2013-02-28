using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class StructData : CollectionData
    {
        #region constructors

        public StructData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor) { }

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "struct"; }
        }

        public override bool IsStruct
        {
            get { return true; }
        }

        #endregion
    }
}
