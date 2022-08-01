using AutoMapper;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateComplianceFieldType;
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

namespace Compliance.UnitTest.Features.ComplianceFieldTypes.Commands.UpdateComplianceFieldType
{
    public class UpdateComplianceFieldTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateComplianceFieldTypeXUnitTests()
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
        public async Task UpdateComplianceFieldType_Return()
        {
            var ComplianceFieldTypeInput = new UpdateComplianceFieldTypeCommand
            {
                ComplianceFieldTypeId = 1,
                ComplianceFieldTypeName = "Test",
                TranslationKey = "Test",
                FieldPath = "Test",
                ComplianceFileSizeKb = 1,
                HeightPx = 1,
                WidthPx = 1,
                Status = 1
            };

            var ComplianceFieldTypeOutput = new UpdateComplianceFieldTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceFieldTypeOutput.Handle(ComplianceFieldTypeInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
