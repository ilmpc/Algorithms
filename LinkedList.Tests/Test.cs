using System;
using Xunit;

namespace AlgorithmsDataStructures.Tests
{
    public class SimpleTests
    {
        public static string NodeToString(LinkedList t)
        {
            Node node = t.head;
            var text = new System.Text.StringBuilder();
            var counter = 0;
            text.Append($"List:\nHead:{t.head!.value}\nTail:{t.tail!.value}\n");
            while (node != null)
            {
                counter++;
                text.Append($"{counter} - {node.value}\n");         
                node = node.next;
            }
            text.Append($"End. {counter} elements in list.");
            return text.ToString();
        }
        [Fact]
        public void Create()
        {
            var t = new LinkedList();
            Assert.NotNull(t);
            Assert.Null(t.head);
            Assert.Null(t.tail);
            Assert.False(t.Remove(1));
            Assert.Equal(t.FindAll(1).Count, 0);
            Assert.Null(t.Find(2));
            Assert.Equal(t.Count(), 0);
        }
        [Fact]
        public void AddOne()
        {
            var t = new LinkedList();
            var node = new Node(1);
            t.AddInTail(node);
            Assert.Equal(t.head, node);
            Assert.Equal(t.tail, node);
            Assert.Equal(t.Count(), 1);
            Assert.Equal(t.Find(1), node);
            Assert.Equal(t.FindAll(1)[0], node);
        }
        
        [Fact]
        public void RemoveOne()
        {
            var t = new LinkedList();
            var node = new Node(1);
            t.AddInTail(node);
            t.Remove(1);
            Assert.Null(t.head);
            Assert.Null(t.tail);
            Assert.Equal(t.Count(), 0);
            Assert.Null(t.Find(1));
            Assert.Equal(t.FindAll(1).Count, 0);
        }
        
        [Fact]
        public void RemoveTwo()
        {
            var t = new LinkedList();
            var node = new Node(1);
            t.AddInTail(node);
            t.InsertAfter(null, new Node(2));
            t.Remove(1);
            t.Remove(2);
            Assert.Null(t.head);
            Assert.Null(t.tail);
            Assert.Equal(t.Count(), 0);
            Assert.Null(t.Find(1));
            Assert.Equal(t.FindAll(1).Count, 0);
        }

        [Fact]
        public void AddALot()
        {
            var t = new LinkedList();
            for (int i = 0; i < 20; i++)
            {
                t.AddInTail(new Node(i));
            }
            Assert.Equal(t.Count(), 20);
        }

        [Fact]
        public void AddALotSame()
        {
            var t = new LinkedList();
            for (int i = 0; i < 20; i++)
            {
                t.AddInTail(new Node(5));
            }
            t.RemoveAll(5);
            //System.Console.WriteLine(t);
            Assert.Equal(0, t.Count());
            Assert.Null(t.head);
            Assert.Null(t.tail);
        }
        [Fact]
        public void PrintList()
        {
            var t = new LinkedList();
            t.AddInTail(new Node(34));
            t.AddInTail(new Node(17));
            t.Remove(34);
            //System.Console.Write(t);
        }
        
    }
}
