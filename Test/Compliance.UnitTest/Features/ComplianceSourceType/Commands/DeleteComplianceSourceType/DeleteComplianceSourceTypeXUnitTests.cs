using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Commands.DeleteComplianceSourceType;
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

namespace Compliance.UnitTest.Features.ComplianceSourceType.Commands.DeleteComplianceSourceType
{
    public class DeleteComplianceSourceTypeXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public DeleteComplianceSourceTypeXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceTypesProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourceTypeRepository.AddDataInputComplianceSourceType(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task DeleteComplianceSourceType_Return()
        {
            var ComplianceSourcesInput = new DeleteComplianceSourceTypeCommand
            {
                ComplianceSourceTypeId = 4

            };

            var ComplianceSourcesOutput = new DeleteComplianceSourceTypeCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplianceSourcesOutput.Handle(ComplianceSourcesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
