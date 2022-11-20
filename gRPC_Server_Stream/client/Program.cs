using Greet;
using Grpc.Core;
namespace client
{
    internal class Program
    {
        const string target = "127.0.0.1:50051";
        static async Task Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure);

            await channel.ConnectAsync().ContinueWith((task) =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("The client connected successfully");
            });

            var client = new GreetingService.GreetingServiceClient(channel);
            var greeting = new Greeting()
            {
                FirstName = "Zobair",
                LastName = "Hussain"
            };
            var request = new GreetManyTimeRequest() { Greeting = greeting };

            var response = client.GreetManyTimes(request);

            while (await response.ResponseStream.MoveNext())
            {
                Console.WriteLine(response.ResponseStream.Current.Result);
                await Task.Delay(200);
            }
        }
    }
}