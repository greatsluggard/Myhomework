using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class OneLinkedList
    {
        public Node head;
        public Node tail;
        public OneLinkedList()
        {
            head = tail = null;
        }

        public void PushFront(int data)
        {
            Node node = new Node(data);
            if (tail == null)
            {
                tail = node;
            }

            node.Next = head;
            head = node;
        }

        public void PushBack(int data)
        {
            Node node = new Node(data);
            if (head == null)
            {
                head = node;
            }
            if (tail != null)
            {
                tail.Next = node;
            }

            tail = node;
        }

        public void PopFront()
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
        }

        public void PopBack()
        {
            if (tail == null)
            {
                return;
            }
            if (head == tail)
            {
                head = tail = null;
                return;
            }

            Node node = head;
            for (; node.Next != tail; node = node.Next) ;
            node.Next = null;
            tail = node;
        }

        public Node GetAt(int index)
        {
            if (index < 0)
            {
                return null;
            }

            Node node = head;
            int count = 0;
            while (node != null && count != index && node.Next != null) 
            {
                node = node.Next;
                count++;
            }

            return (count == index) ? node : null;
        }

        public void Insert(int index, int data)
        {
            Node left = GetAt (index - 1);
            if (left == null)
            {
                return;
            }

            Node right = left.Next;
            Node node = new Node(data);

            if (right == null)
            {
                tail = node;
            }

            left.Next = node;
            node.Next = right;
        }

        public void Erase(int index)
        {
            if (index < 0)
            {
                return;
            }
            if (index == 0)
            {
                PopFront();
                return;
            }

            Node left = GetAt(index - 1);
            Node node = left.Next;
            if (node == null)
            {
                return;
            }
            Node right = node.Next; 
            left.Next = right; 
            if (node == tail)
            {
                tail = left;
            }
        }

        public void PrintList()
        {
            Console.Clear();
            Node node = head;
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void Sort(int data)
        {
            int count = 0;

            if (head == null) //если список пустой
            {
                PushBack(data);
            }
            if (data < head.Data) //если добавляемое значение меньше первого
            {
                PushFront(data);
            }
            if (data > tail.Data) //если добавляемое значение больше последнего
            {
                PushBack(data);
            }
            if (data > head.Data) //если добавляемое значение больше первого
            {
                Node node = head;
                while (data > node.Data)
                {
                    node = node.Next;
                    count++;

                    if (data < node.Data)
                    {
                        Insert(count, data);
                    }
                }
            }
        }
    }
}
