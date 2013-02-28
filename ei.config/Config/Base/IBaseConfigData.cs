using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public interface IBaseConfigData
    {
        void BeginUpdate();
        void DiscardUpdate();
        void EndUpdate(bool fireChangedEvent);

        void SetDefault();

        void CheckSetting(ConfigData configData);

        bool IsChanged { get; }
    }
}
