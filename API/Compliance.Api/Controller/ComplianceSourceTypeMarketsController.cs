using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateBatchComplianceSourceTypeMarket;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateComplianceSourceTypeMarket;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.UpdateBatchComplianceSourceTypeMarket;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Queries;
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
    [SwaggerTag("The Compliance Source Type Markets REST services")]
    public class ComplianceSourceTypeMarketsController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceSourceTypeMarketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Compliance Source Type Markets
        /// </summary>
        /// <param name="command">The data Compliance Source Type Markets.</param>
        /// <returns>
        /// A Compliance Source Type Markets Id 
        /// </returns>
        /// <remarks>
        /// Create Compliance Source Type Markets
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceTypeMarketsCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceTypeMarketsCreateResponse>>> CreateComplianceSourceTypeMarkets([FromBody] CreateComplianceSourceTypeMarketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Compliance Source Type By Id
        /// </summary>
        /// <param name="InputBehaviourId">The Input Behaviour Id.</param>
        /// <returns>
        /// A Compliance Source Type By Id
        /// </returns>
        /// <remarks>
        /// Get Compliance Source Type By Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceSourceTypeById")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<ComplianceSourceTypeMarkets>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ComplianceSourceTypeMarkets>>>> GetComplianceSourceTypeById(Int32 ComplianceSourceTypeId)
        {
            var query = new GetByComplianceSourceTypeMarketById(ComplianceSourceTypeId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        /// <summary>
        /// Update Batch Compliance Source Type Markets
        /// </summary>
        /// <param name="command">The data Input Compliance Source Type Markets.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Batch Compliance Source Type Markets
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateBatchComplianceSourceTypeMarkets([FromBody] UpdateBatchComplianceSourceTypeMarketListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Create Batch Compliance Source Type Markets
        /// </summary>
        /// <param name="command">The data Input Compliance Source Type Markets.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Create Batch Compliance Source Type Markets
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> CreateBatchComplianceSourceTypeMarkets([FromBody] CreateBatchComplianceSourceTypeMarketListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Compliance Source Type Market By Id
        /// </summary>
        /// <param name="ComplianceSourceTypeMarketId">Compliance Source Type Market Id.</param>
        /// <returns>
        /// A Compliance Source Type Market By Id
        /// </returns>
        /// <remarks>
        /// Get Compliance Source Type Market By Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceSourceTypeMarketById")]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceTypeMarkets>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceTypeMarkets>>> GetComplianceSourceTypeMarketById(Int32 ComplianceSourceTypeMarketId)
        {
            var query = new GetComplianceSourceTypeMarketById(ComplianceSourceTypeMarketId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

    }
}
