using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private IAccountDAO accountDAO { get; }

        public AccountController(IAccountDAO accountDAO)
        {
            this.accountDAO = accountDAO;
        }

        /// <summary>
        /// This pulls the logged in user and returns a list of all their accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Account>> GetUserAccounts()
        {
            int? userId = GetCurrentUserId();
            List<Account> result = new List<Account>();
            if (!userId.HasValue)
            {
                return BadRequest();
            }
            try
            {
                result = accountDAO.GetAccountsByUserId(userId.Value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccountById(int id)
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }
            try
            {
                return (accountDAO.GetAccountByAccountId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("users")]
        public ActionResult<List<AccountWithUser>> GetTransferAccounts()
        {
            int? userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return BadRequest();
            }
            try
            {
                return (accountDAO.GetAccountWithUsers().Where(acc => acc.UserId != userId).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        private int? GetCurrentUserId()
        {
            string userId = User.FindFirst("sub")?.Value;
            if (string.IsNullOrWhiteSpace(userId)) return null;
            int.TryParse(userId, out int userIdInt);
            return userIdInt;
        }

    }
}
