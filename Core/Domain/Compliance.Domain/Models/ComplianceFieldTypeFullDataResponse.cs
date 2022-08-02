using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Field Type Full Data Response
    /// </summary>
    public class ComplianceFieldTypeFullDataResponse
    {
        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceFieldTypeId { get; set; }
        /// <summary>
        /// Compliance Field Type Name
        /// </summary>
        /// <value>
        /// Compliance Field Type Name
        /// </value>
        /// <example>Test Name</example>
        public String? ComplianceFieldTypeName { get; set; }
        /// <summary>
        /// Translation Key
        /// </summary>
        /// <value>
        /// Translation Key
        /// </value>
        /// <example>1</example>
        public String? TranslationKey { get; set; }
        /// <summary>
        /// Field Path
        /// </summary>
        /// <value>
        /// Field Path
        /// </value>
        /// <example>Test Data</example>
        public String? FieldPath { get; set; }
        /// <summary>
        /// Compliance Field Size Kb
        /// </summary>
        /// <value>
        /// Compliance Field Size Kb
        /// </value>
        /// <example>1</example>
        public Int32? ComplianceFileSizeKb { get; set; }
        /// <summary>
        /// HeightPx
        /// </summary>
        /// <value>
        /// HeightPx
        /// </value>
        /// <example>1</example>
        public Int16? HeightPx { get; set; }
        /// <summary>
        /// WidthPx
        /// </summary>
        /// <value>
        /// WidthPx
        /// </value>
        /// <example>1</example>
        public Int16? WidthPx { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
        public EnumComplianceSourceStatus Status { get; set; }
        /// <summary>
        /// Input Behaviour
        /// </summary>
        /// <value>
        /// Input Behaviour
        /// </value>
        public InputBehaviourResponse? InputBehaviour { get; set; }
        /// <summary>
        /// File Resource Type
        /// </summary>
        /// <value>
        /// File Resource Type
        /// </value>
        public FileResourceTypeResponse? FileResourceType { get; set; }
        /// <summary>
        /// Compliance Field Types
        /// </summary>
        /// <value>
        /// Compliance Field Types
        /// </value>
        public List<ComplianceSourceTypesResponse>? ComplianceSourceTypes { get; set; }
    }
}
