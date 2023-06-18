using System;

namespace Task3
{
    class Task3
    {
        static public int SortOfCounting(int[] array, int minValue, int maxValue, int frequent)
        {// ниже использую алгоритм сортировки подсчётом
            int temp = 0; // временная переменная, которая принимает количество раз наиболее частого элемента
            int j = 0;
            int[] count = new int[maxValue + 1];
            for (int i = minValue; i <= maxValue; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
                if (count[array[i]] > temp) // этот if ключевая часть кода позволяющая получить...
                {                           //...самый частовстречающийся элемент
                    temp = count[array[i]];
                    frequent = array[i]; 
                }
            }
            for (int i = minValue; i <= maxValue; i++)
            {
                while (count[i] > 0)
                {
                    array[j] = i;
                    j++;
                    count[i]--;
                }
            }
            return frequent;
        }
        static void Main()
        {
            Console.WriteLine("Исходный массив: ");
            int[] arrayofCountingSort = { 8, 3, 88, 2, 9, 6, 88, 5, 88, 7, 88, 82, 88, 13, 4 };
            foreach (int i in arrayofCountingSort)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Результат сортировки подсчётом: ");
            Console.WriteLine(SortOfCounting(arrayofCountingSort, 0, 100, 0));
        }
    }
}
