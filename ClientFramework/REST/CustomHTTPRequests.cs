﻿using ClientFramework.Data;
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
            System.Diagnostics.Debug.WriteLine("PostConfirmation");
            HttpClient client = new HttpClient();
            Uri webService = new Uri("");
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(orderID, orderID.GetType());
            StringContent content = new StringContent(jsonString);
            HttpResponseMessage message = await client.PostAsync(webService, content);
            if (message.IsSuccessStatusCode) return message;
            else return null;
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
    }
}