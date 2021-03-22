using System;
using Xunit;
using AlgorithmsDataStructures;

namespace AlgorithmsDataStructures
{
    public class UnitTest1
    {
        [Fact]
        public void SimpleTest()
        {
            var deq = new Deque<int>();
            deq.AddFront(12);
            Assert.Equal(1, deq.Size());
            deq.AddTail(21);
            Assert.Equal(2, deq.Size());
            Assert.Equal(12, deq.RemoveFront());
            Assert.Equal(21, deq.RemoveFront());
            Assert.Equal(0, deq.Size());
            Assert.Null(deq.RemoveFront());
        }
        
        [Fact]
        public void PalindTest()
        {
            Assert.True(Utils.IsPalindrome("qwertyytrewq"));
            Assert.True(Utils.IsPalindrome("qwerty1ytrewq"));
            Assert.False(Utils.IsPalindrome("qwertgytrewq"));
        }
    }
}
