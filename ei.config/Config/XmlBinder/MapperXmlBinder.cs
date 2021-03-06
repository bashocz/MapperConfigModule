using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    internal class MapperXmlBinder : BaseXmlBinder
    {
        #region private methods

        private List<string> GetUrlList(XmlDocument xmlDoc, string elementName)
        {
            List<string> urlList = new List<string>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement urlElement = node as XmlElement;
                    urlList.Add(urlElement.InnerText);
                }
            }

            return urlList;
        }

        private DrawProperty GetDrawProperty(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "VariableName");
            string variableName = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                variableName = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Name");
            string name = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                name = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Font");
            string fontName = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                fontName = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Size");
            int size = 0;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                size = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Bold");
            bool bold = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                bold = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Foreground");
            string foreColorName = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                foreColorName = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Background");
            string backColorName = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                backColorName = (xmlNodeList.Item(0) as XmlElement).InnerText;

            if ((!string.IsNullOrEmpty(name)) && (!string.IsNullOrEmpty(fontName)) && (size > 0) &&
                !string.IsNullOrEmpty(foreColorName) && !string.IsNullOrEmpty(backColorName))
            {
                Font font;
                if (bold)
                    font = new Font(fontName, size, FontStyle.Bold);
                else
                    font = new Font(fontName, size, FontStyle.Regular);
                Color foreColor;
                string[] foreColorStr = foreColorName.Split(';');
                if (string.Compare(foreColorStr[0], "Custom", true) != 0)
                    foreColor = Color.FromName(foreColorStr[0]);
                else
                    foreColor = Color.FromArgb(Convert.ToInt32(foreColorStr[1]), Convert.ToInt32(foreColorStr[2]), Convert.ToInt32(foreColorStr[3]));
                Color backColor;
                string[] backColorStr = backColorName.Split(';');
                if (string.Compare(backColorStr[0], "Custom", true) != 0)
                    backColor = Color.FromName(backColorStr[0]);
                else
                    backColor = Color.FromArgb(Convert.ToInt32(backColorStr[1]), Convert.ToInt32(backColorStr[2]), Convert.ToInt32(backColorStr[3]));

                return new DrawProperty(variableName, name, font, backColor, foreColor);
            }
            return null;
        }

        private HotKeysListData GetHotKeysProperty(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Name");
            string name = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                name = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "VariableName");
            string variableName = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                variableName = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Value");
            string value = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                value = (xmlNodeList.Item(0) as XmlElement).InnerText;

            return new HotKeysListData(name, variableName, value);
        }

        private LongPauseEventListData GetLongPauseEventProperty(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Name");
            string name = string.Empty;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                name = (xmlNodeList.Item(0) as XmlElement).InnerText;

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Enabled");
            bool enabled = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                enabled = Boolean.Parse((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "ReasonCode");
            int reasonCode = -1;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                reasonCode = Int32.Parse((xmlNodeList.Item(0) as XmlElement).InnerText);

            return new LongPauseEventListData(name, enabled, reasonCode);
        }

        private List<DrawProperty> GetDrawPropertyList(XmlDocument xmlDoc, string elementName)
        {
            List<DrawProperty> drawPropertyList = new List<DrawProperty>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement drawPropertyElement = node as XmlElement;
                    DrawProperty drawProperty = GetDrawProperty(drawPropertyElement, elementName);
                    if (drawProperty != null)
                        drawPropertyList.Add(drawProperty);
                }
            }

            return drawPropertyList;
        }

        private List<HotKeysListData> GetHotKeysPropertyList(XmlDocument xmlDoc, string elementName)
        {
            List<HotKeysListData> hotPropertyKeysList = new List<HotKeysListData>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement hotKeysPropertyElement = node as XmlElement;
                    HotKeysListData hotKeysProperty = GetHotKeysProperty(hotKeysPropertyElement, elementName);
                    if (hotKeysProperty != null)
                        hotPropertyKeysList.Add(hotKeysProperty);
                }
            }

            return hotPropertyKeysList;
        }

        private List<LongPauseEventListData> GetLongPauseEventPropertyList(XmlDocument xmlDoc, string elementName)
        {
            List<LongPauseEventListData> longPauseEventPropertyList = new List<LongPauseEventListData>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement longPauseEventPropertyElement = node as XmlElement;
                    LongPauseEventListData longPauseEventProperty = GetLongPauseEventProperty(longPauseEventPropertyElement, elementName);
                    if (longPauseEventProperty != null)
                        longPauseEventPropertyList.Add(longPauseEventProperty);
                }
            }

            return longPauseEventPropertyList;
        }

        #endregion

        #region public methods

        public void LoadGeneral(XmlDocument xmlDoc, GeneralConfigData configData)
        {
            configData.LoginEnabled = GetBool(xmlDoc, "LoginEnabled", configData.LoginEnabled);
            configData.SystemType = GetEnum(xmlDoc, "SystemType", configData.SystemType);
            configData.LogLevel = GetEnum(xmlDoc, "LogLevel", configData.LogLevel);
            configData.LongPauseEnabled = GetBool(xmlDoc, "LongPauseEnabled", configData.LongPauseEnabled);
            configData.LongPauseDelayTime = GetInt(xmlDoc, "LongPauseDelay", configData.LongPauseDelayTime);
            configData.TowerLightType = GetEnum(xmlDoc, "TowerLightType", configData.TowerLightType);
            configData.TowerLightPort = GetInt(xmlDoc, "TowerLightPort", configData.TowerLightPort);
            configData.UseTrakLot = GetBool(xmlDoc, "UseTrakLot", configData.UseTrakLot);
        }

        public void LoadDir(XmlDocument xmlDoc, DirConfigData configData)
        {
            configData.LoggingDir = GetString(xmlDoc, "LogDir", configData.LoggingDir);
            configData.SetupDir = GetString(xmlDoc, "SetupDir", configData.SetupDir);
            configData.CacheDir = GetString(xmlDoc, "CacheDir", configData.CacheDir);
            configData.ManualCheckFileName = GetString(xmlDoc, "ManualCheckFileName", configData.ManualCheckFileName);
            configData.ManualCheckLocalDir = GetString(xmlDoc, "ManualCheckLocalDir", configData.ManualCheckLocalDir);
            configData.ManualCheckServerDir = GetString(xmlDoc, "ManualCheckServerDir", configData.ManualCheckServerDir);
            configData.OfflineLotConfigCacheDir = GetString(xmlDoc, "OfflineLotConfigCacheDir", configData.OfflineLotConfigCacheDir);
        }

        public void LoadEnvGeneral(XmlDocument xmlDoc, EnvGeneralConfigData configData)
        {
            configData.CultureName = GetString(xmlDoc, "CultureName", configData.CultureName);
            configData.RecoveryYield = GetBool(xmlDoc, "DisplayRecoveryYield", configData.RecoveryYield);
            configData.DrawCircle = GetBool(xmlDoc, "DrawWaferCircle", configData.DrawCircle);
            configData.DrawGrid = GetBool(xmlDoc, "DrawWaferGrid", configData.DrawGrid);
            configData.AutoCenter = GetBool(xmlDoc, "DrawWaferAutoCenter", configData.AutoCenter);
        }

        public void LoadColor(XmlDocument xmlDoc, ColorConfigData configData)
        {
            List<DrawProperty> drawPropertyList = GetDrawPropertyList(xmlDoc, "EnvColorItem");
            if (drawPropertyList.Count > 0)
            {
                configData.UpdateDrawPropertyList(drawPropertyList);
            }
        }

        public void LoadHotKeys(XmlDocument xmlDoc, HotKeysConfigData configData)
        {
            List<HotKeysListData> hotKeysPropertyList = GetHotKeysPropertyList(xmlDoc, "HotKeyItem");
            if (hotKeysPropertyList.Count > 0)
            {
                configData.UpdateHotKeysList(hotKeysPropertyList);
            }  
        }

        public void LoadLotSearch(XmlDocument xmlDoc, LotSearchConfigData configData)
        {
            configData.UseLimitedLotSearch = GetBool(xmlDoc, "UseLimitedLotSearch", configData.UseLimitedLotSearch);
            configData.DaysBackward = GetInt(xmlDoc, "SearchDaysBackward", configData.DaysBackward);
        }

        public void LoadEvent(XmlDocument xmlDoc, EventConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "EventEnabled", configData.Enabled);
            configData.WriteVerificationCount = GetInt(xmlDoc, "EventWriteVerificationCount", configData.WriteVerificationCount);
            configData.SendingCount = GetInt(xmlDoc, "EventSendingCount", configData.SendingCount);
            configData.EventDir = GetString(xmlDoc, "EventDirectory", configData.EventDir);
            configData.RejectedEventDir = GetString(xmlDoc, "EventRejectedDirectory", configData.RejectedEventDir);
            configData.LpEventConfigData.UpdateLongPauseEventList(GetLongPauseEventPropertyList(xmlDoc, "EventLpEventItem"));
        }

        public void LoadWmxml(XmlDocument xmlDoc, WmxmlConfigData configData)
        {
            configData.AlwaysSaveWaferMaps = GetBool(xmlDoc, "WmxmlAlwaysSave", configData.AlwaysSaveWaferMaps);

            configData.LocalWmxmlVersion = GetEnum(xmlDoc, "WmxmlLocalVersion", configData.LocalWmxmlVersion);
            configData.LocalFileFormat = GetEnum(xmlDoc, "WmxmlLocalFormat", configData.LocalFileFormat);
            configData.LocalOutputWmxmlEnabled = GetBool(xmlDoc, "WmxmlLocalOutputEnabled", configData.LocalOutputWmxmlEnabled);
            configData.LocalInputWmxmlEnabled = GetBool(xmlDoc, "WmxmlLocalInputEnabled", configData.LocalInputWmxmlEnabled);
            configData.LocalOutputWmxmlDir = GetString(xmlDoc, "WmxmlLocalOutputDir", configData.LocalOutputWmxmlDir);
            configData.LocalInputWmxmlDir = GetString(xmlDoc, "WmxmlLocalInputDir", configData.LocalInputWmxmlDir);
            configData.LocalTempWmxmlDir = GetString(xmlDoc, "WmxmlLocalTempDir", configData.LocalTempWmxmlDir);

            configData.ServerWmxmlVersion = GetEnum(xmlDoc, "WmxmlServerVersion", configData.ServerWmxmlVersion);
            configData.ServerFileFormat = GetEnum(xmlDoc, "WmxmlServerFormat", configData.ServerFileFormat);
            configData.ServerOutputWmxmlEnabled = GetBool(xmlDoc, "WmxmlServerOutputEnabled", configData.ServerOutputWmxmlEnabled);
            configData.ServerInputWmxmlEnabled = GetBool(xmlDoc, "WmxmlServerInputEnabled", configData.ServerInputWmxmlEnabled);
            configData.ServerOutputWmxmlDir = GetString(xmlDoc, "WmxmlServerOutputDir", configData.ServerOutputWmxmlDir);
            configData.ServerInputWmxmlDir = GetString(xmlDoc, "WmxmlServerInputDir", configData.ServerInputWmxmlDir);
            configData.ServerUnsentWmxmlDir = GetString(xmlDoc, "WmxmlServerUnsentDir", configData.ServerUnsentWmxmlDir);

            configData.ExternalWmxmlVersion = GetEnum(xmlDoc, "WmxmlExternalVersion", configData.ExternalWmxmlVersion);
            configData.ExternalFileFormat = GetEnum(xmlDoc, "WmxmlExternalFormat", configData.ExternalFileFormat);
            configData.ExternalOutputEnabled = GetBool(xmlDoc, "WmxmlExternalOutputEnabled", configData.ExternalOutputEnabled);
            configData.ExternalInputEnabled = GetBool(xmlDoc, "WmxmlExternalInputEnabled", configData.ExternalInputEnabled);
            configData.ExternalOutputWmxmlDir = GetString(xmlDoc, "WmxmlExternalOutputDir", configData.ExternalOutputWmxmlDir);
            configData.ExternalInputWmxmlDir = GetString(xmlDoc, "WmxmlExternalInputDir", configData.ExternalInputWmxmlDir);
            configData.ExternalUnsentWmxmlDir = GetString(xmlDoc, "WmxmlExternalUnsentDir", configData.ExternalUnsentWmxmlDir);

            configData.VaultWmxmlVersion = GetEnum(xmlDoc, "WmxmlWebServiceVersion", configData.VaultWmxmlVersion);
            configData.VaultFileFormat = GetEnum(xmlDoc, "WmxmlWebServiceFormat", configData.VaultFileFormat);
            configData.VaultOutputEnabled = GetBool(xmlDoc, "WmxmlWebServiceOutputEnabled", configData.VaultOutputEnabled);
            configData.VaultInputEnabled = GetBool(xmlDoc, "WmxmlWebServiceInputEnabled", configData.VaultInputEnabled);
            configData.VaultUnsentWmxmlDir = GetString(xmlDoc, "WmxmlWebServiceUnsentDir", configData.VaultUnsentWmxmlDir);
            configData.VaultTimeoutSeconds = GetInt(xmlDoc, "WmxmlWebServiceTimeoutSeconds", configData.VaultTimeoutSeconds);
            List<string> urlList = GetUrlList(xmlDoc, "WmxmlWebServiceUrlItem");
            if (urlList.Count > 0)
            {
                configData.ClearWebServiceUrlList();
                configData.AddRangeToWebServiceUrlList(urlList);
            }

            configData.LocalOutputSecsEnabled = GetBool(xmlDoc, "SecsLocalOutputEnabled", configData.LocalOutputSecsEnabled);
            configData.LocalOutputSecsDir = GetString(xmlDoc, "SecsLocalOutputDir", configData.LocalOutputSecsDir);
            configData.ServerOutputSecsEnabled = GetBool(xmlDoc, "SecsServerOutputEnabled", configData.ServerOutputSecsEnabled);
            configData.ServerOutputSecsDir = GetString(xmlDoc, "SecsServerOutputDir", configData.ServerOutputSecsDir);
            configData.ServerUnsentSecsDir = GetString(xmlDoc, "SecsServerUnsentDir", configData.ServerUnsentSecsDir);
        }

        public void LoadNewton(XmlDocument xmlDoc, NewtonConfigData configData)
        {
            configData.WmxmlVersion = GetEnum(xmlDoc, "NewtonWmxmlVersion", configData.WmxmlVersion);
            configData.FileFormat = GetEnum(xmlDoc, "NewtonWmxmlFormat", configData.FileFormat);
            configData.Enabled = GetBool(xmlDoc, "NewtonEnabled", configData.Enabled);
            configData.NewtonFile = GetString(xmlDoc, "NewtonFile", configData.NewtonFile);
            configData.WmxmlOutputDir = GetString(xmlDoc, "NewtonWmxmlOutputDir", configData.WmxmlOutputDir);
            configData.StatusFile = GetString(xmlDoc, "NewtonStatusFile", configData.StatusFile);
            configData.Timeout = GetInt(xmlDoc, "NewtonTimeout", configData.Timeout);
        }

        public void LoadGenesis(XmlDocument xmlDoc, GenesisConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "GenesisEnabled", configData.Enabled);
        }

        public void LoadRtm(XmlDocument xmlDoc, RtmConfigData configData)
        {
            configData.Enabled = GetBool(xmlDoc, "RtmEnabled", configData.Enabled);
            configData.RtmDir = GetString(xmlDoc, "RtmDir", configData.RtmDir);
            configData.AgentName = GetString(xmlDoc, "RtmAgentName", configData.AgentName);
            configData.AgentCmd = GetString(xmlDoc, "RtmAgentCmd", configData.AgentCmd);
            configData.WatchPeriod = GetInt(xmlDoc, "RtmWatchPeriod", configData.WatchPeriod);
        }

        #endregion
    }
}
