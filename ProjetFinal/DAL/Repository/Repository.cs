using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.WCF;

namespace WebScraper.DAL
{
    public class Repository : IRepository
    {
        public bool AddNewQuery(QueryContract query)
        {
            return false; // throw new NotImplementedException();
        }

        public bool AddNewQuery(string name, string description, string url, string script, DateTime expiry, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        public bool CheckExistingQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuery(QueryContract query)
        {


        }

        public List<Query> getAllQuery()
        {
            throw new NotImplementedException();
        }

        public List<Query> getQueryByName(string name)
        {
            throw new NotImplementedException();
        }

        public QueryContract GetQueryContractByName(string queryName)
        {
            throw new NotImplementedException();
        }

        public ResultsHeaderContract GetQueryResults(QueryContract query)
        {
            throw new NotImplementedException();
        }

        public List<string> GetResults(Query query)
        {
            throw new NotImplementedException();
        }

        public ResultsHeaderContract GetSelectorResults(SelectorContract selector)
        {
            throw new NotImplementedException();
        }

        public List<ResultsDetailContract> GetSelectorResultsDetails(SelectorContract selector)
        {
            throw new NotImplementedException();
        }

        public void ModifyQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC)
        {
            Console.WriteLine("Repo");
            ResultsHeader rh = new ResultsHeader()
            {
                Id = rHC.Id, //Guid.NewGuid();
                QueryExecutionDate = rHC.QueryExecutionDate,
                Selector = null, // selector?
                Selector_Id = rHC.Selector.Id
            };
            rh.ResultsDetails = listRDC.Select(item => //dbContext.ResultsDetails
                new ResultsDetail()
                {
                    Id = item.Id,
                    CLEF = item.CLEF,
                    Value = item.Value,
                    ResultsHeader_Id = rh.Id,
                    ResultsHeader = rh
                }).ToList();

            //dbContext.ResultsHeaders.Add(rh);
            //dbContext.ResultsDetails.Add(rh.ResultsDetails); done with linq
            //dbContext.SaveChanges();

            return -1;

        }

        public void SetResults(Query query, string scrapingResults)
        {
            throw new NotImplementedException();
        }

        public string TestServer()
        {
            throw new NotImplementedException();
        }
    }

    public class RepositoryOLD : IRepository
    {
        private DBWebScrapingEntities dbContext = new DBWebScrapingEntities();


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
            //return dbContext.Queries.Where(q => q.Id == query.Id) != null ? true : false;
            return dbContext.Queries.Where(q => q.Name == query.Name) != null ? true : false;
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
            throw new NotImplementedException();

        }

        public List<Query> getAllQuery()
        {
            throw new NotImplementedException();
        }

        public void ModifyQuery(Query query)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuery(QueryContract query)
        {
            if (query != null)
            {

                if (query.ListePages != null)
                    foreach (var p in query.ListePages)
                    {
                        if (p.ListeSelectors != null)
                            foreach (var s in p.ListeSelectors)
                            {
                                List<ResultsHeader> rhlEF = dbContext.ResultsHeaders.Where(rh => rh.Selector_Id == s.Id).ToList();
                                //delete results details
                                rhlEF.ForEach(rh =>
                                    dbContext.ResultsDetails.RemoveRange(rh.ResultsDetails)
                                    );
                                //delete results headers
                                dbContext.ResultsHeaders.RemoveRange(rhlEF);
                                //delete selector/foreachloop
                                var selectorEF = dbContext.Selectors.Where(slc => slc.Id == s.Id).FirstOrDefault();
                                dbContext.Selectors.Remove(selectorEF);
                            }
                        var pageEF = dbContext.Pages.Where(pg => pg.Id == p.Id).FirstOrDefault();
                        dbContext.Pages.Add(pageEF);
                    }
                var queryEF = dbContext.Queries.Where(qr => qr.Id == query.Id).FirstOrDefault();
                dbContext.Queries.Remove(queryEF);

                dbContext.SaveChanges();
            }

        }

