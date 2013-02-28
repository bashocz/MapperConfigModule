using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldGpib
    {
        #region private fields

        private SelfManagedXmlNode xmlNode;

        private BooleanXmlElement systemControllerElement;
        private IntegerXmlElement boardIndexElement;
        private IntegerXmlElement boardPrimaryAddressElement;
        private IntegerXmlElement boardSecondaryAddressElement;
        private IntegerXmlElement devicePrimaryAddressElement;
        private IntegerXmlElement deviceSecondaryAddressElement;
        private BooleanXmlElement isEoiElement;
        private BooleanXmlElement isEosElement;
        private BooleanXmlElement eightBitEosElement;
        private IntegerXmlElement eosCharElement;

        #endregion

        #region constructors

        public XmlOldGpib()
        {
            xmlNode = new SelfManagedXmlElement("GPIB");

            systemControllerElement = new BooleanXmlElement("SystemController", true);
            xmlNode.AddChild(systemControllerElement);

            boardIndexElement = new IntegerXmlElement("BoardIndex", 0);
            xmlNode.AddChild(boardIndexElement);

            boardPrimaryAddressElement = new IntegerXmlElement("BoardPrimaryAddress", 0);
            xmlNode.AddChild(boardPrimaryAddressElement);

            boardSecondaryAddressElement = new IntegerXmlElement("BoardSecondaryAddress", 0); // 0 is NONE
            xmlNode.AddChild(boardSecondaryAddressElement);

            devicePrimaryAddressElement = new IntegerXmlElement("DevicePrimaryAddress", 1);
            xmlNode.AddChild(devicePrimaryAddressElement);

            deviceSecondaryAddressElement = new IntegerXmlElement("DeviceSecondaryAddress", 0); // 0 is NONE
            xmlNode.AddChild(deviceSecondaryAddressElement);

            isEoiElement = new BooleanXmlElement("IsEOI", true);
            xmlNode.AddChild(isEoiElement);

            isEosElement = new BooleanXmlElement("IsEOS", false);
            xmlNode.AddChild(isEosElement);

            eightBitEosElement = new BooleanXmlElement("EightBitEOS", false);
            xmlNode.AddChild(eightBitEosElement);

            eosCharElement = new IntegerXmlElement("EowChar", 0);
            xmlNode.AddChild(eosCharElement);
        }

        #endregion

        #region public properties

        public SelfManagedXmlNode XmlNode
        {
            get { return xmlNode; }
        }

        public bool SystemController
        {
            get { return systemControllerElement.Value; }
            set { systemControllerElement.Value = value; }
        }

        public int BoardIndex
        {
            get { return boardIndexElement.Value; }
            set { boardIndexElement.Value = value; }
        }

        public int BoardPrimaryAddress
        {
            get { return boardPrimaryAddressElement.Value; }
            set { boardPrimaryAddressElement.Value = value; }
        }

        public int BoardSecondaryAddress
        {
            get { return boardSecondaryAddressElement.Value; }
            set { boardSecondaryAddressElement.Value = value; }
        }

        public int DevicePrimaryAddress
        {
            get { return devicePrimaryAddressElement.Value; }
            set { devicePrimaryAddressElement.Value = value; }
        }

        public int DeviceSecondaryAddress
        {
            get { return deviceSecondaryAddressElement.Value; }
            set { deviceSecondaryAddressElement.Value = value; }
        }

        public bool IsEoi
        {
            get { return isEoiElement.Value; }
            set { isEoiElement.Value = value; }
        }

        public bool IsEos
        {
            get { return isEosElement.Value; }
            set { isEosElement.Value = value; }
        }

        public bool EightBitEos
        {
            get { return eightBitEosElement.Value; }
            set { eightBitEosElement.Value = value; }
        }

        public byte EosChar
        {
            get { return (byte)eosCharElement.Value; }
            set { eosCharElement.Value = value; }
        }

        #endregion
    }
}
