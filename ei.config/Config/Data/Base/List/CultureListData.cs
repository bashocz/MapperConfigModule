using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class CultureListData : ValueListData<CultureData>
    //{
    //    #region constructors

    //    public CultureListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override CultureData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            CultureData cultureData = new CultureData(ConfigType.All, prefix, "", "", "");
    //            cultureData.SetData(xmlElement);

    //            if (cultureData.WasRead)
    //                return cultureData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //    }

    //    protected override string GetItemData(string offset, string prefix, CultureData item)
    //    {
    //    }

    //    #endregion
    //}
}
