using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType
{
    /// <summary>
    /// Update Batch Compliance Field Type Command
    /// </summary>
    public class UpdateBatchComplianceFieldTypeCommand
    {
        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>1</example>
        [Required]
        public Int32 ComplianceFieldTypeId { get; set; }
        /// <summary>
        /// Compliance Field Type Name
        /// </summary>
        /// <value>
        /// Compliance Field Type Name
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string ComplianceFieldTypeName { get; set; } = string.Empty;
        /// <summary>
        /// Translation Key
        /// </summary>
        /// <value>
        /// Translation Key
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string TranslationKey { get; set; } = string.Empty;
        /// <summary>
        /// Field Path
        /// </summary>
        /// <value>
        /// Field Path
        /// </value>
        /// <example>Test Path</example>
        [Required]
        public string FieldPath { get; set; } = string.Empty;
        /// <summary>
        /// Compliance File Size Kb
        /// </summary>
        /// <value>
        /// Compliance File Size Kb
        /// </value>
        /// <example>20</example>
        [Required]
        public int? ComplianceFileSizeKb { get; set; }
        /// <summary>
        /// HeightPx
        /// </summary>
        /// <value>
        /// HeightPx
        /// </value>
        /// <example>20</example>
        [Required]
        public short? HeightPx { get; set; }
        /// <summary>
        /// WidthPx
        /// </summary>
        /// <value>
        /// WidthPx
        /// </value>
        /// <example>20</example>
        [Required]
        public short? WidthPx { get; set; }
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
        /// <summary>
        /// Input Behaviour Id
        /// </summary>
        /// <value>
        /// Input Behaviour Id
        /// </value>
        /// <example>1</example>
        [Required]
        public int InputBehaviourId { get; set; }
        /// <summary>
        /// File Resource Type Id
        /// </summary>
        /// <value>
        /// File Resource Type Id
        /// </value>
        /// <example>1</example>
        [Required]
        public int FileResourceTypeId { get; set; }
    }
}
