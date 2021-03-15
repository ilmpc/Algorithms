using System;
using Xunit;
using AlgorithmsDataStructures;

namespace Stack.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Empty()
        {
            var stack = new Stack<int>();
            Assert.Equal(0, stack.Size());
            Assert.Equal(default(int), stack.Peek());
            Assert.Equal(default(int), stack.Pop());
        }

        [Fact]
        public void PushPeekPop()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            Assert.Equal(1, stack.Size());
            Assert.Equal(1, stack.Peek());
            Assert.Equal(1, stack.Size());
            
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Size());
            Assert.Equal(default(int), stack.Peek());
            Assert.Equal(default(int), stack.Pop());
        }
        [Fact]
        public void Push2PeekPopPop()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Size());
            Assert.Equal(2, stack.Peek());
            Assert.Equal(2, stack.Size());

            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Size());
            Assert.Equal(1, stack.Peek());
            Assert.Equal(1, stack.Size());

            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Size());
            Assert.Equal(default(int), stack.Peek());
            Assert.Equal(default(int), stack.Pop());
        }
        [Fact]
        public void BalancedString()
        {
            var s = "(()((())()))";
            Assert.True(Analyzer.IsBalanced(s));
        }
        [Fact]
        public void NotBalancedString()
        {
            // Lack of closing
            var s = "(()((())()";
            Assert.False(Analyzer.IsBalanced(s));
            // Excess closing
            s = "(()((()))))))()))";
            Assert.False(Analyzer.IsBalanced(s));
        }
        [Fact]
        public void BalancedStringCustomSymAndExtraText()
        {
            var s = @"using System; namespace Main {    class Program    {        static void Main(string[] args)        {            Console.WriteLine(""Hello World!"");        }    } }";
            Assert.True(Analyzer.IsBalanced(s, '{', '}'));
        }
    }
}
