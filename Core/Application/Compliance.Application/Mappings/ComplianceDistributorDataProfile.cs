using AutoMapper;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    /// <summary>
    /// Compliance Distributor Data  Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ComplianceDistributorDataProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceDistributorDataProfile"/> class.
        /// </summary>
        public ComplianceDistributorDataProfile()
        {
            CreateMap<ComplianceDistributorData, ComplianceDistributorDataResponse>()
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));
        }
    }
}
