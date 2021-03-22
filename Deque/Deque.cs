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
            var temp = data.First is null ? default(T) : data.First.Value;
            data.RemoveFirst();
            return temp;
        }

        public T RemoveTail()
        {
            var temp = data.Last is null ? default(T) : data.Last.Value;
            data.RemoveLast();
            return temp;
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