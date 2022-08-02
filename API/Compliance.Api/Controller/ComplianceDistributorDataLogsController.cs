using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls;
using Compliance.Application.Features.ComplianceDistributorDataLogsBls.Queries;
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
    [SwaggerTag("The Compliance Distributor Data Logs REST services")]
    public class ComplianceDistributorDataLogsController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceDistributorDataLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Batch Compliance Compliance Distributor Data Logs
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data Logs.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Create Batch Compliance Compliance Distributor Data Logs
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> CreateBatchComplianceDistributorDataLogs([FromBody] CreateBatchComplianceDistributorDataLogsBlsListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Compliance Distributor Data Full Data Logs List By Distributor Id
        /// </summary>
        /// <param name="complianceDistributorId">Distributor Id</param>
        /// <returns>
        /// A Compliance Distributor Data Full Data Logs List by  Distributor Id
        /// </returns>
        /// <remarks>
        /// Get Compliance Distributor Data Full Data Logs List By Distributor Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("ComplianceDistributorDataLogsFullDataListByDistributor")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<ComplianceDistributorDataLogs>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceDistributorDataLogs>>>> GetComplianceDistributorDataFullDataListByDistributor(Int32 complianceDistributorId)
        {
            var query = new GetComplianceDistributorDataLogsFullDataByDistributorId(complianceDistributorId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

    }
}
