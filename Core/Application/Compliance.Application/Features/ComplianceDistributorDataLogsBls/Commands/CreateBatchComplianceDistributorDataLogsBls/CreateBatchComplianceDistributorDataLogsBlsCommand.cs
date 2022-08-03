using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls
{

    /// <summary>
    /// Create Batch Compliance Distributor Data Logs Bls Command
    /// </summary>
    public class CreateBatchComplianceDistributorDataLogsBlsCommand
    {
        /// <summary>
        /// Compliance Distributor Log Message
        /// </summary>
        /// <value>
        /// Compliance Distributor Log Message
        /// </value>
        /// <example>Test Message</example>
        [Required]
        public String? ComplianceDistributorLogMessage { get; set; }
        /// <summary>
        /// Compliance Distributor Log Data
        /// </summary>
        /// <value>
        /// Compliance Distributor Log Data
        /// </value>
        /// <example>Test Data</example>
        [Required]
        public String? ComplianceDistributorLogData { get; set; }
        /// <summary>
        /// Compliance Distributor Data Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Id
        /// </value>
        /// <example>Test Data</example>
        [Required]
        public Int32 ComplianceDistributorDataId { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
        [Required]
        public byte Status { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        /// <value>
        /// Created Date
        /// </value>
        /// <example>2022-11-10</example>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        /// <value>
        /// CreatedBy
        /// </value>
        /// <example>1</example>
        public int CreatedBy { get; set; }
        /// <summary>
        /// UpdatedDate
        /// </summary>
        /// <value>
        /// UpdatedDate
        /// </value>
        /// <example>2022-11-10</example>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        /// <value>
        /// UpdatedBy
        /// </value>
        /// <example>1</example>
        public int? UpdatedBy { get; set; }

    }
}
