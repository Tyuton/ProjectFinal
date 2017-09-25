using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.DAL;
using WebScraper.WCF;

namespace WebScraper.WCF
{
    public class RepositoryService1 : IRepositoryService1
    {
        IRepository rep = new Repository();

        public bool AddNewQuery(QueryContract query)
        {
            return rep.AddNewQuery(query);
        }

        public void DeleteQuery(QueryContract q)
        {
            rep.DeleteQuery(q);
        }

        public List<QueryContract> GetAllQueryContract()
        {
            return rep.GetAllQueryContract();
        }

        public List<PageContract> GetPageContractById(string QueryId)
        {
            return rep.GetPageContractById(QueryId);
        }

        public QueryContract GetQueryContractByName(string queryName)
        {
            return rep.GetQueryContractByName(queryName);
        }

        public string getQueryDescription(string name)
        {
            return rep.getQueryByName(name)[0].Description;
        }

        public List<SelectorContract> GetSelectorContractById(string PageId)
        {
            return rep.GetSelectorContractById(PageId);
        }

        public ResultsHeaderContract GetSelectorResults(SelectorContract selector)
        {
            return rep.GetSelectorResults(selector);
        }

        public List<ResultsDetailContract> GetSelectorResultsDetails(SelectorContract selector)
        {
            return rep.GetSelectorResultsDetails(selector);
        }

        public int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC)
        {
            return rep.SaveResults(rHC, listRDC);
        }
    }
}
