﻿using AutoMapper;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.UpdateBatchComplianceSourceTypeMarket;
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

namespace Compliance.UnitTest.Features.ComplianceSourceTypeMarket.Commands.UpdateComplianceSourceTypeMarket
{
    public class UpdateBacthComplianceSourceTypeMarketXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBacthComplianceSourceTypeMarketXUnitTests()
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
        public async Task UpdateBacthComplianceSourceTypeMarket_Return()
        {
            UpdateBatchComplianceSourceTypeMarketListCommand listComplianceSourceTypeMarket = new UpdateBatchComplianceSourceTypeMarketListCommand();
            UpdateBatchComplianceSourceTypeMarketCommand? updateBatchComplianceSourceTypeMarketCommand = new UpdateBatchComplianceSourceTypeMarketCommand();

            updateBatchComplianceSourceTypeMarketCommand.ComplianceSourceTypeMarketId = 7;
            updateBatchComplianceSourceTypeMarketCommand.MarketId = 13;
            updateBatchComplianceSourceTypeMarketCommand.Status = 1;
            updateBatchComplianceSourceTypeMarketCommand.CreatedBy = 1;
            updateBatchComplianceSourceTypeMarketCommand.CreatedDate = DateTime.Today;
            updateBatchComplianceSourceTypeMarketCommand.UpdatedBy = 1;
            updateBatchComplianceSourceTypeMarketCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchComplianceSourceTypeMarketCommand> List = new List<UpdateBatchComplianceSourceTypeMarketCommand>();

            List.Add(updateBatchComplianceSourceTypeMarketCommand);

            listComplianceSourceTypeMarket.ComplainceSourcesTypeMarket = List;

            var ComplainceSourcesOutput = new UpdateBatchComplianceSourceTypeMarketCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceSourcesOutput.Handle(listComplianceSourceTypeMarket, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
