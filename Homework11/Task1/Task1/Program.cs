using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            MyThreadPool<int> pool = new MyThreadPool<int>(5);

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                pool.AddTask(() => random.Next(100));
            }

            var myTask = pool.AddTask(() => 2 * 2); 
            myTask = pool.ContinueWith(x => x * 100);

            Console.WriteLine(myTask);
        }
    }
}