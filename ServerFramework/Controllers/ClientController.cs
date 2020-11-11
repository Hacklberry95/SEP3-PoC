using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Services;
using ServerFramework.Data;

namespace ServerFramework.Controllers
{
    [Route("api/clientControl")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ClientWebService client;

        public ClientController()
        {
            client = new ClientWebServiceImpl();
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
    }
}
