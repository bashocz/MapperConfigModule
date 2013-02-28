using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class LaserscribeFormatData : StructData
    {
        #region private fields

        private BooleanData enabled;
        private StringData mask;

        #endregion

        #region constructors

        public LaserscribeFormatData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.enabled = new BooleanData(configType, prefix + name, "Enabled", "Enabled", "", false);
            AddChild(this.enabled);

            this.mask = new StringData(configType, prefix + name, "Mask", "Mask", "", "");
            AddChild(this.mask);
        }

        #endregion

        #region public methods

        public void ChangeItem(bool enabled, string mask)
        {
            //BeginChange();

            this.enabled.Value = enabled;
            this.mask.Value = mask;

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabled.Value; }
        }

        public string Mask
        {
            get { return mask.Value; }
        }

        #endregion
    }
}
