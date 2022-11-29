using Data;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;

        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(Accounts accounts)
        {
            var res = await accountService.AddAccount(accounts);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance(string account)
        {
            var res = await accountService.GetBalance(account);
            return Ok(res);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await accountService.GetAll());   
        }

    }
}
