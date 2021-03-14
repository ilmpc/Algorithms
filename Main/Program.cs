using System;
using AlgorithmsDataStructures;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new DynArray<int>();
            for (int i = 0; i < 17; i++)
            {
                arr.Append(i);
            }
            arr.Remove(5);
            arr.Remove(0);

            for (int i = 0; i < 6; i++)
            {
                arr.Remove(arr.count - 1);
            }
        }
    }
}
