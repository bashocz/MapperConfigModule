using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldLotSearch : XmlOldBase
    {
        #region private fields

        private BooleanXmlElement useLimitedLotSearchElement;
        private IntegerXmlElement daysBackwardElement;

        #endregion

        #region constructors

        public XmlOldLotSearch()
        {
            configElement = new SelfManagedXmlElement("LotSearch");
            configElement.ClearAllChildren = true;
            rootElement.AddChild(configElement);

            useLimitedLotSearchElement = new BooleanXmlElement("UseLimitedLotSearch", false);
            configElement.AddChild(useLimitedLotSearchElement);

            daysBackwardElement = new IntegerXmlElement("SearchLotsNotOlderThan", 365);
            configElement.AddChild(daysBackwardElement);
        }

        #endregion

        #region public properties

        public bool UseLimitedLotSearch
        {
            get { return useLimitedLotSearchElement.Value; }
            set { useLimitedLotSearchElement.Value = value; }
        }

        public int DaysBackward
        {
            get { return daysBackwardElement.Value; }
            set { daysBackwardElement.Value = value; }
        }

        #endregion

    }
}
