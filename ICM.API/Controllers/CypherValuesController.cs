using ICM.Application.GetData.QueriesICM;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CypherValuesController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public CypherValuesController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet("~/GetDashData")]
        public async Task<IActionResult> GetDashDataAsync()
        {
            var response = await _mediator.Send(new GetAllDashRequest());
            return Ok(response.OrderByDescending(i => i.Id));
        }

        [HttpGet("~/GetETHData")]
        public async Task<IActionResult> GetETHDataAsync()
        {
            var response = await _mediator.Send(new GetAllETHRequest());
            return Ok(response.OrderByDescending(i => i.Id));
        }

        [HttpGet("~/GetBTCData")]
        public async Task<IActionResult> GetBTCDataAsync()
        {
            var response = await _mediator.Send(new GetAllBTCRequest());
            return Ok(response.OrderByDescending(i => i.Id));
        }


    }
}
