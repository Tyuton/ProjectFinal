
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.WCF
{
    [DataContract]
    public class QueryContract
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
        [DataMember]
        public List<PageContract> ListePages { get; set; }

    }

    public class PageContract
    {
        
        public Guid Id { get; set; }
        public virtual QueryContract Query { get; set; }
        public string URL { get; set; }
        public List<SelectorContract> ListeSelectors { get; set; }

    }

    public class SelectorContract
    {
        public Guid Id { get; set; }
        public virtual PageContract Page { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }

    public class ResultsHeaderContract
    {
        public Guid Id { get; set; }
        public virtual SelectorContract Selector { get; set; }
        public DateTime QueryExecutionDate { get; set; }
    }

    public class ResultsDetailContract
    {
        public Guid Id { get; set; }
        public virtual ResultsHeaderContract ResultsHeader { get; set; }
        public string Value { get; set; }
    }
}
