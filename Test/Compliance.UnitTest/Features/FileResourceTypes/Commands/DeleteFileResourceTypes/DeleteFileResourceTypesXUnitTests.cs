using AutoMapper;
using Compliance.Application.Features.FileResourceTypes.Commands.DeleteFileResourceTypes;
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

namespace Compliance.UnitTest.Features.FileResourceTypes.Commands.DeleteFileResourceTypes
{
    public class DeleteFileResourceTypesXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public DeleteFileResourceTypesXUnitTests()
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
        public async Task DeleteFileResourceType_Return()
        {
            var fileResourceTypesInput = new DeleteFileResourceTypesCommand
            {
                FileResourceTypeId = 1
            };

            var FileResourceTypesOutput = new DeleteFileResourceTypesCommandHandler(_unitOfWork.Object, _mapper);

            var result = await FileResourceTypesOutput.Handle(fileResourceTypesInput, CancellationToken.None);

            result.ShouldBeOfType<ApiResponse<Boolean>>();

            result.CodeResult = StatusCodes.Status200OK.ToString();
        }
    }
}
