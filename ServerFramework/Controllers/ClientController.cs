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
        private ClientWebService client;

        public ClientController()
        {
            client = new ClientWebServiceImpl();
        }

        /// <summary>
        /// Loader posts order confirmation
        /// </summary>
        /// <param name="orderId">Id of order to confirm</param>
        /// <returns>HTTP status code 200 or 500.</returns>
        [HttpPost]
        public async Task<ActionResult> PostConfirmation([FromBody] int orderId)
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
    }
}
