using Grpc.Core;
using Prime;
using static Prime.PrimeNumberService;

namespace server
{
    public class PrimeServiceImpl : PrimeNumberServiceBase
    {
        public override async Task PrimeNumberDecomposion(PrimeNumberDecompositionRequest request, IServerStreamWriter<PrimeNumberDecompositionResponse> responseStream, ServerCallContext context)
        {
            int num = request.Number;
            Console.WriteLine($"Number is {num}");
            int divisor = 2;
            while (num > 1)
            {
                if (num % divisor == 0)
                {
                    await responseStream.WriteAsync(new PrimeNumberDecompositionResponse() { PrimeFactor = divisor });
                    num = (int)num / divisor;
                }
                else
                {
                    divisor++;
                }
            }
        }
    }
}
