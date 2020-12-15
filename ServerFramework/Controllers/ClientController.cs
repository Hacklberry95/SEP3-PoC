using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Authorization;
using ServerFramework.Services;
using ServerFramework.Data;

namespace ServerFramework.Controllers
{
    [Route("api/clientControl")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ClientWebService client;
        private ISocketService SocketService;
        public ClientController()
        {
            client = new ClientWebServiceImpl();
            SocketService = new SocketServiceImpl();
        }

        [HttpPost]
        public async Task<ActionResult> PostConfirmation(int orderId)
        {
            try
            {
                await client.ConfirmOrder(orderId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpPost]
        public async Task<ActionResult> PostConfirmation(Order order)
        {
            try
            {
                await client.ConfirmOrder(order);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> PostConfirmation(Item item)
        {
            try
            {
                await client.ReceiveItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                var user = SocketService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
/*
        [HttpPost]
        public async Task<ActionResult> PostConfirmation(int itemId)
        {
            try
            {
                await client.ReceiveItem(itemId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }*/
    }
}
