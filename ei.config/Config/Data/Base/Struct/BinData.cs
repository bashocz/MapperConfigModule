using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class BinData : StructData
    {
        #region private fields

        private IntegerData value;
        private BooleanData good;
        private BooleanData reprobable;
        private BooleanData inkable;

        private Bin bin;

        #endregion

        #region constructors

        public BinData(ConfigType configType, string prefix, string name, string description, string editor)
            : base(configType, prefix, name, description, editor)
        {
            this.value = new IntegerData(configType, prefix + name, "Value", "Value", "", 0);
            AddChild(this.value);

            this.good = new BooleanData(configType, prefix + name, "Good", "Die is good", "", false);
            AddChild(this.good);

            this.reprobable = new BooleanData(configType, prefix + name, "Reprobed", "Die is reprobable", "", false);
            AddChild(this.reprobable);

            this.inkable = new BooleanData(configType, prefix + name, "Inked", "Die is inkable", "", false);
            AddChild(this.inkable);

            NewBin();
        }

        #endregion

        #region private methods

        private void NewBin()
        {
            bin = new Bin(value.Value, good.Value, reprobable.Value, inkable.Value);
        }

        #endregion

        #region public methods

        public void ChangeItem(int value, bool good, bool reprobable, bool inkable)
        {
            //BeginChange();

            this.value.Value = value;
            this.good.Value = good;
            this.reprobable.Value = reprobable;
            this.inkable.Value = inkable;

            NewBin();

            //EndChange();
            DataChanged();
        }

        #endregion

        #region public properties

        public Bin Bin
        {
            get { return bin; }
        }

        #endregion
    }
}
