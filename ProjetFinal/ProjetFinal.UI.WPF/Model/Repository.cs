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
            return new List<Query>
            {
                new Query { Nom = "Requête 1", url = { "http://www.ffr.fr", "http://competitions.ffr.fr/index.php/ffr/rugby_francais/competitions" } },
                new Query { Nom = "Requête 2", url = { "https://www.google.fr/", "https://fr.wikipedia.org/" } },
                //new Query { }

            };
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
        public List<string> url { get; set; }

        public string Nom { get; set; }

        public override string ToString()
        {
            return Nom;
        }
        

    }
}
