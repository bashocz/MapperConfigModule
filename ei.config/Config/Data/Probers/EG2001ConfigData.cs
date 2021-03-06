using System;
using System.IO.Ports;
using System.Xml;
using System.Reflection;

namespace EI.Config
{
    public class Eg2001ConfigData : BaseConfigData<Eg2001ConfigData>
    {
        #region private fields

        private bool enableManualMicroCoordsChange;
        private SerialPortConfigData serial;

        #endregion

        #region constructors

        public Eg2001ConfigData()
            : base()
        {
            serial = new SerialPortConfigData();

            childList.Add(serial as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enableManualMicroCoordsChange = false;

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        /// <summary>
        /// If this property is set to true, 
        /// the user can modify micro-coords manualy and mapper will not 
        /// repaire them after the mapper is released from the pause.
        /// </summary>
        public bool EnableManualMicroCoordsChange
        {
            get { return enableManualMicroCoordsChange; }
            set { SetValue(ref enableManualMicroCoordsChange, value); }
        }

        /// <summary>
        /// Sub configuration data for serial port.
        /// </summary>
        public SerialPortConfigData Serial
        {
            get { return serial; }
        }

        #endregion
    }
}
