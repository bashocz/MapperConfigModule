using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Self managed XmlAttribute with string value.
    /// </summary>
    public class StringXmlAttribute : ValueXmlAttribute
    {
        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the attribute.</param>
        /// <param name="defaultValue">The default value for the attribute.</param>
        public StringXmlAttribute(string name, string defaultValue) : base(name, defaultValue) { }

        #endregion

        #region protected methods

        protected override object ParseValue(string text)
        {
            return text;
        }

        #endregion

        #region properties

        /// <summary>
        /// The string value of this attribute.
        /// </summary>
        public string Value
        {
            get { return (AttributeValue as string); }
            set { AttributeValue = value; }
        }

        #endregion

    }
}
