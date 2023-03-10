using AutoMapper;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchAnReturnComplianceDistributorData;
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
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Compliance.UnitTest.Features.ComplianceDistributorsData.Commands.UpdateBatchAnReturnComplianceDistributorData
{
    public class UpdateBatchAnReturnComplianceDistributorDataXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBatchAnReturnComplianceDistributorDataXUnitTests()
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
        public async Task UpdateBatchAnReturnComplianceDistributorData_Return()
        {

            UpdateBatchAnReturnComplianceDistributorDataListCommand listComplainceDistributorData = new UpdateBatchAnReturnComplianceDistributorDataListCommand();
            UpdateBatchAnReturnComplianceDistributorDataCommand? updateBatchComplainceDistributorDataCommand = new UpdateBatchAnReturnComplianceDistributorDataCommand();

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceDistributorData.Where(x => x.ComplianceDistributorDataId == 6).FirstOrDefault();

            updateBatchComplainceDistributorDataCommand.ComplianceDistributorDataId = 6;
            updateBatchComplainceDistributorDataCommand.ComplianceSourceTypeId = Mock.ComplianceSourceTypeId;
            updateBatchComplainceDistributorDataCommand.DistributorId = 20;
            updateBatchComplainceDistributorDataCommand.FieldData = "test";
            updateBatchComplainceDistributorDataCommand.Status = 1;
            updateBatchComplainceDistributorDataCommand.CreatedBy = 1;
            updateBatchComplainceDistributorDataCommand.CreatedDate = DateTime.Today;
            updateBatchComplainceDistributorDataCommand.UpdatedBy = 1;
            updateBatchComplainceDistributorDataCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchAnReturnComplianceDistributorDataCommand> List = new List<UpdateBatchAnReturnComplianceDistributorDataCommand>();

            List.Add(updateBatchComplainceDistributorDataCommand);

            listComplainceDistributorData.ComplianceDistributorData = List;

            var ComplainceFieldTypeOutput = new UpdateBatchAnReturnComplianceDistributorDataCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceFieldTypeOutput.Handle(listComplainceDistributorData, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
