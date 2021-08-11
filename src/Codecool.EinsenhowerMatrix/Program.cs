using System;
using System.Collections.Generic;
using System.Text;

namespace Codecool.EinsenhowerMatrix
{
    /// <summary>
    /// Entry point for app
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry method for app
        /// </summary>
        /// <param name="args">command line args</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to the Eisenhower Task Manager!");
            new EisenhowerMain().Run();
            Console.WriteLine("\nThank you for using the Eisenhower Task Manager!");
        }
    }
}
