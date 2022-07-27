using AutoMapper;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    public class ComplianceDistributorDataProfile : Profile
    {
        public ComplianceDistributorDataProfile()
        {
            CreateMap<ComplianceDistributorData, ComplianceDistributorDataResponse>()
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));
        }
    }
}
