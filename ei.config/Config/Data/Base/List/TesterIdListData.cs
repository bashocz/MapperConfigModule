using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class TesterIdListData : ValueListData<string>
    //{
    //    #region constructors

    //    public TesterIdListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override string GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if ((xmlElement != null) && !string.IsNullOrEmpty(xmlElement.InnerText))
    //            return xmlElement.InnerText;
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //        return offset + "<Item name=\"" + prefix + "\" datatype=\"string\" description=\"" + description + "\" />";
    //    }

    //    protected override string GetItemData(string offset, string prefix, string item)
    //    {
    //        return offset + "<Item name=\"" + prefix + "\" value=\"" + item + "\">";
    //    }

    //    #endregion
    //}
}
