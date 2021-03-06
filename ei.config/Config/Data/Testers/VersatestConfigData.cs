using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class VersatestConfigData : BaseConfigData<VersatestConfigData>
    {
        #region private fields

        private SerialPortConfigData serial;

        #endregion

        #region constructors

        public VersatestConfigData()
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
            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

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