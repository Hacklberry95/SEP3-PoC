using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Services;
using ServerFramework.Data;
using ServerFramework.Logic;

namespace ServerFramework.Controllers
{
    [Route("api/orderControl")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ClientWebServiceImpl client;

        public OrderController()
        {
            client = new ClientWebServiceImpl();
        }

        [Route("/takeOrder")]
        [HttpGet]
        public async Task<ActionResult> TakeNewOrder()
        {
            try
            {
                Order order = await client.TakeNewOrder();
                return Ok(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult> FinalizePicking([FromBody] int id)
        {
            try
            {
                await client.FinalizePicking(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [Route("/cancel")]
        [HttpPost]
        public async Task<ActionResult> CancelOrder([FromBody] int id)
        {
            try
            {
                await client.CancelOrder(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [Route("/queueNew")]
        [HttpPost]
        public async Task<ActionResult> QueueNewOrder([FromBody] string content)
        {
            try
            {
                string[] arr = content.Split("#");
                bool isHigh = false;
                Order order;
                if (arr[1] == true.ToString())
                {
                    isHigh = true;
                }
                order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(arr[0]);
                await client.QueueNewOrder(order, isHigh);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> DeleteOrder([FromBody] int id)
        {
            try
            {
                await client.DeleteOrder(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [Route("/clearQueue")]
        [HttpDelete]
        public async Task<ActionResult> ClearOrderQueue()
        {
            try
            {
                await client.ClearOrderQueue();
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [Route("/position")]
        [HttpGet]
        public async Task<ActionResult> CheckOrderPosition([FromQuery] int id)
        {
            try
            {
                int pos = await client.CheckOrderPosition(id);
                return Ok(pos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [Route("/cutFromOrder")]
        [HttpPost]
        public async Task<ActionResult> CutFromOrder([FromBody] string content)
        {
            try
            {
                string[] arr = content.Split("#");
                await client.CutFromOrder(Int32.Parse(arr[0]), Int32.Parse(arr[1]));
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
