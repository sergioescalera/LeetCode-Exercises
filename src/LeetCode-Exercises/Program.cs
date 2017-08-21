using LeetCode.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
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
                .ToArray();

            Console.WriteLine("-------------------");
            Console.WriteLine("Select an exercise:");
            Console.WriteLine();

            for (var i = 0; i < exercises.Length; i++)
            {
                var exercise = exercises[i];

                Console.WriteLine($"{i} - {exercise.Name}");
            }

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
