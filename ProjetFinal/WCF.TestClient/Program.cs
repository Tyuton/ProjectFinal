
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF;
using WebScraper.WCF;

namespace WCF.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChannelFactory<IService1> Canal =
            //     new ChannelFactory<IService1>("Canal1");
            //IService1 serv = Canal.CreateChannel();



            ChannelFactory<IRepositoryService1> Canal2 =
new ChannelFactory<IRepositoryService1>("Canal2");
            IRepositoryService1 serv2 = Canal2.CreateChannel();


            var test = serv2.getQueryDescription("Ali");
            Console.WriteLine(test);            
            Console.Read();


            //       ChannelFactory<IRepository> Canal2 =
            //new ChannelFactory<IRepository>("Canal2");
            //       IRepository serv2 = Canal2.CreateChannel();


            //       List<Query> test = serv2.getQueryByName("Ali");
            //       Console.WriteLine(test.ToString());
            //       Console.WriteLine(serv2.CheckExistingQuery(test[0]));
            //       Console.Read();
        }
    }
}
