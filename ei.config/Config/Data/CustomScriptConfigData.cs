using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class CustomScriptConfigData : BaseConfigData<CustomScriptConfigData>
    {
        #region private fields

        private bool enabled;
        private List<CustomScript> customScriptList;

        #endregion

        #region constructors

        public CustomScriptConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region private methods

        public void ClearCustomScriptList()
        {
            ClearList(customScriptList);
        }

        public void AddToCustomScriptList(CustomScript customScript)
        {
            AddToList(customScriptList, customScript);
        }

        public void AddRangeToCustomScriptList(List<CustomScript> customScriptRangeList)
        {
            AddRangeToList(customScriptList, customScriptRangeList);
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            customScriptList = new List<CustomScript>();
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public IList<CustomScript> CustomScriptList
        {
            get { return customScriptList.AsReadOnly(); }
        }

        #endregion
    }
}