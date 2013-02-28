using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public class ProcessMethodConfigData : BaseConfigData<ProcessMethodConfigData>
    {
        #region private fields

        private ProcessMode _processMode;
        private bool _pauseAfterReprobeSpecific;

        private PassConfigData _passCfg;

        // probing
        private UpConfigData _upCfg;
        private SupConfigData _supCfg;
        private SpConfigData _spCfg;
        private CpConfigData _cpCfg;
        private EpConfigData _epCfg;
        private SspConfigData _sspCfg;
        private FpConfigData _fpCfg;

        // map editing
        private MeConfigData _meCfg;
        // automated optical inspection
        private AoiConfigData _aoiCfg;

        // inking
        private SiConfigData _siCfg;
        private EiConfigData _eiCfg;

        #endregion

        #region constructor

        public ProcessMethodConfigData()
            : base()
        {
            _passCfg = new PassConfigData();

            _upCfg = new UpConfigData();
            _supCfg = new SupConfigData();
            _spCfg = new SpConfigData();
            _cpCfg = new CpConfigData();
            _epCfg = new EpConfigData();
            _sspCfg = new SspConfigData();
            _fpCfg = new FpConfigData();

            _meCfg = new MeConfigData();
            _aoiCfg = new AoiConfigData();

            _siCfg = new SiConfigData();
            _eiCfg = new EiConfigData();

            childList.Add(_passCfg as IBaseConfigData);

            childList.Add(_upCfg as IBaseConfigData);
            childList.Add(_supCfg as IBaseConfigData);
            childList.Add(_spCfg as IBaseConfigData);
            childList.Add(_cpCfg as IBaseConfigData);
            childList.Add(_epCfg as IBaseConfigData);
            childList.Add(_sspCfg as IBaseConfigData);
            childList.Add(_fpCfg as IBaseConfigData);

            childList.Add(_meCfg as IBaseConfigData);
            childList.Add(_aoiCfg as IBaseConfigData);

            childList.Add(_siCfg as IBaseConfigData);
            childList.Add(_eiCfg as IBaseConfigData);

            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            _processMode = ProcessMode.Probing;
            _pauseAfterReprobeSpecific = true;

            foreach (IBaseConfigData child in childList)
                child.SetDefault();
        }

        #endregion

        #region properties

        public ProcessMode ProcessMode
        {
            get { return _processMode; }
            set { SetEnumValue(ref _processMode, value); }
        }

        public bool PauseAfterReprobeSpecific
        {
            get { return _pauseAfterReprobeSpecific; }
            set { _pauseAfterReprobeSpecific = value; }
        }

        public PassConfigData Pass
        {
            get { return _passCfg; }
        }

        public UpConfigData UnitProbe
        {
            get { return _upCfg; }
        }

        public SupConfigData SmartUnitProbe
        {
            get { return _supCfg; }
        }

        public SpConfigData SampleProbe
        {
            get { return _spCfg; }
        }

        public CpConfigData ClassProbe
        {
            get { return _cpCfg; }
        }

        public EpConfigData EdgeProbe
        {
            get { return _epCfg; }
        }

        public SspConfigData SmartSampleProbe
        {
            get { return _sspCfg; }
        }

        public FpConfigData FlexibleProbe
        {
            get { return _fpCfg; }
        }

        public MeConfigData MapEdit
        {
            get { return _meCfg; }
        }

        public AoiConfigData Aoi
        {
            get { return _aoiCfg; }
        }

        public SiConfigData SmartInk
        {
            get { return _siCfg; }
        }

        public EiConfigData EdgeInk
        {
            get { return _eiCfg; }
        }

        #endregion
    }
}
