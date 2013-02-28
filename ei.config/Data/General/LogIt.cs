using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace EI.Config
{
    public class LogIt
    {
        #region constants

        private const string logFileNameConst = "log_{0}.txt";
        private const string simpleFileNameConst = "simple_{0}.txt";
        private const string formatDateTimeConst = "yyyy-MM-dd_HH-mm";

        #endregion

        #region private fields

        private static DateTime timeStamp;

        private static DirConfigData configData;

        private static string logFileName;
        private static string simpleFileName;
        private static string testFileName;
        private static string initialLogFileName = null;
        private static bool isUnitTest = false;
        private static bool copyNextCreatedLog = false;
        private static bool isFirstWaferBased = false;

        #endregion

        #region constructors

        static LogIt()
        {
        }

        #endregion

        #region public methods

        public static void Open(bool isUnitTest)
        {
        }

        /// <summary>
        /// Creates logging based on lot ID / wafer number provided.
        /// </summary>
        /// <param name="lotID">A System.String that specifies
        /// lot ID for file naming.</param>
        /// <param name="waferNumber">A System.String that specifies
        /// wafer number for file naming.</param>
        /// <param name="isWaferBased">A System.Boolean that specifies
        /// whether logging is wafer-based. Lot-based if false.</param>
        /// <returns></returns>
        public static void OpenNewLog(string lotID, int waferNumber, bool isWaferBased)
        {
        }

        public static void Close()
        {
        }

        public static void Info(string message)
        {
        }

        public static void Warning(string message)
        {
        }
        public static void Warning(string message, Exception ex)
        {
        }

        public static void Error(string message)
        {
        }
        public static void Error(string message, Exception ex)
        {
        }

        public static void Debug(string message)
        {
        }
        public static void Debug(string message, Exception ex)
        {
        }

        public static void Fatal(string message)
        {
        }
        public static void Fatal(string message, Exception ex)
        {
        }

        public static void SimpleInfo(string message)
        {
        }

        public static void TestInfo(string message)
        {
        }

        public static void TestWarn(string message)
        {
        }
        public static void TestWarn(string message, Exception ex)
        {
        }

        public static void TestError(string message)
        {
        }
        public static void TestError(string message, Exception ex)
        {
        }

        public static void TestFatal(string message)
        {
        }
        public static void TestFatal(string message, Exception ex)
        {
        }

        /// <summary>
        /// Method ensure loging unhandled exception
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private static void UnhandledExceptionHandler(object s, UnhandledExceptionEventArgs e)
        {
        }

        #endregion

        #region public propetries

        public static string LogFileName
        {
            get { return logFileName; }
        }

        public static string SimpleFileName
        {
            get { return simpleFileName; }
        }

        public static string TestLogFileName
        {
            get { return testFileName; }
        }

        public static string InitialLogFileName
        {
            get { return initialLogFileName; }
        }

        #endregion
    }
}
