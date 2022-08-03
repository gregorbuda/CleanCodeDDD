using AutoMapper;
using Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes;
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

namespace Compliance.UnitTest.Features.FileResourceTypes.Commands.CreateFileResourceTypes
{
    public class CreateFileResourceTypesXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public CreateFileResourceTypesXUnitTests()
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
        public async Task CreateFileResourceType_Return()
        {
            var fileResourceTypesInput = new CreateFileResourceTypesCommand
            {
                Name = "Test",
                TranslationKey = "Test TK",
                Description = "Test Des",
                MaxSize = 1
            };

            var FileResourceTypesOutput = new CreateFileResourceTypesCommandHandler(_unitOfWork.Object, _mapper);

            var result = await FileResourceTypesOutput.Handle(fileResourceTypesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<FileResourceTypeCreateResponse>>();

            Assert.True(result.CodeResult == StatusCodes.Status200OK.ToString()); 
        }
    }
}
