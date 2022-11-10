using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
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
