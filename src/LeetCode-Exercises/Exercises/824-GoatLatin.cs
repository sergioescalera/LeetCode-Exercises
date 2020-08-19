using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class GoatLatin
    {
        public static void Run()
        {
            var ex = new GoatLatin();

            do
            {
                Console.WriteLine("Enter sentence");

                var line = Console.ReadLine();

                if (String.IsNullOrEmpty(line))
                    break;

                var goat = ex.ToGoatLatin(line);

                Console.WriteLine(goat);
                Console.WriteLine();

            } while (true);
        }

        /*

The rules of Goat Latin are as follows:

If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
For example, the word 'apple' becomes 'applema'.
 
If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
For example, the word "goat" becomes "oatgma".
 
Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
Return the final sentence representing the conversion from S to Goat Latin.


         */
        public string ToGoatLatin(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));

            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();

            var vowels = new HashSet<char>(new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' });

            var suffix = "a";

            foreach (var word in words)
            {
                if (String.IsNullOrWhiteSpace(word))
                    continue;

                var latinWord = word;

                var firstLetter = word[0];

                if (vowels.Contains(firstLetter) == false)
                {
                    latinWord = word.Substring(1) + word[0];
                }

                latinWord += "ma" + suffix;

                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }

                sb.Append(latinWord);

                suffix += 'a';
            }

            return sb.ToString();
        }
    }
}
