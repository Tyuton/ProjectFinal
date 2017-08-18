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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime? DataExpiryDate { get; set; }
        public DateTime? DataTimeStamp { get; set; }
    }

    class Page
    {        
        public Guid Id { get; set; }
        public virtual Query Query { get; set; }
        public string URL { get; set; }

    }

    class Selector
    {
        public Guid Id { get; set; }
        public virtual Page Page { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }

    class ResultsHeader
    {
        public Guid Id { get; set; }
        public virtual Selector Selector { get; set; }
        public DateTime QueryExecutionDate { get; set; }
    }

    class ResultsDetail
    {
        public Guid Id { get; set; }
        public virtual ResultsHeader ResultsHeader { get; set; }
        public string Value { get; set; }
    }
}
