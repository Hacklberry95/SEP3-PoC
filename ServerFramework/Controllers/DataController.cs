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
        DataWebService client;

        public async Task<ActionResult> RefactorThisToo(int OID)
        {
            try
            {
                await client.RefactorTheNameLater(OID);
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
