using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class ThresholdYield
    {
        public ThresholdYield(int max, List<ProcessMethod> methods)
        {
            YieldMax = max;
            _methods = new List<ProcessMethod>();
            if (methods != null)
            {
                _methods.AddRange(methods);

                _methods.Sort(delegate(ProcessMethod a, ProcessMethod b)
                {
                    return a.Sequence - b.Sequence;
                });
            }
        }

        public int YieldMax { get; private set; }

        private readonly List<ProcessMethod> _methods;
        public IList<ProcessMethod> Methods
        {
            get { return _methods.AsReadOnly(); }
        }
    }
}
