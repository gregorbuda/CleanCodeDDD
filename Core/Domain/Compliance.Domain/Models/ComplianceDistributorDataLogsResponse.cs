using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    public class ComplianceDistributorDataLogsResponse
    {
        public int ComplianceDistributorLogId { get; set; }
        public string ComplianceDistributorLogMessage { get; set; }
        public string ComplianceDistributorLogData { get; set; }
        public int ComplianceDistributorDataId { get; set; }
        public byte Status { get; set; }
    }
}
