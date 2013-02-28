using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Self managed XmlAttribute with bool value.
    /// </summary>
    public class BooleanXmlAttribute : ValueXmlAttribute
    {
        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="defaultValue">The default value for the attribute.</param>
        public BooleanXmlAttribute(string name, bool defaultValue) : base(name, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string text)
        {
            if (text == null)
                throw new ArgumentNullException("The string value to parse the boolean value from is null.");

            text = text.Trim().ToLower();
            if (text.Equals("true"))
                return true;
            else if (text.Equals("false"))
                return false;
            else
                throw new ArgumentException("Cannot parse boolean from the value: '" + text + "'");
        }

        #endregion

        #region properties

        /// <summary>
        /// The boolean value of this attribute.
        /// </summary>
        public bool Value
        {
            get { return (bool)AttributeValue; }
            set { AttributeValue = value; }
        }

        #endregion

    }
}
