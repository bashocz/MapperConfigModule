using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldNewton : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private StringXmlElement newtonFileElement;
        private StringXmlElement newtonMapDirElement;
        private StringXmlElement statusFileElement;
        private IntegerXmlElement timeoutElement;

        #endregion

        #region constructors

        public XmlOldNewton()
        {
            configElement = new SelfManagedXmlElement("Newton");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("Enabled", false);
            configElement.AddChild(enabledElement);

            newtonFileElement = new StringXmlElement("NewtonPath", "C:\\Mapper\\Gatekeeper\\NewtUtils.bat");
            configElement.AddChild(newtonFileElement);

            newtonMapDirElement = new StringXmlElement("NewtonMapPath", "C:\\Mapper\\Gatekeeper\\Maps");
            configElement.AddChild(newtonMapDirElement);

            statusFileElement = new StringXmlElement("StatusFile", "C:\\Mapper\\Gatekeeper\\Status.txt");
            configElement.AddChild(statusFileElement);

            timeoutElement = new IntegerXmlElement("NewtonTimeout", 600);
            configElement.AddChild(timeoutElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public string NewtonFile
        {
            get { return newtonFileElement.Value; }
            set { newtonFileElement.Value = value; }
        }

        public string NewtonMapDir
        {
            get { return newtonMapDirElement.Value; }
            set { newtonMapDirElement.Value = value; }
        }

        public string StatusFile
        {
            get { return statusFileElement.Value; }
            set { statusFileElement.Value = value; }
        }

        public int Timeout
        {
            get { return timeoutElement.Value; }
            set { timeoutElement.Value = value; }
        }

        #endregion
    }
}
