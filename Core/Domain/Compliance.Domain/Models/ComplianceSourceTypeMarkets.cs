using System;
using System.Collections.Generic;
using System.Text;

namespace Compliance.Domain.Models
{    
    /// <summary>
     /// Compliance Source Type Markets
     /// </summary>
    public class ComplianceSourceTypeMarkets
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
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
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
        /// Compliance Distributor DataI Id
        /// </summary>
        /// <value>
        /// Compliance Distributor DataI Id
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
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Compliance Source Type
        /// </summary>
        /// <value>
        /// Compliance Source Type
        /// </value>
        public ComplianceSourceTypes ComplianceSourceType { get; set; }
        /// <summary>
        /// Market Id
        /// </summary>
        /// <value>
        /// Market Id
        /// </value>
        /// <example>1</example>
        public Int32 MarketId { get; set; }

    }
}
