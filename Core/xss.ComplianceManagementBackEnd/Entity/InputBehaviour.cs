using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace xss.ComplianceManagementBackEnd.Entity
{
    public partial class InputBehaviour
    {
        public InputBehaviour()
        {
            ComplianceFieldType = new HashSet<ComplianceFieldType>();
        }

        public int InputBehaviourId { get; set; }
        public string InputBehaviourName { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<ComplianceFieldType> ComplianceFieldType { get; set; }
    }
}
