using WebScraper.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.WCF;

namespace WebScraper.WCF
{
    public class RepositoryService1 : IRepositoryService1
    {
        Repository rep = new Repository();

        public bool AddNewQuery(QueryContract query)
        {
            return rep.AddNewQuery(query);
        }

        public void DeleteQuery(QueryContract q)
        {
            throw new NotImplementedException();
        }

        public List<QueryContract> GetAllQueryContract()
        {
            throw new NotImplementedException();
        }

        public QueryContract GetQueryContractByName(string queryName)
        {
            return rep.GetQueryContractByName(queryName);
        }

        public string getQueryDescription(string name)
        {
            return rep.getQueryByName(name)[0].Description;
        }

        public ResultsHeaderContract GetSelectorResults(SelectorContract selector)
        {
            throw new NotImplementedException();
        }

        public List<ResultsDetailContract> GetSelectorResultsDetails(SelectorContract selector)
        {
            throw new NotImplementedException();
        }

        public int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC)
        {
            throw new NotImplementedException();
        }
    }
}
