using System;
using System.Threading;

namespace Task1
{
    public class Lazy : ILazy<int>
    {
        private Func<int> get;

        object locker = new object();

        public Lazy(int a, int b)
        {
            get = () =>
            {
                int result = a + b;
                return result;
            };
        }

        public int Get()
        {
            lock (locker)
            {
                return get();
            }
        }
    }

    public class LazyFactory
    {
        public static Lazy CreateSingleThreadMode(int a, int b)
        {
            try
            {
                if ((a < 0) || (b < 0))
                {
                    throw new ArgumentException("Аргументы не могут принимать отрицательные значения");
                }
            }
            catch (ArgumentException)
            {
                throw;
            }
            Lazy singleLazy = new Lazy(a, b);
            Func<int> Get = () => singleLazy.Get();

            Thread thread = new Thread(() => Get());
            thread.Start();

            return singleLazy;
        }

        public static (Lazy, bool) CreateMultiThreadMode(int a, int b)
        {
            Lazy multiLazy = new Lazy(a, b);
            Func<int> Get = () => multiLazy.Get();

            int temp = 1;               //...Строки с 60-62, 68-72 были созданы для проверки многопоточной реализации на предмет наличия гонок. 
            int numberOfThread;         //...проверка достаточно тупая, но ничего иного в голову не пришло. Просто сравниваю наименования потоков...
            bool threadAscending = true;//...если они идут по возрастанию, значит гонок и конкуренции среди потоков нет. 
                                        //...Также для этой цели, пришлось использовать кортеж. Изначально возвращаемый тип метода был только Lazy.
            for (int i = 1; i < 6; i++)
            {
                Thread thread = new Thread(() => Get());
                thread.Name = $"{i}";
                numberOfThread = int.Parse(thread.Name);
                if (numberOfThread != temp)
                {
                    threadAscending = false;
                }
                thread.Start();
                Console.WriteLine(thread.Name + " поток: " + multiLazy.Get());
                temp++;

            }
            return (multiLazy, threadAscending);
        }
    }
}