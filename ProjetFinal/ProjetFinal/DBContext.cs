using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    /// <summary>
    /// Creation des tables de la base de données + connection string
    /// </summary>
    class QueryContext : DbContext
    {
        public QueryContext() : base("name=QueryConnectionString")
        {

        }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Selector> Selectors { get; set; }
        public DbSet<ResultsHeader> ResultsHeaders { get; set; }
        public DbSet<ResultsDetail> ResultsDetails { get; set; }

    }
}
