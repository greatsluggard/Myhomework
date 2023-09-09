using System;

namespace Task1
{
    class Task1
    {
        static void Main()
        {
            string choice;

            Tree<int> tree = new Tree<int>();

            do
            {
                Console.WriteLine();

                Console.WriteLine("0 - выход");
                Console.WriteLine("1 - добавить значение");
                Console.WriteLine("2 - удалить значение");
                Console.WriteLine("3 - проверка принадлежности к множеству");
                Console.WriteLine("4 - напечатать элементы в возрастающем порядке");
                Console.WriteLine("5 - напечатать элементы в убывающем порядке");

                choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Введите значение для добавления в дерево: ");
                    int.TryParse(Console.ReadLine(), out int value);

                    tree.AddToTree(value);
                }

                if (choice == "2")
                {
                    Console.Write("Введите значение для удаления из дерева: ");
                    int.TryParse(Console.ReadLine(), out int value);

                    tree.DeleteNode(value);
                }

                if (choice == "3")
                {
                    Console.Write("Введите значение для проверки принадлежности к множеству: ");
                    int.TryParse(Console.ReadLine(), out int value);

                    tree.IsBelongsToSet(value);
                }

                if (choice == "4")
                {
                    tree.PrintTreeAscending();
                    Console.ReadKey();
                }

                if (choice == "5")
                {
                    tree.PrintTreeDescending();
                    Console.ReadKey();
                }
            } while (choice != "0");
        }
    }
}
