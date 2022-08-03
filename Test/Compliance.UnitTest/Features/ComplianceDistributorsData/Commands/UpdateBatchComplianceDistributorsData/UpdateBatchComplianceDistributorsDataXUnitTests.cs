using AutoMapper;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData;
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

namespace Compliance.UnitTest.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData
{
    public class UpdateBatchComplianceDistributorsDataXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBatchComplianceDistributorsDataXUnitTests()
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
        public async Task UpdateBatchComplianceDistributorsData_Return()
        {

            UpdateBatchComplianceDistributorsDataListCommand listComplainceDistributorData = new UpdateBatchComplianceDistributorsDataListCommand();
            UpdateBatchComplianceDistributorsDataCommand? updateBatchComplainceDistributorDataCommand = new UpdateBatchComplianceDistributorsDataCommand();

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceDistributorData.Where(x => x.ComplianceDistributorDataId == 6).FirstOrDefault();


            updateBatchComplainceDistributorDataCommand.ComplianceDistributorDataId = 6;
            updateBatchComplainceDistributorDataCommand.ComplianceSourceTypeId = Mock.ComplianceSourceTypeId;
            updateBatchComplainceDistributorDataCommand.DistributorId = 20;
            updateBatchComplainceDistributorDataCommand.FieldData = "Test";
            updateBatchComplainceDistributorDataCommand.Status = 1;
            updateBatchComplainceDistributorDataCommand.CreatedBy = 1;
            updateBatchComplainceDistributorDataCommand.CreatedDate = DateTime.Today;
            updateBatchComplainceDistributorDataCommand.UpdatedBy = 1;
            updateBatchComplainceDistributorDataCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchComplianceDistributorsDataCommand> List = new List<UpdateBatchComplianceDistributorsDataCommand>();

            List.Add(updateBatchComplainceDistributorDataCommand);

            listComplainceDistributorData.ComplianceDistributorData = List;

            var ComplainceFieldTypeOutput = new UpdateBatchComplianceDistributorsDataCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceFieldTypeOutput.Handle(listComplainceDistributorData, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
