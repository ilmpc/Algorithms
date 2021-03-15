using System;
using Xunit;

using AlgorithmsDataStructures;

namespace Queue.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Empty()
        {
            var q = new Queue<int>();
            q.Enqueue(5);
            Assert.Equal(5, q.Dequeue());
        }
    }
}
