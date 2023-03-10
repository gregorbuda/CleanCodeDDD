using AutoMapper;
using Compliance.Domain.Models;


namespace Compliance.Application.Mappings
{
    /// <summary>
    /// Compliance Distributor Data Logs Profile AutoMapper
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ComplianceDistributorDataLogsProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceDistributorDataLogsProfile"/> class.
        /// </summary>
        public ComplianceDistributorDataLogsProfile()
        {
            CreateMap<ComplianceDistributorDataLogs, ComplianceDistributorDataLogsResponse>()
                 .ForMember(dest => dest.ComplianceDistributorDataId, opt => opt.MapFrom(src => src.ComplianceDistributorDataId))
                 .ForMember(dest => dest.ComplianceDistributorLogMessage, opt => opt.MapFrom(src => src.ComplianceDistributorLogMessage))
                 .ForMember(dest => dest.ComplianceDistributorLogData, opt => opt.MapFrom(src => src.ComplianceDistributorLogData))
                 .ForMember(dest => dest.ComplianceDistributorLogId, opt => opt.MapFrom(src => src.ComplianceDistributorLogId))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));
        }
    }
}
