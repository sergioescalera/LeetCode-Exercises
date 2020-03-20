using LeetCode.Attributes;
using System;

namespace LeetCode.Exercises
{
    [Exercise]
    public class AddBinaryExercise
    {
        public static void Run()
        {
            var exercise = new AddBinaryExercise();

            do
            {
                Console.WriteLine("Enter a =");

                var a = Console.ReadLine();

                Console.WriteLine("Enter b =");

                var b = Console.ReadLine();

                if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b))
                {
                    return;
                }

                var solution = exercise.AddBinary(a, b);

                Console.WriteLine("a + b = {0}", solution);

            } while (true);
        }

        public string AddBinary(string a, string b)
        {
            if (String.IsNullOrEmpty(a))
                return b;

            if (String.IsNullOrEmpty(b))
                return a;

            var n = a.Length >= b.Length ? a.Length : b.Length;
            var c = false;
            
            var sum = "";

            for (int i = 1; i <= n; i++)
            {
                var j = a.Length - i;
                var k = b.Length - i;

                var x = j >= 0 ? a[j] : '0';
                var y = k >= 0 ? b[k] : '0';

                if (x == '0' && y == '0')
                {
                    if (c)
                    {
                        sum = '1' + sum;
                    }
                    else
                    {
                        sum = '0' + sum;
                    }

                    c = false;
                }
                else if (x == '1' && y == '1')
                {
                    if (c)
                    {
                        sum = '1' + sum;
                    }
                    else
                    {
                        sum = '0' + sum;
                    }

                    c = true;
                }
                else
                {
                    if (c)
                    {
                        sum = '0' + sum;
                    }
                    else
                    {
                        sum = '1' + sum;

                        c = false;
                    }
                }
            }

            if (c)
            {
                sum = '1' + sum;
            }
            
            return sum;
        }
    }
}
