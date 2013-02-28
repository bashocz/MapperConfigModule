using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Xml;
using System.Collections;

namespace EI.Config
{
    public class EnvGeneralConfigData: BaseConfigData<EnvGeneralConfigData>
    {
        #region private fields

        private bool autoCenter;
        private bool drawCircle;
        private bool drawGrid;
        private bool recoveryYield;
        private string cultureName;
        private List<Culture> cultureList;

        #endregion

        #region constructors

        public EnvGeneralConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            autoCenter = true;
            drawCircle = false;
            drawGrid = true;
            recoveryYield = false;
            cultureName = "English";
            cultureList = new List<Culture>();
            cultureList.Add(new Culture("English", "en-US"));
        }

        public void ClearCutureList()
        {
            ClearList(cultureList);
        }

        public void AddToCultureList(Culture culture)
        {
            AddToList(cultureList, culture);
        }

        public void AddRangeToCultureList(List<Culture> cultureRangeList)
        {
            AddRangeToList(cultureList, cultureRangeList);
        }

        #endregion

        #region properties

        public CultureInfo Culture
        {
            get 
            {
                for (int idx = 0; idx < cultureList.Count; idx++)
                    if (string.Compare(cultureList[idx].Name, cultureName, true) == 0)
                        return CultureInfo.CreateSpecificCulture(cultureList[idx].Code);
                return null;
            }
        }

        public string CultureName
        {
            get { return cultureName; }
            set { SetValue(ref cultureName, value); }
        }

        public IList<Culture> CultureList
        {
            get { return cultureList.AsReadOnly(); }
        }

        public bool AutoCenter
        {
            get { return autoCenter; }
            set { SetValue(ref autoCenter, value); }
        }

        public bool DrawCircle
        {
            get { return drawCircle; }
            set { SetValue(ref drawCircle, value); }
        }

        public bool DrawGrid
        {
            get { return drawGrid; }
            set { SetValue(ref drawGrid, value); }
        }

        public bool RecoveryYield
        {
            get { return recoveryYield; }
            set { SetValue(ref recoveryYield, value); }
        }

        #endregion
    }
}
