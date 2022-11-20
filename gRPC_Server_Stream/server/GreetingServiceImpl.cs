using Greet;
using Grpc.Core;
using static Greet.GreetingService;

namespace server
{
    internal class GreetingServiceImpl : GreetingServiceBase
    {
        public override async Task GreetManyTimes(GreetManyTimeRequest request, IServerStreamWriter<GreetManyTimeResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"The server received the request : ");
            Console.WriteLine(request.ToString());

            string result = String.Format($"hello {request.Greeting.FirstName} {request.Greeting.LastName}");

            foreach (int i in Enumerable.Range(1, 10))
            {
                await responseStream.WriteAsync(new GreetManyTimeResponse() { Result = result });
            }
        }
    }
}
