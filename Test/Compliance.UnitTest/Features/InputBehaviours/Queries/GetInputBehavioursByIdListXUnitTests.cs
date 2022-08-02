using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Queries;
using Compliance.Application.Mappings;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Repositories;
using Compliance.UnitTest.Mock;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Compliance.UnitTest.Features.InputBehaviours.Queries
{
    public class GetInputBehavioursByIdListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetInputBehavioursByIdListXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<InputBehaviourProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockInputBehaviourRepository.AddDataInputBehaviourRepository(_unitOfWork.Object.applicationDbContext);
        }

        [Fact]
        public async Task GetInputBehavioursByIdList_Return()
        {
            var handler = new GetInputBehavioursByIdListHandler(_unitOfWork.Object, _mapper);

            var request = new GetInputBehavioursByIdList(1);

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<InputBehaviourResponse>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
