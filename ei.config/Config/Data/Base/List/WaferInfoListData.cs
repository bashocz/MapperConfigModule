using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    //public class WaferInfoListData : ValueListData<WaferInfo>
    //{
    //    #region constructors

    //    public WaferInfoListData(ConfigType configType, string prefix, string name, string description, string editor, string itemPrefix, string itemDescription)
    //        : base(configType, prefix, name, description, editor, itemPrefix, itemDescription) { }

    //    #endregion

    //    #region private methods

    //    private string GetParentLotIdListValue(IList<string> parentLotIdList)
    //    {
    //        string result = string.Empty;
    //        for (int idx = 0; idx < parentLotIdList.Count; idx++)
    //        {
    //            result += parentLotIdList[idx];
    //            if (idx > 0)
    //                result += ";";
    //        }
    //        return result;
    //    }

    //    #endregion

    //    #region protected methods

    //    protected override WaferInfo GetItemValue(XmlElement xmlElement, string prefix)
    //    {
    //        if (xmlElement != null)
    //        {
    //            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Index");
    //            int index = 0;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                index = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "SlotIndex");
    //            int slotIndex = 0;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                slotIndex = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ParentLotId");
    //            string parentLotId = string.Empty;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                parentLotId = (xmlNodeList.Item(0) as XmlElement).InnerText;

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ParentLotIdList");
    //            List<string> parentLotIdList = new List<string>();
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                parentLotIdList.AddRange(((xmlNodeList.Item(0) as XmlElement).InnerText).Split(';'));

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ProbedCount");
    //            int probedCount = 0;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                probedCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ReprobedCount");
    //            int reprobedCount = 0;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                reprobedCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "SampledCount");
    //            int sampledCount = 0;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                sampledCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "InkedCount");
    //            int inkedCount = 0;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                inkedCount = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Laserscribe");
    //            string laserscribe = string.Empty;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                laserscribe = (xmlNodeList.Item(0) as XmlElement).InnerText;

    //            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Scrap");
    //            bool scrap = false;
    //            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
    //                scrap = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

    //            if (index != 0)
    //                return new WaferInfo(index, slotIndex, parentLotId, parentLotIdList, probedCount, reprobedCount, sampledCount, inkedCount, laserscribe, scrap);
    //        }
    //        return null;
    //    }

    //    protected override string GetItemTemplate(string offset, string prefix, string description)
    //    {
    //        string result = string.Empty;
    //        result += offset + "<Item name=\"" + prefix + "Item\" mesName=\"Wafer\" datatype=\"struct\" description=\"" + description + "\">";
    //        result += offset + "  <Item name=\"" + prefix + "Index\" mesName=\"LotInfo.WaferInfoList.WaferIndex\" datatype=\"integer\" description=\"Wafer index\" />";
    //        result += offset + "  <Item name=\"" + prefix + "SlotIndex\" mesName=\"LotInfo.WaferInfoList.SlotIndex\" datatype=\"integer\" description=\"Slot index\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ParentLotId\" mesName=\"LotInfo.WaferInfoList.ParentLotId\" datatype=\"string\" description=\"Parent lot ID\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ParentLotIdList\" mesName=\"LotInfo.WaferInfoList.ParentLotIdList\" datatype=\"string\" description=\"Parent lot IDs list\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ProbedCount\" mesName=\"LotInfo.WaferInfoList.ProbedCount\" datatype=\"integer\" description=\"Probed count\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ReprobedCount\" mesName=\"LotInfo.WaferInfoList.ReprobedCount\" datatype=\"integer\" description=\"Reprobed count\" />";
    //        result += offset + "  <Item name=\"" + prefix + "SampledCount\" mesName=\"LotInfo.WaferInfoList.SampledCount\" datatype=\"integer\" description=\"Sampled count\" />";
    //        result += offset + "  <Item name=\"" + prefix + "InkedCount\" mesName=\"LotInfo.WaferInfoList.InkedCount\" datatype=\"integer\" description=\"Inked count\" />";
    //        result += offset + "  <Item name=\"" + prefix + "Laserscribe\" mesName=\"LotInfo.WaferInfoList.LaserScribe\" datatype=\"string\" description=\"Laserscribe\" />";
    //        result += offset + "  <Item name=\"" + prefix + "Scrap\" mesName=\"LotInfo.WaferInfoList.Scrap\" datatype=\"boolean\" description=\"Scrap\" />";
    //        result += offset + "</Item>";
    //        return result;
    //    }

    //    protected override string GetItemData(string offset, string prefix, WaferInfo item)
    //    {
    //        string result = string.Empty;
    //        result += offset + "<Item name=\"" + prefix + "Item\" value=\"\">";
    //        result += offset + "  <Item name=\"" + prefix + "Index\" value=\"" + item.Index.ToString() + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "SlotIndex\" value=\"" + item.SlotIndex.ToString() + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ParentLotId\" value=\"" + item.ParentLotId + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ParentLotIdList\" value=\"" + GetParentLotIdListValue(item.ParentLotIdList) + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ProbedCount\" value=\"" + item.ProbedCount.ToString() + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "ReprobedCount\" value=\"" + item.ReprobedCount.ToString() + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "SampledCount\" value=\"" + item.SampledCount.ToString() + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "InkedCount\" value=\"" + item.InkedCount.ToString() + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "Laserscribe\" value=\"" + item.Laserscribe + "\" />";
    //        result += offset + "  <Item name=\"" + prefix + "Scrap\" value=\"" + item.Scrap.ToString() + "\" />";
    //        result += offset + "</Item>";
    //        return result;
    //    }

    //    #endregion
    //}
}
