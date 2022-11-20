using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace server
{
    internal class GreetingServiceImpl : GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            string result = string.Format($"hello {request.Greeting.FirstName} {request.Greeting.LastName}");

            return Task.FromResult(new GreetingResponse() { Result = result });
        }
    }
}
