using System;
using System.Linq;
using System.ServiceModel;

namespace Wcf.Client
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        string[] GetMessages(string item);
    }

    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("press any key to continue");
            Console.ReadLine();

            string address = "net.tcp://localhost:6565/MessageService";           
            var binding = new NetTcpBinding(SecurityMode.None);
            var channel = new ChannelFactory<IMessageService>(binding);
            var endpoint = new EndpointAddress(address);
            var proxy = channel.CreateChannel(endpoint);
            var result = proxy?.GetMessages("hello");
            if (result != null)
            {
                result.ToList().ForEach(p =>
                {
                    Console.WriteLine(p);
                }) ;
            }

            Console.ReadLine();
        }
    }
}
