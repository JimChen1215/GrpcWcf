// See https://aka.ms/new-console-template for more information
using DemoGrpcService;
using Grpc.Net.Client;
///By adding a service reference, it installs 3 NuGet pkgs:
///         Grpc.Net.Client,  Google.Protobuf,  Grpc.Tools
Console.WriteLine("Welcome to Grpc client!");

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7044");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);

reply = await client.SayHello2Async(new HelloRequest { Name = "Jeff" });
Console.WriteLine("Response: " + reply.Message);

reply = await client.HelloWorldAsync(new HelloRequest { Name = "Eric" });
Console.WriteLine("Hello World Response: " + reply.Message);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();