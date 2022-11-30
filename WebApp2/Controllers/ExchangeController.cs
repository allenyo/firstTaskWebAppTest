using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

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
        public IActionResult Exchange(ExchangeRequestModel requestModel)
        {
            var res = exchangeService.Exchange(requestModel);
            return Ok(res);
        }
    }
}
