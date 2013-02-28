using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace EI.Config
{
    internal class XmlOldDb : XmlOldBase
    {
        #region nested classes

        private class CryptorEngine
        {
            private const string key = "KeyForEncrypt/Decrypt";

            public CryptorEngine()
            {
            }

            /// <summary>
            /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
            /// </summary>
            /// <param name="toEncrypt">string to be encrypted</param>
            /// <returns></returns>
            public string Encrypt(string toEncrypt)
            {
                if (string.IsNullOrEmpty(toEncrypt))
                    return string.Empty;

                byte[] keyArray;
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            /// <summary>
            /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
            /// </summary>
            /// <param name="cipherString">encrypted string</param>
            /// <returns></returns>
            public string Decrypt(string cipherString)
            {
                try
                {
                    byte[] keyArray;
                    byte[] toEncryptArray = Convert.FromBase64String(cipherString);

                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    tdes.Clear();
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch (Exception ex)
                {
                    LogIt.Warning("CryptorEngine.Decrypt: " + ex.Message);
                    return null;
                }
            }
        }

        #endregion

        #region private fields

        private BooleanXmlElement enabledElement;

        private StringXmlElement databaseServerNameElement;
        private StringXmlElement databaseNameElement;
        private IntegerXmlElement portElement;
        private StringXmlElement userIdElement;
        private StringXmlElement passwordElement;

        private BooleanXmlElement useTrakLotElement;

        #endregion

        #region constructors

        public XmlOldDb()
        {
            configElement = new SelfManagedXmlElement("Database");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("IsEnabled", true);
            configElement.AddChild(enabledElement);

            databaseServerNameElement = new StringXmlElement("DatabaseServerName", string.Empty);
            configElement.AddChild(databaseServerNameElement);

            databaseNameElement = new StringXmlElement("DatabaseName", string.Empty);
            configElement.AddChild(databaseNameElement);

            portElement = new IntegerXmlElement("Port", 1521);
            configElement.AddChild(portElement);

            userIdElement = new StringXmlElement("UserId", string.Empty);
            configElement.AddChild(userIdElement);

            passwordElement = new StringXmlElement("Password", string.Empty);
            configElement.AddChild(passwordElement);

            useTrakLotElement = new BooleanXmlElement("UseTrakLotId", true);
            configElement.AddChild(useTrakLotElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public string DatabaseServerName
        {
            get { return databaseServerNameElement.Value; }
            set { databaseServerNameElement.Value = value; }
        }

        public string DatabaseName
        {
            get { return databaseNameElement.Value; }
            set { databaseNameElement.Value = value; }
        }

        public int Port
        {
            get { return portElement.Value; }
            set { portElement.Value = value; }
        }

        public string UserId
        {
            get { return userIdElement.Value; }
            set { userIdElement.Value = value; }
        }

        public string Password
        {
            get
            {
                CryptorEngine cryptor = new CryptorEngine();
                return cryptor.Decrypt(passwordElement.Value);
            }
            set
            {
                CryptorEngine cryptor = new CryptorEngine();
                passwordElement.Value = cryptor.Encrypt(value);
            }
        }

        public bool UseTrakLot
        {
            get { return useTrakLotElement.Value; }
            set { useTrakLotElement.Value = value; }
        }

        #endregion
    }
}