        public bool AddNewQuery(QueryContract query)
        {

            if (query == null)
                return false;

            var queryEF = new Query();
            queryEF.Id = Guid.NewGuid();
            queryEF.Name = query.Name;
            queryEF.Description = query.Description;
            queryEF.DataExpiryDate = query.DataExpiryDate;
            queryEF.DataTimeStamp = query.DataTimeStamp;

            dbContext.Queries.Add(queryEF);

            if (query.ListePages != null)
                foreach (var p in query.ListePages)
                {
                    var pageEF = new Page();
                    pageEF.Id = Guid.NewGuid();
                    pageEF.Query = queryEF;
                    pageEF.URL = p.URL;
                    dbContext.Pages.Add(pageEF);

                    if (p.ListeSelectors != null)
                        foreach (var s in p.ListeSelectors)
                        {
                            var selectorEF = new Selector();
                            selectorEF.Id = Guid.NewGuid();
                            selectorEF.Page = pageEF;
                            selectorEF.Value = s.Value;
                            dbContext.Selectors.Add(selectorEF);
                        }
                }

            dbContext.SaveChanges();
            return true;
        }

        public QueryContract GetQueryContractByName(string queryName)
        {
            List<Query> qs = getQueryByName(queryName);
            if (qs != null)
            {
                var qs0 = qs[0];
                QueryContract qc = new QueryContract();
                qc.Name = qs0.Name;
                qc.Description = qs0.Description;
                qc.Id = qs0.Id;
                qc.DataExpiryDate = qs0.DataExpiryDate;
                qc.DataTimeStamp = qs0.DataTimeStamp;
                if (qs0.Pages != null)
                {
                    qc.ListePages = qs0.Pages.Select(item => new PageContract()
                    {
                        Id = item.Id,
                        URL = item.URL,
                        ListeSelectors = item.Selectors.Select(item2 => new SelectorContract()
                        {
                            Id = item2.Id,
                            Value = item2.Value,
                        }).ToList()
                    }).ToList();
                }
                //qc.ListePages = qs[0].Pages;
                return qc;
            }
            else
                return null;
        }

        // return -1 if error
        public int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC)
        {
            //List<ResultsDetail> rd = new List<ResultsDetail>();
            ResultsHeader rh = new ResultsHeader()
            {
                Id = rHC.Id, //Guid.NewGuid();
                QueryExecutionDate = rHC.QueryExecutionDate,
                Selector = null, // selector?
                Selector_Id = rHC.Selector.Id
            };
            rh.ResultsDetails = listRDC.Select(item => dbContext.ResultsDetails
            .Add(
                new ResultsDetail()
                {
                    Id = item.Id,
                    CLEF = item.CLEF,
                    Value = item.Value,
                    ResultsHeader_Id = rh.Id,
                    ResultsHeader = rh
                }
            )).ToList();

            dbContext.ResultsHeaders.Add(rh);
            //dbContext.ResultsDetails.Add(rd); done with linq
            dbContext.SaveChanges();

            return 1;
        }

        public ResultsHeaderContract GetSelectorResults(SelectorContract selector)
        {
            if (selector == null)
                return null;

            ResultsHeader rhEF = dbContext.ResultsHeaders.Where(rh => rh.Selector_Id == selector.Id).ToList().FirstOrDefault();
            var RHC = new ResultsHeaderContract()
            {
                Id = rhEF.Id,
                QueryExecutionDate = rhEF.QueryExecutionDate,
                Selector = selector
            };

            return RHC;
        }

        public List<ResultsDetailContract> GetSelectorResultsDetails(SelectorContract selector)
        {
            ResultsHeaderContract RHC = GetSelectorResults(selector);
            List<ResultsDetailContract> rdcl = dbContext.ResultsDetails
                .Where(rd => rd.ResultsHeader_Id == RHC.Id)
                .Select(rd =>
                new ResultsDetailContract()
                {
                    Id = rd.Id,
                    CLEF = rd.CLEF,
                    Value = rd.Value,
                }
            ).ToList();
            return rdcl;
        }
    }
}
