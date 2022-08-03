using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Compliance.Application.Features.FileResourceTypes.Commands.DeleteFileResourceTypes
{
    /// <summary>
    /// Create File Resource Types Command
    /// </summary>
    public class DeleteFileResourceTypesCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// File Resource Type Id
        /// </summary>
        /// <value>
        /// File Resource Type Id
        /// </value>
        /// <example>1</example>
        [Required]
        public Int32 FileResourceTypeId { get; set; }
    }
}
