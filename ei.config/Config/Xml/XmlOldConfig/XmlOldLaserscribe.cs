using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldLaserscribe : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement enabledElement;
        private LaserscribeFormatsXmlElement laserscribeFormatsElement;
        private BooleanXmlElement laserscribeMatchingEnabledElement;
        private LotFiltersXmlElement lotsWithLaserscribesInDbElement;
        private BooleanXmlElement usingLaserscribeFromDBElement;
        #endregion

        #region constructors

        public XmlOldLaserscribe()
        {
            configElement = new SelfManagedXmlElement("Laserscribe");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            enabledElement = new BooleanXmlElement("OcrEnabled", false);
            configElement.AddChild(enabledElement);

            laserscribeFormatsElement = new LaserscribeFormatsXmlElement("LaserscribeFormats");
            configElement.AddChild(laserscribeFormatsElement);

            laserscribeMatchingEnabledElement = new BooleanXmlElement("LaserscribeMatchingEnabled", false);
            configElement.AddChild(laserscribeMatchingEnabledElement);

            lotsWithLaserscribesInDbElement = new LotFiltersXmlElement("LotsWithLaserscribesInDb");
            configElement.AddChild(lotsWithLaserscribesInDbElement);

            usingLaserscribeFromDBElement = new BooleanXmlElement("UsingLasersribeFromDB", false);
            configElement.AddChild(usingLaserscribeFromDBElement);
        }

        #endregion

        #region public properties

        public bool Enabled
        {
            get { return enabledElement.Value; }
            set { enabledElement.Value = value; }
        }

        public bool LaserscribeMatchingEnabled
        {
            get { return laserscribeMatchingEnabledElement.Value; }
            set { laserscribeMatchingEnabledElement.Value = value; }
        }

        public List<LaserscribeFormat> LaserscribeFormats
        {
            get { return laserscribeFormatsElement.Values; }
            set { laserscribeFormatsElement.Values = value; }
        }

        public List<LotFilter> LotsWithLaserscribesInDb
        {
            get { return lotsWithLaserscribesInDbElement.Values; }
            set { lotsWithLaserscribesInDbElement.Values = value; }
        }
        public bool EnableUsingLaserscribeFromDB
        {
            get { return usingLaserscribeFromDBElement.Value; }
            set { usingLaserscribeFromDBElement.Value = value; }
        }
        #endregion
    }
}
