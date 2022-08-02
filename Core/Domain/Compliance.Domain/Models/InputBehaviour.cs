using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Input Behaviour
    /// </summary>
    public partial class InputBehaviour
    {
        public InputBehaviour()
        {
            ComplianceFieldType = new HashSet<ComplianceFieldType>();
        }
        /// <summary>
        /// Input Behaviour Id
        /// </summary>
        /// <value>
        /// Input Behaviour Id
        /// </value>
        /// <example>1</example>      
        public Int32 InputBehaviourId { get; set; }
        /// <summary>
        /// Input Behaviour Name
        /// </summary>
        /// <value>
        /// Input Behaviour Name
        /// </value>
        /// <example>Test Input Behaviour</example>   
        public String InputBehaviourName { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>  
        public byte Status { get; set; }
        /// <summary>
        /// Created By
        /// </summary>
        /// <value>
        /// Created By
        /// </value>
        /// <example>1</example>
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
        /// Compliance Field Type
        /// </summary>
        /// <value>
        /// Compliance Field Type
        /// </value>
        public virtual ICollection<ComplianceFieldType> ComplianceFieldType { get; set; }
    }
}
