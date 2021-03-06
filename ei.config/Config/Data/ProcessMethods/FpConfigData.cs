using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class FpConfigData : BaseConfigData<FpConfigData>
    {
        #region private fields

        private bool enabled;
        private List<ProcessMethod> startMethods;
        private List<ThresholdYield> endMethods;

        #endregion

        #region constructors

        public FpConfigData()
            : base()
        {
            SetDefault();
        }

        #endregion

        #region public methods

        public override void SetDefault()
        {
            enabled = false;
            startMethods = new List<ProcessMethod>();
            endMethods = new List<ThresholdYield>();
        }

        public void ClearStartMethodsList()
        {
            ClearList(startMethods);
        }

        public void AddToStartMethodsList(ProcessMethod method)
        {
            AddToList(startMethods, method);
            SortStartMethodsList();
        }

        public void AddRangeStartMethodsList(List<ProcessMethod> methods)
        {
            AddRangeToList(startMethods, methods);
            SortStartMethodsList();
        }

        public void ClearEndMethodsList()
        {
            ClearList(endMethods);
        }

        public void AddToEndMethodsList(ThresholdYield method)
        {
            AddToList(endMethods, method);
        }

        public void AddRangeEndMethodsList(List<ThresholdYield> methods)
        {
            //If the list of thresholdYield doesn't contain 100 % yield so add it there.
            // TO-DO basho - what's happen if 100% yield is already there???
            if (methods != null)
                methods = new List<ThresholdYield>();
            if (methods.Count > 0)
            {
                foreach (ThresholdYield ty in methods)
                {
                    if (ty.YieldMax == 100)
                    {
                        AddRangeToList(endMethods, methods);
                        return;
                    }
                }
            }
            ThresholdYield ty100Percent = new ThresholdYield(100, null);
            methods.Add(ty100Percent);
            AddRangeToList(endMethods, methods);        
        }

        /// <summary>
        /// Sort start method by their sequence
        /// </summary>
        private void SortStartMethodsList()
        {
            startMethods.Sort(delegate(ProcessMethod a, ProcessMethod b)
            {
                return a.Sequence - b.Sequence;
            });
        }

        #endregion

        #region properties

        public bool Enabled
        {
            get { return enabled; }
            set { SetValue(ref enabled, value); }
        }

        public IList<ProcessMethod> StartMethods
        {
            get { return startMethods.AsReadOnly(); }
        }

        public IList<ThresholdYield> EndMethods
        {
            get { return endMethods.AsReadOnly(); }
        }

        #endregion
    }
}
