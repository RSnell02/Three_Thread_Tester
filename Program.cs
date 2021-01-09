/*
 * Project: ThreeThreadTester
 * Filename: Program.cs
 * Author: R. Snell
 * Date: Jan. 09, 2021
 * Purpose: To demonstrate the use and functioning of threads and the basic concepts of threading.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreeThreadTester
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create three new threads and name them.
            // The first thread.
            MessagePrinter printer1 = new MessagePrinter();    // Creates a MessagePrinter object
            // The Print method of the MessagePrint class passed as a delegate to ThreadStart
            // Create and initialize the thread
            Thread thread1 = new Thread(new ThreadStart(printer1.Print));
            // Name the thread
            thread1.Name = "Thread1";

            // The second thread.
            MessagePrinter printer2 = new MessagePrinter();    // Creates a MessagePrinter object
            // The Print method of MessagePrint class passed as a delegate to ThreadStart
            // Create and initialize the thread
            Thread thread2 = new Thread(new ThreadStart(printer2.Print));
            // Name the thread
            thread2.Name = "Thread2";

            // THe third thread
            MessagePrinter printer3 = new MessagePrinter(); // Creates a MessagePrinter object
            // The Print method of MessagePrint class passed as a delegate to ThreadStart
            // Create and initialize the thread
            Thread thread3 = new Thread(new ThreadStart(printer3.Print));
            // Name the thread
            thread3.Name = "Thread3";

            //Console.WriteLine("Starting threads");

            // Call each thread's Start method to place each thread in the running state
            thread1.Start();    // Start thread1
            thread2.Start();    // Start thread2
            thread3.Start();    // Start thread3

            Console.WriteLine("Threads started\n");
        }   // end Main90
    }   // end class Program

    // The MessagePrinter class
    class MessagePrinter
    {
        private int sleepTime;  // Random sleep time for threads
        private static Random random = new Random();

        // constructor
        public MessagePrinter()
        {
            // Pick a random time between 0 and 5 seconds
            sleepTime = random.Next(5001);  // 5001 milliseconds
        }   // end constructor

        // Method Print() controls thread that prints message
        public void Print()
        {
            // Obtain reference to currently executing thread
            Thread current = Thread.CurrentThread;
            // Put thread to sleep for sleepTime of time and print name of the thread
            Console.WriteLine($"{current.Name} going to sleep for {sleepTime} milliseconds.");
            Thread.Sleep(sleepTime);
            //  Print thread name when sleeping
            Console.WriteLine($"{current.Name} done sleeping.");
        }
    }   // end class MessagePrinter
}   // end namespace
