using System;
using System.Collections.Generic;

namespace Task4
{
    class MergeSorting<T> where T : IComparable<T>
    {
        public void Sort(List<T> list)
        {
            if (list.Count <= 1) return;

            int middle = list.Count / 2;

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(list[i]);
            }

            for (int i = middle; i < list.Count; i++)
            {
                right.Add(list[i]);
            }

            Sort(left);
            Sort(right);

            Merge(list, left, right);
        }

        private void Merge(List<T> list, List<T> left, List<T> right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    list[resultIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    list[resultIndex] = right[rightIndex];
                    rightIndex++;
                }

                resultIndex++;
            }

            while (leftIndex < left.Count)
            {
                list[resultIndex] = left[leftIndex];
                leftIndex++;
                resultIndex++;
            }

            while (rightIndex < right.Count)
            {
                list[resultIndex] = right[rightIndex];
                rightIndex++;
                resultIndex++;
            }
        }
    }
}
