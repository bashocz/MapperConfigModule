using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Self managed XmlElement with string value. String value is mandatory.
    /// </summary>
    public class StringXmlElement : ValueXmlElement
    {
        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="defaultValue">The default string value for the element.</param>
        public StringXmlElement(string name, string defaultValue) : base(name, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string text)
        {
            return text;
        }

        protected override string ValueToString(object value)
        {
            if (value == null)
                return string.Empty;
            return value.ToString();
        }

        #endregion

        #region properties

        /// <summary>
        /// The string value of the element.
        /// </summary>
        public string Value
        {
            get { return (string)ElementValue; }
            set { ElementValue = value; }
        }

        #endregion
    }
}
