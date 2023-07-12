using System;

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
                    int.TryParse(Console.ReadLine(), out int data);
                    oneLinkedList.Add(data);

                    /*Console.WriteLine("Куда вы хотите добавить значение?");
                    Console.WriteLine();
                    Console.WriteLine("1 - Добавить в начало списка.");
                    Console.WriteLine("2 - Добавить в конец списка.");
                    Console.WriteLine("3 - Куда хочу, туда добавляю.");

                    string choiceForAdding = Console.ReadLine();

                    switch (choiceForAdding)
                    {
                        case "1":
                            Console.Clear();
                            Console.Write("Введите данные для добавления в начало: ");
                            int.TryParse(Console.ReadLine(), out int data1);
                            oneLinkedList.PushFront(data1);
                            Console.WriteLine("Данные добавлены.");
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.Write("Введите данные для добавления в конец: ");
                            int.TryParse(Console.ReadLine(), out int data2);
                            oneLinkedList.Sort(data2);
                            Console.WriteLine("Данные добавлены.");
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Clear();
                            Console.Write("Введите данные для добавления: ");
                            int.TryParse(Console.ReadLine(), out int data3);
                            Console.Write("Введите место в списке: ");
                            int.TryParse(Console.ReadLine(), out int index);
                            oneLinkedList.Insert(index, data3);
                            Console.ReadKey();
                            break;
                    }   //изначальная реализация списка была такой...
                       //...оставил эту часть кода закоменченной просто для себя
                }*///изначальная реализация
                }

                if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine($"Значение {oneLinkedList.PopBack()} удалено из списка");
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
                            oneLinkedList.Delete(itemForDelete);
                            Console.ReadKey();
                            break;
                    }*/ //изначальная реализация
                }

                if (choice == "3")
                {
                    oneLinkedList.PrintList();
                }

            } while (choice != "0");
        }
    }
}
