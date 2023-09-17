using System;

namespace Task1
{
    public class Tree<T> where T : IComparable<T>
    {
        public class Node<T>
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

        private Node<T> _root;

        public T ReturnRootData()
        {
            return _root.Data;
        }

        public Tree()
        {
            _root = null;
        }

        public void Add(T value)
        {
            if (_root == null)
            {
                _root = new Node<T>(value);
                return;
            }

            Node<T> current = _root;
            Node<T> parent = null;

            while (current != null)
            {
                parent = current;

                if (value.CompareTo(current.Data) < 0)
                {
                    current = current.Left;
                }
                else if (value.CompareTo(current.Data) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return;
                }
            }

            Node<T> node = new Node<T>(value);

            if (value.CompareTo(parent.Data) < 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }
        }

        public void Delete(T value)
        {
            if (_root == null)
            {
                Console.WriteLine("Пустое бинарное дерево!");
                Console.ReadKey();
                return;
            }

            Node<T> current = _root;
            Node<T> parent = null;

            while (current != null && value.CompareTo(current.Data) != 0)
            {
                parent = current;

                if (value.CompareTo(current.Data) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            if (current == null)
            {
                return;
            }

            if (current.Left == null && current.Right == null)
            {
                if (parent != null)
                {
                    if (parent.Left == current)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
                else
                {
                    _root = null;
                }
            }
            else if (current.Left == null)
            {
                if (parent != null)
                {
                    if (parent.Left == current)
                    {
                        parent.Left = current.Right;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
                else
                {
                    _root = current.Right;
                }
            }
            else if (current.Right == null)
            {
                if (parent != null)
                {
                    if (parent.Left == current)
                    {
                        parent.Left = current.Left;
                    }
                    else
                    {
                        parent.Right = current.Left;
                    }
                }
                else
                {
                    _root = current.Left;
                }
            }
            else
            {
                Node<T> currentParent = current;
                Node<T> currentRightChild = current.Right;

                while (currentRightChild.Left != null)
                {
                    currentParent = currentRightChild;
                    currentRightChild = currentRightChild.Left;
                }

                if (currentParent != current)
                {
                    currentParent.Left = currentRightChild.Right;
                    currentRightChild.Right = current.Right;
                }

                currentRightChild.Left = current.Left;

                if (parent != null)
                {
                    if (parent.Left == current)
                    {
                        parent.Left = currentRightChild;
                    }
                    else
                    {
                        parent.Right = currentRightChild;
                    }
                }
                else
                {
                    _root = currentRightChild;
                }
            }
        }

        public void Find(T value)
        {
            Node<T> node = _root;

            do
            {
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
                        node = node.Left;
                    }
                    else if (value.CompareTo(node.Data) > 0)
                    {
                        node = node.Right;
                    }
                }
                if (node == null)
                {
                    Console.WriteLine("Значение не принадлежит множеству");
                    Console.ReadKey();
                    return;
                }
            } while (node != null);
        }

        public void PrintTreeAscending()
        {
            PrintTreeAscending(_root);
        }

        private void PrintTreeAscending(Node<T> node)
        {
            if (_root == null )
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
            PrintTreeDescending(_root);
        }

        private void PrintTreeDescending(Node<T> node)
        {
            if (_root == null)
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