using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes
{
    public class CreateFileResourceTypesCommand : IRequest<ApiResponse<FileResourceTypeCreateResponse>>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string TranslationKey { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int MaxSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int Status { get; set; }
    }
}
