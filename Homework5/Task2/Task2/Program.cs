using System;

namespace Task2
{
    class Program
    {
        static void Main()
        {
            OneCyclicList cyclicList = new OneCyclicList();

            Console.Write("Введите количество воинов всего: ");
            int.TryParse(Console.ReadLine(), out int n);

            Console.Write("Погибает каждый: ");
            int.TryParse(Console.ReadLine(), out int m);

            Console.WriteLine();

            int warriorNumber = 1;
            for (int i = 0; i < n; i++)
            {
                cyclicList.Push(warriorNumber);
                warriorNumber++;
            }

            Console.WriteLine ("Позиция воина, который останется последним - " +cyclicList.DeleteOfEveryM(m - 1));
        }
    }
}