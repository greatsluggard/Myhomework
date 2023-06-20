using System;
using System.IO;

namespace Task3
{
    class Task3
    {
        static void Main()
        {
            Menu menu = new Menu();
            string choice;
            string result = " "; //переменная в которую добавляются данные из 1 метода, чтобы потом сохранить их в 5-ом
            do
            { 
                Console.WriteLine("Вы открыли телефонный справочник: ");
                Console.WriteLine("Нажмите 0 - выйти");
                Console.WriteLine("Нажмите 1 - добавить запись (имя: телефон)");
                Console.WriteLine("Нажмите 2 - распечатать все имеющиеся записи");
                Console.WriteLine("Нажмите 3 - найти телефон по имени");
                Console.WriteLine("Нажмите 4 - найти имя по телефону");
                Console.WriteLine("Нажмите 5 - сохранить текущие данные в файл");
                
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        {
                            Console.Clear();
                            menu.Exit();
                            break;
                        }
                    case "1":
                        {
                            Console.Clear();
                            result = menu.AddRecord();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            menu.PrintAllLines();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            menu.NameFinder();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            menu.PhoneFinder();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            menu.SaveCurrentData(result);
                            break;
                        }
                }
            } while (choice != "0");
        }
    }
}
