using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Data;
using ServerFramework.Services;

namespace ServerFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ClientWebServiceImpl client;

        public ItemController()
        {
            client = new ClientWebServiceImpl();
        }

        [HttpPost]
        public async Task<ActionResult> ReceiveItem(string content)
        {
            try
            {
                string[] arr = content.Split('#');
                int itemID = int.Parse(arr[0]);
                int count = int.Parse(arr[1]);
                await client.ReceiveItem(itemID, count);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewItem(Item item)
        {
            try
            {
                await client.AddNewItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
