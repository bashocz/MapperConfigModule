using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldKeithley : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement keithleyElement;

        private StringXmlElement scriptFileNameElement;
        private StringXmlElement csvOutputDirElement;
        private XmlOldGpib gpibElement;

        #endregion

        #region constructors

        public XmlOldKeithley()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            keithleyElement = new SelfManagedXmlElement("Keithley");
            testersElement.AddChild(keithleyElement);

            scriptFileNameElement = new StringXmlElement("ScriptFileName", "");
            keithleyElement.AddChild(scriptFileNameElement);

            csvOutputDirElement = new StringXmlElement("CsvOutputDir", "C:\\Mapper\\Keithley\\Stdf");
            keithleyElement.AddChild(csvOutputDirElement);

            gpibElement = new XmlOldGpib();
            keithleyElement.AddChild(gpibElement.XmlNode);
        }

        #endregion

        #region public properties

        public string ScriptFileName
        {
            get { return scriptFileNameElement.Value; }
            set { scriptFileNameElement.Value = value; }
        }

        public string CsvOutputDir
        {
            get { return csvOutputDirElement.Value; }
            set { csvOutputDirElement.Value = value; }
        }
        public XmlOldGpib Gpib
        {
            get { return gpibElement; }
        }

        #endregion
    }
}
