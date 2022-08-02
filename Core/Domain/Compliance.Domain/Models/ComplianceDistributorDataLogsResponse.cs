using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Distributor Data Logs Response
    /// </summary>
    public class ComplianceDistributorDataLogsResponse
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
        /// <example>Test</example>
        public String? ComplianceDistributorLogMessage { get; set; }
        /// <summary>
        /// Compliance Distributor Data 
        /// </summary>
        /// <value>
        /// Compliance Distributor Data 
        /// </value>
        /// <example>Test Data</example>
        public String? ComplianceDistributorLogData { get; set; }
        /// <summary>
        /// Compliance Distributor Data Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Id
        /// </value>
        /// <example>2</example>
        public Int32 ComplianceDistributorDataId { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>2</example>
        public byte Status { get; set; }
    }
}
