using System;
using Module3HW1.Comparers;

namespace Module3HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.TestInts();
            Console.WriteLine(Environment.NewLine);
            program.TestStrings();
        }

        public void TestInts()
        {
            var comparer = new IntComparer();
            var collection = new Collection<int>();
            collection.Add(2);
            collection.Add(3);
            collection.Add(1);
            collection.Add(5);
            collection.Add(4);

            collection.Remove(5);
            collection.RemoveAt(0);
            collection.AddRange(new int[] { 9, 22, -3, 10 });
            collection.Sort(comparer);
            Console.WriteLine("Ints:");
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public void TestStrings()
        {
            var comparer = new Comparers.StringComparer();
            var coll = new Collection<string>();
            coll.Add("A");
            coll.Add("B");
            coll.Add("Y");
            coll.Add("I");
            coll.Add("Z");

            coll.Remove("1");
            coll.RemoveAt(3);
            coll.AddRange(new string[] { "Q", "M", "P" });
            coll.Sort(comparer);
            Console.WriteLine("Strings:");
            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }
        }
    }
}