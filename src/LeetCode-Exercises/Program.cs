﻿using LeetCode.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                var exercise = SelectExercise();

                if (exercise == null)
                    break;

                exercise.Invoke(null, null);

            } while (true);
        }

        private static MethodInfo SelectExercise()
        {
            var exerciseType = typeof(ExerciseAttribute);
            var exercises = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.CustomAttributes.Any(o => o.AttributeType == exerciseType))
                .OrderBy(t => t.Name)
                .ToArray();

            Console.WriteLine("-------------------");
            Console.WriteLine("Select an exercise:");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            for (var i = 0; i < exercises.Length; i++)
            {
                var exercise = exercises[i];

                Console.WriteLine($"{i} - {exercise.Name}");
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();

            var line = Console.ReadLine();

            Console.WriteLine("-------------------");

            var index = -1;

            if (Int32.TryParse(line, out index)
                && index >= 0
                && index < exercises.Length)
                return exercises[index].GetMethod(
                    "Run",
                    BindingFlags.Public | BindingFlags.Static);

            return null;
        }
    }
}
