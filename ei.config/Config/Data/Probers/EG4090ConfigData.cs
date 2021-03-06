using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class Eg4090ConfigData : BaseConfigData<Eg4090ConfigData>
    {
        #region private fields

        private bool sendProfileData;
        private ProberCommandSequence commandSequenceAfterLoadWafer;

        private EgCommunicationType communicationType;

        private GpibConfigData gpib;
        private SerialPortConfigData serial;

        #endregion

        #region constructors

        public Eg4090ConfigData()
            : base()
        {
            gpib = new GpibConfigData();
            serial = new SerialPortConfigData();

            childList.Add(gpib as IBaseConfigData);
            childList.Add(serial as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            sendProfileData = false;
            commandSequenceAfterLoadWafer = ProberCommandSequence.AlignProfile;
            communicationType = EgCommunicationType.GPIB;

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        public bool SendProfileData
        {
            get { return sendProfileData; }
            set { SetValue(ref sendProfileData, value); }
        }

        public ProberCommandSequence CommandSequenceAfterLoadWafer
        {
            get { return commandSequenceAfterLoadWafer; }
            set { commandSequenceAfterLoadWafer = value; }
        }

        /// <summary>
        /// The type of the communication used to communicate with a prober.
        /// </summary>
        public EgCommunicationType CommunicationType
        {
            get { return communicationType; }
            set { communicationType = value; }
        }

        /// <summary>
        /// Sub configuration data for the GPIB settings.
        /// </summary>
        public GpibConfigData Gpib
        {
            get { return gpib; }
        }

        /// <summary>
        /// Sub configuration data for the serial port settings.
        /// </summary>
        public SerialPortConfigData Serial
        {
            get { return serial; }
        }

        #endregion
    }
}
