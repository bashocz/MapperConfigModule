using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace EI.Config
{
    internal class MainConfigXmlBinder
    {
        #region save private methods

        private void SaveConfig(XmlDocument xmlDoc, ConfigConfigData configData)
        {
            XmlConfig xmlConfig = new XmlConfig();

            xmlConfig.MapperId = configData.MapperId;
            xmlConfig.TesterId = configData.TesterId;
            xmlConfig.ProberId = configData.ProberId;
            xmlConfig.NewConfigEnabled = configData.NewConfigEnabled;
            xmlConfig.WsConfigEnabled = configData.WsEnabled;
            xmlConfig.WsTimeoutSeconds = configData.WsTimeoutSeconds;
            xmlConfig.WsOnlineCheckTimeoutSeconds = configData.WsOnlineCheckTimeoutSeconds;
            xmlConfig.WsAddressList = new List<string>(configData.WsAddressList);

            xmlConfig.SaveConfig(xmlDoc);
        }

        #endregion

        #region load private methods

        private bool LoadConfig(XmlDocument xmlDoc, ConfigConfigData configData)
        {
            XmlConfig xmlConfig = new XmlConfig();
            bool isReadAll = xmlConfig.LoadConfig(xmlDoc);

            configData.MapperId = xmlConfig.MapperId;
            configData.TesterId = xmlConfig.TesterId;
            configData.ProberId = xmlConfig.ProberId;
            configData.NewConfigEnabled = xmlConfig.NewConfigEnabled;
            configData.WsEnabled = xmlConfig.WsConfigEnabled;
            configData.WsTimeoutSeconds = xmlConfig.WsTimeoutSeconds;
            configData.ClearWsAddressList();
            configData.AddRangeToWsAddressList(xmlConfig.WsAddressList);
            configData.ShakeWsAddressList();
            configData.WsOnlineCheckTimeoutSeconds = xmlConfig.WsOnlineCheckTimeoutSeconds;
            return isReadAll;
        }

        #endregion

        #region public methods

        public bool Load(ConfigData configData)
        {
            if (File.Exists(configData.Config.MainLocalConfigFile))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(configData.Config.MainLocalConfigFile);

                    return LoadConfig(xmlDoc, configData.Config);
                }
                catch (Exception ex)
                {
                    LogIt.Error("Exception in MainConfigXmlBinder.Load method:", ex);
                }
            }
            return false;
        }

        public void Save(ConfigData configData)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

                SaveConfig(xmlDoc, configData.Config);

                xmlDoc.Save(configData.Config.MainLocalConfigFile);
            }
            catch (Exception ex)
            {
                LogIt.Error("Exception in MainConfigXmlBinder.Save method:", ex);
            }
        }

        #endregion
    }
}
