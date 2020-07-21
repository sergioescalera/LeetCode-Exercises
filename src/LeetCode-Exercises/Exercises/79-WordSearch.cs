using LeetCode.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Exercises
{
    [Exercise]
    public class WordSearch
    {
        public static void Run()
        {
            var board = new[]
            {
                new [] { 'A', 'B', 'C', 'E' },
                new [] { 'S', 'F', 'C', 'S' },
                new [] { 'A', 'D', 'E', 'E' }
            };

            var ex = new WordSearch();

            //Console.WriteLine("Expected: true, Actual: {0}", ex.Exist(board, "ABCCED"));
            //Console.WriteLine("Expected: true, Actual: {0}", ex.Exist(board, "SEE"));
            //Console.WriteLine("Expected: false, Actual: {0}", ex.Exist(board, "ABCB"));

            //board = new[] {
            //new[] { 'A', 'B', 'C', 'E' },
            //    new[] { 'S', 'F', 'E', 'S' },
            //    new[] { 'A', 'D', 'E', 'E' }
            //};

            //Console.WriteLine("Expected: true, Actual: {0}", ex.Exist(board, "ABCESEEEFS"));

            board = new[] 
            {
                new [] { 'b','a','a','b','a','b' },
                new [] { 'a','b','a','a','a','a' },
                new [] { 'a','b','a','a','a','b' },
                new [] { 'a','b','a','b','b','a' },
                new [] { 'a','a','b','b','a','b' },
                new [] { 'a','a','b','b','b','a' },
                new [] { 'a','a','b','a','a','b' }
            };

            Console.WriteLine(
                "Expected: true, Actual: {0}",
                ex.Exist(board, "aabbbbabbaababaaaabababbaaba"));
            
            Console.ReadLine();
        }

        public bool Exist(char[][] board, string word)
        {
            if (board == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(word))
            {
                return true;
            }

            var letters = word.ToArray();

            //var cache = new HashSet<string>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var path = new HashSet<string>();

                    if (FindPath(
                        board, 
                        i, 
                        j, 
                        letters,
                        0, 
                        path))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool FindPath(
            char[][] board,
            int x,
            int y, 
            char[] word,
            int index,
            HashSet<string> path)
        {
            if (index >= word.Length)
            {
                return true;
            }

            if (x < 0 || y < 0 || x >= board.Length || y >= board[x].Length)
            {
                return false;
            }

            if (word[index] != board[x][y])
            {
                return false;
            }

            var pathKey = $"{x},{y}";
            
            path.Add(pathKey);

            if (path.Count == word.Length)
            {
                return true;
            }

            var up = new[] { x - 1, y };
            var down = new[] { x + 1 , y };
            var left = new[] { x, y - 1 };
            var right = new[] { x, y + 1 };

            var directions = new[] { right, down, left, up };

            foreach (var direction in directions)
            {
                var dx = direction[0];
                var dy = direction[1];
                var dkey = $"{dx},{dy}";

                if (path.Contains(dkey))
                {
                    continue;
                }

                if (FindPath(
                    board, 
                    dx,
                    dy, 
                    word, 
                    index + 1, 
                    path))
                {
                    return true;
                }
            }

            path.Remove(pathKey);

            return false;
        }
    }
}
