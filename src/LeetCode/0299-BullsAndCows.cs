using System.Linq;

namespace LeetCode
{
    public class BullsAndCows
    {
        public string GetHint(string secret, string guess)
        {
            if (secret == null || guess == null)
            {
                return null;
            }

            if (secret.Length != guess.Length)
            {
                return null;
            }

            var bulls = 0;
            var cows = 0;
            var n = secret.Length;

            var letters = secret
                .GroupBy(c => c)
                .ToDictionary(c => c.Key, c => c.Count());

            for (int i = 0; i < n; i++)
            {
                var c = guess[i];

                if (c == secret[i])
                {
                    bulls++;
                    letters[c]--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                var c = guess[i];

                if (c != secret[i] && letters.ContainsKey(c) && letters[c] > 0)
                {
                    cows++;
                    letters[c]--;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}
