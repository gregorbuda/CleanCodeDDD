﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours
{
    /// <summary>
    /// Update Batch Input Behaviours Command
    /// </summary>
    public class UpdateBatchInputBehavioursCommand
    {
        /// <summary>
        /// Input Behaviour Id
        /// </summary>
        /// <value>
        /// Input Behaviour Id
        /// </value>
        /// <example>1</example>
        [Required]
        public Int32 InputBehaviourId { get; set; }
        /// <summary>
        /// Input Behaviour Name
        /// </summary>
        /// <value>
        /// Input Behaviour Name
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string InputBehaviourName { get; set; } = string.Empty;
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
        /// CreatedDate
        /// </summary>
        /// <value>
        /// CreatedDate
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
