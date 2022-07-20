using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace xss.ComplianceManagementBackEnd.Entity
{
    public partial class ComplianceDistributorDataLogs
    {
        public int ComplianceDistributorLogId { get; set; }
        public string ComplianceDistributorLogMessage { get; set; }
        public string ComplianceDistributorLogData { get; set; }
        public int ComplianceDistributorDataId { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ComplianceDistributorData ComplianceDistributorData { get; set; }
    }
}
