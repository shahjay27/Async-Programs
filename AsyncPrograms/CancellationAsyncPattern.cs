//async Task<string> MyMethodAsync(CancellationToken ct)
//{
//    //Task t = Task.Delay(5000, ct);
//    Task t = Task.Delay(5000);
//    await t;
//    ct.ThrowIfCancellationRequested();
//    return "completed";
//}

//CancellationTokenSource cts = new CancellationTokenSource();
//var awaiter = MyMethodAsync(cts.Token).GetAwaiter();
//awaiter.OnCompleted(() =>
//{
//    string result = awaiter.GetResult();
//    Console.WriteLine(result);
//});
//Thread.Sleep(2000);
//cts.Cancel();
//Console.ReadLine();