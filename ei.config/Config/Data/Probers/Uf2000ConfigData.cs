using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class Uf2000ConfigData : BaseConfigData<Uf2000ConfigData>
    {
        #region private fields

        private GpibConfigData gpib;

        #endregion

        #region constructors

        public Uf2000ConfigData()
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
