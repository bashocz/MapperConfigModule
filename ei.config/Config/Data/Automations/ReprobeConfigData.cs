using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    /// <summary>
    /// Configuration data for automatic reprobe functionality.
    /// </summary>
    public class ReprobeConfigData : BaseConfigData<ReprobeConfigData>
    {
        #region private fields

        private bool enabled;
        private int numberOfReprobes;
        private bool reprobeOnTheFly;
        
        #endregion

        #region constructors

        public ReprobeConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            numberOfReprobes = 1;
            reprobeOnTheFly = false;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public int NumberOfReprobes
        {
            get { return numberOfReprobes; }
            set { SetValue(ref numberOfReprobes, value); }
        }

        public bool ReprobeOnTheFly
        {
            get { return reprobeOnTheFly; }
            set { SetValue(ref reprobeOnTheFly, value); }
        }

        #endregion
    }
}
