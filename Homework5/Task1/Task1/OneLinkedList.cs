using System;

namespace Task1
{
    public class OneLinkedList
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

        public void PushFront(int data)
        {
            Node node = new Node(data);
            if (Tail == null)
            {
                Tail = node;
            }

            node.Next = Head;
            Head = node;
        }

        public void PushBack(int data)
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
        }

        public int PopFront()
        {
            if (Head == null)
            {
                return 0;
            }
            if (Head == Tail)
            {
                Head = Tail = null;
                return 0;
            }

            Node node = Head;
            Head = node.Next;
            return node.Data;
        }

        public int PopBack()
        {
            if (Tail == null)
            {
                return 0;
            }
            if (Head == Tail)
            {
                Head = Tail = null;
                return 0;
            }

            Node node = Head;
            Node remember = Tail;
            while (node.Next != Tail)
            {
                node = node.Next;
            } 
            node.Next = null;
            Tail = node;

            return remember.Data;
        }

        public int SizeOfList ()
        {
            Node node = Head;
            int count = 0;

            do
            {
                count++;
                node = node.Next;
            } while (node.Next != null);

            return count;
        }

        public int GetNodeDataByIndex(int index)
        {
            if (SizeOfList() < 0)
            {
                Console.WriteLine("Список пуст.");
                return 0;
            }

            Node node = Head;
            int count = 0;
            while (node != null && count != index && node.Next != null)
            {
                node = node.Next;
                count++;
            }

            return count == index ? node.Data : 0;
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

            return count == index ? node : null;
        }

        public bool Insert(int index, int data)
        {

            Node left = GetNodeByIndex (index - 1);
            if (left == null)
            {
                Console.WriteLine("Значение не добавлено, обратите внимание на вводимые данные");
                return false;
            }

            if (left == Tail)
            {
                PushBack(data);
                Console.WriteLine("Значение добавлено в конец списка. Вы могли просто использовать метод PushBack");
                return true;
            }

            Node right = left.Next;
            Node node = new Node(data);

            if (right == null)
            {
                Tail = node;
            }

            left.Next = node;
            node.Next = right;

            Console.WriteLine("Значение успешно добавлено по индексу");
            return true;
        }

        public bool Delete(int index)
        {
            if (index < 0)
            {
                Console.WriteLine("Вы пытаетесь удалить элемент с номером которого не существует в списке");
                return false;
            }
            if (index == 0)
            {
                PopFront();
                Console.WriteLine("Первый элемент из списка удачно удалён");
                return true;
            }

            Node left = GetNodeByIndex(index - 1);
            Node node = left.Next;
            if (node == null)
            {
                Console.WriteLine("Значение которое вы пытаетесь удалить и так не существует");
                return false;
            }
            Node right = node.Next; 
            left.Next = right; 
            if (node == Tail)
            {
                Tail = left;
            }

            Console.WriteLine("Значение по введённому вами индексу успешно удалено");
            return true;
        }

        public void PrintList()
        {
            Console.Clear();
            Node node = Head;
            while (node != null)
            {
                Console.Write(node.Data + " ");
                node = node.Next;
            }
            Console.ReadKey();
        }

        public void SortOfElements(int data)
        {
            int count = 0;

            if (Head == null) //если список пустой
            {
                PushBack(data);
            }
            if (data < Head.Data) //если добавляемое значение меньше первого
            {
                PushFront(data);
            }
            if (data > Tail.Data) //если добавляемое значение больше последнего
            {
                PushBack(data);
            }
            if (data > Head.Data) //если добавляемое значение больше первого
            {
                Node node = Head;
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
