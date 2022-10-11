using EnsekTechnicalTest.Models;
using EnsekTechnicalTest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace EnsekTechnicalTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ApiResponse<List<Account>>> GetAll()
        {
            var accounts = await _service.GetAccounts();

            if (accounts == null)
            {
                return new ApiResponse<List<Account>>
                {
                    Success = false,
                    Error = "Failed to get Accounts"
                };
            }

            return new ApiResponse<List<Account>>
            {
                Success = true,
                Value = accounts,
            };
        }

        [HttpGet("{accountId}")]
        public async Task<ApiResponse<Account>> Get(int accountId)
        {
            var account = await _service.GetAccount(accountId);

            if (account == null)
            {
                return new ApiResponse<Account>
                {
                    Success = false,
                    Error = $"No Account found for id: {accountId}"
                };
            }

            return new ApiResponse<Account>
            {
                Success = true,
                Value = account,
            };
        }
    }
}
