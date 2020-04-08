using LeetCode.Attributes;
using LeetCode.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class GenerateParenthesesExercise
    {
        public static void Run()
        {
            var exercise = new GenerateParenthesesExercise();

            do
            {
                var n = exercise.ReadNum();

                if (n == null) break;

                var s = exercise.GenerateParenthesis(n.Value);

                foreach (var item in s)
                {
                    Console.WriteLine(item);
                }

            } while (true);
        }

        public IList<string> GenerateParenthesis(int n)
        {
            if (n <= 0)
            {
                return new string[] { "" };
            }

            var list = new List<string>();

            var sucess = GenerateParenthesis(n, n, n, "", list);

            return list;
        }

        private bool GenerateParenthesis(
            int n, 
            int open, 
            int close, 
            string current,
            List<string> list)
        {
            if (open == 0 && close == 0)
            {
                return true;
            }

            if (open > close)
            {
                return false;
            }

            if (open == 0)
            {
                list.Add(current + new string(')', close));

                return true;
            }

            GenerateParenthesis(n, open - 1, close, current + "(", list);

            if (close > open)
            {
                GenerateParenthesis(n, open, close - 1, current + ")", list);
            }

            return list.Count > 0;
        }
    }
}
