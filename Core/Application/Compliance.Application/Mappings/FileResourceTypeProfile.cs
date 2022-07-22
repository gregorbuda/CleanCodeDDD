using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
using Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes;
using Compliance.Application.Features.FileResourceTypes.Commands.UpdateFileResourceTypes;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    public class FileResourceTypeProfile : Profile
    {
        public FileResourceTypeProfile()
        {
            CreateMap<CreateFileResourceTypesCommand, FileResourceType>();

            CreateMap<FileResourceType, FileResourceTypeCreateResponse>()
             .ForMember(dest => dest.FileResourceTypeId, opt => opt.MapFrom(src => src.FileResourceTypeId));

            CreateMap<FileResourceType, FileResourceTypeResponse>();

            CreateMap<UpdateFileResourceTypesCommand, FileResourceType>();
        }
    }
}
