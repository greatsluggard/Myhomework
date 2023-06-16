using System;

namespace Task3
{
    class Task3
    {
        class SortMethods
        {
            public int[] CountingSort(int[] array, int maxnumber)
            {
                int[] output = new int[array.Length];
                int[] count = new int[maxnumber + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    count[array[i]]++;
                }
                for (int i = 1; i <= maxnumber; i++)
                {
                    count[i] += count[i - 1];
                }
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    output[count[array[i]] - 1] = array[i];
                    count[array[i]]--;
                }
                return output;
            }
        }
        class SortMethodsDemo
        {
            static void Main()
            {
                SortMethods sortMethods = new SortMethods();
                Console.WriteLine("Исходный массив: ");
                int[] arrayofCountingSort = { 7, 3, 5, 2, 1, 0, 0, 2, 5, 5 };
                foreach (int i in arrayofCountingSort)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Результат сортировки подсчётом: ");
                int[] resultCountingSort = sortMethods.CountingSort(arrayofCountingSort, 7);
                foreach (int i in resultCountingSort)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();// конец реализации сортировки подсчётом 
                Console.WriteLine(); // и начало сортировки пузырьком
                Console.WriteLine("Исходный массив: ");
                int temporary;
                int[] arrayofBubbleSort = { 165, 13, 99, 2, 2, 68, 41, 70, 10, 7 };
                foreach (int i in arrayofBubbleSort)
                {
                    Console.Write(i + " ");
                }
                for (int i = 0; i < arrayofBubbleSort.Length; i++)
                {
                    for (int j = 0; j < arrayofBubbleSort.Length - i - 1; j++)
                    {
                        if (arrayofBubbleSort[j] > arrayofBubbleSort[j + 1])
                        {
                            temporary = arrayofBubbleSort[j];
                            arrayofBubbleSort[j] = arrayofBubbleSort[j + 1];
                            arrayofBubbleSort[j + 1] = temporary;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Результат сортировки пузырьком: ");
                foreach (int i in arrayofBubbleSort)
                {
                    Console.Write(i + " ");
                }
                Console.ReadKey();
            }
        }
    }
}