using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    interface IQueue<T> : IEnumerable<T>
    {
        // Returns true if there are no objects in the queue.
        bool IsEmpty();

        // Adds a new object to the end of the queue.
        void Enqueue(T newObj);

        // Removes an object from the head of the queue, and returns it.
        T Dequeue();

        // Returns the head of the queue.
        T Peek();

        // Returns the number of objects in the queue.
        int Count();
    }
}
