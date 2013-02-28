using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace EI.Config
{
    /// <summary>
    /// Self managed XmlElement with double value.
    /// </summary>
    public class DoubleXmlElement : ValueXmlElement
    {
        #region private fields

        private double minimum = Double.MinValue;
        private double maximum = Double.MaxValue;

        #endregion

        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="defaultValue">The default double value for the element.</param>
        public DoubleXmlElement(string name, double defaultValue) : base(name, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string text)
        {
            double value = Convert.ToDouble(text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            CheckRange(value);
            return value;
        }

        protected override string ValueToString(object value)
        {
            if (value == null)
                return string.Empty;
            return ((double)value).ToString(CultureInfo.CreateSpecificCulture("en"));
        }

        #endregion

        #region private methods

        /// <summary>
        /// Checks if the value is within min and max range.
        /// </summary>
        /// <param name="value">The value to check.</param>
        private void CheckRange(double value)
        {
            if (value < minimum)
            {
                throw new FormatException("parsed value " + value + " < minimum of " + minimum);
            }
            if (value > maximum)
            {
                throw new FormatException("parsed value " + value + " > maximum of " + maximum);
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// The double value of the element.
        /// </summary>
        public double Value
        {
            get { return (double)ElementValue; }
            set
            {
                CheckRange(value);
                ElementValue = value;
            }
        }

        /// <summary>
        /// Minimum allowed value for the value.
        /// </summary>
        public double Minimum
        {
            get { return minimum; }
            set { minimum = value; }
        }

        /// <summary>
        /// Maximum allowed value for the value.
        /// </summary>
        public double Maximum
        {
            get { return maximum; }
            set { maximum = value; }
        }

        #endregion
    }
}
