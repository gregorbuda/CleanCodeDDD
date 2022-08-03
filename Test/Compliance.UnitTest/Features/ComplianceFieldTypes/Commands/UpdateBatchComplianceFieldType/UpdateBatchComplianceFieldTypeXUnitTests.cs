using AutoMapper;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType;
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

namespace Compliance.UnitTest.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType
{
    public class UpdateBatchComplianceFieldTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBatchComplianceFieldTypeXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceFieldTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceFieldTypesRepository.AddDataInputComplianceFieldTypes(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task UpdateBatchComplianceFieldType_Return()
        {

            UpdateBatchComplianceFieldTypeListCommand listComplainceFieldType = new UpdateBatchComplianceFieldTypeListCommand();
            UpdateBatchComplianceFieldTypeCommand? updateBatchComplainceFieldTypeCommand = new UpdateBatchComplianceFieldTypeCommand();

            var Mock = _unitOfWork.Object.applicationDbContext.ComplianceFieldType.Where(x => x.ComplianceFieldTypeId == 2).FirstOrDefault();

            updateBatchComplainceFieldTypeCommand.ComplianceFieldTypeId = 2;
            updateBatchComplainceFieldTypeCommand.ComplianceFieldTypeName = "Test1";
            updateBatchComplainceFieldTypeCommand.TranslationKey = "test";
            updateBatchComplainceFieldTypeCommand.FieldPath = "Test";
            updateBatchComplainceFieldTypeCommand.ComplianceFileSizeKb = 1;
            updateBatchComplainceFieldTypeCommand.HeightPx = 1;
            updateBatchComplainceFieldTypeCommand.WidthPx = 1;
            updateBatchComplainceFieldTypeCommand.InputBehaviourId = Mock.InputBehaviourId;
            updateBatchComplainceFieldTypeCommand.FileResourceTypeId =Mock.FileResourceTypeId;
            updateBatchComplainceFieldTypeCommand.Status = 1;
            updateBatchComplainceFieldTypeCommand.CreatedBy = 1;
            updateBatchComplainceFieldTypeCommand.CreatedDate = DateTime.Today;
            updateBatchComplainceFieldTypeCommand.UpdatedBy = 1;
            updateBatchComplainceFieldTypeCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchComplianceFieldTypeCommand> List = new List<UpdateBatchComplianceFieldTypeCommand>();

            List.Add(updateBatchComplainceFieldTypeCommand);

            listComplainceFieldType.ComplainceFieldTypeList = List;

            var ComplainceFieldTypeOutput = new UpdateBatchComplianceFieldTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceFieldTypeOutput.Handle(listComplainceFieldType, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
