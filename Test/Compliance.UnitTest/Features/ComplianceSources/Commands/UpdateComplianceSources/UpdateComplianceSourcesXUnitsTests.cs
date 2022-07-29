using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
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

namespace Compliance.UnitTest.Features.ComplianceSources.Commands.UpdateComplianceSources
{
    public class UpdateComplianceSourcesXUnitsTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateComplianceSourcesXUnitsTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourcesRepository.AddDataInputComplianceSources(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task UpdateComplianceSource_Return()
        {
            var ComplianceSourcesInput = new UpdateComplianceSourceCommand
            {
                ComplianceSourceId = 1,
                ComplianceSourceName = "Test",
                Status = 1
            };

            var ComplianceSourcesOutput = new UpdateComplianceSourceCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceSourcesOutput.Handle(ComplianceSourcesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
