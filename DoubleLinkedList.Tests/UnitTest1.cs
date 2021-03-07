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
            Assert.Equal(node, list.head);
            Assert.Equal(node, list.tail);
            Assert.Equal(node, list.Find(0));
            Assert.Single(list.FindAll(0));
            Assert.Equal(node, list.FindAll(0)[0]);
            Assert.True(list.Remove(0));
        }
    }
}
