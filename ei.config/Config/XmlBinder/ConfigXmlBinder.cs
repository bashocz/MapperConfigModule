using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    internal class ConfigXmlBinder
    {
        #region private fields

        private void LoadMapper(XmlDocument xmlDoc, ConfigData configData)
        {
            MapperXmlBinder mapperXmlBinder = new MapperXmlBinder();
            mapperXmlBinder.LoadGeneral(xmlDoc, configData.General);
            mapperXmlBinder.LoadDir(xmlDoc, configData.Dir);
            mapperXmlBinder.LoadEnvGeneral(xmlDoc, configData.EnvGeneral);
            mapperXmlBinder.LoadColor(xmlDoc, configData.Color);
            mapperXmlBinder.LoadHotKeys(xmlDoc, configData.HotKeys);
            mapperXmlBinder.LoadLotSearch(xmlDoc, configData.LotSearch);
            mapperXmlBinder.LoadEvent(xmlDoc, configData.Event);
            mapperXmlBinder.LoadWmxml(xmlDoc, configData.Wmxml);
            mapperXmlBinder.LoadNewton(xmlDoc, configData.Newton);
            mapperXmlBinder.LoadGenesis(xmlDoc, configData.Genesis);
            mapperXmlBinder.LoadRtm(xmlDoc, configData.Rtm);

            TesterXmlBinder testerXmlBinder = new TesterXmlBinder();
            testerXmlBinder.LoadTester(xmlDoc, configData.Tester);

            ProberXmlBinder proberXmlBinder = new ProberXmlBinder();
            proberXmlBinder.LoadProber(xmlDoc, configData.Prober);
        }

        private void LoadLot(XmlDocument xmlDoc, ConfigData configData)
        {
            LotXmlBinder lotXmlBinder = new LotXmlBinder();
            lotXmlBinder.LoadDialog(xmlDoc, configData.Dialog);
            lotXmlBinder.LoadCheckin(xmlDoc, configData.Checkin);
            lotXmlBinder.LoadProcessMethod(xmlDoc, configData.ProcessMethod);
            lotXmlBinder.LoadProbeInTemp(xmlDoc, configData.ProbeInTemp);
            lotXmlBinder.LoadLaserscribe(xmlDoc, configData.Laserscribe);
            lotXmlBinder.LoadReprobe(xmlDoc, configData.Reprobe);
            lotXmlBinder.LoadConsecutiveFail(xmlDoc, configData.ConsecutiveFail);
            lotXmlBinder.LoadCutoff(xmlDoc, configData.Cutoff);
            lotXmlBinder.LoadKelvinDie(xmlDoc, configData.KelvinDie);
            lotXmlBinder.LoadIncompleteProbe(xmlDoc, configData.IncompleteProbe);
            lotXmlBinder.LoadShiftedAlignment(xmlDoc, configData.ShiftedAlignment);
            lotXmlBinder.LoadLotInfo(xmlDoc, configData.LotInfo);
        }

        #endregion

        #region public methods

        public bool Load(ConfigData configData, XmlDocument xmlDoc)
        {
            try
            {
                // calling both configuration routines, config type is no needed
                // there only particular items are presented in xmlDoc configuration stream
                LoadMapper(xmlDoc, configData);
                LoadLot(xmlDoc, configData);
            }
            catch (Exception ex)
            {
                LogIt.Error("Exception in ConfigXmlBinder.Load method:", ex);
                return false;
            }
            return true;
        }

        public void Save(ConfigData configData, string fileName, XmlDocument xmlDoc)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                xmlDoc.Save(fileName);
            }
            catch (Exception ex)
            {
                LogIt.Error("Exception in ConfigXmlBinder.Save method:", ex);
            }
        }

        #endregion
    }
}
