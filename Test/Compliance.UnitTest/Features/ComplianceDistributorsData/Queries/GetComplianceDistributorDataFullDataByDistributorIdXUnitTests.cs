using AutoMapper;
using Compliance.Application.Features.ComplianceDistributorsData.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceDistributorsData.Queries
{
    public class GetComplianceDistributorDataFullDataByDistributorIdXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceDistributorDataFullDataByDistributorIdXUnitTests()
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
        public async Task GetComplianceDistributorDataFullDataByDistributorId_Return()
        {
            var handler = new GetComplianceDistributorDataFullDataByDistributorIdHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceDistributorDataFullDataByDistributorId(20);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
