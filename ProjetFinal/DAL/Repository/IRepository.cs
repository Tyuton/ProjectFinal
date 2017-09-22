using WebScraper.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WebScraper.WCF;

namespace WebScraper.DAL
{

    public interface IRepository
    {

        string TestServer();



        bool AddNewQuery(WebScraper.WCF.QueryContract query);
        bool AddNewQuery(string name, string description, string url, string script, DateTime expiry, DateTime timestamp);


        List<Query> getQueryByName(string name);

        List<Query> getAllQuery();
        QueryContract GetQueryContractByName(string queryName);
        void ModifyQuery(Query query);

        void DeleteQuery(Query query);

        bool CheckExistingQuery(Query query);
        //get results details

        List<string> GetResults(Query query);
        int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC);
        void SetResults(Query query, string scrapingResults);

    }
}
