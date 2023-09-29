using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Task1
{
    public class HashTableException : Exception
    {
        public HashTableException(string message) : base(message) { }
    }
    public class HashTable
    {
        private List<HashNode> arrayOfValues;
        private class HashNode
        {
            public string Key { get; set; }
            public int Value { get; set; }
            public HashNode Next { get; set; }

            public HashNode(string key, int data)
            {
                Key = key;
                Value = data;
                Next = null;
            }
        }

        public HashTable(int size)
        {
            arrayOfValues = new List<HashNode>(new HashNode[size]);
            try
            {
                if (size == 0)
                {
                    throw new HashTableException("Длина массива не может равняться 0. Это приведёт к ошибке хэширования.");
                }
            }
            catch (HashTableException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            Size = size;
        }

        public int Size { get { return arrayOfValues.Count; } set { } }

        public int GetHash(string key)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                hash = (hash << 5) - hash + key[i];
            }

            return Math.Abs(hash);
        }

        public int GetIndex(string key)
        {
            int hash = GetHash(key);
            return hash % arrayOfValues.Count;
        }

        public void Add(string key, int value)
        {
            int index = GetIndex(key);
            HashNode node = arrayOfValues[index];

            try
            {
                if (value < 0)
                {
                    throw new HashTableException("В контексте решения данной задачи значение не может быть отрицательным");
                }
            }
            catch (HashTableException ex)
            {
                Console.WriteLine("Произошло исключение: " + ex.Message);
            }

            if (node == null)
            {
                arrayOfValues[index] = new HashNode(key, value);
            }
            else
            {
                while (node.Next != null && node.Key != key)
                {
                    node = node.Next;
                }

                if (node.Key == key)
                {
                    node.Value++;
                }
                else
                {
                    node.Next = new HashNode(key, value);
                }
            }
        }

        public int Print(string key)
        {
            try
            {
                if (key.Length == 0)
                {
                    throw new HashTableException(" Значение ключа не может быть пустым");
                }
            }
            catch (HashTableException ex)
            {
                Console.WriteLine("В методе Print произошла ошибка!" + ex.Message);
            }
            int index = GetIndex(key);
            HashNode node = arrayOfValues[index];

            while (node != null && node.Key != key)
            {
                node = node.Next;
            }

            if (node == null)
            {
                return -1;
            }
            else
            {
                return node.Value;
            }
        }

        public void GetMaxAndAverageListLength()
        {
            int maxListLength = 0;
            int totalListLength = 0;
            int numLists = 0;

            foreach (var bucket in arrayOfValues)
            {
                int listLength = 0;
                var currentNode = bucket;

                while (currentNode != null)
                {
                    listLength++;
                    currentNode = currentNode.Next;
                }

                if (listLength > maxListLength)
                {
                    maxListLength = listLength;
                }

                totalListLength += listLength;
                numLists++;
            }

            double averageListLength = (double)totalListLength / numLists;

            Console.WriteLine("Средняя длина заполнения сегмента списка в таблице - " + averageListLength);
            Console.WriteLine("Макс. длина заполнения сегмента списка в таблице - " + maxListLength);
        }
    }
}