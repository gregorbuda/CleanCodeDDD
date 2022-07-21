using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Commands.DeleteComplainceSources;
using Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources;
using Compliance.Application.Features.ComplianceSources.Queries;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Compliance.Api.Controller
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ComplainceSourceController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplainceSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceCreateResponse>>> CreateComplianceSource([FromBody] CreateComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetComplianceSourceById")]
        [ProducesResponseType(typeof(ComplianceSourceCreateResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceCreateResponse>>> GetComplianceSourceById(Int32 ComplianceSourceId)
        {
            var query = new GetComplianceSourceByIdList(ComplianceSourceId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        [HttpGet("GetComplianceSourceAll")]
        [ProducesResponseType(typeof(ComplianceSourceCreateResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<ComplianceSourceCreateResponse>>>> GetComplianceSourceAll()
        {
            var query = new GetComplianceSourceAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateStreamer([FromBody] UpdateComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> DeleteStreamer([FromBody] DeleteComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
