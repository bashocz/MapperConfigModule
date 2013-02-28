using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Class represents pass of the probe. The lot can be probed in different passes,
    /// each of them can have its own set of reprobing rules etc.
    /// </summary>
    public class Pass
    {
        #region private fields

        /// <summary>
        /// A System.string that specifies the pass id (name).
        /// </summary>
        private readonly string id;

        /// <summary>
        /// The list of bin values to reprobe when reprobing
        /// map from previous pass.
        /// </summary>
        private readonly List<int> previousPassReprobeBinList;

        /// <summary>
        /// The list of bin values to reprobe when reprobing
        /// map from actual pass or doing automatic reprobe on-the-fly etc.
        /// </summary>
        private readonly List<int> actualPassReprobeBinList;

        #endregion

        #region constructors

        /// <summary>
        /// Creates the object of Pass.
        /// <param name="id">The ID of a pass.</param>
        /// </summary>
        public Pass(string id, List<int> previousPassReprobeBinList, List<int> actualPassReprobeBinList)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            if (previousPassReprobeBinList == null)
            {
                throw new ArgumentNullException("previousPassReprobeBinList");
            }

            if (actualPassReprobeBinList == null)
            {
                throw new ArgumentNullException("actualPassReprobeBinList");
            }

            this.id = id;
            this.previousPassReprobeBinList = new List<int>(previousPassReprobeBinList);
            this.actualPassReprobeBinList = new List<int>(actualPassReprobeBinList);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Returns string representation of this object.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return "PassId = " + Id;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the pass id (name).
        /// </summary>
        public string Id
        {
            get { return id; }
        }

        /// <summary>
        /// The list of bin values to reprobe when reprobing
        /// map from previous pass.
        /// </summary>
        public List<int> PreviousPassReprobeBinList
        {
            get { return previousPassReprobeBinList; }
        }

        /// <summary>
        /// The list of bin values to reprobe when reprobing
        /// map from actual pass or doing automatic reprobe on-the-fly etc.
        /// </summary>
        public List<int> ActualPassReprobeBinList
        {
            get { return actualPassReprobeBinList; }
        }

        #endregion
    }
}