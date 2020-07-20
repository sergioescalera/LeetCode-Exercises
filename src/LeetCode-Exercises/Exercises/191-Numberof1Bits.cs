namespace LeetCode.Exercises
{
    public class Numberof1Bits
    {
        public int HammingWeight(uint n)
        {
            int c = 0;

            do
            {
                if (n % 2 == 1)
                {
                    c++;
                }

                n /= 2;
            }
            while (n > 0);

            return c;
        }
    }
}
