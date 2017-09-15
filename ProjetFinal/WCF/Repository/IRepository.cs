using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF
{
    [ServiceContract]
    public interface IRepository
    {
        [OperationContract]
        string TestServer();

        [OperationContract]
        bool AddNewQuery(string name, string description, string url, string script, DateTime expiry, DateTime timestamp);

        List<Query> getQueryByName(string name);

        List<Query> getAllQuery();

        void ModifyQuery(Query query);

        void DeleteQuery(Query query);

        bool CheckExistingQuery(Query query);

        //get results details
        List<string> GetResults(Query query);

        void SetResults(Query query, string scrapingResults);

    }
}
