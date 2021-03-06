using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    internal class XmlOldPowertech : XmlOldBase
    {
        #region private fields

        private SelfManagedXmlElement testerElement;
        private SelfManagedXmlElement testersElement;
        private SelfManagedXmlElement tmtElement;

        private XmlOldSerial serialElement;

        #endregion

        #region constructors

        public XmlOldPowertech()
        {
            testerElement = new SelfManagedXmlElement("Tester");
            rootElement.AddChild(testerElement);

            testersElement = new SelfManagedXmlElement("Testers");
            testerElement.AddChild(testersElement);

            tmtElement = new SelfManagedXmlElement("Powertech");
            tmtElement.ClearAllChildren = true;
            testersElement.AddChild(tmtElement);

            serialElement = new XmlOldSerial();
            tmtElement.AddChild(serialElement.XmlNode);
        }

        #endregion

        #region public properties

        public XmlOldSerial Serial
        {
            get { return serialElement; }
        }

        #endregion
    }
}
