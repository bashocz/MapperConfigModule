using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldVirtualTester : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement vtElement;

        private IntegerXmlElement connectElement;
        private IntegerXmlElement disconnectElement;
        private IntegerXmlElement initElement;
        private IntegerXmlElement startLotElement;
        private IntegerXmlElement endLotElement;
        private IntegerXmlElement startWaferElement;
        private IntegerXmlElement endWaferElement;
        private IntegerXmlElement probeDieElement;
        private IntegerXmlElement probeDieFinishedElement;
        private IntegerXmlElement getTestProgramNameElement;
        private IntegerXmlElement getTemperatureElement;

        private BooleanXmlElement isRandomElement;
        private IntegerXmlElement yieldElement;
        private BooleanXmlElement isGrowingElement;
        private StringXmlElement inputWmxmlPathElement;

        #endregion

        #region constructors

        public XmlOldVirtualTester()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            vtElement = new SelfManagedXmlElement("Virtual");
            vtElement.ClearAllChildren = true;
            testersElement.AddChild(vtElement);

            connectElement = new IntegerXmlElement("ConnectDelay", 0);
            vtElement.AddChild(connectElement);

            disconnectElement = new IntegerXmlElement("DisconnectDelay", 0);
            vtElement.AddChild(disconnectElement);

            initElement = new IntegerXmlElement("InitDelay", 1000);
            vtElement.AddChild(initElement);

            startLotElement = new IntegerXmlElement("StartLotDelay", 2000);
            vtElement.AddChild(startLotElement);

            endLotElement = new IntegerXmlElement("EndLotDelay", 0);
            vtElement.AddChild(endLotElement);

            startWaferElement = new IntegerXmlElement("StartWaferDelay", 100);
            vtElement.AddChild(startWaferElement);

            endWaferElement = new IntegerXmlElement("EndWaferDelay", 100);
            vtElement.AddChild(endWaferElement);

            probeDieElement = new IntegerXmlElement("ProbeDieDelay", 1);
            vtElement.AddChild(probeDieElement);

            probeDieFinishedElement = new IntegerXmlElement("ProbeDieFinishedDelay", 0);
            vtElement.AddChild(probeDieFinishedElement);

            getTestProgramNameElement = new IntegerXmlElement("GetTestProgramNameDelay", 0);
            vtElement.AddChild(getTestProgramNameElement);

            getTemperatureElement = new IntegerXmlElement("GetTemperatureDelay", 0);
            vtElement.AddChild(getTemperatureElement);

            isRandomElement = new BooleanXmlElement("IsRandom", true);
            vtElement.AddChild(isRandomElement);

            yieldElement = new IntegerXmlElement("Yield", 100);
            vtElement.AddChild(yieldElement);

            isGrowingElement = new BooleanXmlElement("IsGrowing", false);
            vtElement.AddChild(isGrowingElement);

            inputWmxmlPathElement = new StringXmlElement("InputWmxmlPath", "C:\\Mapper\\VirtualTester\\InputMaps");
            vtElement.AddChild(inputWmxmlPathElement);
        }

        #endregion

        #region public properties

        public int ConnectDelay
        {
            get { return connectElement.Value; }
            set { connectElement.Value = value; }
        }

        public int DisconnectDelay
        {
            get { return disconnectElement.Value; }
            set { disconnectElement.Value = value; }
        }

        public int InitDelay
        {
            get { return initElement.Value; }
            set { initElement.Value = value; }
        }

        public int StartLotDelay
        {
            get { return startLotElement.Value; }
            set { startLotElement.Value = value; }
        }

        public int EndLotDelay
        {
            get { return endLotElement.Value; }
            set { endLotElement.Value = value; }
        }

        public int StartWaferDelay
        {
            get { return startWaferElement.Value; }
            set { startWaferElement.Value = value; }
        }

        public int EndWaferDelay
        {
            get { return endWaferElement.Value; }
            set { endWaferElement.Value = value; }
        }

        public int ProbeDieDelay
        {
            get { return probeDieElement.Value; }
            set { probeDieElement.Value = value; }
        }

        public int ProbeDieFinishedDelay
        {
            get { return probeDieFinishedElement.Value; }
            set { probeDieFinishedElement.Value = value; }
        }

        public int GetTestProgramNameDelay
        {
            get { return getTestProgramNameElement.Value; }
            set { getTestProgramNameElement.Value = value; }
        }

        public int GetTemperatureDelay
        {
            get { return getTemperatureElement.Value; }
            set { getTemperatureElement.Value = value; }
        }

        public bool IsRandom
        {
            get { return isRandomElement.Value; }
            set { isRandomElement.Value = value; }
        }

        public int Yield
        {
            get { return yieldElement.Value; }
            set { yieldElement.Value = value; }
        }

        public bool IsGrowing
        {
            get { return isGrowingElement.Value; }
            set { isGrowingElement.Value = value; }
        }

        public string InputWmxmlPath
        {
            get { return inputWmxmlPathElement.Value; }
            set { inputWmxmlPathElement.Value = value; }
        }

        #endregion
    }
}
