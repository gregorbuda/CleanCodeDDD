using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Mappings;
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

namespace Compliance.UnitTest.Features.ComplianceSources.Commands.CreateComplianceSources

{
    public class CreateComplianceSourcesXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateComplianceSourcesXUnitTests()
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
        public async Task CreateComplianceSource_Return()
        {

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceSourceTypeMarkets.Where(x => x.ComplianceSourceTypeMarketId == 7).FirstOrDefault();


            var ComplianceSourcesInput = new CreateComplianceSourceCommand
            {
                ComplianceSourceName = "Test",
                Status = 1
            };

            var ComplianceSourcesOutput = new CreateComplianceSourceCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceSourcesOutput.Handle(ComplianceSourcesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceSourceCreateResponse>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
