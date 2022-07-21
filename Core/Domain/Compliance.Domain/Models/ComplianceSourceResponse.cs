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
        public byte Status { get; set; }
        /// <summary>
        /// The update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        /// <example>2022-05-09T12:20:19Z</example>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// The update by.
        /// </summary>
        /// <value>
        /// The update by.
        /// </value>
        /// <example>99</example>
        public int? UpdatedBy { get; set; }
        /// <summary>
        /// The create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        /// <example>2022-05-09T12:20:19Z</example>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The create by.
        /// </summary>
        /// <value>
        /// The create by.
        /// </value>
        /// <example>99</example>
        public int? CreatedBy { get; set; }

    }
}
