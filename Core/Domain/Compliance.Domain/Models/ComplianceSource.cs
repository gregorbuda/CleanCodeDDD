using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Source
    /// </summary>
    public partial class ComplianceSource
    {
        public ComplianceSource()
        {
            ComplianceSourceTypes = new HashSet<ComplianceSourceTypes>();
        }

        /// <summary>
        /// Compliance Source  Id
        /// </summary>
        /// <value>
        /// Compliance Source  Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceId { get; set; }
        /// <summary>
        /// Compliance Source Name
        /// </summary>
        /// <value>
        /// Compliance Source Name
        /// </value>
        /// <example>Test Name</example>
        public String ComplianceSourceName { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
        public byte Status { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        /// <value>
        /// Created Date
        /// </value>
        /// <example>2022-10-10</example>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Created By
        /// </summary>
        /// <value>
        /// Created By
        /// </value>
        /// <example>1</example>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Updated Date
        /// </summary>
        /// <value>
        /// Updated Date
        /// </value>
        /// <example>2022-10-10</example>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// Updated By
        /// </summary>
        /// <value>
        /// Updated By
        /// </value>
        /// <example>1</example>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// Compliance Source Types
        /// </summary>
        /// <value>
        /// Compliance Source Types
        /// </value>
        public virtual ICollection<ComplianceSourceTypes> ComplianceSourceTypes { get; set; }
    }
}
