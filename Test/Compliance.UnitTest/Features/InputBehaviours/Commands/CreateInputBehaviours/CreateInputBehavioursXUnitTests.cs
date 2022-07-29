using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Commands.CreateInputBehaviours;
using Compliance.Application.Mappings;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Repositories;
using Compliance.UnitTest.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Compliance.UnitTest.Features.InputBehaviours.CreateInputBehaviours
{
    public class CreateInputBehavioursXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateInputBehavioursXUnitTests()
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
        public async Task CreateInputBehaviour_Return()
        {
            var inputBehaviourInput = new CreateInputBehavioursCommand
            {
                InputBehaviourName = "Gregor",
                Status = 1
            };

            var inputBehaviourOutput = new CreateInputBehavioursCommandHandler(_unitOfWork.Object, _mapper);

            var result = await inputBehaviourOutput.Handle(inputBehaviourInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<InputBehaviourCreateResponse>>();
        }
    }
}
