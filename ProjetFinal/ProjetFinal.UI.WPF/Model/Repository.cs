using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal.UI.WPF.Model
{
    class Repository : IRepository
    {
        private List<Query> queries = null;

        public Repository()
        {
            // Fake DB
            queries = new List<Query>
            {
                new Query { Nom = "Requête 1",
                    urls = new List<URL>{
                        new URL()
                        {
                            url = "http://www.ffr.fr",
                            selectors=new List<Selector>
                            {
                                new Selector() { script="JS" },
                                new Selector() { script="Python" }
                            }
                        },
                        new URL()
                        {
                            url = "http://competitions.ffr.fr/index.php/ffr/rugby_francais/competitions",
                            selectors=new List<Selector>
                            {
                                new Selector() { script="xPath" },
                                new Selector() { script="jQuery" }
                            }
                        }
                    }


                },
                new Query { Nom = "Requête 2",
                    urls = new List<URL>{
                        new URL()
                        {
                            url = "http://www.google.fr",
                            selectors=new List<Selector>
                            {
                                new Selector() { script="JS2" },
                                new Selector() { script="Python2" }
                            }
                        },
                        new URL()
                        {
                            url = "http://fr.wikipedia.org",
                            selectors=new List<Selector>
                            {
                                new Selector() { script="xPath2" },
                                new Selector() { script="jQuery2" }
                            }
                        }
                    }
                }

            };
        }
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
            return queries;
        }
        public List<URL> getAllURL(Query query)
        {
            return query.urls;
        }
        public List<Selector> getAllSelectors(URL url)
        {
            return url.selectors;
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


    /// ///////////////////////////////////////////////
    // Model
    class Query
    {
        public List<URL> urls { get; set; }

        public string Nom { get; set; }

        public override string ToString()
        {
            return Nom;
        }
    }
    public class URL
    {
        public List<Selector> selectors { get; set; }
        public string url { get; set; }
        public override string ToString()
        {
            return url; 
        }

    }
    public class Selector
    {
        public string script { get; set; }
        public override string ToString()
        {
            return script; 
        }
    }
}
