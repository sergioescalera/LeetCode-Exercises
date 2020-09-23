using System.Linq;

namespace LeetCode
{
    public class GasStation
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {

            if (gas == null || cost == null)
            {
                return -1;
            }

            if (gas.Length != cost.Length)
            {
                return -1;
            }

            int n = gas.Length;

            int sumGas = gas.Sum();
            int sumCost = cost.Sum();

            if (sumGas < sumCost)
            {
                return -1;
            }

            for (int i = 0; i < n; i++)
            {
                if (gas[i] >= cost[i] && CanCompleteCircuit(gas, cost, n, i))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool CanCompleteCircuit(
            int[] gas, 
            int[] cost, 
            int n,
            int start)
        {
            int tank = 0;

            for (int i = 0; i < n; i++)
            {
                int j = (start + i) % n;

                tank += gas[j] - cost[j];

                if (tank < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
