using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    internal class ProberXmlBinder : BaseXmlBinder
    {
        #region private fields

        private DriverXmlBinder driverXmlBinder;

        #endregion

        #region constructors

        public ProberXmlBinder()
        {
            driverXmlBinder = new DriverXmlBinder();
        }

        #endregion

        #region private methods

        private void LoadEg2001(XmlDocument xmlDoc, Eg2001ConfigData configData)
        {
            configData.EnableManualMicroCoordsChange = GetBool(xmlDoc, "Eg2001MicroCoordChange", configData.EnableManualMicroCoordsChange);
            driverXmlBinder.LoadSerial(xmlDoc, "Eg2001Serial", configData.Serial);
        }

        private void LoadEg4090(XmlDocument xmlDoc, Eg4090ConfigData configData)
        {
            configData.SendProfileData = GetBool(xmlDoc, "Eg4090SendProfileData", configData.SendProfileData);
            configData.CommunicationType = GetEnum(xmlDoc, "Eg4090CommunicationType", EgCommunicationType.GPIB);
            configData.CommandSequenceAfterLoadWafer = GetEnum(xmlDoc, "Eg4090CommandSequenceAfterLoadWafer", configData.CommandSequenceAfterLoadWafer);
            driverXmlBinder.LoadGpib(xmlDoc, "Eg4090Gpib", configData.Gpib);
            driverXmlBinder.LoadSerial(xmlDoc, "Eg4090Serial", configData.Serial);
        }

        private void LoadGsi(XmlDocument xmlDoc, GsiConfigData configData)
        {
            driverXmlBinder.LoadTcpIp(xmlDoc, "GsiTcpIp", configData.TcpIp);
        }

        private void LoadKla1007(XmlDocument xmlDoc, Kla1007ConfigData configData)
        {
            driverXmlBinder.LoadGpib(xmlDoc, "Kla1007Gpib", configData.Gpib);
        }

        private void LoadTelp8(XmlDocument xmlDoc, Telp8ConfigData configData)
        {
            driverXmlBinder.LoadGpib(xmlDoc, "Telp8Gpib", configData.Gpib);
        }

        private void LoadUf2000(XmlDocument xmlDoc, Uf2000ConfigData configData)
        {
            driverXmlBinder.LoadGpib(xmlDoc, "Uf2000Gpib", configData.Gpib);
        }

        private void LoadVirtualProber(XmlDocument xmlDoc, VirtualProberConfigData configData)
        {
            configData.ConnectDelay = GetInt(xmlDoc, "ProberVirtualConnectDelay", configData.ConnectDelay);
            configData.DisconnectDelay = GetInt(xmlDoc, "ProberVirtualDisconnectDelay", configData.DisconnectDelay);
            configData.InitDelay = GetInt(xmlDoc, "ProberVirtualInitDelay", configData.InitDelay);
            configData.WriteSettingDelay = GetInt(xmlDoc, "ProberVirtualWriteSettingDelay", configData.WriteSettingDelay);
            configData.ReadSettingDelay = GetInt(xmlDoc, "ProberVirtualReadSettingDelay", configData.ReadSettingDelay);
            configData.WriteAlignmentDelay = GetInt(xmlDoc, "ProberVirtualWriteAlignmentDelay", configData.WriteAlignmentDelay);
            configData.ReadAlignmentDelay = GetInt(xmlDoc, "ProberVirtualReadAlignemtDelay", configData.ReadAlignmentDelay);
            configData.StartLotDelay = GetInt(xmlDoc, "ProberVirtualStartLotDelay", configData.StartLotDelay);
            configData.EndLotDelay = GetInt(xmlDoc, "ProberVirtualEndLotDelay", configData.EndLotDelay);
            configData.LoadWaferDelay = GetInt(xmlDoc, "ProberVirtualLoadWaferDelay", configData.LoadWaferDelay);
            configData.UnloadWaferDelay = GetInt(xmlDoc, "ProberVirtualUnloadWaferDelay", configData.UnloadWaferDelay);
            configData.StartWaferDelay = GetInt(xmlDoc, "ProberVirtualStartWaferDelay", configData.StartWaferDelay);
            configData.EndWaferDelay = GetInt(xmlDoc, "ProberVirtualEndWaferDelay", configData.EndWaferDelay);
            configData.GetWaferIdDelay = GetInt(xmlDoc, "ProberVirtualGetWaferIdDelay", configData.GetWaferIdDelay);
            configData.MoveToDelay = GetInt(xmlDoc, "ProberVirtualMoveToDelay", configData.MoveToDelay);
            configData.InkDieDelay = GetInt(xmlDoc, "ProberVirtualInkDieDelay", configData.InkDieDelay);
            configData.ContactDelay = GetInt(xmlDoc, "ProberVirtualContactDelay", configData.ContactDelay);
            configData.UncontactDelay = GetInt(xmlDoc, "ProberVirtualUncontactDelay", configData.UncontactDelay);
            configData.RecontactDelay = GetInt(xmlDoc, "ProberVirtualRecontactDelay", configData.RecontactDelay);
            configData.TestCompleteDelay = GetInt(xmlDoc, "ProberVirtualTestCompleteDelay", configData.TestCompleteDelay);
            configData.PauseDelay = GetInt(xmlDoc, "ProberVirtualPauseDelay", configData.PauseDelay);
            configData.ContinueDelay = GetInt(xmlDoc, "ProberVirtualContinueDelay", configData.ContinueDelay);
            configData.AbortDelay = GetInt(xmlDoc, "ProberVirtualAbortDelay", configData.AbortDelay);
            configData.ShowMessageDelay = GetInt(xmlDoc, "ProberVirtualShowMessageDelay", configData.ShowMessageDelay);
            configData.ClearMessageDelay = GetInt(xmlDoc, "ProberVirtualClearMessageDelay", configData.ClearMessageDelay);
            configData.BuzzerOnDelay = GetInt(xmlDoc, "ProberVirtualBuzzerOnDelay", configData.BuzzerOnDelay);
            configData.BuzzerOffDelay = GetInt(xmlDoc, "ProberVirtualBuzzerOffDelay", configData.BuzzerOffDelay);
            configData.ForwardCommandDelay = GetInt(xmlDoc, "ProberVirtualForwardCommandDelay", configData.ForwardCommandDelay);
        }

        #endregion

        #region public methods

        public void LoadProber(XmlDocument xmlDoc, ProberConfigData configData)
        {
            configData.ActiveProber = GetString(xmlDoc, "ProberActive", configData.ActiveProber);
            configData.Timeout = GetInt(xmlDoc, "ProberTimeout", configData.Timeout);
            configData.SimulatorEnabled = GetBool(xmlDoc, "ProberSimulatorEnabled", configData.SimulatorEnabled);

            configData.IsProbeCleanEnabled = GetBool(xmlDoc, "ProbeCleanEnabled", configData.IsProbeCleanEnabled);
            configData.IsProbeXyScrub = GetBool(xmlDoc, "ProbeCleanScrub", configData.IsProbeXyScrub);
            configData.ProbeCleanCount = GetInt(xmlDoc, "ProbeCleanCount", configData.ProbeCleanCount);

            LoadEg2001(xmlDoc, configData.Eg2001);
            LoadEg4090(xmlDoc, configData.Eg4090);
            LoadGsi(xmlDoc, configData.Gsi);
            LoadKla1007(xmlDoc, configData.Kla1007);
            LoadTelp8(xmlDoc, configData.Telp8);
            LoadUf2000(xmlDoc, configData.Uf2000);
            LoadVirtualProber(xmlDoc, configData.Virtual);
        }

        #endregion
    }
}
