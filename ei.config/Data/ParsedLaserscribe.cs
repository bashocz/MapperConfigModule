using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Information extracted from wafer laserscribe.
    /// </summary>
    public class ParsedLaserscribe
    {
        #region private fields

        private string waferLocationCode;

        private string serialNumber;

        private string lotId;

        private int? waferNumber;

        #endregion

        #region constructors

        #endregion

        #region public properties

        /// <summary>
        /// Location code of the wafer as it would appear in PROMIS lot ID, e.g. <code>"SF"</code> for PROMIS lot ID <code>"SF63978.1X"</code>.
        /// This value don't have to be set for external lots (which don't have PROMIS lot ID).
        /// </summary>
        public string WaferLocationCode
        {
            get { return waferLocationCode; }
            set { waferLocationCode = value; }
        }

        /// <summary>
        /// Serial number of the wafer as it would appear in PROMIS lot ID, e.g. <code>"63978"</code> for PROMIS lot ID <code>"SF63978.1X"</code>.
        /// This value don't have to be set for external lots (which don't have PROMIS lot ID).
        /// </summary>
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }

        /// <summary>
        /// Unique wafer number in the lot. Does not need to have a value.
        /// </summary>
        public int? WaferNumber
        {
            get { return waferNumber; }
            set { waferNumber = value; }
        }

        /// <summary>
        /// Unique lot Id. Does not need to have a value.
        /// </summary>
        public string LotId
        {
            get { return lotId; }
            set { lotId = value; }
        }

        #endregion
    }
}
