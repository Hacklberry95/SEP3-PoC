using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerFramework.Services
{
    public class DataWebServiceImpl : DataWebService
    {
        public async Task ConfirmOrder(int orderId)
        {
            //bruh moment in my brain, where to send that shid
            HttpClient httpClient = new HttpClient();
            string serialId = JsonSerializer.Serialize(orderId, orderId.GetType());
            StringContent content = new StringContent(serialId);
            await httpClient.PostAsync(, content);
        }
    }
}
