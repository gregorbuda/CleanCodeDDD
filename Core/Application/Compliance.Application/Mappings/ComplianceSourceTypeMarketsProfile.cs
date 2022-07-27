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

            CreateMap<ComplianceSourceTypeMarkets, ComplianceSourceTypeMarketsResponse>()
                .ForMember(dest => dest.ComplianceSourceTypeMarketId, opt => opt.MapFrom(src => src.ComplianceSourceTypeMarketId))
                .ForMember(dest => dest.ComplianceSourceTypeId, opt => opt.MapFrom(src => src.ComplianceSourceTypeId))
                .ForMember(dest => dest.Markets, opt => opt.MapFrom(src => src.Markets))
                .ForMember(dest => dest.ComplianceSourceType, opt => opt.MapFrom(src => src.ComplianceSourceType))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)(EnumComplianceSourceStatus)src.Status));

            CreateMap<Market, MarketResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CurrencySymbol, opt => opt.MapFrom(src => src.CurrencySymbol))
                .ForMember(dest => dest.MarketCurrency, opt => opt.MapFrom(src => src.MarketCurrency))
                .ForMember(dest => dest.MarketName, opt => opt.MapFrom(src => src.MarketName));

        }
    }
}
