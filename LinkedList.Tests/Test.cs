using System;
using Xunit;
using Xunit.Abstractions;

namespace AlgorithmsDataStructures.Tests
{
    public class SimpleTests
    {
        private readonly ITestOutputHelper output;

        public SimpleTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        public static string NodeToString(LinkedList t)
        {
            Node node = t.head;
            var text = new System.Text.StringBuilder();
            var counter = 0;
            text.Append($"List:\nHead:{t.head?.value}\nTail:{t.tail?.value}\n");
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
            Assert.Empty(t.FindAll(1));
            Assert.Null(t.Find(2));
            Assert.Equal(0, t.Count());
            NodeToString(t);
        }
        [Fact]
        public void AddOne()
        {
            var t = new LinkedList();
            var node = new Node(1);
            t.AddInTail(node);
            Assert.Equal(node, t.head);
            Assert.Equal(node, t.tail);
            Assert.Equal(1, t.Count());
            Assert.Equal(node, t.Find(1));
            Assert.Equal(node, t.FindAll(1)[0]);
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
            Assert.Equal(0, t.Count());
            Assert.Null(t.Find(1));
            Assert.Empty(t.FindAll(1));
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
            Assert.Equal(0, t.Count());
            Assert.Null(t.Find(1));
            Assert.Equal(0, t.FindAll(1).Count);
        }

        [Fact]
        public void AddALot()
        {
            var t = new LinkedList();
            for (int i = 0; i < 20; i++)
            {
                t.AddInTail(new Node(i));
            }
            Assert.Equal(20, t.Count());
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
        public void AddALotSameInFront()
        {
            var t = new LinkedList();
            for (int i = 0; i < 20; i++)
            {
                t.InsertAfter(null, new Node(5));
            }
            t.RemoveAll(5);
            //System.Console.WriteLine(t);
            Assert.Equal(0, t.Count());
            Assert.Null(t.head);
            Assert.Null(t.tail);
        }

        [Fact]
        public void AddALotSameInFrontRemoveByOne()
        {
            var t = new LinkedList();
            for (int i = 0; i < 20; i++)
            {
                t.InsertAfter(null, new Node(5));
            }
            for (int i = 0; i < 19; i++)
            {
                t.Remove(5);
            }
            output.WriteLine(NodeToString(t));
            Assert.Equal(5, t.Find(5).value);
            Assert.Equal(1, t.Count());
            Assert.NotNull(t.head);
            Assert.NotNull(t.tail);
            Assert.Equal(5, t.head.value);
            Assert.Equal(5, t.tail.value);
            Assert.Equal(t.tail, t.head);
            t.Remove(5);
            output.WriteLine(NodeToString(t));
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

    public class PerMethodTest
    {
        [Fact]
        public void FindAllTest()
        {
            var t = new LinkedList();

            Assert.Empty(t.FindAll(1));
            var node_1 = new Node(1);
            t.AddInTail(node_1);
            Assert.Single(t.FindAll(1));
            Assert.Equal(node_1, t.FindAll(1)[0]);

            for (int i = 0; i < 10; i++)
            {
                t.AddInTail(new Node(1));
            }
            Assert.Equal(11, t.FindAll(1).Count);

            t.InsertAfter(null, new Node(5));
            Assert.Equal(11, t.FindAll(1).Count);

            t.Remove(1);
            Assert.Equal(10, t.FindAll(1).Count);
        }

        [Fact]
        public void RemoveTest()
        {
            var t = new LinkedList();

            t.AddInTail(new Node(1));
            t.Remove(1);
            Assert.Equal(0, t.Count());
            Assert.Equal(0, t.FindAll(1).Count);
            Assert.Null(t.head);
            Assert.Null(t.tail);

            t.AddInTail(new Node(2));
            var second_node = new Node(2);
            t.AddInTail(second_node);

            t.Remove(2);
            Assert.Equal(1, t.Count());
            Assert.Equal(1, t.FindAll(2).Count);
            Assert.Equal(second_node, t.head);
            Assert.Equal(second_node, t.tail);

            t.Remove(2);
            Assert.Equal(0, t.Count());
            Assert.Equal(0, t.FindAll(2).Count);
            Assert.Null(t.head);
            Assert.Null(t.tail);

            t.AddInTail(new Node(1));
            t.AddInTail(second_node);

            t.Remove(1);
            Assert.Equal(1, t.Count());
            Assert.Equal(1, t.FindAll(2).Count);
            Assert.Equal(second_node, t.head);
            Assert.Equal(second_node, t.tail);

            t.Remove(2);
            Assert.Equal(0, t.Count());
            Assert.Equal(0, t.FindAll(2).Count);
            Assert.Null(t.head);
            Assert.Null(t.tail);

            var first_node = new Node(1);
            t.AddInTail(first_node);
            t.AddInTail(second_node);

            t.Remove(2);
            Assert.Equal(1, t.Count());
            Assert.Equal(1, t.FindAll(1).Count);
            Assert.Equal(first_node, t.head);
            Assert.Equal(first_node, t.tail);



        }
    }
}
