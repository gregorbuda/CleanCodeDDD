using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Source Type Markets Response
    /// </summary>
    public class ComplianceSourceTypeMarketsResponse
    {
        /// <summary>
        /// Compliance Source Type Market Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Market Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceTypeMarketId { get; set; }
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Market Id
        /// </summary>
        /// <value>
        /// Market Id
        /// </value>
        /// <example>1</example>
        public Int32 MarketId { get; set; }
        /// <summary>
        /// Compliance Source Type
        /// </summary>
        /// <value>
        /// Compliance Source Type
        /// </value>
        public ComplianceSourceTypesResponse? ComplianceSourceType { get; set; }
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
