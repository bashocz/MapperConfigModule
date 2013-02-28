using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class MaskFormat
    {
        #region private field

        /// <summary>
        /// String representing specific mask.
        /// </summary>
        private string mask;

        /// <summary>
        /// Indicate if mask is enabled
        /// </summary>
        private bool enabled;

        #endregion

        #region constructors

        /// <summary>
        /// Create empty instance
        /// </summary>
        public MaskFormat()
        {
        }

        /// <summary>
        /// Creates instance filled with given data.
        /// </summary>
        /// <param name="mask">The format mask.</param>
        /// <param name="enabled">If this format mask is enabled.</param>
        public MaskFormat(string mask, bool enabled)
        {
            this.mask = mask;
            this.enabled = enabled;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Tries to parse given laserscribe against laserscribe mask this instance represents.
        /// </summary>
        /// <param name="laserscribe">The laserscribe to parse.</param>
        /// <returns>The information extracted from the laserscribe.</returns>
        /// <exception cref="System.FormatException">When parsing failed.</exception>
        /// <exception cref="System.ArgumentNullException">When some argument is <code>null</code>.</exception>
        public ParsedLaserscribe ParseLaserscribe(string laserscribe)
        {
            if (laserscribe == null)
            {
                throw new ArgumentNullException("laserscribe");
            }

            if (laserscribe.Length != mask.Length)
            {
                throw new FormatException("laserscribe length does not match format length");
            }

            string actualMask = mask;

            string locationCode = null;
            string serialNumber = null;
            string parsedLotId = null;
            string waferNumber = null;

            for (int i = 0; i < actualMask.Length; i++)
            {
                char maskChar = actualMask[i];
                char parsedChar = laserscribe[i];

                switch (maskChar)
                {
                    case 'l':
                        parsedLotId += parsedChar;
                        break;
                    case 'L':
                        locationCode += parsedChar;
                        parsedLotId += parsedChar;
                        break;
                    case 'N':
                        if (Char.IsDigit(parsedChar))
                        {
                            string serialNumberChar = Convert.ToString(parsedChar);
                            serialNumber += serialNumberChar;
                            parsedLotId += serialNumberChar;
                        }
                        else
                        {
                            throw new FormatException("expected digit on position " + i);
                        }

                        break;

                    case 'W':
                        if (Char.IsDigit(parsedChar))
                        {
                            waferNumber += parsedChar;
                            break;
                        }
                        else
                        {
                            throw new FormatException("expected digit on position " + i);
                        }
                    case 'C':
                    case '?':
                        break;
                    default:
                        if (maskChar != parsedChar)
                        {
                            throw new FormatException("expected char '" + maskChar + "' on position " + i);
                        }
                        break;
                }
            }

            ParsedLaserscribe result = new ParsedLaserscribe();

            if ((locationCode != null) && (locationCode.Length != 2))
            {
                throw new FormatException("wafer location code is not 2 characters long");
            }

            if (serialNumber != null && serialNumber.Length != 5)
            {
                throw new FormatException("serial number is not 5 digits");
            }

            result.WaferLocationCode = locationCode;
            result.SerialNumber = serialNumber;
            result.LotId = parsedLotId;
            if (waferNumber != null)
                result.WaferNumber = Convert.ToInt32(waferNumber);
            else
                result.WaferNumber = null;
            return result;

        }

        /// <summary>
        /// Tries to parse given lot ID against lot ID mask this instance represents.
        /// </summary>
        /// <param name="laserscribe">The lot ID to parse.</param>
        /// <returns>The information extracted from the lot ID.</returns>
        /// <exception cref="System.FormatException">When parsing failed.</exception>
        /// <exception cref="System.ArgumentNullException">When some argument is <code>null</code>.</exception>
        public ParsedLot ParseLotId(string lotId)
        {
            if (lotId == null)
            {
                throw new ArgumentNullException("lotId");
            }

            if (lotId.Length != mask.Length)
            {
                throw new FormatException("LotId length does not match format length");
            }

            string locationCode = null;
            string serialNumber = null;
            string parsedLotId = null;

            for (int i = 0; i < mask.Length; i++)
            {
                char maskChar = mask[i];
                char parsedChar = lotId[i];

                switch (maskChar)
                {
                    case 'L':
                        locationCode += parsedChar;
                        parsedLotId += parsedChar;
                        break;

                    case 'N':

                        if (Char.IsDigit(parsedChar))
                        {
                            string serialNumberChar = Convert.ToString(parsedChar);
                            serialNumber += serialNumberChar;
                            parsedLotId += serialNumberChar;
                        }
                        else
                        {
                            throw new FormatException("expected digit on position " + i);
                        }

                        break;

                    case 'l':
                        parsedLotId += parsedChar;
                        break;

                    case '?':
                        break;

                    default:
                        if (maskChar != parsedChar)
                        {
                            throw new FormatException("expected char '" + maskChar + "' on position " + i);
                        }
                        break;
                }
            }

            ParsedLot result = new ParsedLot();

            if (locationCode != null && locationCode.Length != 2)
            {
                throw new FormatException("location code is not 2 characters long");
            }

            if (serialNumber != null && serialNumber.Length != 5)
            {
                throw new FormatException("serial number is not 5 digits");
            }

            result.LotId = parsedLotId;
            result.LocationCode = locationCode;
            result.SerialNumber = serialNumber;

            return result;
        }

        /// <summary>
        /// Returns human readable representation of this object.
        /// </summary>
        /// <returns>The objects' representation.</returns>
        public override string ToString()
        {
            return mask;
        }

        #endregion

        #region public properties

        /// <summary>
        /// Format mask.
        /// </summary>
        public string Mask
        {
            get { return mask; }
            set { mask = value; }
        }

        /// <summary>
        /// If this mask is enabled.
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// If this mask contains SEMI checksum.
        /// </summary>
        public bool IsSemiChecksum
        {
            get { return (mask != null && mask.EndsWith("CC")); }
        }

        #endregion

    }
}
