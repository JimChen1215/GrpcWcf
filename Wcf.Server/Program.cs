 using System;
using System.ServiceModel;

namespace Wcf.Server
{
    internal class Program
    {
        [ServiceContract]
        public interface IMessageService
        {
            [OperationContract]
            string[] GetMessages(string item);
        }

        [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
        public class MessageService : IMessageService
        {
            public string[] GetMessages(string item)
            {
                Console.WriteLine($"request item: {item}");
                return new string[] { "server1", "server2", "server3",  item  };
            }
        }

        static void Main()
        {
            var uris = new Uri[1];
            string address = "net.tcp://localhost:6565/MessageService";
            uris[0] = new Uri(address);
            IMessageService msgSvc = new MessageService();
            ServiceHost host = new ServiceHost(msgSvc, uris);
            var binding = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(typeof(IMessageService), binding, "");
            host.Opened += HostOpened;
            host.Open();
            Console.ReadLine();
        }

        private static void HostOpened(object sender, EventArgs e)
        {
            Console.WriteLine("message service started...");
        }
    }
}
