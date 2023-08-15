using System;
using System.Collections;

namespace StackForHomework
{
    public class MyStack<T>: IEnumerable
    {

        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }


            public Node (T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }
        private int countOfSize = 0;

        private Node head = null;
        private Node tail = null;

        public void Push(T data) //Добавление элемента на вершину стэка
        {
            Node node = new Node(data);
            if (tail == null)
            {
                tail = node;
            }

            node.Next = head;

            if (head != null)
            {
                head.Prev = node;
            }

            head = node;
            node.Prev = null;

            countOfSize++;
        }

        public void Pop() //Удаление элемента с вершины стэка
        {
            if (head == null)
            {
                return;
            }
            if (head == tail)
            {
                head = tail = null;
                return;
            }

            Node node = head;
            head = node.Next;
            node.Prev = null;

            countOfSize--;

            return;
        }

        public int Size() //Получение размерности стэка
        {
            return countOfSize;
        }

        public T Top() //Получение значения элемента находящегося на вершине стэка
        {
            return head.Data;
        }

        public bool IsEmpty() => head == null; //Проверка на наличие или отсутствие элементов в стэке

        public IEnumerator GetEnumerator() //Возможность использования стэка в цикле foreach
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}