using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Repository
    {
        private QueryContext dbQueryContext = new QueryContext();

        /// <summary>
        /// TODO Add a new query...
        /// </summary>
        /// <returns></returns>
        public bool AddNewQuery()
        {
            //throw new NotImplementedException();
            var q = new Query();
            q.Name = "test";
            dbQueryContext.Queries.Add(q);
            dbQueryContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// return id of queries with same "name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<int> getQuery(string name)
        {
            throw new NotImplementedException();
        }

        List<Object> ExecuteQuery(int queryId)
        {
            throw new NotImplementedException();
        }

        bool CheckExistingQuery(int queryId)
        {
            throw new NotImplementedException();
        }


    }
}
