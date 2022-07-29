using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{

    /// <summary>
    /// Compliance Source Response
    /// </summary>
    public class ComplianceSourceResponse
    {
        
        /// <summary>
        /// The Compliance identifier.
        /// </summary>
        /// <value>
        /// The Compliance identifier.
        /// </value>
        /// <example>1</example>
        public int ComplianceSourceId { get; set; }
        /// <summary>
        /// The Compliance name.
        /// </summary>
        /// <value>
        /// The Compliance name.
        /// </value>
        /// <example>Compliance Name 1</example>
        public string ComplianceSourceName { get; set; }
        /// <summary>
        /// The Compliance Status.
        /// </summary>
        /// <value>
        /// The Compliance Status.
        /// </value>
        /// <example>Active</example>
        public EnumComplianceSourceStatus Status { get; set; }
    }
}
