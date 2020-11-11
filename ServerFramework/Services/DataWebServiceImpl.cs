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
            System.Diagnostics.Debug.WriteLine("DataWebServiceConfirm");
            HttpClient httpClient = new HttpClient();
            Uri uri = new Uri("http://localhost:8080/team/WOrder");
            string serialId = JsonSerializer.Serialize(orderId, orderId.GetType());
            StringContent content = new StringContent(serialId);
            await httpClient.PostAsync(uri, content);
        }
    }
}
