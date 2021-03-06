using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class DoubleData : ValueData
    {
        #region constructors

        public DoubleData(ConfigType configType, string prefix, string name, string description, string editor, double defaultValue)
            : base(configType, prefix, name, description, editor, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string value)
        {
            return Convert.ToDouble(value);
        }

        #endregion

        #region public properties

        public override string DataType
        {
            get { return "double"; }
        }

        public double Value
        {
            get
            {
                if (currentValue != null)
                    return (double)currentValue;
                return 0.0;
            }
            set { SetNewValue(value); }
        }

        public double Default
        {
            get
            {
                if (defaultValue != null)
                    return (double)defaultValue;
                return 0.0;
            }
            set { defaultValue = value; }
        }

        #endregion
    }
}
