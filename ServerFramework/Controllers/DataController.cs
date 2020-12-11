using System;
using Microsoft.AspNetCore.Mvc;
using ServerFramework.Services;

namespace ServerFramework.Controllers
{
    [Route("api/dataControl")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private DataWebService db;

        public DataController()
        {
            db = new DataWebServiceImpl();
        }

        [HttpPost]
        public async void ConfirmOrder(int orderId)
        {
            try
            {
                await db.ConfirmOrder(orderId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
