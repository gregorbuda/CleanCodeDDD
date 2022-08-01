using AutoMapper;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.CreateComplianceFieldType;
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

namespace Compliance.UnitTest.Features.ComplianceFieldTypes.Commands.CreateComplianceFieldType
{
    public class CreateComplianceFieldTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateComplianceFieldTypeXUnitTests()
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
        public async Task CreateComplianceFieldType_Return()
        {
            var ComplianceFieldTypeInput = new CreateComplianceFieldTypeCommand
            {
                ComplianceFieldTypeName = "Test",
                TranslationKey = "Test",
                FieldPath = "Test" ,
                ComplianceFileSizeKb = 1,
                HeightPx = 1,
                WidthPx = 1,
                Status = 1
            };

            var ComplianceFieldTypeOutput = new CreateComplianceFieldTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceFieldTypeOutput.Handle(ComplianceFieldTypeInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceFieldTypeCreateResponse>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
