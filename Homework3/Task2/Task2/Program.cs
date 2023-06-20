using System;

namespace Task2
{
    class Task2
    {
        static void Main()
        {
            //создание и ввод переменных
            int N;
            int K;
            do
            {
                Console.Write("Введите N: ");
                int.TryParse(Console.ReadLine(), out N);
            } while (N < 1 || N > 5000);
            do
            { 
                Console.Write("Введите K: ");
                int.TryParse(Console.ReadLine(), out K);
            } while (K < 1 || K > 300000);
            Console.WriteLine();

            //создание массивов и их заполнение;
            Random random = new Random();
            int[] arrayN = new int[N];
            for (int i = 0; i < arrayN.Length; i++)
            {
                arrayN[i] = random.Next(0, 1000000001);
            }
            Array.Sort(arrayN); // сортировка массивов перед использованием в алгоритме бинарного поиска;

            int[] arrayK = new int[K];
            for (int i = 0; i < arrayK.Length; i++)
            {
                arrayK[i] = random.Next(0, 1000000001);
            }
            Array.Sort(arrayK);

            // алгоритм O (N log N);
            int lowBorderN = 0;
            int highBorderN = arrayN.Length - 1;
            int midNumberN = 0;
            int findThisN = N;

            while (arrayN[midNumberN] != findThisN)
            {
                midNumberN = (lowBorderN + highBorderN) / 2;
                if (findThisN < arrayN[midNumberN])
                {
                    highBorderN = midNumberN - 1;
                }
                else if (findThisN > arrayN[midNumberN])
                {
                    lowBorderN = midNumberN + 1;
                }
                if (arrayN[midNumberN] == findThisN)
                {
                    Console.WriteLine("Значение N содержится в массиве");
                    break;
                }
                if (lowBorderN > highBorderN)
                {
                    Console.WriteLine("Значение N не содержится в массиве");
                    break;
                }
            }

            // алгоритм O (K log N);
            int lowBorderK = 0;
            int highBorderK = arrayK.Length - 1;
            int midNumberK = 0;
            int findThisK = K;

            while (arrayK[midNumberK] != findThisK)
            {
                midNumberK = (lowBorderK + highBorderK) / 2;
                if (findThisK < arrayK[midNumberK])
                {
                    highBorderK = midNumberK - 1;
                }
                else if (findThisK > arrayK[midNumberK])
                {
                    lowBorderK = midNumberK + 1;
                }
                if (arrayK[midNumberK] == findThisK)
                {
                    Console.WriteLine("Значение K содержится в массиве");
                    break;
                }
                if (lowBorderK > highBorderK)
                {
                    Console.WriteLine("Значение K не содержится в массиве");
                    break;
                }
            }
        }
    }
}