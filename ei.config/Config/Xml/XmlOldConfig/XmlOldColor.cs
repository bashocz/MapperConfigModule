using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldColor : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement themeElement;
        private ColoresXmlElement coloresElement;

        #endregion

        #region constructors

        public XmlOldColor()
        {
            configElement = new SelfManagedXmlElement("FontsAndColors");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            themeElement = new SelfManagedXmlElement("ThemesValue");
            themeElement.ClearAllChildren = true;
            configElement.AddChild(themeElement);

            coloresElement = new ColoresXmlElement("Custom");
            themeElement.AddChild(coloresElement);
        }

        #endregion

        #region public properties

        public List<DrawProperty> DrawPropertyList
        {
            get { return coloresElement.Values; }
            set { coloresElement.Values = value; }
        }

        #endregion
    }
}
