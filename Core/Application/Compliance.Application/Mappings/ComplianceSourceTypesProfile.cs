using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Commands.CreateComplianceSourceType;
using Compliance.Application.Features.ComplianceSourceType.Commands.UpdateComplianceSourceType;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    public class ComplianceSourceTypesProfile : Profile
    {
        public ComplianceSourceTypesProfile()
        {
            CreateMap<CreateComplianceSourceTypeCommand, ComplianceSourceTypes>();

            CreateMap<ComplianceSourceTypes, ComplianceSourceTypeCreateResponse>()
            .ForMember(dest => dest.ComplianceSourceTypeId, opt => opt.MapFrom(src => src.ComplianceSourceTypeId));

            CreateMap<ComplianceSourceTypes, ComplianceSourceTypesResponse>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));

            CreateMap<ComplianceSourceTypes, ComplianceSourceTypesFullDataResponse>()
                .ForMember(dest => dest.ComplianceFieldType, opt => opt.MapFrom(src => src.ComplianceFieldType))
                .ForMember(dest => dest.ComplianceSource, opt => opt.MapFrom(src => src.ComplianceSource))
                .ForMember(dest => dest.ComplianceSourceTypeMarkets, opt => opt.MapFrom(src => src.ComplianceSourceTypeMarkets))
                .ForMember(dest => dest.ComplianceDistributorData, opt => opt.MapFrom(src => src.ComplianceDistributorData))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));


            CreateMap<UpdateComplianceSourceTypeCommand, ComplianceSourceTypes>();
        }
    }
}
