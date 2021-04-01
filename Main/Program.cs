using System;
using System.Collections.Generic;

using AlgorithmsDataStructures;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var list = new OrderedList<int>(true);
            var values = new List<int>{1, -10, 2};
            
            list.Add(1);
            list.Add(-10);
            list.Add(2);
            list.Delete(-10);
            list.Delete(1);
            list.Delete(2);
            list.GetAll().ForEach((node) => Console.WriteLine(node.value));
            values.Sort();
            values.ForEach(Console.WriteLine);
        }
    }
}
