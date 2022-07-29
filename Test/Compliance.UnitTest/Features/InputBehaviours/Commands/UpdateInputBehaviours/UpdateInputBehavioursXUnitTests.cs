using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Commands.UpdateInputBehaviours;
using Compliance.Application.Mappings;
using Compliance.Application.Responses;
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

namespace Compliance.UnitTest.Features.InputBehaviours.UpdateInputBehaviours
{
    public  class UpdateInputBehavioursXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateInputBehavioursXUnitTests()
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
        public async Task UpdateInputBehaviour_Return()
        {
            var InputBehaviourInput = new UpdateInputBehavioursCommand
            {
                InputBehaviourId = 1,
                InputBehaviourName = "Test",
                Status = 1
            };

            var InputBehaviourOutput = new UpdateInputBehavioursCommandHandler(_unitOfWork.Object, _mapper);

            var result = await InputBehaviourOutput.Handle(InputBehaviourInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
