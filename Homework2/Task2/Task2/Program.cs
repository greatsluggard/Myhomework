using System;

namespace Task2
{
    class Task2
    {
        static void Main()
        {
            int count1 = 0;
            int temperance = 1;
            int.TryParse(Console.ReadLine(), out int degree);
            Console.WriteLine();
            for (int i = 0; i < degree; i++)
            {
                int number = 2; 
                temperance *= number;
                count1++;
            }
            Console.WriteLine(temperance);
            Console.WriteLine("Линейная реализация O(N): количество итераций - " + count1);
            Console.WriteLine();
            int count2 = 0;
            int[] degreesList = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };
            int lowArrayBoundary = 0;
            int highArrayBoundary = degreesList.Length - 1;
            int middleNumber = 0;
            int findthis = temperance;
            while (degreesList[middleNumber] != findthis)
            {
                middleNumber = (lowArrayBoundary + highArrayBoundary) / 2;
                if (findthis < degreesList[middleNumber])
                {
                    highArrayBoundary = middleNumber - 1;
                }
                else if (findthis > degreesList[middleNumber])
                {
                    lowArrayBoundary = middleNumber + 1;
                }
                count2++;
            }
            Console.WriteLine(findthis);
            Console.WriteLine("Логарифмическая реализация O(log N): количество итераций - " + count2);
            Console.ReadKey();
        }
    }
}