using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    return node;
                }
                node = node.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            // The Elvis operator is missing here terribly, but it's appears only in C# 6 :c
            if (head == null) return false;

            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
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
                    return true;
                }
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            while (this.Remove(_value)) { }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            var counter = 0;
            Node node = head;
            while (node != null)
            {
                counter++;
                node = node.next;
            }
            return counter;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
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

    }
}