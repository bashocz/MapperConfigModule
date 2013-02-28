using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class LaserscribeLotFilterData : StructData
    {
        #region private fields

        private StringData mask;
        private BooleanData checksum;

        #endregion

        #region constructors

        public LaserscribeLotFilterData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.mask = new StringData(configType, prefix + name, "Mask", "Lot ID mask", "", "");
            AddChild(this.mask);

            this.checksum = new BooleanData(configType, prefix + name, "Checksum", "Laserscribe has semi checksum", "", false);
            AddChild(this.checksum);
        }

        #endregion

        #region public methods

        public void ChangeItem(string mask, bool checksum)
        {
            //BeginChange();

            this.mask.Value = mask;
            this.checksum.Value = checksum;

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public string Mask
        {
            get { return mask.Value; }
        }

        public bool Checksum
        {
            get { return checksum.Value; }
        }

        #endregion
    }
}
