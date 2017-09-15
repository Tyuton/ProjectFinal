using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IService1> Canal =
                 new ChannelFactory<IService1>("Canal1");
            IService1 serv = Canal.CreateChannel();

            Console.WriteLine( serv.GetData(12) );
            Console.Read();
        }
    }
}
