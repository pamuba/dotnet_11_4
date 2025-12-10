//var books = new List<Book.Book>
//        {
//            new Book.Book("The Catcher in the Rye", "J.D. Salinger"),
//            new Book.Book("To Kill a Mockingbird", "Harper Lee"),
//            new Book.Book("1984", "George Orwell"),
//            new Book.Book("The Great Gatsby", "F. Scott Fitzgerald"),
//            new Book.Book("1984", "Thomas Pynchon")
//        };
//books.Sort(new BookComparer.BookComparer());
//Console.WriteLine("Books sorted by title and author:");
//foreach (var book in books)
//{
//    Console.WriteLine($"{book.Title} by {book.Author}");
//}



using System.Diagnostics;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("C# For Loop");
//        int number = 10;
//        for (int count = 0; count < number; count++)
//        {
//            //Thread.CurrentThread.ManagedThreadId returns an integer that 
//            //represents a unique identifier for the current managed thread.
//            Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
//            //Sleep the loop for 10 miliseconds
//            Thread.Sleep(10);
//        }
//        Console.WriteLine();

//        Console.WriteLine("Parallel For Loop");
//        Parallel.For(0, number, count =>
//        {
//            Console.WriteLine($"value of count = {count}, thread = {Thread.CurrentThread.ManagedThreadId}");
//            //Sleep the loop for 10 miliseconds
//            Thread.Sleep(10);
//        });
//        Console.ReadLine();
//    }
//}
////////////////////////////////////////////////////
//class Program
//{
//    static void Main()
//    {
//        DateTime StartDateTime = DateTime.Now;
//        Stopwatch stopWatch = new Stopwatch();
//        Console.WriteLine("For Loop Execution start");
//        stopWatch.Start();
//        for (int i = 0; i < 10; i++)
//        {
//            long total = DoSomeIndependentTask();
//            Console.WriteLine("{0} - {1}", i, total);
//        }
//        DateTime EndDateTime = DateTime.Now;
//        Console.WriteLine("For Loop Execution end ");
//        stopWatch.Stop();
//        Console.WriteLine($"Time Taken to Execute the For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

//        Console.ReadLine();
//    }
//    static long DoSomeIndependentTask()
//    {
//        //Do Some Time Consuming Task here
//        //Most Probably some calculation or DB related activity
//        long total = 0;
//        for (int i = 1; i < 100000000; i++)
//        {
//            total += i;
//        }
//        return total;
//    }
//}
/////////////////////////////////////////////////////////////
//class Program
//{
//    static void Main()
//    {
//        DateTime StartDateTime = DateTime.Now;
//        Stopwatch stopWatch = new Stopwatch();
//        Console.WriteLine("Parallel For Loop Execution start");
//        stopWatch.Start();

//        Parallel.For(0, 10, i => {
//            long total = DoSomeIndependentTask();
//            Console.WriteLine("{0} - {1}", i, total);
//        });
//        DateTime EndDateTime = DateTime.Now;
//        Console.WriteLine("Parallel For Loop Execution end ");
//        stopWatch.Stop();
//        Console.WriteLine($"Time Taken to Execute Parallel For Loop in miliseconds {stopWatch.ElapsedMilliseconds}");

//        Console.ReadLine();
//    }
//    static long DoSomeIndependentTask()
//    {
//        //Do Some Time Consuming Task here
//        //Most Probably some calculation or DB related activity
//        long total = 0;
//        for (int i = 1; i < 100000000; i++)
//        {
//            total += i;
//        }
//        return total;
//    }
//}
//////////////////////////////////////////////Parallel Options/////////////////////////////////

//class Program
//{
//    static void Main(string[] args)
//    {
//        //Limiting the maximum degree of parallelism to 2
//        var options = new ParallelOptions()
//        {
//            MaxDegreeOfParallelism = 2
//        };
//        int n = 10;
//        Parallel.For(0, n, options, i =>
//        {
//            Console.WriteLine(@"value of i = {0}, thread = {1}",
//            i, Thread.CurrentThread.ManagedThreadId);
//            Thread.Sleep(10);
//        });
//        Console.WriteLine("Press any key to exist");
//        Console.ReadLine();
//    }
//}

////////////////////////////////////Parallel Thread Termination////////////////
//class Program
//{
//    static void Main()
//    {
//        var BreakSource = Enumerable.Range(0, 1000).ToList();
//        int BreakData = 0;
//        Console.WriteLine("Using loopstate Break Method");
//        Parallel.For(0, BreakSource.Count, (i, BreakLoopState) =>
//        {
//            BreakData += i;
//            if (BreakData > 100)
//            {
//                BreakLoopState.Break();
//                Console.WriteLine("Break called iteration {0}. data = {1} ", i, BreakData);
//            }
//        });
//        Console.WriteLine("Break called data = {0} ", BreakData);
//        var StopSource = Enumerable.Range(0, 1000).ToList();
//        int StopData = 0;
//        Console.WriteLine("Using loopstate Stop Method");
//        Parallel.For(0, StopSource.Count, (i, StopLoopState) =>
//        {
//            StopData += i;
//            if (StopData > 100)
//            {
//                StopLoopState.Stop();
//                Console.WriteLine("Stop called iteration {0}. data = {1} ", i, StopData);
//            }
//        });
//        Console.WriteLine("Stop called data = {0} ", StopData);
//        Console.ReadKey();
//    }
//}

///////////////////////////////Parallel Foreach//////////////////////////////////////
class Program
{
    static void Main()
    {
        var BreakSource = Enumerable.Range(0, 1000).ToList();
        int BreakData = 0;
        Console.WriteLine("Using loopstate Break Method");
        Parallel.For(0, BreakSource.Count, (i, BreakLoopState) =>
        {
            BreakData += i;
            if (BreakData > 100)
            {
                BreakLoopState.Break();
                Console.WriteLine("Break called iteration {0}. data = {1} ", i, BreakData);
            }
        });
        Console.WriteLine("Break called data = {0} ", BreakData);
        var StopSource = Enumerable.Range(0, 1000).ToList();
        int StopData = 0;
        Console.WriteLine("Using loopstate Stop Method");
        Parallel.For(0, StopSource.Count, (i, StopLoopState) =>
        {
            StopData += i;
            if (StopData > 100)
            {
                StopLoopState.Stop();
                Console.WriteLine("Stop called iteration {0}. data = {1} ", i, StopData);
            }
        });
        Console.WriteLine("Stop called data = {0} ", StopData);
        Console.ReadKey();
    }
}

