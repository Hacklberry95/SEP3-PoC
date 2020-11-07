using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientFramework.Data;

namespace ServerFramework.Services
{
    public class ClientWebServiceImpl : ClientWebService
    {
        private string DataURI;
        
        public async Task ConfirmOrder(Order order)
        {
            int i = order.getOrderId();
            await ConfirmOrder(i);
        }

        public async Task ConfirmOrder(int id)
        {
            HttpClient httpClient = new HttpClient();
            string serialId = JsonSerializer.Serialize(id, id.GetType());
            StringContent content = new StringContent(serialId);
            await httpClient.PostAsync(DataURI, content);
        }
    }
}
