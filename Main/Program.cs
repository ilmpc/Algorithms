using System;

using AlgorithmsDataStructures;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList2();
            for (int i = 0; i < 10; i++)
            {
                list.InsertAfter(null, new Node(0));
            }
            /* Assert.NotNull(list.head);
            Assert.NotNull(list.tail);
            Assert.NotSame(list.head, list.tail);
            Assert.Equal(10, list.Count());
            Assert.Equal(10, list.FindAll(0).Count); */
        }
    }
}
