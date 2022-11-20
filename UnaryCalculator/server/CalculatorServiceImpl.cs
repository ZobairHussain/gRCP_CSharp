using Calculator;
using Grpc.Core;
using static Calculator.CalculatorService;

namespace server
{
    internal class CalculatorServiceImpl : CalculatorServiceBase
    {
        public override Task<SumResponse> Sum(SumRequest request, ServerCallContext context)
        {
            int result = request.A + request.B;
            return Task.FromResult(new SumResponse() { Result = result });
        }
    }
}
