using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class ComplianceSourceTypeMarketsResponse
    {
        public int ComplianceSourceTypeMarketId { get; set; }
        public int ComplianceSourceTypeId { get; set; }
        public MarketResponse Markets { get; set; }
        public ComplianceSourceTypesResponse ComplianceSourceType { get; set; }
        public byte Status { get; set; }
    }
}
