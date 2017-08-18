using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
     interface IRepository
    {

        /// <summary>
        /// TODO Add a new query...
        /// </summary>
        /// <returns></returns>
        bool AddNewQuery(string name, string des, string url, string script, DateTime expiry, DateTime timestamp);

        /// <summary>
        /// return id of queries with same "name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<Query> getQueryByName(string name);

        List<Query> getAllQuery();

        void ModifyQuery(Query query);

        void DeleteQuery(Query query);

        bool CheckExistingQuery(Query query);

        //get results details
         List<string> GetResults(Query query);

         void SetResults(Query query, string scrapingResults);

}
}
