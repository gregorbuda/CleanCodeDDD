
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Compliance.Application.Features.InputBehaviours.Commands.DeleteInputBehaviours
{
    /// <summary>
    /// Delete Input Behaviours Command
    /// </summary>
    public class DeleteInputBehavioursCommand : IRequest<ApiResponse<Boolean>>
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
    }
}
