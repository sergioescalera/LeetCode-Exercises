using LeetCode.Input;
using System;
using System.Linq;

namespace LeetCode.Extensions
{
    public static class ExerciseExtensions
    {
        public static Double? ReadDouble(this Object obj, String prompt = null)
        {
            Console.WriteLine(prompt ?? "Enter number...");

            var line = Console.ReadLine();

            if (Double.TryParse(line, out var n))
            {
                return n;
            }

            return null;
        }

        public static Int32? ReadNum(this Object obj, String prompt = null)
        {
            Console.WriteLine(prompt ?? "Enter number...");

            var line = Console.ReadLine();

            if (Int32.TryParse(line, out var n))
            {
                return n;
            }

            return null;
        }

        public static Int32[] ReadNums(this Object obj)
        {
            Console.WriteLine("Enter numbers...");

            var line = Console.ReadLine();

            if (String.IsNullOrEmpty(line))
            {
                return null;
            }

            var array = line.Split(',', ';', ' ');

            return array
                .Where(o => String.IsNullOrWhiteSpace(o) == false)
                .Select(o => Int32.TryParse(o, out var n) ? n : default(Int32?))
                .Where(o => o.HasValue)
                .Select(o => o.GetValueOrDefault())
                .ToArray();
        }

        public static ListNode ReadList(this Object obj)
        {
            Console.WriteLine("Enter numbers...");

            var line = Console.ReadLine();

            if (String.IsNullOrEmpty(line))
            {
                return null;
            }

            var array = line.Split(',', ';', ' ')
                .Select(o => Int32.TryParse(o, out var n) ? n : default(Int32?))
                .Where(o => o.HasValue)
                .ToArray();

            if (array.Length == 0)
                return null;

            var head = new ListNode(array[0].Value);
            var tail = head;

            for (int i = 1; i < array.Length; i++)
            {
                tail.next = new ListNode(array[i].Value);
                tail = tail.next;
            }

            return head;
        }
    }
}
