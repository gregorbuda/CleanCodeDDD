using Compliance.Api.Utils;
using Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes;
using Compliance.Application.Features.FileResourceTypes.Commands.DeleteFileResourceTypes;
using Compliance.Application.Features.FileResourceTypes.Commands.UpdateFileResourceTypes;
using Compliance.Application.Features.FileResourceTypes.Queries;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Compliance.Api.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetailsNotFound), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetailsNotAcceptable), (int)HttpStatusCode.NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetailsInternalServerError), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetailsUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [SwaggerTag("The File Resource Type REST services")]
    public class FileResourceTypeController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public FileResourceTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create File Resource Type
        /// </summary>
        /// <param name="command">The data File Resource Type.</param>
        /// <returns>
        /// A File Resource Type Id 
        /// </returns>
        /// <remarks>
        /// Create File Resource Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<FileResourceTypeCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<FileResourceTypeCreateResponse>>> CreateFileResourceType([FromBody] CreateFileResourceTypesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update File Resource Type
        /// </summary>
        /// <param name="command">The data File Resource Type.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update File Resource Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateFileResourceType([FromBody] UpdateFileResourceTypesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Delete File Resource Type
        /// </summary>
        /// <param name="command">The data File Resource Type.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Delete File Resource Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpDelete()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> DeleteFileResourceType([FromBody] DeleteFileResourceTypesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get File Resource Type All
        /// </summary>
        /// <param></param>
        /// <returns>
        /// A File Resource Type List
        /// </returns>
        /// <remarks>
        /// Get File Resource Type All
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("FileResourceTypeAll")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<FileResourceType>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<FileResourceType>>>> GetFileResourceTypeAll()
        {
            var query = new GetFileResourceTypesAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }


        /// <summary>
        /// Get File Resource Type By Id
        /// </summary>
        /// <param name="FileResourceTypeId">The File Resource Type Id.</param>
        /// <returns>
        /// A File Resource Type By Id 
        /// </returns>
        /// <remarks>
        /// Get File Resource Type By Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("FileResourceTypeById")]
        [ProducesResponseType(typeof(ApiResponse<FileResourceType>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<FileResourceType>>> GetFileResourceTypeById(Int32 FileResourceTypeId)
        {
            var query = new GetFileResourceTypesByIdList(FileResourceTypeId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

    }
}
