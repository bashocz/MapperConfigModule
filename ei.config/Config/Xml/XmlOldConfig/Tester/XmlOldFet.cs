using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldFet : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement fetElement;

        private IntegerXmlElement boardNoElement;
        private BooleanXmlElement enableSendingXyCoordsElement;
        private XmlOldGpib gpibElement;

        #endregion

        #region constructors

        public XmlOldFet()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            fetElement = new SelfManagedXmlElement("FetTtl");
            testersElement.AddChild(fetElement);

            boardNoElement = new IntegerXmlElement("BoardNo", 0);
            fetElement.AddChild(boardNoElement);

            enableSendingXyCoordsElement = new BooleanXmlElement("EnableSendingXYCoordinates", true);
            fetElement.AddChild(enableSendingXyCoordsElement);

            gpibElement = new XmlOldGpib();
            fetElement.AddChild(gpibElement.XmlNode);
        }

        #endregion

        #region public properties

        public int BoardNo
        {
            get { return boardNoElement.Value; }
            set { boardNoElement.Value = value; }
        }

        public bool EnableSendingXyCoords
        {
            get { return enableSendingXyCoordsElement.Value; }
            set { enableSendingXyCoordsElement.Value = value; }
        }
        public XmlOldGpib Gpib
        {
            get { return gpibElement; }
        }

        #endregion
    }
}
