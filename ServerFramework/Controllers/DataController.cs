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
