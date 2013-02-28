using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldGeneral : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement loginEnabledElement;

        private EnumXmlElement<SystemType> systemTypeElement;

        private EnumXmlElement<LogLevel> logLevelElement;

        private BooleanXmlElement longPauseEnabledElement;
        private IntegerXmlElement longPauseDelayTimeElement;

        private BooleanXmlElement towerLightEnabledElement;
        private IntegerXmlElement towerLightPortElement;

        private BooleanXmlElement alwaysSaveWaferMapsElement;

        private BooleanXmlElement errorDialogContinueEnabledElement;
        private BooleanXmlElement pauseDialogAfterWaferEnabledElement;
        private BooleanXmlElement pauseDialogAfterWaferAutoReleaseElement;

        #endregion

        #region constructors

        public XmlOldGeneral()
        {
            configElement = new SelfManagedXmlElement("General");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            loginEnabledElement = new BooleanXmlElement("EnableLogin", true);
            configElement.AddChild(loginEnabledElement);

            systemTypeElement = new EnumXmlElement<SystemType>("SystemType", SystemType.Prober);
            configElement.AddChild(systemTypeElement);

            logLevelElement = new EnumXmlElement<LogLevel>("LogLevel", LogLevel.Info);
            configElement.AddChild(logLevelElement);

            longPauseEnabledElement = new BooleanXmlElement("EnableLongPause", true);
            configElement.AddChild(longPauseEnabledElement);

            longPauseDelayTimeElement = new IntegerXmlElement("DelayTime", 600);
            configElement.AddChild(longPauseDelayTimeElement);

            towerLightEnabledElement = new BooleanXmlElement("EnableTowerLight", false);
            configElement.AddChild(towerLightEnabledElement);

            towerLightPortElement = new IntegerXmlElement("TowerLightPortAddress", 0x378);
            configElement.AddChild(towerLightPortElement);

            alwaysSaveWaferMapsElement = new BooleanXmlElement("AlwaysSaveWaferMaps", false);
            configElement.AddChild(alwaysSaveWaferMapsElement);

            errorDialogContinueEnabledElement = new BooleanXmlElement("ErrorDialogContinueEnabled", false);
            configElement.AddChild(errorDialogContinueEnabledElement);

            pauseDialogAfterWaferEnabledElement = new BooleanXmlElement("PauseDialogAfterWaferEnabled", true);
            configElement.AddChild(pauseDialogAfterWaferEnabledElement);

            pauseDialogAfterWaferAutoReleaseElement = new BooleanXmlElement("PauseDialogAfterWaferAutoRelease", true);
            configElement.AddChild(pauseDialogAfterWaferAutoReleaseElement);
        }

        #endregion

        #region public properties

        public bool LoginEnabled
        {
            get { return loginEnabledElement.Value; }
            set { loginEnabledElement.Value = value; }
        }

        public SystemType SystemType
        {
            get { return systemTypeElement.Value; }
            set { systemTypeElement.Value = value; }
        }

        public LogLevel LogLevel
        {
            get { return logLevelElement.Value; }
            set { logLevelElement.Value = value; }
        }

        public bool LongPauseEnabled
        {
            get { return longPauseEnabledElement.Value; }
            set { longPauseEnabledElement.Value = value; }
        }

        public int LongPauseDelayTime
        {
            get { return longPauseDelayTimeElement.Value; }
            set { longPauseDelayTimeElement.Value = value; }
        }

        public bool TowerLightEnabled
        {
            get { return towerLightEnabledElement.Value; }
            set { towerLightEnabledElement.Value = value; }
        }

        public int TowerLightPort
        {
            get { return towerLightPortElement.Value; }
            set { towerLightPortElement.Value = value; }
        }

        public bool AlwaysSaveWaferMaps
        {
            get { return alwaysSaveWaferMapsElement.Value; }
            set { alwaysSaveWaferMapsElement.Value = value; }
        }

        public bool ErrorDialogContinueEnabled
        {
            get { return errorDialogContinueEnabledElement.Value; }
            set { errorDialogContinueEnabledElement.Value = value; }
        }

        public bool PauseDialogAfterWaferEnabled
        {
            get { return pauseDialogAfterWaferEnabledElement.Value; }
            set { pauseDialogAfterWaferEnabledElement.Value = value; }
        }

        public bool PauseDialogAfterWaferAutoRelease
        {
            get { return pauseDialogAfterWaferAutoReleaseElement.Value; }
            set { pauseDialogAfterWaferAutoReleaseElement.Value = value; }
        }

        #endregion
    }
}
