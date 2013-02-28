using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EI.Config
{
    /// <summary>
    /// Able to determine whether given lots match this filter's mask.
    /// Contains additional properties for matching lots.
    /// </summary>
    public class LotFilter
    {
        #region private fields

        private readonly string mask;
        private readonly Regex regex;

        private bool laserscribesHaveSemiChecksum;

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance of the filter.
        /// </summary>
        /// <param name="mask">The lot ID mask.
        /// The character <code>'*'</code> marks group of zero or more characters,
        /// <code>'?'</code> marks one character,
        /// everything else have to match lot ID exactly.</param>
        public LotFilter(string mask)
        {
            if (mask == null)
            {
                throw new ArgumentNullException("mask");
            }

            this.mask = mask;
            regex = CreateRegex(mask);
        }

        #endregion

        #region private methods

        /// <summary>
        /// Creates regular expression that is able to match the given mask.
        /// </summary>
        /// <param name="mask">The mask to create regular expression pattern from.</param>
        /// <returns>The <code>Regex</code> instance.</returns>
        private Regex CreateRegex(string mask)
        {
            string pattern = "^";

            foreach (char maskChar in mask)
            {
                if (maskChar == '?')
                {
                    pattern += ".";
                }
                else if (maskChar == '*')
                {
                    pattern += ".*";
                }
                else
                {
                    pattern += Regex.Escape(maskChar.ToString());
                }
            }

            pattern += "$";

            return new Regex(pattern);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Checks if the given lot matches this filter.
        /// </summary>
        /// <param name="lot">The lot to check.</param>
        /// <returns>The value <code>true</code> it the given lot matches this mask,
        /// <code>false</code> otherwise.</returns>
        public bool Matches(string lotId)
        {
            return regex.IsMatch(lotId);
        }

        #endregion

        #region public properties

        /// <summary>
        /// The lot ID mask.
        /// The character <code>'*'</code> marks group of zero or more characters,
        /// <code>'?'</code> marks one character,
        /// everything else have to match lot ID exactly.
        /// </summary>
        public string Mask
        {
            get { return mask; }
        }

        /// <summary>
        /// Whether wafers of the lot, which matches this filter, have laserscribes with SEMI checksum.
        /// </summary>
        public bool LaserscribesHaveSemiChecksum
        {
            get { return laserscribesHaveSemiChecksum; }
            set { laserscribesHaveSemiChecksum = value; }
        }

        #endregion
    }
}
