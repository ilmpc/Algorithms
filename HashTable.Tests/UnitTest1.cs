using System;
using Xunit;

namespace AlgorithmsDataStructures
{
    public class UnitTest1
    {
        [Fact]
        public void GoodUsage()
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


        [Fact]
        public void FullTable()
        {
            var table = new HashTable(5, 1);
            var elements = new string[] { "qwe", "ewe", "asdbrt", "qwe", "bsfqwasdfbna;sjjdsadsa"};
            foreach (string s in elements)
            {
                table.Put(s);
            }
            foreach (string s in elements)
            {
                Assert.NotEqual(-1, table.Find(s));
            }
            Assert.Equal(-1, table.SeekSlot("q"));
        }

        [Fact]
        public void SeekSlotOnFirstAttempt()
        {
            var table = new HashTable(17, 2);
            Assert.Equal(table.HashFun("q"), table.SeekSlot("q"));
        }

        [Fact]
        public void SeekInZeroSizeTable()
        {
            var table = new HashTable(0, 2);
            Assert.Equal(-1, table.SeekSlot("q"));
        }
        
        [Fact]
        public void Collisions()
        {
            var table = new HashTable(5, 3);
            var elements = new string[] { "qwe", "qwe", "qwe" };
            foreach (string s in elements)
            {
                table.Put(s);
            }
            foreach (string s in new []{"qwe", "gr"})
            {
                Assert.NotEqual(-1, table.SeekSlot(s));
            }
        }
        
        [Fact]
        public void FindInEmptyTable()
        {
            var table = new HashTable(5, 3);
            Assert.Equal(-1, table.Find("q"));
            table = new HashTable(0, 1);
            Assert.Equal(-1, table.Find("q"));
        }
        
        [Fact]
        public void SeekInEmptyTable()
        {
            var table = new HashTable(5, 3);
            table.SeekSlot("q");
            Assert.Equal(0, table.SeekSlot(""));
            Assert.Equal(0, table.SeekSlot(null));
            table.HashFun("0123456789");
        }

    }
}
