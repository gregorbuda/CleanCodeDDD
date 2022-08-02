using AutoMapper;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.CreateComplianceFieldType;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateComplianceFieldType;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    /// <summary>
    /// Compliance Field Type Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ComplianceFieldTypeProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceFieldTypeProfile"/> class.
        /// </summary>
        public ComplianceFieldTypeProfile()
        {
            CreateMap<CreateComplianceFieldTypeCommand, ComplianceFieldType>();

            CreateMap<ComplianceFieldType, ComplianceFieldTypeCreateResponse>()
                .ForMember(dest => dest.ComplianceFieldTypeId, opt => opt.MapFrom(src => src.ComplianceFieldTypeId));

            CreateMap<ComplianceFieldType, ComplianceFieldTypeResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));

            CreateMap<UpdateComplianceFieldTypeCommand, ComplianceFieldType>();

            CreateMap<ComplianceFieldType, ComplianceFieldTypeFullDataResponse>()
                .ForMember(dest => dest.FileResourceType, opt => opt.MapFrom(src => src.FileResourceType))
                .ForMember(dest => dest.InputBehaviour, opt => opt.MapFrom(src => src.InputBehaviour))
                .ForMember(dest => dest.ComplianceSourceTypes, opt => opt.MapFrom(src => src.ComplianceSourceTypes))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));

        }
    }
}
