using System.Collections.Generic;

namespace LeetCode.Data
{
    public class ValueComparer : IComparer<Value>
    {
        public int Compare(Value x, Value y)
        {
            if (x.val != y.val)
            {
                return x.val - y.val;
            }

            return x.i - y.i;
        }
    }
}
