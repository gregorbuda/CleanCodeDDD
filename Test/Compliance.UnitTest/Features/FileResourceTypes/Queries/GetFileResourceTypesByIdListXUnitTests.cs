using AutoMapper;
using Compliance.Application.Features.FileResourceTypes.Queries;
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

namespace Compliance.UnitTest.Features.FileResourceTypes.Queries
{
    public class GetFileResourceTypesByIdListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetFileResourceTypesByIdListXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<FileResourceTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockFileResourceTypesRepository.AddDataInputFileResourceTypes(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task GetFileResourceTypesByIdList_Return()
        {
            var handler = new GetFileResourceTypesByIdListHandler(_unitOfWork.Object, _mapper);

            var request = new GetFileResourceTypesByIdList(1);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<FileResourceType>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
