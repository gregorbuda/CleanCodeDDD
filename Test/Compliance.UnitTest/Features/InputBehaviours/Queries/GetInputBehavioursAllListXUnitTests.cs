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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Compliance.UnitTest.Features.InputBehaviours.Queries
{
    public class GetInputBehavioursAllListXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetInputBehavioursAllListXUnitTests()
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
        public async Task GetInputBehavioursAllList_Return()
        {
            var handler = new GetInputBehavioursAllListHandler(_unitOfWork.Object, _mapper);

            var request = new GetInputBehavioursAllList();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<IReadOnlyList<InputBehaviour>>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        } 
    }
}
