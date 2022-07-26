using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    public class ComplianceSourceProfile : Profile
    {
        public ComplianceSourceProfile()
        {
            CreateMap<CreateComplianceSourceCommand, ComplianceSource>();

            CreateMap<ComplianceSource, ComplianceSourceCreateResponse>()
             .ForMember(dest => dest.ComplianceSourceId, opt => opt.MapFrom(src => src.ComplianceSourceId));

            CreateMap<ComplianceSource, ComplianceSourceResponse>()
                .ForMember(dest => dest.ComplianceSourceId, opt => opt.MapFrom(src => src.ComplianceSourceId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));

            CreateMap<ComplianceSourceTypes, ComplianceSourceTypesResponse>();

            CreateMap<UpdateComplianceSourceCommand, ComplianceSource>();
        }
    }
}
