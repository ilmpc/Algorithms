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

        public int Size() => data.Count;

        public void Rotate(int times)
        {
            times = times % this.Size();
            for (int i = 0; i < times; i++)
            {
                var node = data.First;
                data.RemoveFirst();
                data.AddLast(node);
            }
        }

        public override String ToString()
        {
            var str = new System.Text.StringBuilder();
            foreach (var item in data)
            {
                str.Append($"{item} <- ");
            }
            return str.ToString();
        }
        public T[] ToArray() 
        {
            var arr = new T[data.Count];
            data.CopyTo(arr, 0);
            return arr;
        }

    }
}
