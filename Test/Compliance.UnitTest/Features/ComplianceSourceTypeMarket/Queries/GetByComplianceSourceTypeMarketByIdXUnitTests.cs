using AutoMapper;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceSourceTypeMarket.Queries
{
    public class GetByComplianceSourceTypeMarketByIdXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetByComplianceSourceTypeMarketByIdXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceTypeMarketsProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourceTypeMarketRepository.AddDataComplianceSourceTypeMarket(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task GetByComplianceSourceTypeMarketByIdList_Return()
        {
            var handler = new GetByComplianceSourceTypeMarketByIdHandler(_unitOfWork.Object, _mapper);

            var request = new GetByComplianceSourceTypeMarketById(4);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
