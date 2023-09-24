using System;

namespace Task1
{
    class Task1
    {
        static void Main()
        {
            string choice;

            AssociativeArray<string,string> array = new AssociativeArray<string,string>();

            do
            {
                Console.WriteLine();

                Console.WriteLine("0 - выход");
                Console.WriteLine("1 - добавить значение");
                Console.WriteLine("2 - получить значение");
                Console.WriteLine("3 - проверить наличие ключа");
                Console.WriteLine("4 - удалить ключ и значение");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите ключ: ");
                    string key = Console.ReadLine();
                    Console.Write("Введите значение: ");
                    string value = Console.ReadLine();

                    array.Add(key, value);
                }

                if (choice == "2")
                {
                    Console.WriteLine("Введите ключ чтобы получить значение: ");
                    string key = Console.ReadLine();

                    Console.WriteLine("Значение ключа: " +array.GetValue(key));
                }

                if (choice == "3")
                {
                    Console.Write("Введите ключ для проверки: ");
                    string key = Console.ReadLine();
                    array.Check(key);
                }

                if (choice == "4")
                {
                    Console.WriteLine("Введите ключ для удаления: ");
                    string key = Console.ReadLine();
                    array.Delete(key);
                }

            } while (choice != "0");
        }
    }
}