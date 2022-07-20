using System;
using System.Collections.Generic;

namespace Compliance.Domain.Models
{
    public partial class ComplianceDistributorData
    {
        public ComplianceDistributorData()
        {
            ComplianceDistributorDataLogs = new HashSet<ComplianceDistributorDataLogs>();
        }

        public int ComplianceDistributorDataId { get; set; }
        public int ComplianceSourceTypeId { get; set; }
        public int DistributorId { get; set; }
        public string FieldData { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ComplianceSourceTypes ComplianceSourceType { get; set; }
        public virtual ICollection<ComplianceDistributorDataLogs> ComplianceDistributorDataLogs { get; set; }
    }
}
