using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Class represents a measured result that defines
    /// integer result value and three flags indicate whether
    /// result is good (passed), whether measurement could be
    /// reprobed and whether die could be inked.
    /// </summary>
    public class Bin
    {
        #region private fields

        /// <summary>
        /// A System.Int32 that specifies 
        /// the bin value of measurement result.
        /// </summary>
        private readonly int binValue;

        /// <summary>
        /// A System.Boolean that indicates
        /// whether die marked with this bin is good die.
        /// </summary>
        private readonly bool isGoodDie;

        /// <summary>
        /// A System.Boolean that indicates
        /// whether die marked with this bin could be reprobed.
        /// </summary>
        private readonly bool isReprobedDie;

        /// <summary>
        /// A System.Boolean that indicates
        /// whether die marked with this bin will be inked.
        /// </summary>
        private readonly bool isInkedDie;

        #endregion

        #region constructors

        /// <summary>
        /// Create the object of Bin.
        /// </summary>
        /// <param name="binValue">A System.Int32 that specifies 
        /// the bin value of measurement result.</param>
        /// <param name="isGoodDie">A System.Boolean that indicates
        /// whether die marked with this bin is good die.</param>
        /// <param name="isReprobedDie">A System.Boolean that indicates
        /// whether die marked with this bin could be reprobed.</param>
        /// <param name="isInkedDie">A System.Boolean that indicates
        /// whether die marked with this bin will be inked.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Argument binValue is out of range [0..255].</exception>
        public Bin(int binValue, bool isGoodDie, bool isReprobedDie, bool isInkedDie)
        {
            if ((binValue < 0) || (binValue > 255))
                throw new ArgumentOutOfRangeException("Bin constructor: Argument 'binValue' is out of range [0..255].");

            this.binValue = binValue;
            this.isGoodDie = isGoodDie;
            this.isReprobedDie = isReprobedDie;
            this.isInkedDie = isInkedDie;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Converts the value of this object to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "BinValue = " + binValue.ToString() + ", IsGoodDie = " + isGoodDie.ToString() +
                ", IsReprobedDie = " + isReprobedDie.ToString() + ", IsInkedDie = " + isInkedDie.ToString();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the BIN value defined result of measurement.
        /// </summary>
        public int BinValue
        {
            get { return binValue; }
        }

        /// <summary>
        /// Indicates whether BIN value respective measurement is passed.
        /// </summary>
        public bool IsGoodDie
        {
            get { return isGoodDie; }
        }

        /// <summary>
        /// Indicates whether die marked with this bin could be reprobed.
        /// </summary>
        public bool IsReprobedDie
        {
            get { return isReprobedDie; }
        }

        /// <summary>
        /// Indicates whether die marked with this bin will be inked.
        /// </summary>
        public bool IsInkedDie
        {
            get { return isInkedDie; }
        }

        #endregion
    }
}
