using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            cyclicList.Pop(m-1);
        }
    }
}