using System;
using System.Collections;

namespace StackForHomework
{
    public class MyStack: IEnumerable
    {
        private class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }


            public Node(object data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        Node Head = null;
        Node Tail = null;

        public void Push(object data) //Добавление элемента на вершину стэка
        {
            Node node = new Node(data);
            if (Tail == null)
            {
                Tail = node;
            }

            node.Next = Head;

            if (Head != null)
            {
                Head.Prev = node;
            }

            Head = node;
            node.Prev = null;
        }

        public void Pop() //Удаление элемента с вершины стэка
        {
            if (Head == null)
            {
                return;
            }
            if (Head == Tail)
            {
                Head = Tail = null;
                return;
            }

            Node node = Head;
            Head = node.Next;
            node.Prev = null;

            return;
        }

        public int Size() //Получение размерности стэка
        {
            Node node = Head;
            int count = 0;
            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }

        public object Top() //Получение значения элемента находящегося на вершине стэка
        {
            if (Head == null)
            {
                return 0;
            }
            return Head.Data;
        }

        public bool Empty() //Проверка на наличие или отсутствие элементов в стэке
        {
            if (Head == null)
            {
                Console.WriteLine("Стэк пуст");
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator GetEnumerator() //Возможность использования стэка в цикле foreach
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}