using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        private LinkedList<T> data;
        public Stack()
        {
            data = new LinkedList<T>();
        }

        public int Size()
        {
            return data.Count;
        }

        public T Pop()
        {
            if (data.Count == 0) { return default(T); }
            var item = data.First.Value;
            data.RemoveFirst();
            return item;
        }

        public void Push(T item)
        {
            data.AddFirst(item);
        }

        public T Peek()
        {
            if (data.Count == 0) { return default(T); }
            return data.First.Value;
        }
    }

    public class Analyzer
    {
        public static bool IsBalanced(String str, Char open_sym, Char close_sym)
        {
            var stack = new Stack<Char>();
            foreach (var el in str)
            {
                if (el == open_sym)
                {
                    stack.Push(el);
                }
                else if (el == close_sym)
                {
                    if (stack.Peek() != open_sym) { return false; }
                    stack.Pop();
                }
            }
            if (stack.Size() == 0) { return true; }
            return false;
        }

        public static bool IsBalanced(String str) => IsBalanced(str, '(', ')');

    }

}