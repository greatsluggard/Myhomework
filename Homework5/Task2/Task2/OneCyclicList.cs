using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class OneCyclicList
    {
        public Node head;
        public Node tail;

        public OneCyclicList()
        {
            head = tail = null;
        }

        public void Push(int data)
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
            tail.Next = head;
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

        public void Erase(int index)
        {
            if (index < 0)
            {
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

            if (node == head)
            {
                head = right;
            }
        }

        public int Pop(int m)
        {
            Node node = head;

            int count = 0; // переменная для счётчика индексов элементов в списке
            int nodeValue = 0; // позиция воина/элемента для удаления
            do
            {
                count++;
                nodeValue++;
                if (count == m) //каждый раз, когда count будет равен, к примеру 2...
                                //...будет удаляться каждый 3-ий элемент. 
                {
                    Erase(nodeValue);
                    count = 0;
                }
                if (node == tail)// при повтором обходе списка, нужно сбрасывать счётчик, чтобы индексы элементов не сбивались
                {
                    nodeValue = 0;
                }
                if (head.Next == tail) //когда остаются двое
                {
                    node = node.Next;
                    //Console использую, т.к без этого метод не возвращает значение, почему не понимаю.
                    Console.Write("Номер позиции воина, который останется последним - " + node.Data);
                    Console.WriteLine();
                    return node.Data;
                }

                node = node.Next;

            } while (head != tail);

            return node.Data;
        }
    }
}