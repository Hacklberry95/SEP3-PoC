using ClientFramework.Data;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientFramework.REST
{
    public class CustomHTTPRequests
    {
        public async Task<HttpResponseMessage> PostConfirmation(int orderID)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("PostConfirmation");
                HttpClient client = new HttpClient();
                Uri webService = new Uri("http://localhost:5001/ServerFramework/api/clientControl");
                string jsonString = "";
                jsonString = JsonSerializer.Serialize(orderID.ToString(), String.Empty.GetType());
                StringContent content = new StringContent(jsonString);
                HttpResponseMessage message = await client.PostAsync(webService, content);
                if (message.IsSuccessStatusCode) return message;
                else return null;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return null;
            }
        }

        public async Task<HttpResponseMessage> PostConfirmation(Order order)
        {
            HttpClient client = new HttpClient();
            Uri webService = new Uri("");
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(order, order.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }

        public async Task<HttpResponseMessage> PostLogin(string username, string password)
        {
            HttpClient client = new HttpClient();
            Uri webService = new Uri("");
            string transform = username + "%" + password;
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(transform, transform.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }
    }
}