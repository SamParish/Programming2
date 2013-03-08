using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise2._1
{
    class ArrayQueue<T>
    {
        T[] _objArray;

        internal T[] ObjArray
        {
            get { return _objArray; }
            set { _objArray = value; }
        }

        public ArrayQueue()
        {
            ObjArray = new T[0];
        }

        // Returns true if the count of the array is 0.
        public bool IsEmpty()
        {
            if (ObjArray.Count() == 0)
            {
                return true;
            }
            return false;
        }

        // Adds a new piece of data to the array.
        public void Enqueue(T newObj)
        {
            int orgCount = ObjArray.Count();
            // Create a new Array of nodea that is one bigger than the previous array to hold the 
            T[] newArray = new T[orgCount + 1];

            // Adds all the exisiting data to the new Node
            int i = 0;
            foreach (T obj in ObjArray)
            {
                newArray[i] = obj;
                i++;
            }

            newArray[orgCount] = newObj;

            ObjArray = newArray;
        }

        // Removes the first object in the queue and returns it.
        public T Dequeue()
        {
            // Save data from before we do anything
            int orgCount = ObjArray.Count();
            T data = ObjArray[0];

            //Create a new array one smaller than the previous array was.
            T[] newArray = new T[orgCount - 1];

            //Populate the new array with the data from the old array skipping the first piece of data.
            int i = 0;
            while( i < orgCount-1)
            {
                newArray[i] = ObjArray[i+1];
                i++;
            }
            // Delete the old array and save the new one.
            ObjArray = newArray;

            // Return the first data from the original array. 
            return data;
        }

        // Returns the first object in the queue.
        public T Peek()
        {
            return ObjArray[0];
        }
    }
}
