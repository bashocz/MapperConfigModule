using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    internal class TesterXmlBinder : BaseXmlBinder
    {
        #region private fields

        private DriverXmlBinder driverXmlBinder;

        #endregion

        #region constructors

        public TesterXmlBinder()
        {
            driverXmlBinder = new DriverXmlBinder();
        }

        #endregion

        #region private methods

        private Bin GetBin(XmlElement xmlElement, string prefix)
        {
            XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Value");
            int binValue = -1;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                binValue = Convert.ToInt32((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Good");
            bool isGoodDie = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                isGoodDie = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Reprobed");
            bool isReprobedDie = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                isReprobedDie = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            xmlNodeList = xmlElement.GetElementsByTagName(prefix + "Inked");
            bool isInkedDie = false;
            if ((xmlNodeList.Count == 1) && (xmlNodeList.Item(0) is XmlElement))
                isInkedDie = Convert.ToBoolean((xmlNodeList.Item(0) as XmlElement).InnerText);

            if ((binValue >= 0) && (binValue < 256))
                return new Bin(binValue, isGoodDie, isReprobedDie, isInkedDie);
            return null;
        }

        private List<Bin> GetBinList(XmlDocument xmlDoc, string elementName)
        {
            List<Bin> binList = new List<Bin>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement binElement = node as XmlElement;
                    Bin bin = GetBin(binElement, elementName);
                    if (bin != null)
                        binList.Add(bin);
                }
            }

            return binList;
        }

        private List<int> GetIntList(XmlDocument xmlDoc, string elementName)
        {
            List<int> intList = new List<int>();

            XmlNodeList nodeList = xmlDoc.GetElementsByTagName(elementName);
            foreach (XmlNode node in nodeList)
            {
                if (node is XmlElement)
                {
                    XmlElement intElement = node as XmlElement;
                    intList.Add(Convert.ToInt32(intElement.InnerText));
                }
            }

            return intList;
        }

        private void LoadEagle(XmlDocument xmlDoc, EagleConfigData configData)
        {
            configData.CommunicationType = GetEnum(xmlDoc, "EtsCommunicationType", configData.CommunicationType);
            configData.CommandSet = GetEnum(xmlDoc, "EtsCommandSet", configData.CommandSet);
            configData.ProberId = GetString(xmlDoc, "EtsProberId", configData.ProberId);

            driverXmlBinder.LoadSerial(xmlDoc, "EtsSerial", configData.Serial);
            driverXmlBinder.LoadGpib(xmlDoc, "EtsGpib", configData.Gpib);
            driverXmlBinder.LoadTcpIp(xmlDoc, "EtsTcpIp", configData.TcpIp);

            configData.NewtonEnabled = GetBool(xmlDoc, "EtsNewtonEnabled", configData.NewtonEnabled);
            configData.NewtonCacheFileName = GetString(xmlDoc, "EtsNewtonCacheFile", configData.NewtonCacheFileName);
            driverXmlBinder.LoadSerial(xmlDoc, "EtsNewtonSerial", configData.NewtonSerial);
        }

        private void LoadFet(XmlDocument xmlDoc, FetConfigData configData)
        {
            configData.BoardNo = GetInt(xmlDoc, "FetPioBoardIndex", configData.BoardNo);
            configData.EnableSendingXYCoords = GetBool(xmlDoc, "FetSendXyCoordEnabled", configData.EnableSendingXYCoords);
            driverXmlBinder.LoadGpib(xmlDoc, "FetGpib", configData.Gpib);
        }

        private void LoadDts(XmlDocument xmlDoc, DtsConfigData configData)
        {
            driverXmlBinder.LoadTcpIp(xmlDoc, "DtsTcpIp", configData.TcpIp);
        }

        private void LoadPft(XmlDocument xmlDoc, PftConfigData configData)
        {
            driverXmlBinder.LoadTcpIp(xmlDoc, "PftTcpIp", configData.TcpIp);
        }

        private void LoadTmt(XmlDocument xmlDoc, TmtConfigData configData)
        {
            configData.CommunicationType = GetEnum(xmlDoc, "TmtCommunicationType", configData.CommunicationType);
            configData.CommandSet = GetEnum(xmlDoc, "TmtCommandSet", configData.CommandSet);
            driverXmlBinder.LoadTcpIp(xmlDoc, "TmtTcpIp", configData.TcpIp);
            driverXmlBinder.LoadSerial(xmlDoc, "TmtSerial", configData.Serial);
        }

        private void LoadVersatest(XmlDocument xmlDoc, VersatestConfigData configData)
        {
            driverXmlBinder.LoadSerial(xmlDoc, "VersatestSerial", configData.Serial);
        }

        private void LoadDualVersatest(XmlDocument xmlDoc, DualVersatestConfigData configData)
        {
            driverXmlBinder.LoadSerial(xmlDoc, "DualVersatest1Serial", configData.Tester1Serial);
            driverXmlBinder.LoadSerial(xmlDoc, "DualVersatest2Serial", configData.Tester2Serial);
            configData.ClearTester1SiteList();
            configData.AddRangeToTester1SiteList(GetIntList(xmlDoc, "DualVersatest1SiteItem"));
            configData.ClearTester2SiteList();
            configData.AddRangeToTester2SiteList(GetIntList(xmlDoc, "DualVersatest2SiteItem"));
        }

        private void LoadKeithley(XmlDocument xmlDoc, KeithleyConfigData configData)
        {
            configData.ScriptFileName = GetString(xmlDoc, "KeithleyScriptFileName", configData.ScriptFileName);
            configData.CsvOutputDir = GetString(xmlDoc, "KeithleyCsvOutputDir", configData.CsvOutputDir);
            driverXmlBinder.LoadGpib(xmlDoc, "KeithleyGpib", configData.Gpib);
        }

        private void LoadHp(XmlDocument xmlDoc, HpConfigData configData)
        {
            driverXmlBinder.LoadGpib(xmlDoc, "HpGpib", configData.Gpib);
        }

        private void LoadMaverick(XmlDocument xmlDoc, MaverickConfigData configData)
        {
            driverXmlBinder.LoadTcpIp(xmlDoc, "MaverickTcpIp", configData.TcpIp);
        }

        private void LoadPei(XmlDocument xmlDoc, PeiConfigData configData)
        {
            driverXmlBinder.LoadSerial(xmlDoc, "PeiSerial", configData.Serial);
        }
        private void LoadPowertech(XmlDocument xmlDoc, PowertechConfigData configData)
        {
            driverXmlBinder.LoadSerial(xmlDoc, "PowertechSerial", configData.Serial);
        }

        private void LoadVirtualTester(XmlDocument xmlDoc, VirtualTesterConfigData configData)
        {
            configData.ConnectDelay = GetInt(xmlDoc, "TesterVirtualConnectDelay", configData.ConnectDelay);
            configData.DisconnectDelay = GetInt(xmlDoc, "TesterVirtualDisconnectDelay", configData.DisconnectDelay);
            configData.InitDelay = GetInt(xmlDoc, "TesterVirtualInitDelay", configData.InitDelay);
            configData.StartLotDelay = GetInt(xmlDoc, "TesterVirtualStartLotDelay", configData.StartLotDelay);
            configData.EndLotDelay = GetInt(xmlDoc, "TesterVirtualEndLotDelay", configData.EndLotDelay);
            configData.StartWaferDelay = GetInt(xmlDoc, "TesterVirtualStartWaferDelay", configData.StartWaferDelay);
            configData.EndWaferDelay = GetInt(xmlDoc, "TesterVirtualEndWaferDelay", configData.EndWaferDelay);
            configData.ProbeDieDelay = GetInt(xmlDoc, "TesterVirtualProbeDieDelay", configData.ProbeDieDelay);
            configData.ProbeDieFinishedDelay = GetInt(xmlDoc, "TesterVirtualProbeDieFinishedDelay", configData.ProbeDieFinishedDelay);
            configData.GetTestProgramNameDelay = GetInt(xmlDoc, "TesterVirtualGetTestProgramNameDelay", configData.GetTestProgramNameDelay);
            configData.GetTemperatureDelay = GetInt(xmlDoc, "TesterVirtualGetTemperatureDelay", configData.GetTemperatureDelay);
            configData.IsRandom = GetBool(xmlDoc, "TesterVirtualRandomBinEnabled", configData.IsRandom);
            configData.Yield = GetDouble(xmlDoc, "TesterVirtualRandomYield", configData.Yield);
            configData.IsGrowing = GetBool(xmlDoc, "TesterVirtualGrowingBinEnabled", configData.IsRandom);
            configData.InputWmxmlPath = GetString(xmlDoc, "TesterVirtualInputWmxmlDir", configData.InputWmxmlPath);
            configData.IsInputWmxmlPath = !string.IsNullOrEmpty(configData.InputWmxmlPath);
        }

        #endregion

        #region public methods

        public void LoadTester(XmlDocument xmlDoc, TesterConfigData configData)
        {
            configData.ActiveTester = GetString(xmlDoc, "TesterActive", configData.ActiveTester);
            configData.Timeout = GetInt(xmlDoc, "TesterTimeout", configData.Timeout);
            configData.SimulatorEnabled = GetBool(xmlDoc, "TesterSimulatorEnabled", configData.SimulatorEnabled);
            configData.ClearDefaultBinList();
            configData.AddRangeToDefaultBinList(GetBinList(xmlDoc, "TesterDefaultBinItem"));

            LoadEagle(xmlDoc, configData.Eagle);
            LoadFet(xmlDoc, configData.Fet);
            LoadDts(xmlDoc, configData.Dts);
            LoadPft(xmlDoc, configData.Pft);
            LoadTmt(xmlDoc, configData.Tmt);
            LoadVersatest(xmlDoc, configData.Versatest);
            LoadDualVersatest(xmlDoc, configData.DualVersatest);
            LoadKeithley(xmlDoc, configData.Keithley);
            LoadHp(xmlDoc, configData.Hp);
            LoadMaverick(xmlDoc, configData.Maverick);
            LoadPei(xmlDoc, configData.Pei);
            LoadVirtualTester(xmlDoc, configData.Virtual);
        }

        #endregion
    }
}
