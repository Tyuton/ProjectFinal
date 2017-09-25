using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebScraper.DAL;
using WebScraper.WCF;

namespace WebScraper.WCF
{

    public class ArbitreService : IArbitreService
    {
        IRepository rep = new Repository();
        public List<Match> GetAllMatchsByQueryName(string queryName)
        {
            return rep.GetAllMatchsByQueryName(queryName);
        }
    }
}
