using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            Lazy lazySingleThreadMode = LazyFactory.CreateSingleThreadMode(3, 5);
            Console.WriteLine("Работа в однопоточном режиме: " +
                "\n" + "- Первый вызов Get() вызывает вычисление и возвращает результат;" +
                "\n" + "- Повторные вызовы Get() возвращают тот же объект, что и первый вызов;" +
                "\n" + "- Вычисление должно запускаться не более одного раза;");
            Console.WriteLine("Результат работы в однопоточном режиме: ");
            Console.WriteLine(lazySingleThreadMode.Get());
            Console.WriteLine(lazySingleThreadMode.Get());
            Console.WriteLine(lazySingleThreadMode.Get());

            Console.WriteLine();

            Console.WriteLine("Работа в многопоточном режиме: ");
            (Lazy, bool) lazyMultiThreadedMode = LazyFactory.CreateMultiThreadMode(26, 3);
        }
    }
}
