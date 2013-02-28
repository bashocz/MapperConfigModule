using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EI.Config
{
    public abstract class ValueData : BaseData
    {
        #region private fields

        protected object defaultValue;
        protected object currentValue;

        protected bool changed;
        protected bool wasRead;
        protected bool hasValue;

        #endregion

        #region constructors

        protected ValueData(ConfigType configType, string prefix, string name, string description, string editor, object defaultValue)
            : base(configType, prefix, name, description, editor)
        {
            this.defaultValue =
            this.currentValue = defaultValue;

            changed =
            wasRead =
            hasValue = false;
        }

        #endregion

        #region protected methods

        private bool GetValue(XmlNode xmlNode, out string value)
        {
            value = string.Empty;
            bool isRead = false;

            //XmlNodeList xmlNodeList = xmlNode.GetElementsByTagName(FullName);
            //if (xmlNodeList.Count == 1)
            //{
            //    XmlElement xmlElement = xmlNodeList[0] as XmlElement;
            //    if (xmlElement != null)
            //    {
            //        value = xmlElement.InnerText;
            //        isRead = true;
            //    }
            //}

            return isRead;
        }


        protected bool GetValue(XmlDocument xmlDoc, out string value)
        {
            return GetValue(xmlDoc as XmlNode, out value);
        }

        protected bool GetValue(XmlElement xmlParent, out string value)
        {
            return GetValue(xmlParent as XmlNode, out value);
        }

        protected abstract object ParseValue(string value);

        protected virtual void SetNewValue(object newValue)
        {
            hasValue = true;
            if (!currentValue.Equals(newValue))
            {
                currentValue = newValue;
                changed = true;
                DataChanged();
            }
        }

        #endregion

        #region public methods

        public override string GetTemplate(string offset, ConfigType configType)
        {
            if ((this.configType & configType) != ConfigType.None)
                return offset + "<Item name=\"" + FullName + "\" datatype=\"" + DataType + "\" description=\"" + Description + "\" />" + Environment.NewLine;
            return string.Empty;
        }

        public override string GetData(string offset, ConfigType configType)
        {
            if (((this.configType & configType) != ConfigType.None) && hasValue)
                return offset + BeginTarget() + currentValue.ToString() + EndTarget() + Environment.NewLine;
            return string.Empty;
        }

        public override void SetData(XmlDocument xmlDoc)
        {
            try
            {
                wasRead = false;
                string readValue;
                if (GetValue(xmlDoc, out readValue))
                {
                    SetNewValue(ParseValue(readValue));
                    wasRead = true;
                }
            }
            catch (Exception ex)
            {
                LogIt.Error("Exception during reading '" + FullName + "': ", ex);
            }
        }

        public override void CurrentAsDefault()
        {
            if (hasValue)
                defaultValue = currentValue;
        }

        public override void RevertToDefault()
        {
            if (defaultValue != null)
                SetNewValue(defaultValue);
        }

        #endregion

        #region public properties

        public override bool Changed
        {
            get { return changed; }
            set { changed = value; }
        }

        public override bool HasValue
        {
            get { return hasValue; }
        }

        public override bool WasRead
        {
            get { return wasRead; }
        }

        #endregion
    }
}
