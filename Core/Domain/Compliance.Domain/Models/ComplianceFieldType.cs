using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    public partial class ComplianceFieldType
    {
        public ComplianceFieldType()
        {
            ComplianceSourceTypes = new HashSet<ComplianceSourceTypes>();
        }

        public int ComplianceFieldTypeId { get; set; }
        public string ComplianceFieldTypeName { get; set; }
        public string TranslationKey { get; set; }
        public string FieldPath { get; set; }
        public int? ComplianceFileSizeKb { get; set; }
        public short? HeightPx { get; set; }
        public short? WidthPx { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public int InputBehaviourId { get; set; }
        public virtual InputBehaviour InputBehaviour { get; set; }
        public int FileResourceTypeId { get; set; }
        public virtual FileResourceType FileResourceType { get; set; }
        public virtual ICollection<ComplianceSourceTypes> ComplianceSourceTypes { get; set; }

    }
}
