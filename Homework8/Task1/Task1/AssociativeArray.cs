using System;

namespace Task1
{
    public class AssociativeArray<KeyType, DataType> where KeyType : IComparable<KeyType>
    {
        private class Node
        {
            public KeyType Key { get; set; }
            public DataType Data { get; set; }
            public int Height { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(KeyType key, DataType data)
            {
                Key = key;
                Data = data;
                Height = 0;
                Left = null;
                Right = null;
            }
        }

        private Node _root;

        public AssociativeArray()
        {
            _root = null;
        }

        private int GetHeight(Node node)
        {
            return node == null ? -1 : node.Height;
        }

        private void UpdateHeight(Node node)
        {
            if (GetHeight(node.Left) >= GetHeight(node.Right))
            {
                node.Height = GetHeight(node.Left) + 1;
            }
            else
            {
                node.Height = GetHeight(node.Right) + 1;
            }
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : GetHeight(node.Right) - GetHeight(node.Left);
        }

        private void Swap(Node a, Node b)
        {
            KeyType aKey = a.Key;
            a.Key = b.Key;
            b.Key = aKey;

            DataType aData = a.Data;
            a.Data = b.Data;
            b.Data = aData;
        }

        private void RightRotate(Node node)
        {
            Swap(node, node.Left);
            Node buffer = node.Right;
            node.Right = node.Left;
            node.Left = node.Right.Left;
            node.Right.Left = node.Right.Right;
            node.Right.Right = buffer;
            UpdateHeight(node.Right);
            UpdateHeight(node);
        }

        private void LeftRotate(Node node)
        {
            Swap(node, node.Right);
            Node buffer = node.Left;
            node.Left = node.Right;
            node.Right = node.Left.Right;
            node.Left.Right = node.Left.Left;
            node.Left.Left = buffer;
            UpdateHeight(node.Left);
            UpdateHeight(node);
        }

        private void Balance(Node node)
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

        private Node FindParent(Node node)
        {
            Node current = _root;
            Node parent = null;

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

        public void Add(KeyType key, DataType value)
        {
            {
                if (_root == null)
                {
                    _root = new Node(key, value);
                    return;
                }

                Node current = _root;
                Node parent = null;

                Node node = new Node(key, value);


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


                Node temp = node;
                while (temp != null)
                {
                    UpdateHeight(temp);
                    temp = temp == _root ? null : FindParent(temp);
                    Balance(temp);
                }
            }
        }

        public void Delete (KeyType key)
        {
            if (_root == null)
            {
                Console.WriteLine("Пустое бинарное дерево!");
                Console.ReadKey();
                return;
            }

            Node current = _root;
            Node parent = null;

            while (current != null && key.CompareTo(current.Key) != 0)
            {
                parent = current;

                if (key.CompareTo(current.Key) < 0)
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
                Node currentParent = current;
                Node currentRightChild = current.Right;

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

          
            Node temp = current;
            while (temp != null)
            {
                UpdateHeight(temp);
                temp = temp == _root ? null : FindParent(temp);
                Balance(temp);
            }
        }

        public string GetValue(KeyType key)
        {
            Node node = _root;

            while (node != null)
            {
                if (key.CompareTo(node.Key) == 0)
                {
                    return node.Data.ToString(); 
                }
                else if (key.CompareTo(node.Key) < 0)
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

        public bool Check(KeyType key)
        {
            Node node = _root;

            bool isExist = false;

            do
            {
                if (node == null)
                {
                    Console.WriteLine("Заданный ключ отсутствует");
                }
                else if (key.CompareTo(node.Key) == 0)
                {
                    Console.WriteLine("Заданный ключ присутствует");
                    isExist = true;
                    return isExist;
                }
                else
                {
                    if (key.CompareTo(node.Key) < 0)
                    {
                        node = node.Left;
                    }
                    else if (key.CompareTo(node.Key) > 0)
                    {
                        node = node.Right;
                    }
                }
            } while (node != null);

            return isExist;
        }
    }
}
