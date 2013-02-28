using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class IntegerData : ValueData
    {
        #region constructors

        public IntegerData(ConfigType configType, string prefix, string name, string description, string editor, int defaultValue)
            : base(configType, prefix, name, description, editor, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string value)
        {
            return Convert.ToInt32(value);
        }

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "integer"; }
        }

        public int Value
        {
            get
            {
                if (currentValue != null)
                    return (int)currentValue;
                return 0;
            }
            set { SetNewValue(value); }
        }

        public int Default
        {
            get
            {
                if (defaultValue != null)
                    return (int)defaultValue;
                return 0;
            }
            set { defaultValue = value; }
        }

        #endregion
    }
}
