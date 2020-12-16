using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Authorization;
using ServerFramework.Services;

namespace ServerFramework.Controllers
{
    [Route("api/loginControl")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ClientWebService service;
        public LoginController()
        {
            service = new ClientWebServiceImpl();
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = await service.ValidateUser(username, password);
                string json = JsonSerializer.Serialize(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
