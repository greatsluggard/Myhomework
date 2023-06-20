using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class Menu
    {
        public void Exit()
        {
            Console.WriteLine("Телефонный справочник закрыт.");
            Console.WriteLine();
            Environment.Exit(0);
        }

        public string AddRecord()
        {
            Console.WriteLine("Введите имя и номер для записи: ");
            StringBuilder sbObject = new StringBuilder();
            using (StringWriter swObject = new StringWriter(sbObject))
            {
                List<string> nameAndPhone = new List<string>();
                for (int i = 0; ; i++)
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                        break;
                    nameAndPhone.Add(input);
                }
                swObject.WriteLine(string.Join("\n", nameAndPhone));
            }
            Console.WriteLine();
            Console.WriteLine("Любая кнопка - вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            string result = sbObject.ToString();
            return result;
        }

        public void PrintAllLines()
        {

            string path = @"C:\Number.txt";
            string textfile = File.ReadAllText(path);
            Console.WriteLine(textfile);

            Console.WriteLine();
            Console.WriteLine("Любая кнопка вернёт вас обратно.");
            Console.ReadKey();
            Console.Clear();
        }

        public void NameFinder()
        {
            string path = @"C:\Number.txt";
            Console.Write("Введите имя для поиска телефона: ");
            string name = Console.ReadLine();
            string[] textfile = File.ReadAllLines(path);
            bool contactFound = false;

            foreach (string line in textfile)
            {
                if (line.Contains(name))
                {
                    Console.WriteLine("Контакт найден:" + line.Split(':')[1]);
                    contactFound = true;
                    break;
                }
            }
            if (!contactFound)
            {
                Console.WriteLine("Контактов с таким именем нет");
            }

            Console.WriteLine();
            Console.WriteLine("Любая кнопка вернёт вас обратно.");
            Console.ReadKey();
            Console.Clear();
        }

        public void PhoneFinder()
        {
            string path = @"C:\Number.txt";
            Console.Write("Введите номер для поиска имени: ");
            string phone = Console.ReadLine();
            string[] textfile = File.ReadAllLines(path);
            bool phoneFound = false;

            foreach (string line in textfile)
            {
                if (line.Contains(phone))
                {
                    Console.WriteLine("Имя найдено: " + line.Split(':')[0]);
                    phoneFound = true;
                    break;
                }
            }
            if (!phoneFound)
            {
                Console.WriteLine("Имён с таким номером нет");
            }

            Console.WriteLine();
            Console.WriteLine("Любая кнопка вернёт вас обратно.");
            Console.ReadKey();
            Console.Clear();
        }

        public void SaveCurrentData (string result)
        {
            File.AppendAllText(@"C:\Number.txt", result);
            Console.WriteLine ("Данные внесены в справочник");

            Console.WriteLine();
            Console.WriteLine("Любая кнопка вернёт вас обратно.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
