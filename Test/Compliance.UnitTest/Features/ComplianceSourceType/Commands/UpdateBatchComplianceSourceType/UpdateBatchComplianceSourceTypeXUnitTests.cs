using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Commands.UpdateBatchComplianceSourceType;
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

namespace Compliance.UnitTest.Features.ComplianceSourceType.Commands.UpdateBatchComplianceSourceType
{
    public class UpdateBatchComplianceSourceTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBatchComplianceSourceTypeXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceTypesProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourceTypeMarketRepository.AddDataComplianceSourceTypeMarket(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task UpdateBacthComplianceSourceType_Return()
        {
            UpdateBatchComplianceSourceTypeListCommand listComplianceSourceType = new UpdateBatchComplianceSourceTypeListCommand();
            UpdateBatchComplianceSourceTypeCommand? updateBatchComplianceSourceTypeCommand = new UpdateBatchComplianceSourceTypeCommand();

            updateBatchComplianceSourceTypeCommand.ComplianceSourceTypeId = 4;
            updateBatchComplianceSourceTypeCommand.ComplianceSourceId = 5;
            updateBatchComplianceSourceTypeCommand.ComplianceFieldTypeId = 2;
            updateBatchComplianceSourceTypeCommand.DistributorId = 20;
            updateBatchComplianceSourceTypeCommand.RequiresCompliance = true;
            updateBatchComplianceSourceTypeCommand.ComplianceFileSizeKb = 13;
            updateBatchComplianceSourceTypeCommand.HeightPx = 13;
            updateBatchComplianceSourceTypeCommand.WidthPx = 13;
            updateBatchComplianceSourceTypeCommand.Status = 1;
            updateBatchComplianceSourceTypeCommand.CreatedBy = 1;
            updateBatchComplianceSourceTypeCommand.CreatedDate = DateTime.Today;
            updateBatchComplianceSourceTypeCommand.UpdatedBy = 1;
            updateBatchComplianceSourceTypeCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchComplianceSourceTypeCommand> List = new List<UpdateBatchComplianceSourceTypeCommand>();

            List.Add(updateBatchComplianceSourceTypeCommand);

            listComplianceSourceType.ComplainceSourcesType = List;

            var ComplainceSourcesOutput = new UpdateBatchComplianceSourceTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceSourcesOutput.Handle(listComplianceSourceType, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
