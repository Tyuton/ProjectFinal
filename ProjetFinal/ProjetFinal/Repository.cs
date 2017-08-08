using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    class Repository
    {
        //TODO : Enlever le Test poour ne pas géner le Commit d'Amin
        private QueryContext Test = new QueryContext();

        /// <summary>
        /// TODO Add a new query...
        /// </summary>
        /// <returns></returns>
        bool AddNewQuery()
        {
            throw new NotImplementedException();
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
