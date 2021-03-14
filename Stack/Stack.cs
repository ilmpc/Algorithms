using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private List<T> data;
        public Stack()
        {
            data = new List<T>();
        }

        public int Size()
        {
            return data.Count;
        }

        public T Pop()
        {
            if (data.Count == 0) { return default(T); }
            var last = data.Count - 1;
            var item = data[last];
            data.RemoveAt(last);
            return item;
        }

        public void Push(T item)
        {
            data.Add(item);
        }

        public T Peek()
        {
            if (data.Count == 0) { return default(T); }
            var last = data.Count - 1;
            var item = data[last];
            return item;
        }
    }

}