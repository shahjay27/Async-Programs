///////////-------INTRO---------------
//Task<int> GetPrimeCountAsync(int start, int count)
//{
//    return Task.Run(() =>
//        Enumerable.Range(start, count).Count(n =>
//            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//}

//for (int j = 0; j < 10; j++)
//{
//    Console.WriteLine(j);
//    int i = j; //IMP
//    var awaiter = GetPrimeCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
//    awaiter.OnCompleted(() =>
//    {
//        Console.WriteLine(awaiter.GetResult() + " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
//    });
//}
//Console.WriteLine("done");
//Console.ReadLine();

///////////------- Simple Async Await ---------------
///
//Task<int> GetPrimeCountAsync(int start, int count)
//{
//    return Task.Run(() =>
//        Enumerable.Range(start, count).Count(n =>
//            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
//}

//async Task JustACallingMethod()
//{
//    int result = await GetPrimeCountAsync(1000000, 1000000);
//    Console.WriteLine(result + " primes between " + 1000000 + " and " + (1000000 * 2));
//}

//Task task = JustACallingMethod();
//Console.WriteLine("done");
//task.Wait();

///////////------- For Loop Async Await ---------------
///
Task<int> GetPrimeCountAsync(int start, int count)
{
    return Task.Run(() =>
        ParallelEnumerable.Range(start, count).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
}

async void JustACallingMethod()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine(i);
        int temp = i;
        int result = await GetPrimeCountAsync(temp * 1000000 + 2, 1000000);
        Console.WriteLine(result + " primes between " + (temp * 1000000) + " and " + ((temp + 1) * 1000000 - 1));
    }
    Console.WriteLine("method done");
}

JustACallingMethod();
Console.WriteLine("done");
for (int i = 11; i < 20; i++) Console.WriteLine(i);
Console.ReadLine();

///////////------- Lambda and Anonymous method Async Await ---------------
//Func<Task> unnamed = async () => { await Task.Delay(2000); Console.WriteLine("done"); };
//Task t = unnamed();
//Console.WriteLine("Waiting");
//t.Wait();