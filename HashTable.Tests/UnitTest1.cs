using System;
using Xunit;

namespace AlgorithmsDataStructures
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var table = new HashTable(19, 3);
            var elements = new string[] { "qwe", "ewe", "asdbrt", "qwe", "1213dasdas", "qwe", "qwdasdd" };
            foreach (string s in elements)
            {
                table.Put(s);
            }
            foreach (string s in elements)
            {
                Assert.NotEqual(-1, table.Find(s));
            }
        }
    }
}
