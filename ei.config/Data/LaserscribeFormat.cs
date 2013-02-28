using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Defines wafer laserscribe format and methods for parsing laserscribes.
    /// </summary>
    public class LaserscribeFormat
    {
        #region private fields

        private string mask;

        private bool enabled;

        #endregion

        #region constructors

        /// <summary>
        /// Creates empty instance.
        /// </summary>
        public LaserscribeFormat()
        {
        }

        /// <summary>
        /// Creates instance filled with given data.
        /// </summary>
        /// <param name="mask">The format mask.</param>
        /// <param name="enabled">If this format mask is enabled.</param>
        public LaserscribeFormat(string mask, bool enabled)
        {
            this.mask = mask;
            this.enabled = enabled;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Tries to parse given laserscribe against laserscribe format this instance represents.
        /// </summary>
        /// <param name="laserscribe">The laserscribe to parse.</param>
        /// <param name="externalLot">Whether the given laserscribe should belong to an external lot (not from Onsemi) so it cannot contain PROMIS lot ID etc.</param>
        /// <returns>The information extracted from the laserscribe.</returns>
        /// <exception cref="System.FormatException">When parsing failed.</exception>
        /// <exception cref="System.ArgumentNullException">When some argument is <code>null</code>.</exception>
        public ParsedLaserscribe ParseLaserscribe(string laserscribe, bool externalLot)
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
            //pric
            //if (externalLot)
            //{
            //    actualMask = actualMask.Replace('L', '?');
            //    actualMask = actualMask.Replace('1', '?');
            //    actualMask = actualMask.Replace('2', '?');
            //    actualMask = actualMask.Replace('3', '?');
            //    actualMask = actualMask.Replace('4', '?');
            //    actualMask = actualMask.Replace('5', '?');
            //}

            string waferLocationCode = string.Empty;
            string lotId = string.Empty;
            StringBuilder serialNumberChars = new StringBuilder("?????");
            string waferNumber = string.Empty;

            for (int i = 0; i < actualMask.Length; i++)
            {
                char maskChar = actualMask[i];
                char parsedChar = laserscribe[i];

                switch (maskChar)
                {
                    case 'L':
                        if(!externalLot)
                            waferLocationCode += parsedChar;

                        lotId += parsedChar;
                        break;
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                        if (!externalLot)
                        {
                            if (Char.IsDigit(parsedChar))
                            {
                                int idx = int.Parse(maskChar.ToString()) - 1;
                                serialNumberChars[idx] = parsedChar;
                            }
                            else
                            {
                                throw new FormatException("expected digit on position " + i);
                            }
                        }

                        lotId += parsedChar;
                        break;

                    case 'N':
                        if (Char.IsDigit(parsedChar))
                        {
                            waferNumber += parsedChar;
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

            if ((waferLocationCode.Length != 0) && (waferLocationCode.Length != 2))
            {
                throw new FormatException("wafer location code is not 2 characters long");
            }

            if (waferLocationCode.Length == 0)
            {
                result.WaferLocationCode = null;
            }
            else
            {
                result.WaferLocationCode = waferLocationCode;
            }

            result.SerialNumber = serialNumberChars.ToString();

            if (result.SerialNumber.Equals("?????"))
            {
                // no promis lot ID expected in laserscribe
                result.SerialNumber = null;
            }
            else if (result.SerialNumber.Contains("?"))
            {
                // promis lot ID does not contain all characters
                throw new FormatException("serial number is not 5 digits");
            }

            if (lotId.Length > 0)
            {
                result.LotId = lotId;
            }

            else
            {
                result.LotId = null;
            }

            if (waferNumber.Length > 0)
            {
                result.WaferNumber = int.Parse(waferNumber);
            }
            else
            {
                result.WaferNumber = null;
            }

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
        /// If this format mask is enabled.
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// If this format mask contains SEMI checksum.
        /// </summary>
        public bool IsSemiChecksum
        {
            get { return (mask != null && mask.EndsWith("CC")); }
        }

        #endregion
    }
}
