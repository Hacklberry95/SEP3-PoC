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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ClientWebServiceImpl client;

        public OrderController()
        {
            client = new ClientWebServiceImpl();
        }

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

        [HttpPost]
        public async Task<ActionResult> FinalizePicking(int id)
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

        [HttpPost]
        public async Task<ActionResult> CancelOrder(int id)
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

        [HttpPost]
        public async Task<ActionResult> QueueNewOrder(Order order, bool isHigh)
        {
            try
            {
                await client.QueueNewOrder(order, isHigh);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteOrder(int id)
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

        [HttpHead]
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

        [HttpGet]
        public async Task<ActionResult> CheckOrderPosition(int id)
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

        [HttpHead]
        public async Task<ActionResult> CutFromOrder(int itemId, int orderId)
        {
            try
            {
                await client.CutFromOrder(itemId, orderId);
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
