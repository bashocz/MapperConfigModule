using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class ConsecutiveFailCustomRuleListData : ValueListData<ConsecutiveFailCustomRuleData>
    //{
    //    #region constructors

    //    public ConsecutiveFailCustomRuleListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region protected methods

    //    protected override ConsecutiveFailCustomRuleData GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            ConsecutiveFailCustomRuleData ruleData = new ConsecutiveFailCustomRuleData(ConfigType.All, prefix, "", "", "");
    //            ruleData.SetData(xmlElement);

    //            if (ruleData.WasRead)
    //                return ruleData;
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //    }

    //    protected override string GetItemData(string offset, string prefix, ConsecutiveFailCustomRuleData item)
    //    {
    //    }

    //    #endregion
    //}
}
