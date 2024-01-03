//////****first threading*****

//Thread t = new Thread(WriteY);
//t.Start();
//for(int i = 0;i<=1000;i++) Console.Write(i);
//void WriteY()
//{
//    for(int i = 0;i<=1000; i++) Console.Write("thread");
//}



//////****second threading*****

//void Go()
//{
//    for (int i = 0; i < 1000; i++) Console.WriteLine("In Thread");
//}
//Thread t = new Thread(Go);
//t.Start();
//t.Join(); //Main thread is blocked here - blocking/ unblocking causes context switch overhead.
//Console.WriteLine("Thread Joined");


//////****thread state*****

//void go(object origin)
//{
//    for (int i = 0; i < 1000; i++) Console.Write(origin);
//}
//Thread thread = new Thread(go);
//thread.Start("thread");
//go("main");


//////****thread state 2*****

//bool isTrue = true;
//void go(object origin)
//{
//    if (isTrue)
//    {
//        isTrue = false;
//        Console.WriteLine(origin + ": true");
//    }
//}
//new Thread(go).Start("thread");
//go("main");


//////****locking & thread safety*****
//class ThreadSafe
//{
//    static bool _done;
//    static readonly object _lock = new object();

//    static void Main()
//    {
//        new Thread(Go).Start("thread");
//        Go("main");
//    }

//    static void Go(object origin)
//    {
//        lock( _lock )
//        {
//            if (!_done) { Console.WriteLine("Done from " + origin); _done = true; }
//        }
//    }
//}

//////****Signaling via ManualResetEvent*****
//var signal = new ManualResetEvent(false);
//new Thread((object origin) =>
//{
//    Console.WriteLine("Waitin on: " + origin);
//    signal.WaitOne(); //waiting
//    signal.Dispose();
//    Console.WriteLine("Resuming after getting signal on: " + origin);
//}).Start("Thread");
//Thread.Sleep(2000);
//signal.Set(); //open the signal


//////****TASK*****
//Task<int> task = Task.Run(() =>
//                    Enumerable.Range(2, 3000000).Count(n =>
//                        Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//Console.WriteLine("Task Running");
//Console.WriteLine("Result: " + task.Result);

//////****TASK CONTINUATION*****
///
//Task<int> task = Task.Run(() =>
//    {
//        Console.WriteLine("---In Task---");
//        Console.WriteLine(Task.CurrentId);
//        return Enumerable.Range(2, 3000000).Count(n =>
//          Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
//    });


//var awaiter = task.GetAwaiter();
//var continuedTask = task.ContinueWith(task  =>
//    {
//        Console.WriteLine("---In Awaiter---");
//        Console.WriteLine(Task.CurrentId);
//        Task.Delay(2000);
//        try
//        {
//            int result = task.Result;
//            Console.WriteLine(result);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.ToString());
//        }
//    });
//continuedTask.Wait();

//////****TASK COMPLETION SOURCE*****

//Task<int> GetAnswersToLife()
//{
//    var tcs = new TaskCompletionSource<int>();
//    var timer = new System.Timers.Timer(5000) { AutoReset = false };
//    timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
//    timer.Start();
//    return tcs.Task;
//}
//var awaiter = GetAnswersToLife().GetAwaiter();
//Console.WriteLine("Awaiting");
//int result =  awaiter.GetResult();
//Console.WriteLine("Completed with result: "+result);