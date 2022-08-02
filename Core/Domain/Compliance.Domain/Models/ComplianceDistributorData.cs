using System;
using System.Collections.Generic;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Distributor Data
    /// </summary>
    public partial class ComplianceDistributorData
    {
        public ComplianceDistributorData()
        {
            ComplianceDistributorDataLogs = new HashSet<ComplianceDistributorDataLogs>();
        }

        /// <summary>
        /// Compliance Distributor DataI Id
        /// </summary>
        /// <value>
        /// Compliance Distributor DataI Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceDistributorDataId { get; set; }
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Distributor Id
        /// </summary>
        /// <value>
        /// Distributor Id
        /// </value>
        /// <example>20</example>
        public Int32 DistributorId { get; set; }
        /// <summary>
        /// Field Data
        /// </summary>
        /// <value>
        /// Field Data
        /// </value>
        /// <example>Test</example>
        public string FieldData { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>2</example>
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
        /// <example>2</example>
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
        /// <example>2</example>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// ComplianceSource Type
        /// </summary>
        /// <value>
        /// ComplianceSource Type
        /// </value>
        public virtual ComplianceSourceTypes ComplianceSourceType { get; set; }
        /// <summary>
        /// List Compliance Distributor Data Logs
        /// </summary>
        /// <value>
        /// List Compliance Distributor Data Logs
        /// </value>
        public virtual ICollection<ComplianceDistributorDataLogs> ComplianceDistributorDataLogs { get; set; }
    }
}
