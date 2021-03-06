using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace EI.Config
{
    /// <summary>
    /// Universal config data for serial port wrapper settings. It is usually used as part of another config data.
    /// </summary>
    public class SerialPortConfigData : BaseConfigData<SerialPortConfigData>
    {
        #region private fields

        private string portName;
        private int baudRate;
        private Parity parity;
        private int dataBits;
        private StopBits stopBits;
        private string separator;

        #endregion

        #region constructors

        public SerialPortConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            portName = "COM1";
            baudRate = 9600;
            parity = Parity.None;
            dataBits = 7;
            stopBits = StopBits.One;
            separator = "\\LF";
        }

        #endregion

        #region private methods

        /// <summary>
        /// Checks if separator is correct.
        /// </summary>
        /// <param name="separator">The escaped separator string.</param>
        /// <exception cref="System.Exception">When separator cannot be parsed.</exception>
        private void CheckSeparator(string separator)
        {
            ParseSeparator(separator);
        }

        private string ParseSeparator(string separator)
        {
            const char escChar = '\\';
            bool wasEscChar = false;
            string result = "";
            string token = "";

            foreach (char s in separator)
            {
                if (s == escChar)
                {
                    if (wasEscChar)
                    {
                        result += ParseSeparatorToken(token);
                    }
                    else if (!string.IsNullOrEmpty(token.Trim()))
                    {
                        throw new FormatException("illegal characters prior to escape character: \"" + token + "\"");
                    }

                    token = "";
                    wasEscChar = true;
                }
                else
                {
                    token += s.ToString();
                }
            }

            if (wasEscChar)
            {
                result += ParseSeparatorToken(token);
            }
            else if (!string.IsNullOrEmpty(token.Trim()))
            {
                throw new FormatException("illegal characters prior to escape character: \"" + token + "\"");
            }

            return result;
        }

        private string ParseSeparatorToken(string token)
        {
            if ("CR".Equals(token.ToUpperInvariant().Trim()))
            {
                return "\r";
            }
            else if ("LF".Equals(token.ToUpperInvariant().Trim()))
            {
                return "\n";
            }
            else
            {
                int charCode = Convert.ToInt32(token);
                if ((charCode < (int)Char.MinValue) || (charCode > (int)Char.MaxValue))
                {
                    throw new OverflowException("character value too small or big: " + charCode);
                }
                return ((char)charCode).ToString();
            }
        }

        #endregion

        #region properties

        public string PortName
        {
            get { return portName; }
            set { SetValue(ref portName, value); }
        }

        public int BaudRate
        {
            get { return baudRate; }
            set { SetValue(ref baudRate, value); }
        }

        public Parity Parity
        {
            get { return parity; }
            set { SetEnumValue(ref parity, value); }
        }

        public int DataBits
        {
            get { return dataBits; }
            set { SetValue(ref dataBits, value); }
        }

        public StopBits StopBits
        {
            get { return stopBits; }
            set { SetEnumValue(ref stopBits, value); }
        }

        /// <summary>
        /// Escaped separator string (just for display and editing).
        /// </summary>
        /// <exception cref="System.Exception">When trying to set to something wrong.</exception>
        public string Separator
        {
            get { return separator; }
            set
            {
                CheckSeparator(value);
                SetValue(ref separator, value);
            }
        }

        /// <summary>
        /// Raw unescaped separator value, for real use.
        /// It can also be empty or null string, be careful about this.
        /// </summary>
        public string NewLine
        {
            get
            {
                return ParseSeparator(separator);
            }
        }

        #endregion
    }
}
