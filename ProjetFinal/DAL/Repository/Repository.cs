using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.DAL
{
    public class Repository : IRepository
    {
        private WebScraperDBEntities dbContext = new WebScraperDBEntities();


        public string TestServer()
        {
            return "TEstServer coucou";
        }

        /// <summary>
        /// TODO Add a new query...
        /// </summary>
        /// <returns></returns>
        public bool AddNewQuery(string name, string description, string url, string script, DateTime expiry, DateTime timestamp)
        {
            //throw new NotImplementedException();
            var query = new Query();
            query.Id = Guid.NewGuid();
            query.Name = name;
            query.Description = description;
            query.DataExpiryDate = expiry;
            query.DataTimeStamp = timestamp;

            dbContext.Queries.Add(query);

            var page = new Page();
            page.Id = Guid.NewGuid();
            page.Query = query;
            page.URL = url; 
            dbContext.Pages.Add(page);

            var selector = new Selector();
            selector.Id = Guid.NewGuid();
            selector.Page = page;
            selector.Value = script;
            dbContext.Selectors.Add(selector);

            dbContext.SaveChanges();

            return true;
        }
        /// <summary>
        /// return id of queries with same "name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Query> getQueryByName(string name)
        {
            return dbContext.Queries.Where(q => q.Name == name).ToList();
        }

        public bool CheckExistingQuery(Query query)
        {
            return dbContext.Queries.Where(q => q.Id == query.Id) != null ? true : false;
        }

        //get results details
        public List<string> GetResults(Query query)
        {
            if (query == null && !CheckExistingQuery(query))
            {
                return null;
            }
            var r = (from q in dbContext.Queries
                              join p in dbContext.Pages on q.Id equals p.Query.Id
                              where q.Id == query.Id
                              join s in dbContext.Selectors on p.Id equals s.Page.Id
                              join rh in dbContext.ResultsHeaders on s.Id equals rh.Selector.Id
                              join rd in dbContext.ResultsDetails on rh.Id equals rd.ResultsHeader.Id
                              select rd
          )
         .ToList();
            List<string> sResult = new List<string>();
            foreach (var item in r)
            {
                sResult.Add(item.Value);
            }
            return sResult;
        }

        //TODO définir les params... (ResultsHeader, ResultsDetails)
        public void SetResults(Query query, string scrapingResults)
        {

            //   var selector = dbQueryContext.Selectors
            //.Where(s => s.Page ==
            //   dbQueryContext.Pages
            //   .Where(q => q.Id.ToString() == query.Id.ToString() )
            //      ).ToList();

            //   var selector = from selectors in dbQueryContext.Selectors
            //                  join page in dbQueryContext.Pages on  equals page.QueryId into selectPage
            //                  into dbQueryContext.Queries;

            var ss = (from q in dbContext.Queries
                      join p in dbContext.Pages on q.Id equals p.Query.Id
                      where q.Id == query.Id
                      join s in dbContext.Selectors on p.Id equals s.Page.Id
                      select s
                      )
                     .ToList();     

            foreach (Selector item in ss)
            {//TODO ajouter une boucle pour resultsheader
                var resultsheader = new ResultsHeader();
                resultsheader.Id = Guid.NewGuid();
                resultsheader.Selector = item;
                resultsheader.QueryExecutionDate = DateTime.Now;
                dbContext.ResultsHeaders.Add(resultsheader);
                //TODO ajouter une boucle pour resultsdetails
                var resultsdetails = new ResultsDetail();
                resultsdetails.Id = Guid.NewGuid();
                resultsdetails.ResultsHeader = resultsheader;
                resultsdetails.Value = scrapingResults;//"scraping results";
                dbContext.ResultsDetails.Add(resultsdetails);
            }

            dbContext.SaveChanges();

        }

        public List<Query> getAllQuery()
        {
            throw new NotImplementedException();
        }

        public void ModifyQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuery(Query query)
        {
            throw new NotImplementedException();
        }


    }
}
