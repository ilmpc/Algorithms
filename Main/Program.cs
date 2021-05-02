using System;
using System.Linq;
using AlgorithmsDataStructures;

namespace Main
{
    class Program
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, length).Select(_ => chars[random.Next(chars.Length)]).ToArray());
        }
        public static void Performance()
        {
            var set1 = new PowerSet<string>();
            var set2 = new PowerSet<string>();
            for (int i = 0; i < 5000; i++)
            {
                var data = RandomString(10);
                set1.Put(data);
                set2.Put(data);
            }
            for (int i = 0; i < 10000; i++)
            {
                var data = RandomString(12);
                set1.Put(data);
                data = RandomString(12);
                set2.Put(data);
            }
            Measure((n) => set1.Difference(set2));
            Measure((n) => set1.Union(set2));
            Measure((n) => set1.IsSubset(set2));
            Measure((n) => set1.Intersection(set2));
        }

        private static void Measure(Action<int> measurable)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            measurable(0);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            // new PowerSet<string>().HashFun("ZSGARTOAXS");
            Performance();
        }
    }
}
