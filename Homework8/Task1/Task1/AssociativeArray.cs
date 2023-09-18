using System;

namespace Task1
{
    public class AssociativeArray<T> where T : IComparable<T>
    {
        public class Node<T>
        {
            public T Key { get; set; }
            public T Data { get; set; }
            public int Height { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            public Node(T key, T data)
            {
                Key = key;
                Data = data;
                Height = 0;
                Left = null;
                Right = null;
            }
        }

        private Node<T> _root;

        public AssociativeArray()
        {
            _root = null;
        }

        public int GetHeight(Node<T> node)
        {
            return node == null ? -1 : node.Height;
        }

        public void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        public int GetBalance(Node<T> node)
        {
            return node == null ? 0 : GetHeight(node.Right) - GetHeight(node.Left);
        }

        public void Swap(Node<T> a, Node<T> b)
        {
            T a_key = a.Key;
            a.Key = b.Key;
            b.Key = a_key;

            T a_data = a.Data;
            a.Data = b.Data;
            b.Data = a_data;
        }

        public void RightRotate(Node<T> node)
        {
            Swap(node, node.Left);
            Node<T> buffer = node.Right;
            node.Right = node.Left;
            node.Left = node.Right.Left;
            node.Right.Left = node.Right.Right;
            node.Right.Right = buffer;
            UpdateHeight(node.Right);
            UpdateHeight(node);
        }

        public void LeftRotate(Node<T> node)
        {
            Swap(node, node.Right);
            Node<T> buffer = node.Left;
            node.Left = node.Right;
            node.Right = node.Left.Right;
            node.Left.Right = node.Left.Left;
            node.Left.Left = buffer;
            UpdateHeight(node.Left);
            UpdateHeight(node);
        }

        public void Balance(Node<T> node)
        {
            int balance = GetBalance(node);
            if (balance == -2)
            {
                if (GetBalance(node.Left) == 1)
                {
                    LeftRotate(node.Left);
                }
                RightRotate(node);
            }
            else if (balance == 2)
            {
                if (GetBalance(node.Right) == -1)
                {
                    RightRotate(node.Right); 
                }
                LeftRotate(node);
            }
        }

        public Node<T> FindParent(Node<T> node)
        {
            Node<T> current = _root;
            Node<T> parent = null;

            while (current != null && current != node)
            {
                parent = current;

                if (node.Key.CompareTo(current.Key) < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return parent;
        }

        public void Add(T key, T value)
        {
            if (_root == null)
            {
                _root = new Node<T>(key, value);
                return;
            }

            Node<T> current = _root;
            Node<T> parent = null;

            Node<T> node = new Node<T>(key, value);


            while (current != null)
            {
                parent = current;

                if (current.Key.CompareTo(node.Key) == 0)
                {
                    current.Data = node.Data;
                }

                if (key.CompareTo(current.Key) < 0)
                {
                    current = current.Left;
                }
                else if (key.CompareTo(current.Key) > 0)
                {
                    current = current.Right;
                }
                else 
                {
                    return;
                }
            }

            if (key.CompareTo(parent.Key) < 0)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }
 

            Node<T> temp = node;
            while (temp != null)
            {
                UpdateHeight(temp);
                temp = temp == _root ? null : FindParent(temp);
                Balance(temp);
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

            while (current != null && value.CompareTo(current.Key) != 0)
            {
                parent = current;

                if (value.CompareTo(current.Key) < 0)
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

            if (current != null)
            {
                Node<T> temp = current;
                while (temp != null)
                {
                    UpdateHeight(temp);
                    temp = temp == _root ? null : FindParent(temp);
                    Balance(temp);
                }
            }
        }

        public string GetValue(T value)
        {
            Node<T> node = _root;

            while (node != null)
            {
                if (value.CompareTo(node.Key) == 0)
                {
                    return node.Data.ToString(); 
                }
                else if (value.CompareTo(node.Key) < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return ""; 
        }

        public void Check(T value)
        {
            Node<T> node = _root;

            do
            {
                if (value.CompareTo(node.Key) == 0)
                {
                    Console.WriteLine("Заданный ключ присутствует");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    if (value.CompareTo(node.Key) < 0)
                    {
                        node = node.Left;
                    }
                    else if (value.CompareTo(node.Key) > 0)
                    {
                        node = node.Right;
                    }
                }
                if (node == null)
                {
                    Console.WriteLine("Заданный ключ отсутствует");
                    Console.ReadKey();
                    return;
                }
            } while (node != null);
        }

    }
}
