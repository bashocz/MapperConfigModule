using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class Kla1007ConfigData : BaseConfigData<Kla1007ConfigData>
    {
        #region private fields

        private GpibConfigData gpib;

        #endregion

        #region constructors

        public Kla1007ConfigData()
            : base()
        {
            gpib = new GpibConfigData();

            childList.Add(gpib as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        /// <summary>
        /// Sub configuration data for the GPIB settings.
        /// </summary>
        public GpibConfigData Gpib
        {
            get { return gpib; }
        }

        #endregion
    }
}
