using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.CreateComplianceFieldType;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.DeleteComplianceFieldType;
using Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateComplianceFieldType;
using Compliance.Application.Features.ComplianceFieldTypes.Queries;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
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
    [SwaggerTag("The Compliance Field Type REST services")]
    public class ComplianceFieldTypeController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceFieldTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Compliance Field Type
        /// </summary>
        /// <param name="command">The data Compliance Source.</param>
        /// <returns>
        /// An Compliance Field Type Id 
        /// </returns>
        /// <remarks>
        /// Create Compliance Field Type.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<ComplianceFieldTypeCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceFieldTypeCreateResponse>>> CreateComplianceFieldType([FromBody] CreateComplianceFieldTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Update Compliance Field Type
        /// </summary>
        /// <param name="command">The data Compliance Field Type.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Compliance Field Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateFileResourceType([FromBody] UpdateComplianceFieldTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Delete Compliance Field Type
        /// </summary>
        /// <param name="command">The data Compliance Field Type.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Delete Compliance Field Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpDelete()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> DeleteComplianceFieldType([FromBody] DeleteComplianceFieldTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Compliance Field Type All
        /// </summary>
        /// <param></param>
        /// <returns>
        /// A Compliance Field Type  List
        /// </returns>
        /// <remarks>
        /// Get Compliance Field Type All
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("GetComplianceFieldTypeAll")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ComplianceFieldTypeResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceFieldTypeResponse>>>> GetComplianceFieldTypeAll()
        {
            var query = new GetComplianceFieldTypeAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }


        /// <summary>
        /// Get Compliance Field Type By Id
        /// </summary>
        /// <param name="ComplianceFieldTypeId">The Compliance Field Type Id.</param>
        /// <returns>
        /// A Compliance Field Type Id
        /// </returns>
        /// <remarks>
        /// Get Compliance Field Type By Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("GetComplianceFieldTypeById")]
        [ProducesResponseType(typeof(ApiResponse<ComplianceFieldTypeResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceFieldTypeResponse>>> GetComplianceFieldTypeById(Int32 ComplianceFieldTypeId)
        {
            var query = new GetComplianceFieldTypeByIdList(ComplianceFieldTypeId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }


    }
}
