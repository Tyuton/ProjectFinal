using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.UI.WPF.Model
{
    class Repository : IRepository
    {
        public bool AddNewQuery(string name, string des, string url, string script, DateTime expiry, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        public bool CheckExistingQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public List<Query> getAllQuery()
        {
            throw new NotImplementedException();
        }

        public List<Query> getQueryByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<string> GetResults(Query query)
        {
            throw new NotImplementedException();
        }

        public void ModifyQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public void SetResults(Query query, string scrapingResults)
        {
            throw new NotImplementedException();
        }
    }
    class Query
    {
        public override string ToString()
        {
            return "TestQuery";
        }
    }
}
