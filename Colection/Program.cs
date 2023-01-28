﻿using Collections;

namespace Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var collection = new Collection<int>();
            Console.WriteLine("Current collection: " + collection);

            Console.WriteLine("Collection count: " + collection.Count);
            Console.WriteLine("collection capacity: "  + collection.Capacity);

            collection.Add(5);
            Console.WriteLine("Current collection: " + collection);

            collection.AddRange(6,7);

            Console.WriteLine("Current collectio: " + collection);

            Console.WriteLine("Print the first element: " + collection[0]);

            collection[0] = 55;

            Console.WriteLine();
            Console.WriteLine("Print the first element: " + collection[0]);

            collection.InsertAt(2, 666);
            Console.WriteLine("Current collectio: " + collection);


            collection.Exchange(1, 2);
            Console.WriteLine("Current collectio: " + collection);

            collection.Clear();
            Console.WriteLine("Current collectio: " + collection);


        }
    }
}