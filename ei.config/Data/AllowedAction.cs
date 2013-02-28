using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class AllowedAction
    {
        #region private field

        private AllowedActionType actionType;
        private bool allowed;
        private string reason;

        #endregion

        #region constructor

        public AllowedAction(AllowedActionType actionType, bool allowed, string reason)
        {
            this.actionType = actionType;
            this.allowed = allowed;
            this.reason = reason;
        }

        #endregion

        #region public properties

        public AllowedActionType ActionType
        {
            get { return actionType; }
        }

        public bool Allowed
        {
            get { return allowed; }
        }

        public string Reason
        {
            get { return reason; }
        }

        #endregion

    }
}
