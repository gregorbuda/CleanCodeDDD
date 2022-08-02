using AutoMapper;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateComplianceSourceTypeMarket;
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

namespace Compliance.UnitTest.Features.ComplianceSourceTypeMarket.Commands.CreateComplianceSourceTypeMarket
{
    public class CreateComplianceSourceTypeMarketXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateComplianceSourceTypeMarketXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceTypeMarketsProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourceTypeMarketRepository.AddDataComplianceSourceTypeMarket(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task CreateComplianceSourceTypeMarket_Return()
        {
            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceSourceTypeMarkets.Where(x => x.ComplianceSourceTypeMarketId == 7).FirstOrDefault();


            var ComplianceSourcesInput = new CreateComplianceSourceTypeMarketCommand
            {
                ComplianceSourceTypeId = Mock.ComplianceSourceTypeId,
                MarketId = 13,
                Status = 1
            };

            var ComplianceSourcesOutput = new CreateComplianceSourceTypeMarketCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceSourcesOutput.Handle(ComplianceSourcesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceSourceTypeMarketsCreateResponse>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
