using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class FractionToRecurringDecimal
    {
        public string FractionToDecimal(int num, int den)
        {
            if (num == 0)
            {
                return "0";
            }

            if (den == 0)
            {
                return "0";
            }

            var sign = (num > 0 && den > 0) || (num < 0 && den < 0) ? 1 : -1;

            var numerator = Math.Abs((long)num);
            var denominator = Math.Abs((long)den);

            if (denominator == 1)
            {
                return (sign * numerator).ToString();
            }

            var result = new StringBuilder();
            var dec = false;

            if (numerator < denominator)
            {
                result.Append("0.");

                numerator *= 10;

                dec = true;
            }

            var map = new Dictionary<long, int>();

            while (numerator != 0)
            {
                if (dec)
                {
                    if (map.ContainsKey(numerator))
                    {
                        var index = map[numerator];

                        result.Insert(index, "(");
                        result.Append(")");

                        break;
                    }
                    else
                    {
                        map.Add(numerator, result.Length);
                    }
                }

                if (numerator < denominator)
                {
                    while (numerator < denominator)
                    {
                        if (dec)
                        {
                            result.Append("0");
                        }
                        else
                        {
                            result.Append(".");

                            dec = true;
                        }

                        numerator *= 10;
                    }
                }
                else
                {
                    var d = numerator / denominator;
                    var r = numerator % denominator;

                    result.Append(d);

                    numerator = r;

                    if (dec)
                    {
                        numerator *= 10;
                    }
                }
            }

            var str = result.ToString();

            if (sign < 0)
            {
                str = $"-{str}";
            }

            return str;
        }
    }
}
