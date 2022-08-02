using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Compliance Source Types Full Data Response
    /// </summary>
    public class ComplianceSourceTypesFullDataResponse
    {
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Compliance Source  Id
        /// </summary>
        /// <value>
        /// Compliance Source  Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceSourceId { get; set; }
        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>1</example>
        public Int32 ComplianceFieldTypeId { get; set; }
        /// <summary>
        /// Distributor Id
        /// </summary>
        /// <value>
        /// Distributor Id
        /// </value>
        /// <example>1</example>
        public Int32 DistributorId { get; set; }
        /// <summary>
        /// Requires Compliance
        /// </summary>
        /// <value>
        /// Requires Compliance
        /// </value>
        /// <example>True</example>
        public Boolean RequiresCompliance { get; set; }
        /// <summary>
        /// Compliance File Size Kb
        /// </summary>
        /// <value>
        /// Compliance File Size Kb
        /// </value>
        /// <example>10</example>
        public Int32? ComplianceFileSizeKb { get; set; }
        /// <summary>
        /// Height Px
        /// </summary>
        /// <value>
        /// Height Px
        /// </value>
        /// <example>19</example>
        public Int16? HeightPx { get; set; }
        /// <summary>
        /// Width Px
        /// </summary>
        /// <value>
        /// Width Px
        /// </value>
        /// <example>19</example>
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
        /// Compliance Field Type
        /// </summary>
        /// <value>
        /// Compliance Field Type
        /// </value>
        public ComplianceFieldTypeResponse? ComplianceFieldType { get; set; }
        /// <summary>
        /// Compliance Source
        /// </summary>
        /// <value>
        /// Compliance Source
        /// </value>
        public ComplianceSourceResponse? ComplianceSource { get; set; }
        /// <summary>
        /// List Compliance Source Type Markets
        /// </summary>
        /// <value>
        /// List Compliance Source Type Markets
        /// </value>
        public List<ComplianceSourceTypeMarketsResponse>? ComplianceSourceTypeMarkets { get; set; }
        /// <summary>
        /// List Compliance Distributor Data
        /// </summary>
        /// <value>
        /// List Compliance Distributor Data
        /// </value>
        public List<ComplianceDistributorDataResponse>? ComplianceDistributorData { get; set; }

    }
}
