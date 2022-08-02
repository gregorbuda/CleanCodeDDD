using AutoMapper;
using Compliance.Application.Features.ComplianceSourceType.Queries;
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

namespace Compliance.UnitTest.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypeByIdListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetComplianceSourceTypeByIdListXUnitTests()
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
        public async Task GetByComplianceSourceTypeByIdList_Return()
        {
            var handler = new GetComplianceSourceTypeByIdListHandler(_unitOfWork.Object, _mapper);

            var request = new GetComplianceSourceTypeByIdList(4);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<ComplianceSourceTypes>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
