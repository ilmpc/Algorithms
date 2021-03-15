using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Queue<T>
    {
        private LinkedList<T> data;
        public Queue()
        {
            data = new LinkedList<T>();
        }

        // O(1)
        public void Enqueue(T item)
        {
            data.AddLast(item);
        }

        // O(1)
        public T Dequeue()
        {
            if (data.Count == 0) { return default(T); }
            var item = data.First.Value;
            data.RemoveFirst();
            return item;
        }

        public int Size()
        {
            return data.Count;
        }

    }
}
