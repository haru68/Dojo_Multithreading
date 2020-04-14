using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace Dojo_Multithreading
{
    /*class Program
    {
        static void Main(string[] args)
        {
            List<Thread> myThreads = new List<Thread>();
            ThreadStart threadStart = new ThreadStart(StartThreads);

            for (int i = 0; i < 6; i++)
            {
                Thread myThread = new Thread(threadStart);
                myThreads.Add(myThread);
            }

            foreach (Thread thread in myThreads)
            {
                thread.Start();
            }

            foreach (Thread thread in myThreads)
            {
                thread.Join();
            }

            Console.WriteLine("All threads completed bitch");
        }

        private static void StartThreads()
        {
            int timeSleep = new Random().Next(500, 6000);
            Thread.Sleep(timeSleep);
            Console.WriteLine("Thread number {0} has taken {1} milliseconds to complete", Thread.CurrentThread.ManagedThreadId, timeSleep);
        }
    }*/

    /*class Program
    {
        private CountdownEvent _countdown;
        public ConcurrentQueue<int> Integers = new ConcurrentQueue<int>();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.QueuePopulator();

        }

        public void QueuePopulator()
        {
            _countdown = new CountdownEvent(5);
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    for (int i = 1; i <= 200000; i++)
                    {
                        Integers.Enqueue(3);
                    }
                    _countdown.Signal();
                });
            }
            _countdown.Wait();

            Console.WriteLine(Integers.Count);
        }
    }*/

    class Program
    {

        private CountdownEvent _countdown;
        public ConcurrentQueue<int> Integers = new ConcurrentQueue<int>();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.QueuePopulator();
            program.Run();
        }

        private void Run()
        {
            var threadStart = new ThreadStart(StartThreads);
            Thread myThread = new Thread(threadStart);
            myThread.Start();
        }

        private void StartThreads()
        {
            var sumArray = Integers.ToArray().Sum();
            Console.WriteLine("Sum: "+sumArray);           
        }

        public void QueuePopulator()
        {
            
            _countdown = new CountdownEvent(5);
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                {
                    for (int i = 1; i <= 200000; i++)
                    {
                        Integers.Enqueue(3);
                    }
                    _countdown.Signal();
                   
                });
                
            }
            _countdown.Wait();

            Console.WriteLine(Integers.Count);
        }

      
    }

}
