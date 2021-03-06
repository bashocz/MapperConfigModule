using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EI.Config
{
    public class GuiConfigData
    {
        #region private fields

        private readonly ConfigType configType;
        private readonly string configVersion;
        private readonly XmlDocument templateDoc;
        private readonly int levelCount;

        private readonly List<BaseData>[] childList;

        #endregion

        #region constructors

        public GuiConfigData(ConfigType configType, string configVersion, XmlDocument templateDoc, int levelCount)
        {
            this.configType = configType;
            this.configVersion = configVersion;
            this.templateDoc = templateDoc;
            this.levelCount = levelCount;

            childList = new List<BaseData>[levelCount];
            for (int idx = 0; idx < levelCount; idx++)
                childList[idx] = new List<BaseData>();
            CreateChildList();
        }

        #endregion

        #region private methods

        private BaseData GetData(string type, string name, string description, string editor)
        {
            switch (type.ToLower())
            {
                case "struct":
                    return new StructData(configType, string.Empty, name, description, editor);
                case "list":
                    return new ListData(configType, string.Empty, name, description, editor);
                case "string":
                    return new StringData(configType, string.Empty, name, description, editor, string.Empty);
                case "integer":
                    return new IntegerData(configType, string.Empty, name, description, editor, 0);
                case "double":
                    return new DoubleData(configType, string.Empty, name, description, editor, 0.0);
                case "boolean":
                    return new BooleanData(configType, string.Empty, name, description, editor, false);
            }
            return null;
        }

        private BaseData GetData(XmlElement xmlElement)
        {
            string type = null;
            string name = null;
            string description = null;
            string editor = null;
            for (int idx = 0; idx < xmlElement.Attributes.Count; idx++)
            {
                switch (xmlElement.Attributes[idx].Name)
                {
                    case "datatype":
                        type = xmlElement.Attributes[idx].InnerText;
                        break;
                    case "name":
                        name = xmlElement.Attributes[idx].InnerText;
                        break;
                    case "description":
                        description = xmlElement.Attributes[idx].InnerText;
                        break;
                    case "editor":
                        editor = xmlElement.Attributes[idx].InnerText;
                        break;
                }
            }
            if (!string.IsNullOrEmpty(type))
                return GetData(type, name, description, editor);
            return null;
        }

        private void CreateChildTree(XmlElement xmlParent, CollectionData collectionData)
        {
            for (int idx = 0; idx < xmlParent.ChildNodes.Count; idx++)
            {
                XmlElement xmlChild = xmlParent.ChildNodes[idx] as XmlElement;
                BaseData child = GetData(xmlChild);

                if (child != null)
                {
                    if (child is CollectionData)
                        CreateChildTree(xmlChild, child as CollectionData);

                    if (collectionData is ListData)
                        (collectionData as ListData).ChildStruct = child;
                    else
                        collectionData.AddChild(child);
                }
            }
        }

        private void CreateChildList()
        {
            for (int childIdx = 0; childIdx < levelCount; childIdx++)
            {
                for (int idx = 0; idx < templateDoc.DocumentElement.ChildNodes.Count; idx++)
                {
                    XmlElement xmlChild = templateDoc.DocumentElement.ChildNodes[idx] as XmlElement;
                    BaseData child = GetData(xmlChild);

                    if (child != null)
                    {
                        if (child is CollectionData)
                            CreateChildTree(xmlChild, child as CollectionData);

                        childList[childIdx].Add(child);
                    }
                }
            }
        }

        #endregion

        #region public methods

        public XmlDocument GetLevelData(int levelIdx, string levelName, string levelId)
        {
            string xmlString = string.Empty;

            string cfgType = (configType == ConfigType.Mapper) ? "MAPPER" : "LOT";
            xmlString += "<Mapper version = \"" + configVersion + "\" type = \"" + cfgType + "\" description = \"\" />";
            xmlString += "  <Level name = \"" + levelName.ToUpper() + "\">" + levelId + "</Level>";
            if ((levelIdx >= 0) && (levelIdx < levelCount))
                for (int idx = 0; idx < childList[levelIdx].Count; idx++)
                    xmlString += childList[levelIdx][idx].GetData("  ", configType);
            xmlString += "</Mapper>";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            return xmlDoc;
        }

        public void SetLevelData(int levelIdx, XmlDocument xmlDoc)
        {
            if ((levelIdx >= 0) && (levelIdx < levelCount))
                for (int idx = 0; idx < childList[levelIdx].Count; idx++)
                    childList[levelIdx][idx].SetData(xmlDoc);
        }

        #endregion

        #region public properties

        public ConfigType ConfigType
        {
            get { return configType; }
        }

        public string ConfigVersion
        {
            get { return configVersion; }
        }

        public List<BaseData> this[int idx]
        {
            get
            {
                if ((idx >= 0) && (idx < levelCount))
                    return childList[idx];
                return null;
            }
        }

        #endregion
    }
}
