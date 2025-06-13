using System.Diagnostics.Metrics;

namespace GrpcService.Services;

public static class StaticCounter
{
    static CounterReply counterReply = new() {
        Count = 0,
    };

    public static void AddCounter()
    {
        counterReply.Count ++;
    }

    public static CounterReply GetCounterReply => counterReply;
}
