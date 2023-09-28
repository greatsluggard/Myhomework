using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            string path = @"C:\textForHashTable.txt";

            List<string> wordsList = new List<string>();

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    string[] words = line.Split(' ');

                    wordsList.AddRange(words);
                }
            }

            List<string> uniqueWords = new List<string>();
            foreach (string word in wordsList)
            {
                bool isDuplicate = false;
                for (int i = 0; i < uniqueWords.Count; i++)
                {
                    if (word == uniqueWords[i])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    uniqueWords.Add(word);
                }
            }

            HashTable hashTable = new HashTable(uniqueWords.Count);

            foreach (string word in wordsList)
            {
                hashTable.Add(word, 1);
            }

            foreach (string word in uniqueWords)
            {
                Console.WriteLine(word + " " + hashTable.Print(word));
            }

            double fillFactor = wordsList.Count / uniqueWords.Count;
            Console.WriteLine("Коэффициент заполнения хэш-таблицы: " + fillFactor);

            hashTable.GetMaxAndAverageListLength();

            Console.WriteLine();

            HashTable hashTable2 = new HashTable(0);
            try
            {
                hashTable2.Add("divideByZeroEx", 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
            }

            Console.WriteLine();

            HashTable hashTable3 = new HashTable(10);
            hashTable3.Add("outOfRangeEx", -1);

            Console.WriteLine();

            hashTable3.Print("");

            Console.WriteLine();

            try
            {
                object forMethod = "value";
                int value = (int)forMethod;
                hashTable3.Add("key", value);
            }
            catch(InvalidCastException ex)
            {
                Console.WriteLine("Исключение: "+ex.Message);
            }
        }
    }
}
