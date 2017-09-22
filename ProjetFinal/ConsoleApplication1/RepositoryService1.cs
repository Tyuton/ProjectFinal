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

        public string getQueryDescription(string name)
        {
            return rep.getQueryByName(name)[0].Description;
        }
    }
}
