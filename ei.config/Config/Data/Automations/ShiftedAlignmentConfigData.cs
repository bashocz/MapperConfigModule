using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    /// <summary>
    /// Configuration data for automatic reprobe functionality.
    /// </summary>
    public class ShiftedAlignmentConfigData : BaseConfigData<ShiftedAlignmentConfigData>
    {
        #region private fields

        private bool enabled;
        private double tolerance;
        
        #endregion

        #region constructors

        public ShiftedAlignmentConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            tolerance = 0.0;
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public double Tolerance
        {
            get { return tolerance; }
            set { SetValue(ref tolerance, value); }
        }

        #endregion
    }
}
