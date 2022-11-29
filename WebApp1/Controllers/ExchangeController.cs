using api1Domain.Models;
using api1Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExchangeController : Controller
    {
        private readonly IExchangeService exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            this.exchangeService = exchangeService;
        }

        [HttpPost]
        public async Task<IActionResult> Exchange(ExchangeRequestModel requestModel)
        {
            var res = await exchangeService.Exchange(requestModel);

            return Ok(res);
        }
    }
}
