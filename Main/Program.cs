using System;
using AlgorithmsDataStructures;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable(17, 3);
            Console.WriteLine(table.HashFun("0123456789"));
            Console.WriteLine(table.HashFun("abcdefgh"));
        }
    }
}
