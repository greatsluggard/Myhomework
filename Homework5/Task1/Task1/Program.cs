using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            OneLinkedList oneLinkedList = new OneLinkedList();
            string choice;

            do
            {
                Console.Clear();

                Console.WriteLine("Меню: ");
                Console.WriteLine("0 - закрыть и выйти");
                Console.WriteLine("1 - добавить значение");
                Console.WriteLine("2 - удалить значение");
                Console.WriteLine("3 - распечатать список");

                choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.Clear();
                    Console.WriteLine("Односвязный список закрыт.");
                    Environment.Exit(0);
                }

                if (choice == "1")
                {
                    Console.Clear();
                    Console.Write("Введите значение: ");
                    int.TryParse(Console.ReadLine (), out int data);
                    oneLinkedList.Sort(data);
                    /*Console.WriteLine("Куда вы хотите добавить значение?");
                    Console.WriteLine();
                    Console.WriteLine("1 - Добавить в начало списка.");
                    Console.WriteLine("2 - Добавить в конец списка.");
                    Console.WriteLine("3 - Куда хочу, туда добавляю.");

                    string choiceForAdding = Console.ReadLine();
                    object data;

                    switch (choiceForAdding)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Введите данные для добавления в начало: ");
                            data = Console.ReadLine();
                            oneLinkedList.PushFront(data);
                            Console.WriteLine("Данные добавлены.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Введите данные для добавления в конец: ");
                            data = Console.ReadLine();
                            oneLinkedList.Sort(data);
                            Console.WriteLine("Данные добавлены.");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Clear();
                            Console.Write("Введите данные для добавления: ");
                            data = Console.ReadLine();
                            Console.Write("Введите место в списке: ");
                            int.TryParse(Console.ReadLine(), out int index);
                            oneLinkedList.Insert(index, data);
                            Console.WriteLine("Данные добавлены.");
                            Console.ReadKey();
                            break;
                    }*///изначальная реализация списка была такой...
                                                                                  //...оставил эту часть кода закоменченной просто для себя
                }

                if (choice == "2")
                {
                    Console.Clear();
                    oneLinkedList.PopBack();
                    Console.WriteLine("Элемент удалён.");
                    Console.ReadKey();
                    /*Console.WriteLine("Какое значение хотите удалить?:");
                    Console.WriteLine("1 - Удалить первое значение.");
                    Console.WriteLine("2 - Удалить последнее значение.");
                    Console.WriteLine("3 - Какое хочу, такое удаляю.");
                    string choiceForDelete = Console.ReadLine();

                    switch (choiceForDelete)
                    {
                        case "1":
                            Console.Clear();
                            oneLinkedList.PopFront();
                            Console.WriteLine("Первое значение списка удалено.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            oneLinkedList.PopBack();
                            Console.WriteLine("Последнее значение списка удалено.");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Clear();
                            Console.Write("Тогда введите индекс элемента: ");
                            int.TryParse(Console.ReadLine(), out int itemForDelete);
                            oneLinkedList.Erase(itemForDelete);
                            Console.WriteLine("Элемент удалён.");
                            Console.ReadKey();
                            break;
                    }*///изначальная реализация
                }

                if (choice == "3")
                {
                    oneLinkedList.PrintList();
                }

            } while (choice != "0"); 
        }
    }
}
