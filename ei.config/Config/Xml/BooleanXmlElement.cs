using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Self managed XmlElement with boolean value.
    /// </summary>
    public class BooleanXmlElement : ValueXmlElement
    {

        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="defaultValue">The default boolean value for the element.</param>
        public BooleanXmlElement(string name, bool defaultValue) : base(name, defaultValue) { }

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
        /// The boolean value of the element.
        /// </summary>
        public bool Value
        {
            get { return (bool)ElementValue; }
            set { ElementValue = value; }
        }

        #endregion
    }
}
