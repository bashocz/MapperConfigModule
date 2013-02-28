using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;

namespace EI.Config
{
    public class WaferInfo
    {
        #region private fields

		private readonly int index;
        private readonly int slotIndex;
        private readonly string parentLotId;
        private readonly List<string> parentLotIdList;
        private readonly int probedCount;
        private readonly int reprobedCount;
        private readonly int sampledCount;
        private readonly int inkedCount;
        private readonly string laserscribe;
        private readonly bool scrap;

        #endregion

        #region constructors

        public WaferInfo(int index, int slotIndex, string parentLotId, List<string> parentLotIdList, int probedCount, int reprobedCount, int sampledCount, int inkedCount, string laserscribe, bool scrap)
        {
            this.index = index;
		    this.slotIndex = slotIndex;
		    this.parentLotId = parentLotId;
            this.parentLotIdList = new List<string>();
            if (parentLotIdList != null)
                this.parentLotIdList.AddRange(parentLotIdList);
		    this.probedCount = probedCount;
		    this.reprobedCount = reprobedCount;
            this.sampledCount = sampledCount;
		    this.inkedCount = inkedCount;
		    this.laserscribe = laserscribe;
            this.scrap = scrap;
        }

        #endregion

        #region properties

        public int Index
        {
            get { return index; }
        }

        public int SlotIndex
        {
            get { return slotIndex; }
        }

        public string ParentLotId
        {
            get { return parentLotId; }
        }

        public IList<string> ParentLotIdList
        {
            get { return parentLotIdList.AsReadOnly(); }
        }

        public int ProbedCount
        {
            get { return probedCount; }
        }

        public int ReprobedCount
        {
            get { return reprobedCount; }
        }

        public int SampledCount
        {
            get { return sampledCount; }
        }

        public int InkedCount
        {
            get { return inkedCount; }
        }

        public string Laserscribe
        {
            get { return laserscribe; }
        }

        public bool Scrap
        {
            get { return scrap; }
        }

        #endregion
    }
}
