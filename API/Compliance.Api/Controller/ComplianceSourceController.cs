using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.DeleteComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateBatchComplainceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Queries;
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
    [SwaggerTag("The Compliance Sources REST services")]
    public class ComplianceSourceController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Compliance Source
        /// </summary>
        /// <param name="command">The data Compliance Source.</param>
        /// <returns>
        /// An Compliance Source Id 
        /// </returns>
        /// <remarks>
        /// Create Compliance Source.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceCreateResponse>>> CreateComplianceSource([FromBody] CreateComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Compliance Source By Id
        /// </summary>
        /// <param name="ComplianceSourceId">The Compliance Source Id.</param>
        /// <returns>
        /// A Compliance Source By Id 
        /// </returns>
        /// <remarks>
        /// Get Compliance Source By Id.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceSourceById")]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceResponse>>> GetComplianceSourceById(Int32 ComplianceSourceId)
        {
            var query = new GetComplianceSourceByIdList(ComplianceSourceId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        /// <summary>
        /// Get Compliance Source All
        /// </summary>
        /// <param></param>
        /// <returns>
        /// A Compliance Source List
        /// </returns>
        /// <remarks>
        /// Get Compliance Source All.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceSourceAll")]
        [ProducesResponseType(typeof(ApiResponse<List<ComplianceSourceResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<List<ComplianceSourceResponse>>>> GetComplianceSourceAll()
        {
            var query = new GetComplianceSourceAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }


        /// <summary>
        /// Update Compliance Source
        /// </summary>
        /// <param name="command">The data Compliance Source.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Compliance Source.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateComplianceSource([FromBody] UpdateComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Delete Compliance Source
        /// </summary>
        /// <param name="command">The data Compliance Source.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Delete Compliance Source.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpDelete()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> DeleteComplianceSource([FromBody] DeleteComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update Batch Compliance Source
        /// </summary>
        /// <param name="command">The data Compliance Source.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Batch Compliance Source.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateBatchComplianceSource([FromBody] UpdateBatchComplainceSourcesListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
