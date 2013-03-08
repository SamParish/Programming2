using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    class LinkedQueue<T> : IEnumerable<T>
    {
        Node<T> _front;

        public Node<T> Front
        {
            get { return _front; }
            set { _front = value; }
        }

        // Allows access to each node via its index. 
        public T this[int index]
        {
            get
            {
                Node<T> currentNode = Front;

                int count = 0;
                while (count < index && currentNode.Next != null)
                {
                    count++;
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    throw new Exception("The index is outside the range of the list");
                }
                else
                {
                    return currentNode.Value;
                }
            }
            set
            {
                Node<T> currentNode = Front;

                int count = 0;
                while (count < index && currentNode.Next != null)
                {
                    count++;
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    throw new Exception("The index is outside the range of the list");
                }
                else
                {
                    currentNode.Value = value;
                }
            }
        }

        // Returns true if the Queue is empty.
        public bool IsEmpty()
        {
            return Front == null;
        }

        // Returns the number of nodes in the queue.
        public int Count()
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

            if (IsEmpty())
            {
                throw new NullReferenceException("You cannot Dequeue an empty Queue. Please Enqueue data first.");
            }
            else
            {
                Node<T> tempNode = Front;
                Front = Front.Next;
                return tempNode.Value;
            }
        }

        // Returns the data at the front of the queue. Does not remove it.
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("You cannot peek at an empty Queue. Please enqueue data first.");
            }
            else
            { 
                return Front.Value;
            }

        }

        //
        // Methods to enable foreach loops.
        //

        // Counts through the data values starting at the head.
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count(); i++)
            {
                yield return this[i];
            }
        }

        // Does other stuff?
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
