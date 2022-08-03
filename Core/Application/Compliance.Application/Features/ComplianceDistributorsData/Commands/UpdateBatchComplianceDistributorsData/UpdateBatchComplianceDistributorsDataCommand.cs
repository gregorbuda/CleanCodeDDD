using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData
{
    /// <summary>
    /// Update Batch  Compliance Distributor Data Command
    /// </summary>
    public class UpdateBatchComplianceDistributorsDataCommand
    {
        /// <summary>
        /// Compliance Distributor Data Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Id
        /// </value>
        /// <example>2</example>
        [Required]
        public Int32 ComplianceDistributorDataId { get; set; }
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>2</example>
        [Required]
        public Int32 ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Distributor  Id
        /// </summary>
        /// <value>
        /// Distributor  Id
        /// </value>
        /// <example>2</example>
        [Required]
        public Int32 DistributorId { get; set; }
        /// <summary>
        /// FieldData
        /// </summary>
        /// <value>
        /// FieldData
        /// </value>
        /// <example>Test Data</example>
        [Required]
        public String FieldData { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>2</example>
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
