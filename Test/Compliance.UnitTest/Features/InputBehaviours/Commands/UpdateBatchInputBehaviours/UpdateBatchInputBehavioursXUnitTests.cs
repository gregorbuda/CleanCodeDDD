using AutoMapper;
using Compliance.Application.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours;
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

namespace Compliance.UnitTest.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours
{
    public class UpdateBatchInputBehavioursXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBatchInputBehavioursXUnitTests()
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
        public async Task UpdateBatchInputBehaviour_Return()
        {

            UpdateBatchInputBehavioursListCommand listInputBehaviour = new UpdateBatchInputBehavioursListCommand();
            UpdateBatchInputBehavioursCommand? updateBatchInputBehavioursCommand = new UpdateBatchInputBehavioursCommand();

            updateBatchInputBehavioursCommand.InputBehaviourId = 1;
            updateBatchInputBehavioursCommand.InputBehaviourName = "Test1";
            updateBatchInputBehavioursCommand.Status = 1;
            updateBatchInputBehavioursCommand.CreatedBy = 1;
            updateBatchInputBehavioursCommand.CreatedDate = DateTime.Today;
            updateBatchInputBehavioursCommand.UpdatedBy = 1;
            updateBatchInputBehavioursCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchInputBehavioursCommand> List = new List<UpdateBatchInputBehavioursCommand>();


            List.Add(updateBatchInputBehavioursCommand);

            listInputBehaviour.ComplainceSourcesList = List;

            var InputBehaviourOutput = new UpdateBatchInputBehavioursCommandHandler(_unitOfWork.Object, _mapper);

            var result = await InputBehaviourOutput.Handle(listInputBehaviour, CancellationToken.None);
            
            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
