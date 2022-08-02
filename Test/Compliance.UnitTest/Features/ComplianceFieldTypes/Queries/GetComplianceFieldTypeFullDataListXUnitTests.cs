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
    public class GetComplianceFieldTypeFullDataListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceFieldTypeFullDataListXUnitTests()
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
        public async Task GetComplianceFieldTypeFullDataList_Return()
        {
            var handler = new GetComplianceFieldTypeFullDataListHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceFieldTypeFullDataList();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<ComplianceFieldType>>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
