using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Programs1
    {
        static void Main()
        {
            void Task1()
            {
                Console.WriteLine("1) Написать программу, считающую значение формулы: х^4 + x^3 + x^2 + x + 1 за два умножения.");
                Console.Write("Введите x: ");
                int.TryParse(Console.ReadLine(), out int x);
                int y = x * x;
                int g = (y + 1) * (y + x) + 1;
                Console.WriteLine("Ответ: " +g);
            }
            Task1();
            Console.WriteLine();

            void Task2()
            {
                Console.WriteLine("2) Написать программу нахождения неполного частного от деления А на B (целые числа), \n" +
                    "   используя только операции сложения, вычитания и умножения");
                Console.WriteLine("Введите числа для получения неполного частного: ");
                repeatedcase:
                Console.Write("Для А = ");
                int.TryParse(Console.ReadLine(), out int a);
                Console.Write("Для В = ");
                int.TryParse(Console.ReadLine(), out int b);
                if (a < b)
                {
                    Console.WriteLine("При введённых вами значениях, программа будет работать некоректно!\nПожалуйста введите значения заново.");
                    goto repeatedcase;
                }
                int count = -1;
                for (int i = 0; i <= a; i += b)
                {
                    if (i == a)
                    {
                        Console.WriteLine(i);
                    }
                    count++;
                }
                Console.WriteLine("Неполное частное от деления " + a + " на " + b + " равняется " + count);
            }
            Task2();
            Console.WriteLine();

            void Task3()
            {
                Console.WriteLine("3) Дан массив целых чисел x[1]...x[m+n], рассматриваемый как соединение двух его отрезков: начала x[1]...x[m] длины m и конца x[m+1]...x[m+n] длины n. \nНе используя дополнительных массивов, переставить начало и конец (обращением двух частей массива, а потом его самого).");
                Random random = new Random();
                isErrorCase:
                Console.Write("Введите длину первой части: ");
                int.TryParse(Console.ReadLine(), out int firstPart);
                Console.Write("Введите длину второй части: ");
                int.TryParse(Console.ReadLine(), out int secondPart);
                if ((firstPart < 0) || (secondPart < 0))
                {
                    Console.WriteLine("Длина части массива не может быть меньше нуля. Введите данные заново.");
                    goto isErrorCase;
                }

                Console.WriteLine();
                int[] arr = new int[firstPart + secondPart];
                Console.WriteLine("Первая часть массива: ");
                for (int i = 0; i < firstPart; i++)
                {
                    arr[i] = random.Next(0, 11);
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Вторая часть массива: ");
                for (int i = firstPart; i < firstPart + secondPart; i++)
                {
                    arr[i] = random.Next(0, 11);
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
                Console.Write("Полный массив: ");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine();
                Console.Write("Перевёрнутый массив: ");
                for (int j = firstPart; j <= (secondPart + firstPart) - 1; j++)
                {
                    Console.Write(arr[j] + " ");
                }
                for (int j = 0; j <= firstPart - 1; j++)
                {
                    Console.Write(arr[j] + " ");
                }
            }
            Task3();
            Console.WriteLine();
            Console.WriteLine();

            void Task4()
            {
                Console.WriteLine("4) Посчитать число «счастливых билетов» (билет считается «счастливым», если сумма первых трёх цифр его номера, равна сумме трёх последних), подсчётом числа билетов с заданной суммой трёх цифр.");
                for (int ticket = 100000; ticket < 999999; ticket++)
                {
                    int number1 = ticket / 100000;
                    int number2 = (ticket - (number1 * 100000)) / 10000;
                    int number3 = (ticket - ((number1 * 100000) + (number2 * 10000))) / 1000;
                    int number4 = (ticket - ((number1 * 100000) + (number2 * 10000) + (number3 * 1000))) / 100;
                    int number5 = (ticket - ((number1 * 100000) + (number2 * 10000) + (number3 * 1000) + (number4 * 100))) / 10;
                    int number6 = ticket % 10;
                    int sumFirstThreeNumbers = number1 + number2 + number3;
                    int sumSecondThreeNumbers = number4 + number5 + number6;
                    if (sumFirstThreeNumbers == sumSecondThreeNumbers) Console.WriteLine($"Счастливый билет {number1}{number2}{number3} {number4}{number5}{number6}");
                }
            }
            Task4();
            Console.WriteLine();

            bool CheckBrackets(string str)
            {
                int count = 0;
                foreach (char symbol in str)
                {
                    if (symbol == '(')
                        count++;
                    else if (symbol == ')')
                        count--;
                    if (count < 0) return false;
                }
                return count == 0;
            }
            void Task5()
            {
                Console.WriteLine("5) Написать программу проверки баланса скобок в исходной строке (т.е число открывающих скобок равно числу закрывающих и выполняется правило вложенности скобок).");
                string sourceLine = "Hey! () ()Hello( World)";
                Console.WriteLine(sourceLine);
                if (CheckBrackets(sourceLine))
                    Console.WriteLine("Всё верно");
                else
                    Console.WriteLine("Ошибка");
            }
            Task5();
            Console.WriteLine();

            void Task6()
            {
                Console.WriteLine("6) Заданы две строки: S и S1. Найти количество вхождений S1 в S как подстроки.");
                Console.Write("Введите строку S: ");
                string mainLine = Convert.ToString(Console.ReadLine());
                Console.Write("Введите подстроку S1: ");
                string subLine = Convert.ToString(Console.ReadLine());
                int i = 0;
                int x = -1;
                int count = -1;
                while (i != -1)
                {
                    i = mainLine.IndexOf(subLine, x + 1);
                    x = i;
                    count++;
                }
                Console.WriteLine("Количество вхождений S1 в S как подстроки: " + count);
            }
            Task6();
            Console.WriteLine();

            bool IsSimpleNumber (double x)
            {
                double sqrtX = Math.Sqrt(x);
                for (int j = 2; j <= sqrtX; j++)
                    if (x % j == 0)
                    {
                        return false;
                    }
                        return true;
            }
            void Task7()
            {
                Console.WriteLine("7) Напечатать программу печатающую все простые числа, не превосходящие заданного числа");
                int number = 32;
                Console.WriteLine();
                Console.WriteLine("Простые числа не превосходящие числа " + number);
                for (int i = 1; i < number; i++)
                {
                    if (IsSimpleNumber(i)) 
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            Task7();
            Console.WriteLine();

            int CountZeroElements(int[] array)
            {
                int count = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 0)
                    {
                        count++;
                    }
                }
                return count;
            }
            void Task8()
            {
                Console.WriteLine("8) Написать программу считающую количество нулевых элементов в массиве.");
                Random random = new Random();
                Console.Write("Введите количество элементов массива: ");
                int.TryParse(Console.ReadLine(), out int numberOfElements);
                int[] array = new int[numberOfElements];
                for (int i = 0; i < numberOfElements; i++)
                {
                    array[i] = random.Next(0, 20);
                    Console.Write(array[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Количество нулевых элементов в массиве: " + CountZeroElements(array));
            }
            Task8();
            Console.ReadLine();
        }
    }
}