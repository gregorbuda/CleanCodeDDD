using AutoMapper;
using Compliance.Application.Features.ComplianceFieldTypes.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceFieldTypes.Queries
{
    public class GetComplianceFieldTypeFullDataByIdXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceFieldTypeFullDataByIdXUnitTests()
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
        public async Task GetComplianceFieldTypeFullDataById_Return()
        {
            var handler = new GetComplianceFieldTypeFullDataByIdHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceFieldTypeFullDataById(2);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceFieldType>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
