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
    public class TransferController : ControllerBase
    {
        private IAccountDAO accountDAO { get; }
        private ITransferDAO transferDAO { get; }

        public TransferController(IAccountDAO accountDAO,ITransferDAO transferDAO)
        {
            this.accountDAO = accountDAO;
            this.transferDAO = transferDAO;
        }

        [HttpPost]
        public ActionResult CreateTransfer(Transfer transferIn)
        {
            ActionResult result = BadRequest();
            int? userId = User.GetUserID();
            if(!userId.HasValue)
            {
                return BadRequest();
            }
            // Check if accounts exist
            Account fromAccount = null;
            Account toAccount = null;
            try
            {
                fromAccount = accountDAO.GetAccountByAccountId(transferIn.AccountFrom);
                toAccount = accountDAO.GetAccountByAccountId(transferIn.AccountTo);
                if (fromAccount == null || toAccount == null)
                {
                    return NotFound();
                }
            } catch(Exception e)
            {
                return BadRequest();
            }
            // check balance
            if (fromAccount.Balance < transferIn.Amount)
            {
                return StatusCode(402); // payment required
            }

            // Process the transfer
            try
            {
                Transfer transferOut = transferDAO.AddTransfer(transferIn);
                return Ok(transferOut);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<List<TransferDetail>> GetTransfersForUser(int userId = -1)
        {
            // if no user id provided, get current userId
            if(userId < 0)
            {
                userId = User.GetUserID() ?? -1;
                if (userId < 0)
                {
                    return BadRequest();   
                }
            }

            try
            {
                List<TransferDetail> transferDetails = transferDAO.GetTransferDetails(userId);
                return Ok(transferDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
