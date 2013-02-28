using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class CustomScriptListData : ValueListData<CustomScriptData>
    //{
    //    #region constructors

    //    public CustomScriptListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override CustomScriptData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            CustomScriptData scriptData = new CustomScriptData(ConfigType.All, prefix, "", "", "");
    //            scriptData.SetData(xmlElement);

    //            if (scriptData.WasRead)
    //                return scriptData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //    }

    //    protected override string GetItemData(string offset, string prefix, CustomScriptData item)
    //    {
    //    }

    //    #endregion
    //}
}
