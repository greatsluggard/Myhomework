using System.Collections.Generic;

namespace Task4
{
    class MergeSorting
    {
        public void Merge (List<int> array, int left, int mid, int right)
        {
            int i, j, k;

            int lenght1 = mid - left + 1;
            int lenght2 = right - mid;

            int[] leftArray = new int[lenght1 + 1];
            int[] rightArray = new int[lenght2 + 1];

            for (i = 0; i < lenght1; i++)
            {
                leftArray[i] = array[left + i];
            }

            for (j = 1; j <= lenght2; j++)
            {
                rightArray[j-1] = array[mid + j];
            }

            leftArray[lenght1] = int.MaxValue;
            rightArray[lenght2] = int.MaxValue;

            i = 0;
            j = 0;

            for (k = left; k <= right; k++)
            {
                if (leftArray[i] < rightArray[j])
                {
                    array[k] = leftArray[i];
                    i = i + 1;
                }
                else
                {
                    array[k] = rightArray[j];
                    j = j + 1;
                }
            }
        }

        public void MergeSort (List<int> array, int left, int right)
        {
            int mid;

            if (left < right)
            {
                mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }
    }
}
