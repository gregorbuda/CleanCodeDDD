using AutoMapper;
using Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls;
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

namespace Compliance.UnitTest.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls
{
    public class CreateBatchComplianceDistributorDataLogsBlsXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateBatchComplianceDistributorDataLogsBlsXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceDistributorDataLogsProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceDistributorDataLogsBlsRepository.AddDataInputComplianceDistributorsDataLogsBls(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task CreateBatchComplianceDistributorDataLogsBls_Return()
        {

            CreateBatchComplianceDistributorDataLogsBlsListCommand listComplainceDistributorDataLog = new CreateBatchComplianceDistributorDataLogsBlsListCommand();
            CreateBatchComplianceDistributorDataLogsBlsCommand? createBatchComplainceDistributorDataLogCommand = new CreateBatchComplianceDistributorDataLogsBlsCommand();

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceDistributorDataLogs.Where(x => x.ComplianceDistributorLogId == 1).FirstOrDefault();

            createBatchComplainceDistributorDataLogCommand.ComplianceDistributorLogMessage = "Test Test";
            createBatchComplainceDistributorDataLogCommand.ComplianceDistributorLogData = "Test Second";
            createBatchComplainceDistributorDataLogCommand.ComplianceDistributorDataId = Mock.ComplianceDistributorDataId;
            createBatchComplainceDistributorDataLogCommand.Status = 1;
            createBatchComplainceDistributorDataLogCommand.CreatedBy = 1;
            createBatchComplainceDistributorDataLogCommand.CreatedDate = DateTime.Today;
            createBatchComplainceDistributorDataLogCommand.UpdatedBy = 1;
            createBatchComplainceDistributorDataLogCommand.UpdatedDate = DateTime.Today;

            List<CreateBatchComplianceDistributorDataLogsBlsCommand> List = new List<CreateBatchComplianceDistributorDataLogsBlsCommand>();

            List.Add(createBatchComplainceDistributorDataLogCommand);

            listComplainceDistributorDataLog.complianceDistributorDataLogs = List;

            var ComplainceFieldTypeOutput = new CreateBatchComplianceDistributorDataLogsBlsCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceFieldTypeOutput.Handle(listComplainceDistributorDataLog, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult ==  StatusCodes.Status200OK.ToString());
        }
    }
}
