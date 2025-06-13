using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService.Services
{
    public class CountService : Counter.CounterBase
    {
        private CounterReply counterReply;
        private readonly ILogger<CountService> counterService;
        public CountService(ILogger<CountService> counterService)
        {
            counterReply = new CounterReply
            {
                Count = 1
            };
            this.counterService = counterService;
        }

        public override Task<CounterReply> IncrementCount(Empty request, ServerCallContext context)
        {
            // counterService.LogInformation("Incrementing count by 1");
            StaticCounter.AddCounter();
            // counterService.LogInformation("counter -> " + StaticCounter.GetCounterReply.Count.ToString());

            return Task.FromResult(StaticCounter.GetCounterReply);
        }
    }
}