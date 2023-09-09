using System;

namespace Task1
{
    class Tree<T>
        where T : IComparable<T>
    {
        class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        private Node<T> root;

        public Tree()
        {
            root = null;
        }

        public void AddToTree(T value)
        {
            root = AddToTree(root, value);
        }
        private Node<T> AddToTree(Node<T> node, T value)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }

            else if (value.CompareTo(node.Data) < 0)
            {
                node.Left = AddToTree(node.Left, value);
            }

            else if (value.CompareTo(node.Data) > 0)
            {
                node.Right = AddToTree(node.Right, value);
            }

            return node;
        }

        public void DeleteNode(T value)
        {
            root = DeleteNode(value, root);
        }
        private Node<T> DeleteNode(T value, Node<T> node)
        {
            if (root == null)
            {
                Console.WriteLine("Пустое бинарное дерево!");
                Console.ReadKey();
                return null;
            }

            if (value.CompareTo(node.Data) < 0)
            {
                node.Left = DeleteNode(value, node.Left);
            }
            else if (value.CompareTo(node.Data) > 0)
            {
                node.Right = DeleteNode(value, node.Right);
            }
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    Node<T> temp = node.Right;
                    while (temp.Left != null)
                    {
                        temp = temp.Left;
                    }
                    node.Data = temp.Data;
                    node.Right = DeleteNode(temp.Data, node.Right);
                }
            }

            if (node != null && node.Left == null && node.Right == null && node.Data.CompareTo(root.Data) == 0)
            {
                root = null;
            }

            return node;
        }

        public void IsBelongsToSet(T value)
        {
            IsBelongsToSet(value, root);
        }
        private void IsBelongsToSet(T value, Node<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("Значение не принадлежит множеству");
                Console.ReadKey();
                return;
            }
            if (value.CompareTo(node.Data) == 0)
            {
                Console.WriteLine("Переданное значение принадлежит к множеству");
                Console.ReadKey();
                return;
            }
            else
            {
                if (value.CompareTo(node.Data) < 0)
                {
                    IsBelongsToSet(value, node.Left);
                }
                else
                {
                    IsBelongsToSet(value, node.Right);
                }
            }
        }

        public void PrintTreeAscending()
        {
            PrintTreeAscending(root);
        }
        private void PrintTreeAscending(Node<T> node)
        {
            if (root == null )
            {
                Console.WriteLine("В дереве отсутствуют значения");
                Console.ReadKey();
                return;
            }
            if (node != null)
            {
                PrintTreeAscending(node.Left);
                Console.Write(node.Data + " ");
                PrintTreeAscending(node.Right);
            }
        }

        public void PrintTreeDescending()
        {
            PrintTreeDescending(root);
        }
        private void PrintTreeDescending(Node<T> node)
        {
            if (root == null)
            {
                Console.WriteLine("В дереве отсутствуют значения");
                Console.ReadKey();
                return;
            }
            if (node != null)
            {
                PrintTreeDescending(node.Right);
                Console.Write(node.Data + " ");
                PrintTreeDescending(node.Left);
            }
        }
    }
}