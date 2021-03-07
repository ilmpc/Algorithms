using System;
using Xunit;

using AlgorithmsDataStructures;

namespace DoubleLinkedList.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EmptyTest()
        {
            var list = new LinkedList2();
            Assert.Equal(0, list.Count());
            Assert.Null(list.head);
            Assert.Null(list.tail);
            Assert.Null(list.Find(0));
            Assert.Empty(list.FindAll(0));
            Assert.False(list.Remove(0));
            list.RemoveAll(0);
        }
        [Fact]
        public void AddRemoveEmptyTest()
        {
            var list = new LinkedList2();
            list.AddInTail(new Node(0));
            list.Remove(0);

            Assert.Equal(0, list.Count());
            Assert.Null(list.head);
            Assert.Null(list.tail);
            Assert.Null(list.Find(0));
            Assert.Empty(list.FindAll(0));
            Assert.False(list.Remove(0));
            list.RemoveAll(0);
        }

        [Fact]
        public void Add2RemoveAllEmptyTest()
        {
            var list = new LinkedList2();
            list.AddInTail(new Node(0));
            list.AddInTail(new Node(0));
            list.RemoveAll(0);

            Assert.Equal(0, list.Count());
            Assert.Null(list.head);
            Assert.Null(list.tail);
            Assert.Null(list.Find(0));
            Assert.Empty(list.FindAll(0));
            Assert.False(list.Remove(0));
            list.RemoveAll(0);
        }

        [Fact]
        public void Add1Find1Test()
        {
            var list = new LinkedList2();
            var node = new Node(0);
            list.AddInTail(node);

            Assert.Equal(1, list.Count());
            Assert.Same(node, list.head);
            Assert.Same(node, list.tail);
            Assert.Same(node, list.Find(0));
            Assert.Single(list.FindAll(0));
            Assert.Same(node, list.FindAll(0)[0]);
            Assert.True(list.Remove(0));
        }

        [Fact]
        public void AddLeftRemoveEmptyTest()
        {
            var list = new LinkedList2();
            list.InsertAfter(null, new Node(0));
            list.Remove(0);

            Assert.Equal(0, list.Count());
            Assert.Null(list.head);
            Assert.Null(list.tail);
            Assert.Null(list.Find(0));
            Assert.Empty(list.FindAll(0));
            Assert.False(list.Remove(0));
            list.RemoveAll(0);
        }
        
        [Fact]
        public void AddLeftManyRemoveEmptyTest()
        {
            var list = new LinkedList2();
            for (int i = 0; i < 10; i++)
            {
                list.InsertAfter(null, new Node(0));
            }
            list.RemoveAll(0);

            Assert.Equal(0, list.Count());
            Assert.Null(list.head);
            Assert.Null(list.tail);
            Assert.Null(list.Find(0));
            Assert.Empty(list.FindAll(0));
            Assert.False(list.Remove(0));
            list.RemoveAll(0);
        }

        [Fact]
        public void AddLeftCountTest()
        {
            var list = new LinkedList2();
            for (int i = 0; i < 10; i++)
            {
                list.InsertAfter(null, new Node(0));
            }
            Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            Assert.NotSame(list.head, list.tail);
            Assert.Equal(10, list.Count());
            Assert.Equal(10, list.FindAll(0).Count);
        }

        [Fact]
        public void AddLeftAddAfterItTest()
        {
            var node = new Node(0);
            var node1 = new Node(1);
            var list = new LinkedList2();
            list.InsertAfter(null, node);
            list.InsertAfter(node, node1);
            
            Assert.Same(node, list.head);
            Assert.Same(node1, list.tail);
            Assert.Equal(2, list.Count());
            Assert.Same(node, list.Find(0));
            Assert.Same(node1, list.Find(1));
        }
    }
}
