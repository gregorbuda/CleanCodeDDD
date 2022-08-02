using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{    
    /// <summary>
     /// Compliance Field Type
     /// </summary>
    public partial class ComplianceFieldType
    {
        public ComplianceFieldType()
        {
            ComplianceSourceTypes = new HashSet<ComplianceSourceTypes>();
        }

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
        public String ComplianceFieldTypeName { get; set; }
        /// <summary>
        /// Translation Key
        /// </summary>
        /// <value>
        /// Translation Key
        /// </value>
        /// <example>Test Name</example>
        public String TranslationKey { get; set; }
        /// <summary>
        /// Field Path
        /// </summary>
        /// <value>
        /// Field Path
        /// </value>
        /// <example>Test Path</example>
        public String FieldPath { get; set; }
        /// <summary>
        /// Compliance File Size Kb
        /// </summary>
        /// <value>
        /// Compliance File Size Kb
        /// </value>
        /// <example>750</example>
        public Int32? ComplianceFileSizeKb { get; set; }
        /// <summary>
        /// HeightPx
        /// </summary>
        /// <value>
        /// HeightPx
        /// </value>
        /// <example>3</example>
        public Int16? HeightPx { get; set; }
        /// <summary>
        /// WidthPx
        /// </summary>
        /// <value>
        /// WidthPx
        /// </value>
        /// <example>5</example>
        public Int16? WidthPx { get; set; }
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
        /// Input Behaviour Id
        /// </summary>
        /// <value>
        /// Input Behaviour Id
        /// </value>
        /// <example>Id</example>
        public Int32 InputBehaviourId { get; set; }
        /// <summary>
        /// Input Behaviour
        /// </summary>
        /// <value>
        /// Input Behaviour
        /// </value>
        public virtual InputBehaviour InputBehaviour { get; set; }
        /// <summary>
        /// File Resource Type Id
        /// </summary>
        /// <value>
        /// File Resource Type Id
        /// </value>
        /// <example>1/example>
        public Int32 FileResourceTypeId { get; set; }
        /// <summary>
        /// File Resource Type
        /// </summary>
        /// <value>
        /// File Resource Type
        /// </value>
        public virtual FileResourceType FileResourceType { get; set; }
        /// <summary>
        /// Compliance Source Types
        /// </summary>
        /// <value>
        /// Compliance Source Types
        /// </value>
        public virtual ICollection<ComplianceSourceTypes> ComplianceSourceTypes { get; set; }

    }
}
