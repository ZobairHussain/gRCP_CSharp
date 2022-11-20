using Grpc.Core;
using Prime;

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

            var client = new PrimeNumberService.PrimeNumberServiceClient(channel);
            var request = new PrimeNumberDecompositionRequest() { Number = 120 };
            var response = client.PrimeNumberDecomposion(request);
            while (await response.ResponseStream.MoveNext())
            {
                Console.WriteLine(response.ResponseStream.Current.PrimeFactor);
                await Task.Delay(2000);
            }
        }
    }
}