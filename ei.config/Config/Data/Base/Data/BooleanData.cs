using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class BooleanData : ValueData
    {
        #region constructors

        public BooleanData(ConfigType configType, string prefix, string name, string description, string editor, bool defaultValue)
            : base(configType, prefix, name, description, editor, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string value)
        {
            return Convert.ToBoolean(value);
        }

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "boolean"; }
        }

        public bool Value
        {
            get
            {
                if (currentValue != null)
                    return (bool)currentValue;
                return false;
            }
            set { SetNewValue(value); }
        }

        public bool Default
        {
            get
            {
                if (defaultValue != null)
                    return (bool)defaultValue;
                return false;
            }
            set { defaultValue = value; }
        }

        #endregion
    }
}
