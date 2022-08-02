using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Distributor Data Logs
    /// </summary>
    public partial class ComplianceDistributorDataLogs
    {
        /// <summary>
        /// Compliance Distributor Data Log Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Log Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceDistributorLogId { get; set; }
        /// <summary>
        /// Compliance Distributor Data Log Message
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Log Message
        /// </value>
        /// <example>1</example>
        public String? ComplianceDistributorLogMessage { get; set; }
        /// <summary>
        /// Compliance Distributor Data Log Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Log Id
        /// </value>
        /// <example>1</example>
        public String? ComplianceDistributorLogData { get; set; }
        /// <summary>
        /// Compliance Distributor Data  Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data  Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceDistributorDataId { get; set; }
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
        /// Update Date
        /// </summary>
        /// <value>
        /// Update Date
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
        /// Compliance Distributor Data
        /// </summary>
        /// <value>
        /// Compliance Distributor Data
        /// </value>
        public virtual ComplianceDistributorData ComplianceDistributorData { get; set; }
    }
}
