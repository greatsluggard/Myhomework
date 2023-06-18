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
            int[] array_N = new int[N];
            for (int i = 0; i < array_N.Length; i++)
            {
                array_N[i] = random.Next(0, 1000000001);
            }
            Array.Sort(array_N); // сортировка массивов перед использованием в алгоритме бинарного поиска;

            int[] array_K = new int[K];
            for (int i = 0; i < array_K.Length; i++)
            {
                array_K[i] = random.Next(0, 1000000001);
            }
            Array.Sort(array_K);

            // алгоритм O (N log N);
            int lowBorder_N = 0;
            int highBorder_N = array_N.Length - 1;
            int midNumber_N = 0;
            int findThis_N = N;

            while (array_N[midNumber_N] != findThis_N)
            {
                midNumber_N = (lowBorder_N + highBorder_N) / 2;
                if (findThis_N < array_N[midNumber_N])
                {
                    highBorder_N = midNumber_N - 1;
                }
                else if (findThis_N > array_N[midNumber_N])
                {
                    lowBorder_N = midNumber_N + 1;
                }
                if (array_N[midNumber_N] == findThis_N)
                {
                    Console.WriteLine("Значение N содержится в массиве");
                    break;
                }
                if (lowBorder_N > highBorder_N)
                {
                    Console.WriteLine("Значение N не содержится в массиве");
                    break;
                }
            }

            // алгоритм O (K log N);
            int lowBorder_K = 0;
            int highBorder_K = array_K.Length - 1;
            int midNumber_K = 0;
            int findThis_K = K;

            while (array_K[midNumber_K] != findThis_K)
            {
                midNumber_K = (lowBorder_K + highBorder_K) / 2;
                if (findThis_K < array_K[midNumber_K])
                {
                    highBorder_K = midNumber_K - 1;
                }
                else if (findThis_K > array_K[midNumber_K])
                {
                    lowBorder_K = midNumber_K + 1;
                }
                if (array_K[midNumber_K] == findThis_K)
                {
                    Console.WriteLine("Значение K содержится в массиве");
                    break;
                }
                if (lowBorder_K > highBorder_K)
                {
                    Console.WriteLine("Значение K не содержится в массиве");
                    break;
                }
            }
        }
    }
}