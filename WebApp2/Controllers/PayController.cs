using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controllers[action]")]
    public class PayController : Controller
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;   
        }
    }
}
