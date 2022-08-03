using AutoMapper;
using Compliance.Application.Features.ComplianceDistributorDataLogsBls.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceDistributorDataLogsBls.Queries
{
    public class GetComplianceDistributorDataLogsFullDataByDistributorIdXUnitTets
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceDistributorDataLogsFullDataByDistributorIdXUnitTets()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceDistributorDataLogsProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockComplianceDistributorDataLogsBlsRepository.AddDataInputComplianceDistributorsDataLogsBls(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task GetComplianceDistributorDataLogsFullDataByDistributorId_Return()
        {
            var handler = new GetComplianceDistributorDataLogsFullDataByDistributorIdHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceDistributorDataLogsFullDataByDistributorId(20);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
