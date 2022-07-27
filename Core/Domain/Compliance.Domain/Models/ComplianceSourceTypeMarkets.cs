using System;
using System.Collections.Generic;
using System.Text;

namespace Compliance.Domain.Models
{
    public class ComplianceSourceTypeMarkets
    {
        public int ComplianceSourceTypeMarketId { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public int ComplianceSourceTypeId { get; set; }
        public ComplianceSourceTypes ComplianceSourceType { get; set; }
        public int MarketId { get; set; }
        public Market Markets { get; set; }
    }
}
