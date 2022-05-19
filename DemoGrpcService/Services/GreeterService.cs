using DemoGrpcService;
using Grpc.Core;

namespace DemoGrpcService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("...Grpc server side, request: {Name}",  request.Name);
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<HelloReply> SayHello2(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("...Grpc server side, SayHello2: {Name}", request.Name);
            return Task.FromResult(new HelloReply
            {
                Message = "Thank God, " + request.Name
            });
        }

        public override Task<HelloReply> HelloWorld(HelloRequest request, ServerCallContext context)
        {
            _logger.LogInformation("...Grpc server side, hello world: {Name}", request.Name);
            return Task.FromResult(new HelloReply
            {
                Message = "Great Job, " + request.Name
            });
        }
    }
}