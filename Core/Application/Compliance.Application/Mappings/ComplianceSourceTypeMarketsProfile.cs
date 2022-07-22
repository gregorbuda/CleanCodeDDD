using AutoMapper;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateComplianceSourceTypeMarket;
using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Mappings
{
    public class ComplianceSourceTypeMarketsProfile : Profile
    {
        public ComplianceSourceTypeMarketsProfile()
        {
            CreateMap<CreateComplianceSourceTypeMarketCommand, ComplianceSourceTypeMarkets>();

            CreateMap<ComplianceSourceTypeMarkets, ComplianceSourceTypeMarketsCreateResponse>()
            .ForMember(dest => dest.ComplianceSourceTypeMarketId, opt => opt.MapFrom(src => src.ComplianceSourceTypeMarketId));
        }
    }
}
