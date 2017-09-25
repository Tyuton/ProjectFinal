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
        List<Match> GetAllMatchsByQueryName(string queryName);
        List<Query> getQueryByName(string name);

        List<Query> getAllQuery();
        QueryContract GetQueryContractByName(string queryName);
        List<QueryContract> GetAllQueryContract();
        void ModifyQuery(Query query);

        void DeleteQuery(QueryContract query);
        List<PageContract> GetPageContractById(string queryId);
        bool CheckExistingQuery(Query query);
        //get results details
        List<string> GetResults(Query query);
        int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC);
        void SetResults(Query query, string scrapingResults);
        ResultsHeaderContract GetSelectorResults(SelectorContract selector);
        List<ResultsDetailContract> GetSelectorResultsDetails(SelectorContract selector);
        List<SelectorContract> GetSelectorContractById(string pageId);
    }
}
