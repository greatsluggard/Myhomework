using System;

namespace Task1
{
    class Fibonachi
    {
        public int RecursionFibonachi(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else
            {
                return RecursionFibonachi(number - 1) + RecursionFibonachi(number - 2);
            }
        }
        static void Main()
        {
            Console.Write("Введите порядковый номер элемента последовательности Фибоначчи: ");
            int.TryParse(Console.ReadLine(), out int x);
            Fibonachi ob = new Fibonachi();
            Console.WriteLine("Результат рекурсивного вычисления: " + ob.RecursionFibonachi(x));
            Console.WriteLine();
            int firstNumber = 0;
            int secondNumber = 1;
            int result = 0;
            int count = 0;
            Console.Write("Введите порядковый номер элемента последовательности Фибоначчи: ");
            int.TryParse(Console.ReadLine(), out int numberOfFibo);
            while (count != numberOfFibo)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
                count++;
            }
            Console.Write("Результат итеративного вычисления: " + result);
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}