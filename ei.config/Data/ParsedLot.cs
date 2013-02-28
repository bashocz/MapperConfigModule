using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class ParsedLot
    {

        #region private field

        private string lotId;

        private string locationCode;

        private string serialNumber;

        #endregion

        #region public properties

        /// <summary>
        /// Location code as it would appear in PROMIS lot ID, e.g. <code>"SF"</code> for PROMIS lot ID <code>"SF63978.1X"</code>.
        /// This value don't have to be set for external lots (which don't have PROMIS lot ID).
        /// </summary>
        public string LocationCode
        {
            get { return locationCode; }
            set { locationCode = value; }
        }

        /// <summary>
        /// Serial number as it would appear in PROMIS lot ID, e.g. <code>"63978"</code> for PROMIS lot ID <code>"SF63978.1X"</code>.
        /// This value don't have to be set for external lots (which don't have PROMIS lot ID).
        /// </summary>
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
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
