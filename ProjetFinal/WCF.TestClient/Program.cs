﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF;

namespace WCF.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IService1> Canal =
                 new ChannelFactory<IService1>("Canal1");
            IService1 serv = Canal.CreateChannel();


            ChannelFactory<IRepository> Canal2 =
     new ChannelFactory<IRepository>("Canal2");
            IRepository serv2 = Canal2.CreateChannel();


            Console.WriteLine(serv2.TestServer() );
            Console.Read();
        }
    }
}
