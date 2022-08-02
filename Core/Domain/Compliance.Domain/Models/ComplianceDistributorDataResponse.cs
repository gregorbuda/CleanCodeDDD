using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Distributor Data  Response
    /// </summary>
    public class ComplianceDistributorDataResponse
    {
        /// <summary>
        /// Compliance Distributor Data  Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data  Id
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
        /// <example>10</example>
        public Int32 DistributorId { get; set; }
        /// <summary>
        /// Field Data
        /// </summary>
        /// <value>
        /// Field Data
        /// </value>
        /// <example>Test Data</example>
        public String FieldData { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
        public byte Status { get; set; }
    }
}
