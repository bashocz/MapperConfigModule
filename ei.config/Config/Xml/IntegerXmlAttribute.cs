using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Self managed XmlAttribute with integer value.
    /// </summary>
    public class IntegerXmlAttribute : ValueXmlAttribute
    {
        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="defaultValue">The default value for the attribute.</param>
        public IntegerXmlAttribute(string name, int defaultValue) : base(name, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string text)
        {
            return Convert.ToInt32(text);
        }

        #endregion

        #region properties

        /// <summary>
        /// The integer value of this attribute.
        /// </summary>
        public int Value
        {
            get { return (int)AttributeValue; }
            set { AttributeValue = value; }
        }

        #endregion

    }
}
