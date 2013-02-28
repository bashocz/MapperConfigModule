using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class DefaultBinListData : ValueListData<BinData>
    //{
    //    #region constructors

    //    public DefaultBinListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override BinData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            BinData binData = new BinData(ConfigType.All, prefix, "", "", "");
    //            binData.SetData(xmlElement);

    //            if (binData.WasRead)
    //                return binData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //    }

    //    protected override string GetItemData(string offset, string prefix, BinData item)
    //    {
    //    }

    //    #endregion
    //}
}
