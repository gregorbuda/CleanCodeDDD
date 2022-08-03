using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    /// <summary>
    /// Compliance Source Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ComplianceSourceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceSourceProfile"/> class.
        /// </summary>
        public ComplianceSourceProfile()
        {
            CreateMap<CreateComplianceSourceCommand, ComplianceSource>();

            CreateMap<ComplianceSource, ComplianceSourceCreateResponse>()
             .ForMember(dest => dest.ComplianceSourceId, opt => opt.MapFrom(src => src.ComplianceSourceId));

            CreateMap<ComplianceSource, ComplianceSourceResponse>()
                .ForMember(dest => dest.ComplianceSourceId, opt => opt.MapFrom(src => src.ComplianceSourceId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));


            CreateMap<UpdateComplianceSourceCommand, ComplianceSource>();
        }
    }
}
