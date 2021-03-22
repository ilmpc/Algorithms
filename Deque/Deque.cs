using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Deque<T>
    {
        private LinkedList<T> data;

        public Deque() => data = new LinkedList<T>();

        public Deque(IEnumerable<T> e) => data = new LinkedList<T>(e);

        public void AddFront(T item) => data.AddFirst(item);

        public void AddTail(T item) => data.AddLast(item);

        public T RemoveFront()
        {
            if (this.Size() != 0) {
                var temp = data.First.Value;
                data.RemoveFirst();
                return temp;
            }
            return default(T);
        }

        public T RemoveTail()
        {
            if (this.Size() != 0) {
                var temp = data.Last.Value;
                data.RemoveLast();
                return temp;
            }
            return default(T);
        }

        public int Size() => data.Count;
    }

    public class Utils {
        public static bool IsPalindrome(String s)
        {
            var deq = new Deque<Char>(s);
            foreach (var ch in s)
            {
                if (ch != deq.RemoveTail())
                {
                    return false;
                }
            }
            return true;
        }
    }
}