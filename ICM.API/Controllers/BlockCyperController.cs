using ICM.Application.GetData.CreateICM;
using ICM.Application.GetData.QueriesICM;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ICM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class BlockCyperController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public BlockCyperController(IMediator mediator, IConfiguration configuration)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _httpClient = new HttpClient(clientHandler) {
                BaseAddress = new Uri(configuration.GetValue<string>("ExternalAPIURI:BASEURI")),
             
                            };

            _mediator = mediator;
            _configuration = configuration;
        }


        #region Dash

        [HttpGet("~/SyncBlockCypherDash")]
        public async Task<IActionResult> SyncBlockCypherDashAsync() {

           
            try
            {

                string dashURL = _configuration.GetValue<string>("ExternalAPIURI:DASHURI");
                CreateDashRequest createDashPayload = new CreateDashRequest();

                if (!string.IsNullOrEmpty(dashURL))
                {

                    var response = await _httpClient.GetAsync(dashURL);
                    if (response.IsSuccessStatusCode)
                    {

                        var stringResponse = await response.Content.ReadAsStringAsync();

                        createDashPayload = JsonSerializer.Deserialize<CreateDashRequest>(stringResponse);
                        var newlyCreatedDash = await _mediator.Send(createDashPayload);
                        return Ok(newlyCreatedDash);
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }

                }
            } catch (Exception ex)
            {

            }

            return Ok();
        }

        #endregion

        #region ETH
        [HttpGet("~/SyncBlockCypherETH")]
        public async Task<IActionResult> SyncBlockCypherETHAsync()
        {

            try
            {
                string ethURL = _configuration.GetValue<string>("ExternalAPIURI:ETHURI");
                CreateETHRequest createETHRequest = new CreateETHRequest();

                if (!string.IsNullOrEmpty(ethURL))
                {

                    var response = await _httpClient.GetAsync(ethURL);
                    if (response.IsSuccessStatusCode)
                    {

                        var stringResponse = await response.Content.ReadAsStringAsync();

                        createETHRequest = JsonSerializer.Deserialize<CreateETHRequest>(stringResponse);
                        var newlyCreatedETH = await _mediator.Send(createETHRequest);
                        return Ok(newlyCreatedETH);
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }

                }
            }
            catch (Exception ex)
            {


            }
            return Ok();
        }
        #endregion

        #region BTC

        [HttpGet("~/SyncBlockCypherBTC")]
        public async Task<IActionResult> SyncBlockCypherBTCAsync()
        {
            try
            {
                string btcURL = _configuration.GetValue<string>("ExternalAPIURI:ETHURI");
                CreateBTCRequest createBTCRequest = new CreateBTCRequest();

                if (!string.IsNullOrEmpty(btcURL))
                {

                    var response = await _httpClient.GetAsync(btcURL);
                    if (response.IsSuccessStatusCode)
                    {

                        var stringResponse = await response.Content.ReadAsStringAsync();

                        createBTCRequest = JsonSerializer.Deserialize<CreateBTCRequest>(stringResponse);
                        var newlyCreatedBTC = await _mediator.Send(createBTCRequest);

                        return Ok(newlyCreatedBTC);
                    }
                    else
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }

                }
            }
            catch (Exception ex)
            {


            }
            return Ok();

        }
        #endregion




        [HttpPost("~/ManualPayloadDash")]
        public async Task<IActionResult> ManualDashPostAsync(CreateDashRequest createDashPayload)
        {
            var newlyCreatedDash = await _mediator.Send(createDashPayload);
            return Ok(newlyCreatedDash);

        }

        [HttpPost("~/ManualPayloadETH")]
        public async Task<IActionResult> ManualETHPostAsync(CreateETHRequest createETHPayload)
        {
            var newlyCreatedETH = await _mediator.Send(createETHPayload);
            return Ok(newlyCreatedETH);

        }

        [HttpPost("~/ManualPayloadBTC")]
        public async Task<IActionResult> ManualBTCPostAsync(CreateBTCRequest createBTCPayload)
        {
            var newlyCreatedBTC = await _mediator.Send(createBTCPayload);
            return Ok(newlyCreatedBTC);

        }

    }
    }
