using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using WebScraper.WCF;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host1 = new ServiceHost(typeof(RepositoryService1));

            host1.Open();

            Console.WriteLine("Start WCFHost");

            foreach (ChannelDispatcher dis in host1.ChannelDispatchers)
            {
                Console.WriteLine("Binding: " + dis.BindingName);
                foreach (EndpointDispatcher point in dis.Endpoints)
                {
                    Console.WriteLine("Endpoint: " + point.EndpointAddress);
                }
            }

            Console.WriteLine("Enter to quit.");
            Console.ReadLine();
            host1.Close();

        }
    }
}
