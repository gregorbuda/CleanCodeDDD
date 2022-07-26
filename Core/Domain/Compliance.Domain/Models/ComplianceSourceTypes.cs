using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    public partial class ComplianceSourceTypes
    {
        public int ComplianceSourceTypeId { get; set; }
        public int ComplianceSourceId { get; set; }
        public int ComplianceFieldTypeId { get; set; }
        public int DistributorId { get; set; }
        public bool RequiresCompliance { get; set; }
        public int? ComplianceFileSizeKb { get; set; }
        public short? HeightPx { get; set; }
        public short? WidthPx { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public byte Status { get; set; }

        public virtual ComplianceFieldType ComplianceFieldType { get; set; }
        public virtual ComplianceSource ComplianceSource { get; set; }
        public virtual ICollection<ComplianceSourceTypeMarkets> ComplianceSourceTypeMarkets { get; set; }
        public virtual ICollection<ComplianceDistributorData> ComplianceDistributorData { get; set; }
    }
}
