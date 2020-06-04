using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class ValidSudoku
    {
        public static void Run()
        {
            var sudoku = new char[][]
            {
                new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
            };

            var exercise = new ValidSudoku();

            var isValid = exercise.IsValidSudoku(sudoku);

            Console.WriteLine("Is valid: {0}", isValid);
        }

        public bool IsValidSudoku(char[][] board)
        {
            if (board == null)
                return false;
            
            if (board.Length != length)
            {
                return false;
            }

            for (int i = 0; i < board.Length; i++)
            {
                var row = board[i];

                if (row.Length != length)
                {
                    return false;
                }

                if (!CheckRow(board, i))
                {
                    return false;
                }

                if (!CheckColumn(board, i))
                {
                    return false;
                }

                if (!CheckSquare(board, (i / 3) * 3, (i % 3) * 3))
                {
                    return false;
                }
            }

            return true;
        }

        private readonly Int32 length = 9;
        private readonly Char empty = '.';
        private readonly Dictionary<char, Int32> map = Enumerable
            .Range(1, 9)
            .ToDictionary(n => n.ToString()[0], n => n);

        private bool CheckColumn(char[][] board, int i)
        {
            var bits = new bool[length];

            for (int j = 0; j < length; j++)
            {
                var c = board[j][i];

                if (c == empty)
                {
                    continue;
                }

                var n = map[c] - 1;

                if (bits[n])
                {
                    return false;
                }

                bits[n] = true;
            }

            return true;
        }

        private bool CheckRow(char[][] board, int i)
        {
            var bits = new bool[length];

            for (int j = 0; j < length; j++)
            {
                var c = board[i][j];

                if (c == empty)
                {
                    continue;
                }

                var n = map[c] - 1;

                if (bits[n])
                {
                    return false;
                }

                bits[n] = true;
            }

            return true;
        }

        private bool CheckSquare(char[][] board, int x, int y)
        {
            var bits = new bool[length];

            for (int i = 0; i < length; i++)
            {
                var c = board[x + i / 3][y + i % 3];

                if (c == empty)
                {
                    continue;
                }

                var n = map[c] - 1;

                if (bits[n])
                {
                    return false;
                }

                bits[n] = true;
            }

            return true;
        }
    }
}
