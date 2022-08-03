using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypesIdFullDataListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceSourceTypesIdFullDataListXUnitTests()
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
        public async Task GetComplianceSourceTypesIdFullDataList_Return()
        {
            var handler = new ComplianceSourceTypesIdFullDataListHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceSourceTypesIdFullDataList();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
