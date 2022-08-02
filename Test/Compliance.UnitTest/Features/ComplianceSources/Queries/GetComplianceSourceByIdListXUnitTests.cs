using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceSources.Queries
{
    public class GetComplianceSourceByIdListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceSourceByIdListXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ComplianceSourceProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockComplianceSourcesRepository.AddDataInputComplianceSources(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task GetComplianceSourceByIdList_Return()
        {
            var handler = new GetComplianceSourceByIdListHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceSourceByIdList(1);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceSourceResponse>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
