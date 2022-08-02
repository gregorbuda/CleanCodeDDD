using AutoMapper;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.DeleteComplianceFieldType;
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

namespace Compliance.UnitTest.Features.ComplianceFieldTypes.Commands.DeleteComplianceFieldType
{
    public class DeleteComplianceFieldTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public DeleteComplianceFieldTypeXUnitTests()
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
        public async Task DeleteComplianceFieldType_Return()
        {
            var ComplianceFieldTypeInput = new DeleteComplianceFieldTypeCommand
            {
                ComplianceFieldTypeId = 2
            };

            var ComplianceFieldTypeInputOutput = new DeleteComplianceFieldTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceFieldTypeInputOutput.Handle(ComplianceFieldTypeInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
