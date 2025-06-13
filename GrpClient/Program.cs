// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Timers;
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcClient;

Console.WriteLine("Hello, World!");
using var channel = GrpcChannel.ForAddress("https://localhost:7292");
var client = new Greeter.GreeterClient(channel);
var counterClient = new Counter.CounterClient(channel);
var reply = await client.SayHelloAsync(
    new HelloRequest { Name = "GreeterClient Eduardo" });

Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();

for (int i = 0; i < 10_000; i++)
{
    var replyFromServiceCounter = counterClient.IncrementCount(new Empty());
    Console.WriteLine("Counter: " + replyFromServiceCounter.Count);

}

TimeSpan ts = stopWatch.Elapsed;
// Format and display the TimeSpan value.
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
    ts.Hours, ts.Minutes, ts.Seconds,
    ts.Milliseconds / 10);

/**
Counter: 1
...
Counter: 9999
Counter: 10000
RunTime 00:00:02.82
**/
Console.WriteLine("RunTime " + elapsedTime);
Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();