using System;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            //создание делегата и объекта Lazy для однопоточного режима
            Random random = new Random();

            Func<int> supplier = delegate { return random.Next(100) * 2; };
            LazyForSingleThread<int> lazySingleMode = LazyFactory.CreateSingleThread(supplier);

            //запуск потока и проверка повторных вызовов метода Get
            Console.WriteLine("Однопоточный режим: ");
            Thread singleThread = new Thread(() => lazySingleMode.Get());
            singleThread.Start();
            singleThread.Join();

            lazySingleMode.Get();
            lazySingleMode.Get();
            lazySingleMode.Get();

            Console.WriteLine();

            //создание объекта Lazy для многопоточного режима
            Console.WriteLine("Многопоточный режим: ");
            LazyForMultiThread<int> lazyMultiMode = LazyFactory.CreateMultiThread(supplier);
            for (int i = 1; i < 6; i++) 
            { 
                Thread multiThread = new Thread(() => lazyMultiMode.Get());
                multiThread.Start();
            }
        }
    }
}
