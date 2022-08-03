using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
using Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes;
using Compliance.Application.Features.FileResourceTypes.Commands.UpdateFileResourceTypes;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    /// <summary>
    /// File Resource Type Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class FileResourceTypeProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileResourceTypeProfile"/> class.
        /// </summary>
        public FileResourceTypeProfile()
        {
            CreateMap<CreateFileResourceTypesCommand, FileResourceType>();

            CreateMap<FileResourceType, FileResourceTypeCreateResponse>()
             .ForMember(dest => dest.FileResourceTypeId, opt => opt.MapFrom(src => src.FileResourceTypeId));

            CreateMap<FileResourceType, FileResourceTypeResponse>()
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status)); 

            CreateMap<UpdateFileResourceTypesCommand, FileResourceType>();
        }
    }
}
