using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    /// <summary>
    /// 
    /// </summary>
    class Query
    {
        public int QueryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DataExpiryDate { get; set; }
        public DateTime DataTimeStamp { get; set; }
    }

    class Page
    {
        public int PageId { get; set; }
        public int QueryId { get; set; }
        public string URL { get; set; }

    }

    class Selector
    {
        public int SelectorId { get; set; }
        public int PageId { get; set; }
        public string Value { get; set; }

    }

    class ResultsHeader
    {
        public int ResultsHeaderId { get; set; }
        public int SelectorId { get; set; }
        public DateTime QueryExecutionDate { get; set; }
    }

    class ResultsDetail
    {
        public int ResultsDetailId { get; set; }
        public int ResultsHeaderId { get; set; }
        public string Value { get; set; }
    }
}
