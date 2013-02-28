using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class Culture
    {
        #region private fields

        private readonly string name;
        private readonly string code;

        #endregion

        #region constructors

        public Culture(string name, string code)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (code == null)
            {
                throw new ArgumentNullException("code");
            }

            this.name = name;
            this.code = code;
        }

        #endregion

        #region public properties

        public string Name
        {
            get { return name; }
        }

        public string Code
        {
            get { return code; }
        }

        #endregion
    }
}
