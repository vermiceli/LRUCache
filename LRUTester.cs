// <copyright file="LRUTester.cs" company="Michael Miceli">
// Copyright Michael Miceli.  All rights are reserved.
// </copyright>

namespace Cache
{
    using System;

    /// <summary>
    /// A class that contains the main entry point into the program
    /// </summary>
    public static class LRUTester
    {
        /// <summary>
        /// A simple tester to see if the LRU cache is working correctly
        /// </summary>
        public static void Main()
        {
            LRUCache<int> intCache = new LRUCache<int>() { 1, 2, 3, 4 };
            intCache.Add(5);
            intCache.Remove(2);
            intCache.Add(6);
            Console.WriteLine(intCache);
            Console.ReadLine();
        }
    }
}
