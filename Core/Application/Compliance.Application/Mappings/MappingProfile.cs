using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xss.ComplianceManagementBackEnd.Entity;

namespace Compliance.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateComplianceSourceCommand, ComplianceSource>();
        }
    }
}
