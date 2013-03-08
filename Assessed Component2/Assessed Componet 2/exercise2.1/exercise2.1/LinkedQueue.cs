using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise2._1
{
    class LinkedQueue<T>
    {
        Node<T> _front;

        public Node<T> Front
        {
            get { return _front; }
            set { _front = value; }
        }

        // Returns true if the Queue is empty.
        bool IsEmpty()
        {
            return Front == null;
        }

        // Returns the number of nodes in the queue.
        int Count()
        {
            int count = 0;
            Node<T> currentNode = Front;

            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.Next;
            }

            return count;
        }

        // Adds the incoming T instance to the end of the queue.
        public void Enqueue(T data)
        {
            Node<T> currentNode = Front;

            if (IsEmpty())
            {
                Front = new Node<T>(data);
            }
            else
            {
                // Step through the current node the number of times to get to the end of the 
                // queue, (use count method) set the next reference to the new obj.
                int count = Count(); 
                for (int i = 1; i < count; i++)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = new Node<T>(data);
            }
        }

        // Removes the front item from the queue and returns it.
        public T Dequeue()
        {
            Node<T> tempNode = Front;
            Front = Front.Next;
            return tempNode.Value;
        }

        // Returns the data at the front of the queue. Does not remove it.
        public T Peek()
        {
            return Front.Value;
        }
    }
}
