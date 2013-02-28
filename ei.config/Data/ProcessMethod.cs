using System;
using System.Collections.Generic;
using System.Text;

namespace EI.Config
{
    public class ProcessMethod
    {
        public ProcessMethod(int sequence, string methodName)
        {
            MethodName = methodName;
            Sequence = sequence;
        }

        public int Sequence { get; private set; }
        public string MethodName { get; private set; }
    }
}
