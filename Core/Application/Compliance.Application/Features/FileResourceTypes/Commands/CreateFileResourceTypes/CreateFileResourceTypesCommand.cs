
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes
{
    /// <summary>
    /// Create File Resource Types Command
    /// </summary>
    public class CreateFileResourceTypesCommand : IRequest<ApiResponse<FileResourceTypeCreateResponse>>
    {
        /// <summary>
        /// Name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Translation Key
        /// </summary>
        /// <value>
        /// Translation Key
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string TranslationKey { get; set; } = string.Empty;
        /// <summary>
        /// Description
        /// </summary>
        /// <value>
        /// Description
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// MaxSize
        /// </summary>
        /// <value>
        /// MaxSize
        /// </value>
        /// <example>1</example>
        [Required]
        public int MaxSize { get; set; }
        /// <summary>
        /// CreatedDate
        /// </summary>
        /// <value>
        /// CreatedDate
        /// </value>
        /// <example>2022-11-10</example>
        public DateTime CreatedDate { get; set; }
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
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
        public int Status { get; set; }
    }
}
