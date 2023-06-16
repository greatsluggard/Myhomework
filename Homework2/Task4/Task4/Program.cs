using System;

namespace Task4
{
    class Task4
    {
        static void Main()
        {
            Random rand = new Random();
            Console.Write("Введите кол-во элементов начала массива: ");
            int.TryParse(Console.ReadLine(), out int begin);
            Console.Write("Введите кол-во элементов конца массива: ");
            int.TryParse(Console.ReadLine(), out int end);
            Console.WriteLine();
            int[] array = new int[begin + end];
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
                Console.Write(array[i] + " ");
            }
            int firstElement = array[0];
            int count = 0;
            int temporary;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < firstElement)
                {
                    temporary = array[count];
                    array[count] = array[i];
                    array[i] = temporary;
                    count++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Преобразованный массив: ");
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}