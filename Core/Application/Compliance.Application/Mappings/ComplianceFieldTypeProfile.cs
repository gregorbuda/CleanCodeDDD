﻿using AutoMapper;
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
    public class ComplianceFieldTypeProfile : Profile
    {
        public ComplianceFieldTypeProfile()
        {
            CreateMap<CreateComplianceFieldTypeCommand, ComplianceFieldType>();

            CreateMap<ComplianceFieldType, ComplianceFieldTypeCreateResponse>()
                .ForMember(dest => dest.ComplianceFieldTypeId, opt => opt.MapFrom(src => src.ComplianceFieldTypeId));

            CreateMap<ComplianceFieldType, ComplianceSourceResponse>()
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
