using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    /// <summary>
    /// Self managed XML element with value.
    /// </summary>
    public abstract class ValueXmlElement : SelfManagedXmlElement
    {
        #region private fields

        /// <summary>
        /// The value of the element.
        /// </summary>
        private object elementValue;

        /// <summary>
        /// The default value of the element if the element can't be read.
        /// </summary>
        private object defaultValue;

        #endregion

        #region constructors

        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="name">The name of the element.</param>
        /// <param name="defaultValue">The default value for the element.</param>
        protected ValueXmlElement(string name, object defaultValue)
            : base(name)
        {
            this.elementValue = defaultValue;
            this.defaultValue = defaultValue;
        }

        #endregion

        #region public methods

        public override XmlNode WriteTo(XmlNode parent)
        {
            XmlNode element = base.WriteTo(parent);
            element.InnerText = ValueToString(elementValue);
            return element;
        }

        public override XmlNode ReadFrom(XmlNode parent)
        {
            XmlNode element = base.ReadFrom(parent);

            if (OutOfSync)
            {
                ElementValue = defaultValue;
            }
            else
            {
                try
                {
                    ElementValue = ParseValue(element.InnerText);
                    OutOfSync = false;
                }
                catch (Exception)
                {
                    ElementValue = defaultValue;
                    OutOfSync = true;
                }
            }

            return element;
        }

        /// <summary>
        /// Returns human readable representation of the instance.
        /// </summary>
        /// <returns>The instance's string representation.</returns>
        public override string ToString()
        {
            return GetType().FullName + "{ name: " + name + ", value: " + ValueToString(elementValue) + " }";
        }

        #endregion

        #region protected methods

        /// <summary>
        /// Parses the element's value from the inner text of the element.
        /// Can throw exceptions when can not parse the value.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <returns>The parsed value.</returns>
        protected abstract object ParseValue(string text);

        /// <summary>
        /// Returns the value's string representation to be used in XML.
        /// This is the inversion method for the <code>ParseValue</code> method.
        /// Passing the result of this method to the <code>ParseValue</code> method
        /// should obtain back the equal object.
        /// </summary>
        /// <param name="value">The value to be converted to string.</param>
        /// <returns>The string value of the given value.</returns>
        protected virtual string ValueToString(object value)
        {
            if (value == null)
                return string.Empty;
            return value.ToString();
        }

        #endregion

        #region properties

        /// <summary>
        /// The value of the element.
        /// </summary>
        protected object ElementValue
        {
            get { return elementValue; }
            set
            {
                if (!object.Equals(elementValue, value))
                {
                    elementValue = value;
                    OutOfSync = true;
                }
            }
        }

        #endregion

    }
}
