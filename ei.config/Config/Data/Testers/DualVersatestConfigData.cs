using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class DualVersatestConfigData : BaseConfigData<DualVersatestConfigData>
    {
        #region private fields

        private SerialPortConfigData tester1Serial;
        private SerialPortConfigData tester2Serial;

        private List<int> tester1SiteList;
        private List<int> tester2SiteList;

        #endregion

        #region constructors

        public DualVersatestConfigData()
            : base()
        {
            tester1Serial = new SerialPortConfigData();
            tester2Serial = new SerialPortConfigData();

            childList.Add(tester1Serial as IBaseConfigData);
            childList.Add(tester2Serial as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            tester1SiteList = new List<int>();
            tester2SiteList = new List<int>();

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        public void ClearTester1SiteList()
        {
            ClearList(tester1SiteList);
        }

        public void AddToTester1SiteList(int site)
        {
            AddToList(tester1SiteList, site);
        }

        public void AddRangeToTester1SiteList(List<int> siteList)
        {
            AddRangeToList(tester1SiteList, siteList);
        }

        public void ClearTester2SiteList()
        {
            ClearList(tester2SiteList);
        }

        public void AddToTester2SiteList(int site)
        {
            AddToList(tester2SiteList, site);
        }

        public void AddRangeToTester2SiteList(List<int> siteList)
        {
            AddRangeToList(tester2SiteList, siteList);
        }

        #endregion

        #region properties

        /// <summary>
        /// Sub configuration data for serial port of tester 1.
        /// </summary>
        public SerialPortConfigData Tester1Serial
        {
            get { return tester1Serial; }
        }

        /// <summary>
        /// Sub configuration data for serial port of tester 2.
        /// </summary>
        public SerialPortConfigData Tester2Serial
        {
            get { return tester2Serial; }
        }

        /// <summary>
        /// List of sites operated by tester 1.
        /// </summary>
        public IList<int> Tester1SiteList
        {
            get { return tester1SiteList.AsReadOnly(); }
        }

        /// <summary>
        /// List of sites operated by tester 2.
        /// </summary>
        public IList<int> Tester2SiteList
        {
            get { return tester2SiteList.AsReadOnly(); }
        }

        #endregion
    }
}