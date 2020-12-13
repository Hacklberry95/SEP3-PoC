using ClientFramework.Data;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientFramework.Authorization;

namespace ClientFramework.REST
{
    public class CustomHTTPRequests : ILoginService
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

        public async Task<HttpResponseMessage> PostNewItem(Item item)
        {
            HttpClient client = new HttpClient();
            Uri webService = new Uri("");
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(item, item.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }
        public async Task<HttpResponseMessage> PostAddMoreItem(int id, int count)
        {
            HttpClient client = new HttpClient();
            Uri webService = new Uri("");
            string jsonString = "";
            string sendString = id.ToString() + "#" + count.ToString();
            jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
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

        public async Task<User> ValidateLogin(string username, string password)
        {
            //reeeeeeeeeeee
            //
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5003/users?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            } 
            throw new Exception("User not found");
        }
    }
}