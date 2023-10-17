using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Func<int> task = () => random.Next(100);
                MyThreadPool<int>.AddTask(task);
            }

            MyThreadPool<int> pool = new MyThreadPool<int>(5);

        }
    }
}
