using ClientFramework.Data;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClientFramework.Authorization;
using System.Collections.Generic;

namespace ClientFramework.REST
{   
    public class CustomHTTPRequests : ICustomHttp
    {
        HttpClient client;
        string uriMain;

        public CustomHTTPRequests()
        {
            client = new HttpClient();
            uriMain = "http://localhost:5001/ServerFramework/api/";
        }

        public async Task<HttpResponseMessage> PostConfirmation(int orderID)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("PostConfirmation");
                Uri webService = new Uri(uriMain + "clientControl");
                string jsonString = JsonSerializer.Serialize(orderID.ToString(), String.Empty.GetType());
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

        [Obsolete]
        public async Task<HttpResponseMessage> PostConfirmation(Order order)
        {
            Uri webService = new Uri(uriMain + "clientControl");
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(order, order.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }

        public async Task<HttpResponseMessage> AddNewItem(Item item)
        {
            Uri webService = new Uri(uriMain + "itemControl/addNew");
            string jsonString = JsonSerializer.Serialize(item, item.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }
        public async Task<HttpResponseMessage> PostAddMoreItem(int id, int count)
        {
            Uri webService = new Uri(uriMain + "itemControl");
            string sendString = id.ToString() + "#" + count.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }

        public async Task<User> ValidateLogin(string username, string password)
        {
            //Console.WriteLine("custtomhttprequest validate login");
            Uri webService = new Uri(uriMain + $"/login?username={username}&password={password}");
            HttpResponseMessage response = await client.GetAsync(webService);
            if (response.IsSuccessStatusCode)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            } 
            else throw new Exception("User not found");
        }
        
        //redundant method probably - confirmed
        [Obsolete]
        public async Task<HttpResponseMessage> ConfirmPick(int itemId, int orderId)
        {
            Uri webService = new Uri(uriMain + "clientControl");
            string sendString = itemId.ToString() + "#" + orderId.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }
        
        public async Task<HttpResponseMessage> ReceiveItem(int itemId, int count)
        {
            Uri webService = new Uri(uriMain + "itemControl/receive");
            string sendString = itemId.ToString() + "#" + count.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }

        public async Task<HttpResponseMessage> EditItem(Item item)
        {
            Uri webService = new Uri(uriMain + "itemControl");
            string jsonString = JsonSerializer.Serialize(item, item.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PatchAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> RemoveItem(int itemId)
        {
            Uri webService = new Uri(uriMain + "itemControl");
            string jsonString = JsonSerializer.Serialize(itemId, itemId.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PutAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<Item> GetItem(int itemId)
        {
            Uri webService = new Uri(uriMain + $"itemControl/get?id={itemId}");
            HttpResponseMessage message = await client.GetAsync(webService);
            if (message.IsSuccessStatusCode)
            {
                string json = await message.Content.ReadAsStringAsync();
                Item item = JsonSerializer.Deserialize<Item>(json);
                return item;
            }
            else return null;
        }
        
        public async Task<HttpResponseMessage> MarkItemAsDamaged(int itemId, int count)
        {
            Uri webService = new Uri(uriMain + "itemControl/damaged");
            string sendString = itemId.ToString() + "#" + count.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> AllocatePutaway(Item item, string id)
        {
            Uri webService = new Uri(uriMain + "locationControl/putaway");
            string jsonItem = JsonSerializer.Serialize(item, item.GetType());
            string transmit = JsonSerializer.Serialize(id, String.Empty.GetType());
            string jsonString = jsonItem + "#" + transmit;
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> CreateLocation(string locationId)
        {
            Uri webService = new Uri(uriMain + "locationControl/create");
            string jsonString = JsonSerializer.Serialize(locationId, locationId.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> UpdateLocation(Location location)
        {
            Uri webService = new Uri(uriMain + "locationControl");
            string jsonString = JsonSerializer.Serialize(location, location.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PatchAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> DeleteLocation(string locationId)
        {
            Uri webService = new Uri(uriMain + "locationControl");
            string jsonString = JsonSerializer.Serialize(locationId, locationId.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PutAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> GetLocation(string locationId)
        {
            Uri webService = new Uri(uriMain + $"locationControl/get?id={locationId}");
            HttpResponseMessage message = await client.GetAsync(webService);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<List<string>> ReplenishLocation(string locationId)
        {
            Uri webService = new Uri(uriMain + "locationControl");
            string jsonString = JsonSerializer.Serialize(locationId, locationId.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                string json = await message.Content.ReadAsStringAsync();

            }
            else 
                return null;
        }
        
        //not sure
        public async Task<HttpResponseMessage> TakeNewOrder(Order order)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(order, order.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
        }
        
        public async Task<HttpResponseMessage> FinalizePicking(int id)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = id.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> CancelOrder(int id)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = id.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> QueueNewOrder(Order order, bool isHigh)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = order.ToString() + "#" + isHigh.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> DeleteOrder(int id)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = id.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        //not sure
        public async Task<HttpResponseMessage> ClearOrderQueue(Order order)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = order.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> CheckOrderPosition(int id)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = id.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        public async Task<HttpResponseMessage> CutFromOrder(int itemId, int orderId)
        {
            Uri webService = new Uri(uriMain + "orderControl");
            string sendString = itemId.ToString() + "#" + orderId.ToString();
            string jsonString = JsonSerializer.Serialize(sendString, sendString.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode)
            {
                return message;
            }
            else 
                return null;
        }
        
        ~CustomHTTPRequests()
        {
            client = null;
            GC.Collect();
        }
    }
}