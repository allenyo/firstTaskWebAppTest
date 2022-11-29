using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PayController : Controller
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }

        [HttpPost]
        public async Task<IActionResult> PayToAccount(PayToAccountModel payTo)
        {
            var res = await _payService.PayToAccount(payTo);
            return Ok(res);

        }
    }
}
