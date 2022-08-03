using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Commands.DeleteInputBehaviours;
using Compliance.Application.Mappings;
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

namespace Compliance.UnitTest.Features.InputBehaviours.DeleteInputBehaviours
{
    public class DeleteInputBehavioursXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public DeleteInputBehavioursXUnitTests()
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
        public async Task DeleteInputBehavioursCommand_Return()
        {
            var InputBehavioursInput = new DeleteInputBehavioursCommand
            {
                InputBehaviourId = 1
            };

            var InputOutput = new DeleteInputBehavioursCommandHandler(_unitOfWork.Object, _mapper);

            var result = await InputOutput.Handle(InputBehavioursInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
