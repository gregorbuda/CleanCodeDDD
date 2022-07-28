using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    public partial class ComplianceSource
    {
        public ComplianceSource()
        {
            ComplianceSourceTypes = new HashSet<ComplianceSourceTypes>();
        }

        [Key]
        public int ComplianceSourceId { get; set; }
        public string ComplianceSourceName { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<ComplianceSourceTypes> ComplianceSourceTypes { get; set; }
    }
}
