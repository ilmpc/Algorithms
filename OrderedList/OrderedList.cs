using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            var result = 0;
            if (v1 is string s1 && v2 is string s2)
            {
                result = Math.Sign(s1.Trim().CompareTo(s2.Trim()));
            }
            else if (v1 is IComparable c1 && v2 is IComparable c2)
            {
                result = Math.Sign(c1.CompareTo(c2));
            }

            if (_ascending)
            {
                result = -result;
            }
            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        public void Add(T value)
        {
            Node<T> node = head;
            do
            {
                if (this.Compare(node.value, value) <= 0)
                {
                    var current_node = new Node<T>(value);
                    Node<T> prev;
                    if (node == head) {
                        prev = null; //!
                    } else {
                        prev = node.prev;
                    }
                    prev.next = current_node;
                    node.prev = current_node;
                    current_node.prev = prev;
                    current_node.next = node; 
                }
                node = node?.next;
            } while (node != null);
        }

        public Node<T> Find(T val)
        {
            return null; // здесь будет ваш код
        }

        public void Delete(T val)
        {
            // здесь будет ваш код
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
        }

        public int Count()
        {
            var count = 0;
            Node<T> node = head;
            while (node != null)
            {
                count += 1;
                node = node.next;
            }
            return count;
        }

        List<Node<T>> GetAll()
        {
            var r = new List<Node<T>>();
            var node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}
