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

        public async Task<ActionResult> TakeNewOrder()
        {
            HandleOrder order = new HandleOrder();
            return order.TakeNewOrder();
        }

        public async Task<ActionResult> FinalizePicking(int id)
        {
            HandleOrder order = new HandleOrder();
            order.FinalizePicking(id);
        }

        public async Task<ActionResult> CancelOrder(int id)
        {
            HandleOrder order = new HandleOrder();
            order.CancelOrder(id);
        }

        public async Task<ActionResult> QueueNewOrder(Order order, bool isHigh)
        {
            HandleOrder handler = new HandleOrder();
            handler.QueueNewOrder(order, isHigh);
        }

        public async Task<ActionResult> DeleteOrder(int id)
        {
            HandleOrder handler = new HandleOrder();
            handler.DeleteOrder(id);
        }

        public async Task<ActionResult> ClearOrderQueue()
        {
            HandleOrder handler = new HandleOrder();
            handler.ClearOrderQueue();
        }

        public async Task<ActionResult> CheckOrderPosition(int id)
        {
            HandleOrder handler = new HandleOrder();
            return handler.CheckOrderPosition(id);
        }

        public async Task<ActionResult> CutFromOrder(int itemId, int orderId)
        {
            HandleOrder handler = new HandleOrder();
            handler.CutFromOrder(itemId, orderId);
        }
    }
}
