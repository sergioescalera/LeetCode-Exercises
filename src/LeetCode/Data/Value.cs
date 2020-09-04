using System.Diagnostics;

namespace LeetCode.Data
{
    [DebuggerDisplay("{val}")]
    public struct Value
    {
        public readonly int i;
        public readonly int val;

        public Value(int i, int val)
        {
            this.i = i;
            this.val = val;
        }

        public override bool Equals(object obj)
        {
            return obj is Value val && i == val.i;
        }

        public override int GetHashCode()
        {
            return i.GetHashCode();
        }
    }
}
