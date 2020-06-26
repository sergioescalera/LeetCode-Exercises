using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Exercises
{
    [Exercise]
    public class Search2DMatrix
    {
        public static void Run()
        {
            var matrix = new[] 
            { 
                new [] { 10, 11, 16, 20 }, 
                new [] { 23, 30, 34, 50 },
                new [] { 51, 52, 52, 60 },
                new [] { 151, 152, 152, 160 }
            };
            
            var exercise = new Search2DMatrix();
            var rnd = new Random();

            foreach (var row in matrix)
            {
                foreach (var item in row)
                {
                    var found = exercise.SearchMatrix(matrix, item);

                    if (found == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"{item}: {found}");

                    Console.ForegroundColor = ConsoleColor.White;
                }

                for (int i = 0; i < 10; i++)
                {
                    var testCase = rnd.Next(row.First(), row.Last() + 1);

                    var found = exercise.SearchMatrix(matrix, testCase);

                    if (found != row.Contains(testCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"{testCase}: {found}");

                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.ReadLine();
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }

            if (matrix.Length == 0)
            {
                return false;
            }

            if (matrix[0].Length == 0 || matrix[matrix.Length - 1].Length == 0)
            {
                return false;
            }

            if (target < matrix[0][0])
            {
                return false;
            }

            var lastRow = matrix[matrix.Length - 1];

            if (target > lastRow[lastRow.Length - 1])
            {
                return false;
            }

            var row = FindRow(matrix, target, 0, matrix.Length - 1);

            return FindInRow(matrix[row], target, 0, matrix[row].Length - 1);
        }

        private int FindRow(int[][] matrix, int target, int start, int end)
        {
            var last = matrix.Length - 1;

            if (start >= last)
            {
                return last;
            }

            if (start >= end)
            {
                return start;
            }

            var next = start + 1;

            if (target >= matrix[end][0])
            {
                return end;
            }

            if (target >= matrix[start][0] && target < matrix[next][0])
            {
                return start;
            }

            var middle = start + (end - start) / 2;

            if (target >= matrix[middle][0])
            {
                return FindRow(matrix, target, middle, end - 1);
            }
            else
            {
                return FindRow(matrix, target, start + 1, middle);
            }
        }

        private bool FindInRow(int[] row, int target, int start, int end)
        {
            if (row[start] == target || row[end] == target)
            {
                return true;
            }

            if (target > row[end])
            {
                return false;
            }

            if (start >= end)
            {
                return false;
            }

            var middle = start + (end - start) / 2;

            if (row[middle] >= target)
            {
                return FindInRow(row, target, start + 1, middle);
            }
            else
            {
                return FindInRow(row, target, middle, end - 1);
            }
        }
    }
}
