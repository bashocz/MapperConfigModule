using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class LaserscribeFormatListData : ValueListData<LaserscribeFormatData>
    //{
    //    #region constructors

    //    public LaserscribeFormatListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override LaserscribeFormatData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            LaserscribeFormatData formatData = new LaserscribeFormatData(ConfigType.All, prefix, "", "", "");
    //            formatData.SetData(xmlElement);

    //            if (formatData.WasRead)
    //                return formatData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //    }

    //    protected override string GetItemData(string offset, string prefix, LaserscribeFormatData item)
    //    {
    //    }

    //    #endregion
    //}
}
