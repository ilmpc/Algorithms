using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
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
                if (node.value == _value) nodes.Add(node);
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            if (head == null) return false;

            Node prev_node = null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    if (node == tail)
                    {
                        tail = prev_node;
                    }
                    if (prev_node == null)
                    {
                        head = node.next;
                    }
                    else
                    {
                        prev_node.next = node.next;
                    }
                    return true;
                }
                prev_node = node;
                node = node.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            while (this.Remove(_value)){}
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
            Node node;
            if (_nodeAfter == null)
            {
                node = head;
                head = _nodeToInsert;
            }
            else
            {
                node = _nodeAfter.next;
                _nodeAfter.next = _nodeToInsert;
            }
            if (_nodeAfter == tail){
                tail = _nodeToInsert;
            }
            _nodeToInsert.next = node;
        }
    }
}