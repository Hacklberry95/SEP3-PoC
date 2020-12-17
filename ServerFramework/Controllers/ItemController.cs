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
    [Route("api/itemControl")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ClientWebServiceImpl client;

        public ItemController()
        {
            client = new ClientWebServiceImpl();
        }

        [Route("/receive")]
        [HttpPost]
        public async Task<ActionResult> ReceiveItem([FromBody] string content)
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

        [Route("/addNew")]
        [HttpPost]
        public async Task<ActionResult> AddNewItem([FromBody] Item item)
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

        [HttpPatch]
        public async Task<ActionResult> EditItem([FromBody] Item item)
        {
            try
            {
                await client.EditItem(item);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> RemoveItem([FromBody] int id)
        {
            try
            {
                await client.RemoveItem(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("/get?id={id}")]
        [HttpGet]
        public async Task<ActionResult> GetItem([FromQuery] int id)
        {
            try
            {
                Item item = await client.GetItem(id);
                return Ok(item);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [Route("/damaged")]
        [HttpPost]
        public async Task<ActionResult> MarkItemAsDamaged([FromBody] string content)
        {
            try
            {
                string[] arr = content.Split('#');
                int itemID = int.Parse(arr[0]);
                int count = int.Parse(arr[1]);
                await client.MarkItemAsDamaged(itemID, count);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
