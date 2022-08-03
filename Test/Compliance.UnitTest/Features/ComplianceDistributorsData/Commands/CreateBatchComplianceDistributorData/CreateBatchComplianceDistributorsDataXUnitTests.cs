using AutoMapper;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData;
using Compliance.Application.Mappings;
using Compliance.Infrastructure.Repositories;
using Compliance.UnitTest.Mock;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Compliance.UnitTest.Features.ComplianceDistributorsData.Commands.CreateComplianceDistributorsData
{
    public class CreateBatchComplianceDistributorsDataXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateBatchComplianceDistributorsDataXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceDistributorDataProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceDistributorsDataRepository.AddDataInputComplianceDistributorsData(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task CreateBatchComplianceDistributorData_Return()
        {

            CreateBatchComplianceDistributorDataListCommand listComplainceDistributorData = new CreateBatchComplianceDistributorDataListCommand();
            CreateBatchComplianceDistributorDataCommand? createBatchComplainceDistributorDataCommand = new CreateBatchComplianceDistributorDataCommand();

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceDistributorData.Where(x => x.ComplianceDistributorDataId == 6).FirstOrDefault();

            createBatchComplainceDistributorDataCommand.ComplianceSourceTypeId = Mock.ComplianceSourceTypeId;
            createBatchComplainceDistributorDataCommand.DistributorId = 20;
            createBatchComplainceDistributorDataCommand.FieldData = "test";
            createBatchComplainceDistributorDataCommand.Status = 1;
            createBatchComplainceDistributorDataCommand.CreatedBy = 1;
            createBatchComplainceDistributorDataCommand.CreatedDate = DateTime.Today;
            createBatchComplainceDistributorDataCommand.UpdatedBy = 1;
            createBatchComplainceDistributorDataCommand.UpdatedDate = DateTime.Today;

            List<CreateBatchComplianceDistributorDataCommand> List = new List<CreateBatchComplianceDistributorDataCommand>();

            List.Add(createBatchComplainceDistributorDataCommand);

            listComplainceDistributorData.ComplianceDistributorData = List;

            var ComplainceFieldTypeOutput = new CreateBatchComplianceDistributorDataCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceFieldTypeOutput.Handle(listComplainceDistributorData, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
