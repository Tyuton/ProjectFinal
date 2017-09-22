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

        public QueryContract GetQueryContractByName(string queryName)
        {
            return rep.GetQueryContractByName(queryName);
        }

        public string getQueryDescription(string name)
        {
            return rep.getQueryByName(name)[0].Description;
        }

        public int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC)
        {
            return rep.SaveResults(rHC, listRDC);
        }
    }
}
