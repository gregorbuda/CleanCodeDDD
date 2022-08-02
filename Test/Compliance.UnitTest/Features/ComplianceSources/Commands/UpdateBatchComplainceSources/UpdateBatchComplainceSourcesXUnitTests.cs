using AutoMapper;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateBatchComplainceSources;
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

namespace Compliance.UnitTest.Features.ComplianceSources.Commands.UpdateBatchComplainceSources
{
    public class UpdateBatchComplainceSourcesXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateBatchComplainceSourcesXUnitTests()
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
        public async Task UpdateBatchComplainceSources_Return()
        {

            UpdateBatchComplainceSourcesListCommand listComplainceSources = new UpdateBatchComplainceSourcesListCommand();
            UpdateBatchComplainceSourcesCommand? updateBatchComplainceSourcesCommand = new UpdateBatchComplainceSourcesCommand();

            updateBatchComplainceSourcesCommand.ComplianceSourceId = 1;
            updateBatchComplainceSourcesCommand.ComplianceSourceName = "Test1";
            updateBatchComplainceSourcesCommand.Status = 1;
            updateBatchComplainceSourcesCommand.CreatedBy = 1;
            updateBatchComplainceSourcesCommand.CreatedDate = DateTime.Today;
            updateBatchComplainceSourcesCommand.UpdatedBy = 1;
            updateBatchComplainceSourcesCommand.UpdatedDate = DateTime.Today;

            List<UpdateBatchComplainceSourcesCommand> List = new List<UpdateBatchComplainceSourcesCommand>();

            List.Add(updateBatchComplainceSourcesCommand);

            listComplainceSources.ComplainceSourcesList = List;

            var ComplainceSourcesOutput = new UpdateBatchComplainceSourcesCommandHandler(_unitOfWork.Object, _mapper);

            var result = await ComplainceSourcesOutput.Handle(listComplainceSources, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString());
        }
    }
}
