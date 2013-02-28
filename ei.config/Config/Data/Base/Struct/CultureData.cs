using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class CultureData : StructData
    {
        #region private fields

        private StringData cultureName;
        private StringData cultureCode;

        #endregion

        #region constructors

        public CultureData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.cultureName = new StringData(configType, prefix + name, "Name", "Culture name", "", "English");
            AddChild(this.cultureName);

            this.cultureCode = new StringData(configType, prefix + name, "Name", "Culture code", "", "en-US");
            AddChild(this.cultureCode);
        }

        #endregion

        #region public methods

        public void ChangeItem(string cultureName, string cultureCode)
        {
            //BeginChange();

            this.cultureName.Value = cultureName;
            this.cultureCode.Value = cultureCode;

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public string CultureName
        {
            get { return cultureName.Value; }
        }

        public string CultureCode
        {
            get { return cultureCode.Value; }
        }

        #endregion
    }
}
