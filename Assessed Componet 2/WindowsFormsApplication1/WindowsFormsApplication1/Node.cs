using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Node<T>
    {
        T _value;
        Node<T> _next;          

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }

    }
}
