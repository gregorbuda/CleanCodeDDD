﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.UpdateBatchComplianceSourceTypeMarket
{
    /// <summary>
    /// Update Batch Compliance Source Type Market Command
    /// </summary>
    public class UpdateBatchComplianceSourceTypeMarketCommand
    {
        /// <summary>
        /// Compliance Source Type Market Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Market Id
        /// </value>
        /// <example>1</example>
        [Required]
        public Int32 ComplianceSourceTypeMarketId { get; set; }
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>1</example>
        [Required]
        public int ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Market Id
        /// </summary>
        /// <value>
        /// Market Id
        /// </value>
        /// <example>1</example>
        [Required]
        public int MarketId { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
        [Required]
        public byte Status { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        /// <value>
        /// CreatedBy
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
