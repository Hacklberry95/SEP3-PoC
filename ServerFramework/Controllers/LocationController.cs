using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Data;
using ServerFramework.Services;

namespace ServerFramework.Controllers
{
    [Route("api/locationControl")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ClientWebServiceImpl client;

        public LocationController()
        {
            client = new ClientWebServiceImpl();
        }


        [HttpPost]
        public async Task<ActionResult> AllocatePutaway(string content)
        {
            try
            {
                string[] arr = content.Split('#');
                Item item = JsonSerializer.Deserialize<Item>(arr[0]);
                await client.AllocatePutaway(item, arr[1]);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateLocation(string id)
        {
            try
            {
                await client.CreateLocation(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateLocation(Location item)
        {
            try
            {
                await client.UpdateLocation(item);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteLocation(string id)
        {
            try
            {
                await client.DeleteLocation(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetLocation(string id)
        {
            try
            {
                Location item = await client.GetLocation(id);
                return Ok(item);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ReplenishLocation(string id)
        {
            try
            {
                List<string> list = await client.ReplenishLocation(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
