using AutoMapper;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateBatchComplianceSourceTypeMarket;
using Compliance.Application.Mappings;
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

namespace Compliance.UnitTest.Features.ComplianceSourceTypeMarket.Commands.CreateBatchComplianceSourceTypeMarket
{
    public class CreateBatchComplianceSourceTypeMarketXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateBatchComplianceSourceTypeMarketXUnitTests()
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
        public async Task CreateBacthComplianceSourceTypeMarket_Return()
        {
            CreateBatchComplianceSourceTypeMarketListCommand listComplianceSourceTypeMarket = new CreateBatchComplianceSourceTypeMarketListCommand();
            CreateBatchComplianceSourceTypeMarketCommand? createBatchComplianceSourceTypeMarketCommand = new CreateBatchComplianceSourceTypeMarketCommand();

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceSourceTypeMarkets.Where(x => x.ComplianceSourceTypeMarketId == 7).FirstOrDefault();

            createBatchComplianceSourceTypeMarketCommand.ComplianceSourceTypeId = Mock.ComplianceSourceTypeId;
            createBatchComplianceSourceTypeMarketCommand.MarketId = 13;
            createBatchComplianceSourceTypeMarketCommand.Status = 1;
            createBatchComplianceSourceTypeMarketCommand.CreatedBy = 1;
            createBatchComplianceSourceTypeMarketCommand.CreatedDate = DateTime.Today;
            createBatchComplianceSourceTypeMarketCommand.UpdatedBy = 1;
            createBatchComplianceSourceTypeMarketCommand.UpdatedDate = DateTime.Today;

            List<CreateBatchComplianceSourceTypeMarketCommand> List = new List<CreateBatchComplianceSourceTypeMarketCommand>();

            List.Add(createBatchComplianceSourceTypeMarketCommand);

            listComplianceSourceTypeMarket.ComplainceSourcesTypeMarket = List;

            var ComplainceSourcesOutput = new CreateBatchComplianceSourceTypeMarketCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceSourcesOutput.Handle(listComplianceSourceTypeMarket, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
