using System;

namespace Task2
{
    public class OneCyclicList
    {
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        Node Head = null;
        Node Tail = null;

        public void Push(int data)
        {
            Node node = new Node(data);
            if (Head == null)
            {
                Head = node;
            }
            if (Tail != null)
            {
                Tail.Next = node;
            }
            Tail = node;
            Tail.Next = Head;
        }

        public int SizeOfList()
        {
            Node node = Head;
            int count = 0;

            do
            {
                count++;
                node = node.Next;
            } while (node != Head);

            return count;
        }

        Node GetNodeByIndex(int index)
        {
            if (SizeOfList() < 0)
            {
                Console.WriteLine("Список пуст.");
                return null;
            }

            Node node = Head;
            int count = 0;

            while (node != null && count != index && node.Next != null)
            {
                node = node.Next;
                count++;
            }

            return (count == index) ? node : null;
        }

        public void Delete(int index)
        {
            if (index < 0)
            {
                return;
            }

            Node left = GetNodeByIndex(index - 1);
            Node node = left.Next;

            if (node == null)
            {
                return;
            }

            Node right = node.Next;
            left.Next = right;

            if (node == Tail)
            {
                Tail = left;
            }

            if (node == Head)
            {
                Head = right;
            }
        }

        public int DeleteOfEveryM(int m)
        {
            Node node = Head;

            int count = 0; // переменная для счётчика индексов элементов в списке
            int nodeValue = 0; // позиция воина/элемента для удаления
            do
            {
                count++;
                nodeValue++;
                if (count == m) //каждый раз, когда count будет равен, к примеру 2...
                                //...будет удаляться каждый 3-ий элемент. 
                {
                    Delete(nodeValue);
                    count = 0;
                }
                if (node == Tail)// при повтором обходе списка, нужно сбрасывать счётчик, чтобы индексы элементов не сбивались
                {
                    nodeValue = 0;
                }
                if (Head.Next == Tail) //когда остаются двое
                {
                    node = node.Next;                    
                }

                node = node.Next;

            } while (Head != Tail);

            return node.Data;
        }
    }
}