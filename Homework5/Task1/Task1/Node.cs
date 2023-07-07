using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Node
    {
        public int Data;
        public Node Next;

        public Node(int data) 
        {
            Data = data;
            Next = null;
        }
    }
}
