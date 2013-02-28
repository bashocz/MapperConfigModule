using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    /// <summary>
    /// Represents comment text entered by the operator and stored in database.
    /// </summary>
    public class LotComment
    {
        #region private fields

        private string lotId;
        private DateTime created;
        private string comment;
        private string operatorName;

        #endregion

        #region constructors

        /// <summary>
        /// Creates new instance filled with the given data.
        /// </summary>
        /// <param name="lotId">The ID of the lot this comment is for.</param>
        /// <param name="date">The date of creation of the comment.</param>
        /// <param name="comment">The comment text entered by the operator.</param>
        /// <param name="operatorName">The operator name.</param>
        public LotComment(string lotId, DateTime created, string comment, string operatorName)
        {
            this.lotId = lotId;
            this.created = created;
            this.comment = comment;
            this.operatorName = operatorName;
        }

        #endregion

        #region public methods

        public override string ToString()
        {
            return "LotId = " + lotId + ", Created = " + created +
                ", Comment = " + comment + ", OperatorName = " + operatorName;
        }

        #endregion

        #region public properties

        /// <summary>
        /// The ID of the lot this comment is for.
        /// </summary>
        public string LotId
        {
            get { return lotId; }
        }

        /// <summary>
        /// The date of creation of the comment.
        /// </summary>
        public DateTime Created
        {
            get { return created; }
        }

        /// <summary>
        /// The comment text entered by the operator.
        /// </summary>
        public string Comment
        {
            get { return comment; }
        }

        /// <summary>
        /// The operator name.
        /// </summary>
        public string OperatorName
        {
            get { return operatorName; }
        }

        #endregion
    }
}
