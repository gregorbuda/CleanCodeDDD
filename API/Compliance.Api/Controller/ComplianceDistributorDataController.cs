using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchAnReturnComplianceDistributorData;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData;
using Compliance.Application.Features.ComplianceDistributorsData.Queries;
using Compliance.Domain.Models;
using Example.Application.Features.ComplianceDistributorsData.Commands.UpdateListReturnBoleanComplianceDistributorsData;
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
    [SwaggerTag("The Compliance Distributor Data REST services")]
    public class ComplianceDistributorDataController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceDistributorDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Batch Compliance Compliance Distributor Data
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Create Batch Compliance Compliance Distributor Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> CreateBatchComplianceDistributorData([FromBody] CreateBatchComplianceDistributorDataListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Update Batch Compliance Compliance Distributor Data
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Batch Compliance Compliance Distributor Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateBatchComplianceDistributorData([FromBody] UpdateBatchComplianceDistributorsDataListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Compliance Distributor Data Full Data
        /// </summary>
        /// <param></param>
        /// <returns>
        /// A Compliance Distributor Data Full Data
        /// </returns>
        /// <remarks>
        /// Get Compliance Distributor Data Full Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceDistributorDataFullData")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ComplianceDistributorData>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceDistributorData>>>> GetComplianceDistributorDataFullData()
        {
            var query = new GetComplianceDistributorDataFullDataList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        /// <summary>
        /// Get Compliance Distributor Data Full Data List By Distributor Id
        /// </summary>
        /// <param name="complianceDistributorId">compliance DistributorId Id</param>
        /// <returns>
        /// A Compliance Distributor Data Full Data List by  Distributor Id
        /// </returns>
        /// <remarks>
        /// Get Compliance Distributor Data Full Data List By Distributor Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceDistributorDataFullDataListByDistributor")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ComplianceDistributorData>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceDistributorData>>>> GetComplianceDistributorDataFullDataListByDistributor(Int32 complianceDistributorId)
        {
            var query = new GetComplianceDistributorDataFullDataByDistributorId(complianceDistributorId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        /// <summary>
        /// Update Batch Compliance Compliance Distributor Data
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data.</param>
        /// <returns>
        /// A List of Compliance Compliance Distributor Data
        /// </returns>
        /// <remarks>
        /// Update Batch Compliance Compliance Distributor Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("UpdateBatchReturnList")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ComplianceDistributorData>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceDistributorData>>>> UpdateBatchReturnListComplianceDistributorData([FromBody] UpdateBatchAnReturnComplianceDistributorDataListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Update Batch Compliance Compliance Distributor Data
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data.</param>
        /// <returns>
        /// A List of Compliance Compliance Distributor Data
        /// </returns>
        /// <remarks>
        /// Update Batch Compliance Compliance Distributor Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("UpdateBatchReturnBoolean")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateBatchReturnBooleanComplianceDistributorData([FromBody] UpdateListReturnBoleanComplianceDistributorsDataListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
