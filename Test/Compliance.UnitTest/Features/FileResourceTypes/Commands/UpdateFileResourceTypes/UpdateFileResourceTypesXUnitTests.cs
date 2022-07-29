using AutoMapper;
using Compliance.Application.Features.FileResourceTypes.Commands.UpdateFileResourceTypes;
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

namespace Compliance.UnitTest.Features.FileResourceTypes.Commands.UpdateFileResourceTypes
{
    public class UpdateFileResourceTypesXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public UpdateFileResourceTypesXUnitTests()
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
        public async Task UpdateFileResourceType_Return()
        {
            var fileResourceTypesInput = new UpdateFileResourceTypesCommand
            {
                FileResourceTypeId = 1,
                Name = "Test",
                TranslationKey = "Test TK",
                Description = "Test Des",
                MaxSize = 1
            };

            var FileResourceTypesOutput = new UpdateFileResourceTypesCommandHandler(_unitOfWork.Object, _mapper);

            var result = await FileResourceTypesOutput.Handle(fileResourceTypesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
