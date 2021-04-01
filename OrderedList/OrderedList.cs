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

        public OrderedList(bool ascending)
        {
            head = null;
            tail = null;
            _ascending = ascending;
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

            if (!_ascending)
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
            var insert_node = new Node<T>(value);
            InsertAfter(FindPlace(value), insert_node);
        }

        private Node<T> FindPlace(T value) {
            var node = head;
            while (node != null)
            {
                if (Compare(node.value, value) >= 0) {
                    return node.prev;
                }
                node = node.next;
            }
            return tail;
        }

        
        private void InsertAfter(Node<T> _nodeAfter, Node<T> _nodeToInsert)
        {
            if (_nodeAfter == null)
            {
                _nodeToInsert.prev = null;
                _nodeToInsert.next = head;
                if (head != null)
                {
                    head.prev = _nodeToInsert;
                }
                else {
                    tail = _nodeToInsert; 
                }
                head = _nodeToInsert;
                return;
            }
            _nodeToInsert.prev = _nodeAfter;
            _nodeToInsert.next = _nodeAfter.next;
            if (_nodeAfter.next != null) {
                _nodeAfter.next.prev = _nodeToInsert;    
            } else {
                tail = _nodeToInsert;
            }
            _nodeAfter.next = _nodeToInsert;
            
        }

        public Node<T> Find(T value)
        {
            var node = head;
            while (node != null)
            {
                if (Compare(node.value, value) == 0) {
                    return node;
                }
                node = node.next;
            }
            return null;
        }

        public void Delete(T value)
        {
            var node = Find(value);
            if (node == null) { return; }

            if (node == head)
            {
                if (node.next != null)
                {
                    node.next.prev = null;
                }
                head = node.next;
            }
            if (node == tail)
            {
                if (node.prev != null)
                {
                    node.prev.next = null;
                }
                tail = node.prev;
            }
            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
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
            var node = head;
            while (node != null)
            {
                count += 1;
                node = node.next;
            }
            return count;
        }

        public List<Node<T>> GetAll()
        {
            var all = new List<Node<T>>();
            var node = head;
            while (node != null)
            {
                all.Add(node);
                node = node.next;
            }
            return all;
        }


    }

}