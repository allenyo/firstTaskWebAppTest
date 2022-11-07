using api1Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controllers][action]")]
    public class PayController : Controller
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }
    }
}
