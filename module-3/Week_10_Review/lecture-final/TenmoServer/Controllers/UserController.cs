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
    public class UserController : ControllerBase
    {
        private IUserDAO userDAO { get; }
        public UserController(IUserDAO userDAO)
        {
            this.userDAO = userDAO;
        }

        /// <summary>
        /// This returns all users except for the logged in user
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        public ActionResult<List<User>> GetTransferUsers()
        {
            try
            {
                List<User> users = userDAO.GetUsers();
                return users.Where(u => u.UserId != User.GetUserID()).ToList();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
