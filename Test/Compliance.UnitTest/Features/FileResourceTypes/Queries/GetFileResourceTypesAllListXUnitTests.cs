using AutoMapper;
using Compliance.Application.Features.FileResourceTypes.Queries;
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

namespace Compliance.UnitTest.Features.FileResourceTypes.Queries
{
    public class GetFileResourceTypesAllListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetFileResourceTypesAllListXUnitTests()
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
        public async Task GetFileResourceTypesAllList_Return()
        {
            var handler = new GetFileResourceTypesAllListHandler(_unitOfWork.Object, _mapper);

            var request = new GetFileResourceTypesAllList();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<FileResourceTypeResponse>>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
