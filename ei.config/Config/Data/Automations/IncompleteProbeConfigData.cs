﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Configuration data for Incomplete probe detector automation functionality.
    /// </summary>
    public class IncompleteProbeConfigData : BaseConfigData<IncompleteProbeConfigData>
    {
        #region private field

        /// <summary>
        /// System.Boolean that indicates,
        /// if the detector of incomplete probe is enabled.
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// System.Boolean that indicates,
        /// if after incomplete probe detection,
        /// the completition will be automaticly done.
        /// </summary>
        private bool _autoComplete;

        #endregion

        #region constructor

        public IncompleteProbeConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            _enabled = false;
            _autoComplete = false;
        }

        #endregion

        #region properties

        /// <summary>
        /// Indicates if the detector of incomplete probe is enabled.
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            set { SetValue(ref _enabled, value); }
        }
        /// <summary>
        /// Indicates, if after incomplete probe detection,
        /// the completition will be automaticly done.
        /// </summary>
        public bool AutoComplete
        {
            get { return _autoComplete; }
            set { SetValue(ref _autoComplete, value); }
        }

        #endregion
    }
}
