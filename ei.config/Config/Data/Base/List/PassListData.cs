using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class PassListData : ValueListData<PassData>
    //{
    //    #region constructors

    //    public PassListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override PassData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            PassData passData = new PassData(ConfigType.All, prefix, "", "", "");
    //            passData.SetData(xmlElement);

    //            if (passData.WasRead)
    //                return passData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //    }

    //    protected override string GetItemData(string offset, string prefix, PassData item)
    //    {
    //    }

    //    #endregion
    //}
}
