using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [ServiceContract]
    public interface IRepositoryService1
    {
        [OperationContract]
        string getQueryDescription(string name);
    }
}
