using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Commands.UpdateComplianceSourceType;
using Compliance.Application.Mappings;
using Compliance.Application.Responses;
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

namespace Compliance.UnitTest.Features.ComplianceSourceType.Commands.UpdateComplianceSourceType
{
    public class UpdateComplianceSourceTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateComplianceSourceTypeXUnitTests()
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
        public async Task UpdateComplianceSourceType_Return()
        {
            var ComplianceSourcesInput = new UpdateComplianceSourceTypeCommand
            {
                ComplianceSourceTypeId = 4,
                ComplianceFieldTypeId = 2,
                ComplianceSourceId = 1,
                DistributorId = 20,
                RequiresCompliance = true,
                ComplianceFileSizeKb = 0,
                HeightPx = 2,
                WidthPx = 1,
                Status = 0

            };

            var ComplianceSourcesOutput = new UpdateComplianceSourceTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceSourcesOutput.Handle(ComplianceSourcesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
