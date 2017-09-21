
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.WCF
{
    [DataContract]
    class Query
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime? DataExpiryDate { get; set; }
        [DataMember]
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
