using System;

namespace Task1
{
    class Task1
    {
        public static void SortArrayPart (int[] array, int startIndex, int length)
        {
            if (length < 2 || length >= 10) 
                return;

            int endIndex = startIndex + length;

            for (int i = startIndex + 1; i < endIndex; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= startIndex && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }
        static void Main()
        {
            Random random = new Random();
            int.TryParse(Console.ReadLine(), out int a);
            int.TryParse(Console.ReadLine(), out int b);
            int.TryParse(Console.ReadLine(), out int c);

            int[] array = new int[a + b + c];

            for (int i = 0; i < a; i++)
            {
                array[i] = random.Next(0, 100);
            }
            for (int i = a; i < a + b; i++)
            {
                array[i] = random.Next(0, 100);
            }
            for (int i = b; i < a + b + c; i++)
            {
                array[i] = random.Next(0, 100);
            }

            Console.WriteLine("Весь массив: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            SortArrayPart(array, 0, a); 
            SortArrayPart(array, a, b); 
            SortArrayPart(array, a + b, c); 

            Console.WriteLine();

            Console.WriteLine("Отсортированные части: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
