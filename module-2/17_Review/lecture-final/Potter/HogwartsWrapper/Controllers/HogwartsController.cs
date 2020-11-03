using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogwartsWrapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace HogwartsWrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HogwartsController : ControllerBase
    {
        private readonly IConfiguration _config;
        private const string API_KEY = "$2a$10$gUUIpUEW.JNKMovhL3tzoe4ztUyUYd1ll.Z2m4/YCe4CJ2t.0EaTu";
        private string API_URL_BASE { get; }
        private RestClient client = new RestClient();

        public HogwartsController(IConfiguration config)
        {
            _config = config;
            API_URL_BASE = _config.GetValue<string>("BASE_URL");
        }

        [HttpGet]
        public ActionResult<List<House>> GetAllHouses()
        {
            RestRequest request = new RestRequest(API_URL_BASE + "houses");
            request.AddParameter("key", API_KEY);
            IRestResponse<List<House>> response = client.Get<List<House>>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return BadRequest();
            }
            else if (!response.IsSuccessful)
            {
                return NotFound();
            }
            response.Data.Add(Metal());
            return response.Data;
        }

        private House Metal()
        {
            House output = new House();
            output.name = "Metal";
            output.houseGhost = "Sean Connery";
            output.headOfHouse = "Jennifer O'Brien";
            return output;
        }
    }
}
