using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    /// <summary>
    /// creation des classes qui détaillent les champs des tables 
    /// </summary>
    class Query
    {
        public Guid QueryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime? DataExpiryDate { get; set; }
        public DateTime? DataTimeStamp { get; set; }
    }

    class Page
    {
        public Guid PageId { get; set; }
        public virtual Query QueryId { get; set; }
        public string URL { get; set; }

    }

    class Selector
    {
        public Guid SelectorId { get; set; }
        public virtual Page PageId { get; set; }
        public string Value { get; set; }

    }

    class ResultsHeader
    {
        public Guid ResultsHeaderId { get; set; }
        public virtual Selector SelectorId { get; set; }
        public DateTime QueryExecutionDate { get; set; }
    }

    class ResultsDetail
    {
        public Guid ResultsDetailId { get; set; }
        public virtual ResultsHeader ResultsHeaderId { get; set; }
        public string Value { get; set; }
    }
}
