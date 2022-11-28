using api1Domain.Interfaces;
using api1Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
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
        public async Task<IActionResult> PayToAccountModel(PayToAccountModel model)
        {
            var res = await _payService.PayToAccount(model);
            return Ok(res);
        }
    }
}
