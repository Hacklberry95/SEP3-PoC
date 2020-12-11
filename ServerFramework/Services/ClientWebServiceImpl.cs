using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ServerFramework.Data;

namespace ServerFramework.Services
{
    public class ClientWebServiceImpl : ClientWebService
    {      
        public async Task ConfirmOrder(Order order)
        {
            int i = order.Id;
            await ConfirmOrder(i);
        }
        
        public async Task ReceiveItem(Item item)
        {
            int i = item.Id;
            await ReceiveItem(i);
        }

        public async Task ConfirmOrder(int id)
        {
            System.Diagnostics.Debug.WriteLine("ClientWebServiceConfirm");
            HttpClient httpClient = new HttpClient();
            Uri DataURI = new Uri("http://localhost:5001/ServerFramework/api/dataControl");
            string serialId = JsonSerializer.Serialize(id, id.GetType());
            StringContent content = new StringContent(serialId);
            await httpClient.PostAsync(DataURI, content);
        }
        
        public async Task ReceiveItem(int id)
        {
            System.Diagnostics.Debug.WriteLine("ClientWebServiceConfirm");
            HttpClient httpClient = new HttpClient();
            Uri DataURI = new Uri("http://localhost:5001/ServerFramework/api/dataControl");
            string serialId = JsonSerializer.Serialize(id, id.GetType());
            StringContent content = new StringContent(serialId);
            await httpClient.PostAsync(DataURI, content);
        }

        /*public async Task getOrder(int id)
        {
            HttpClient httpClient = new HttpClient();
            Uri DataURI = new Uri("http://localhost:5001/ServerFramework/api/dataControl");
            string serial = JsonSerializer.Serialize(id, id.GetType());
            StringContent content = new StringContent(serial);
            await httpClient.GetAsync(DataURI, content);
            //lost with this method
        }*/
    }
}
