using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Commands.CreateComplianceSourceType;
using Compliance.Application.Mappings;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Repositories;
using Compliance.UnitTest.Mock;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Compliance.UnitTest.Features.ComplianceSourceType.Commands.CreateComplianceSourceType
{
    public class CreateComplianceSourceTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateComplianceSourceTypeXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceTypesProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourceTypeRepository.AddDataInputComplianceSourceType(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task CreateComplianceSourceType_Return()
        {
            var ComplianceSourcesInput = new CreateComplianceSourceTypeCommand
            {
                ComplianceFieldTypeId =2,
                ComplianceSourceId = 1,      
                DistributorId = 20,       
                RequiresCompliance = true,       
                ComplianceFileSizeKb = 0,     
                HeightPx = 2,
                WidthPx = 1,
                Status = 0

                };

            var ComplianceSourcesOutput = new CreateComplianceSourceTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceSourcesOutput.Handle(ComplianceSourcesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceSourceTypeCreateResponse>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
