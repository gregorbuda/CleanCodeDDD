using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSourceType.Commands.CreateComplianceSourceType;
using Compliance.Application.Features.ComplianceSourceType.Commands.DeleteComplianceSourceType;
using Compliance.Application.Features.ComplianceSourceType.Commands.UpdateComplianceSourceType;
using Compliance.Application.Features.ComplianceSourceType.Queries;
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
    [SwaggerTag("The Compliance Source Type REST services")]
    public class ComplianceSourceTypeController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceSourceTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Compliance Source Type
        /// </summary>
        /// <param name="command">The data Compliance Source Type.</param>
        /// <returns>
        /// An Compliance Source Type Id 
        /// </returns>
        /// <remarks>
        /// Create Compliance Source Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceTypeCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceTypeCreateResponse>>> CreateComplianceSourceType([FromBody] CreateComplianceSourceTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update Compliance Source Type
        /// </summary>
        /// <param name="command">The data Compliance Source Type.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Compliance Source Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateComplianceSourceType([FromBody] UpdateComplianceSourceTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Delete Compliance Source Type
        /// </summary>
        /// <param name="command">The data Compliance Source Type.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Delete Compliance Source Type
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpDelete()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> DeleteComplianceSourceType([FromBody] DeleteComplianceSourceTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Get Compliance Source Type All
        /// </summary>
        /// <param></param>
        /// <returns>
        /// A Compliance Source Type List
        /// </returns>
        /// <remarks>
        /// Get Compliance Source Type All
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceSourceTypeAll")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>>> GetComplianceSourceTypeAll()
        {
            var query = new GetComplianceSourceTypeAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        /// <summary>
        /// Get Compliance Source Type Market By Id
        /// </summary>
        /// <param name="ComplianceSourceTypeId">The Compliance Source Type Id.</param>
        /// <returns>
        /// A Compliance Source Type Market By Id
        /// </returns>
        /// <remarks>
        /// Get Compliance Source Type Market By Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceSourceTypeMarketById")]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceTypeMarkets>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceTypeMarkets>>> GetComplianceSourceTypeMarketById(Int32 ComplianceSourceTypeId)
        {
            var query = new GetComplianceSourceTypeByIdList(ComplianceSourceTypeId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }
    }
}
