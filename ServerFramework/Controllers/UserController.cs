using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Authorization;
using ServerFramework.Data;
using ServerFramework.Services;

namespace ServerFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ClientWebServiceImpl client;

        public UserController()
        {
            client = new ClientWebServiceImpl();
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(User user)
        {
            try
            {
                await client.AddUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateUser(User item)
        {
            try
            {
                await client.UpdateUser(item);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(string id)
        {
            try
            {
                await client.DeleteUser(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUser(string id)
        {
            try
            {
                User item = await client.GetUser(id);
                return Ok(item);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
