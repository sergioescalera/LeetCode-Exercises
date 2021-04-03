using System;

namespace LeetCode.Algorithm
{
    public class QuickSort
    {
        public static void Sort(Int32[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = array[start + (end - start) / 2];
            var index = Partition(array, start, start, pivot);

            Sort(array, start, index - 1);
            Sort(array, index, end);
        }

        private static int Partition(int[] array, int start, int end, int pivot)
        {
            while (start <= end)
            {
                while (start <= end && array[start] < pivot)
                {
                    start++;
                }

                while (end >= start && array[end] > pivot)
                {
                    end--;
                }

                if (start <= end)
                {
                    Swap(array, start, end);
                    start++;
                    end--;
                }
            }

            return start;
        }

        private static void Swap(int[] array, int start, int end)
        {
            var temp = array[start];

            array[start] = array[end];
            array[end] = temp;
        }
    }
}
