using api1Domain.Models;
using api1Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
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
        public async Task<IActionResult> Add(Accounts accounts)
        {
            var res = await accountService.AddAccount(accounts);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance(string account)
        {
            var balance = await accountService.GetBalance(account);
            return Ok(balance);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await accountService.GetAll());
        }

    }
}
