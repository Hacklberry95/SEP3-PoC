using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ServerFramework.Authorization;
using ServerFramework.Data;
using ServerFramework.Logic;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace ServerFramework.Services
{
    public class ClientWebServiceImpl : ClientWebService
    {
        public async Task<User> ValidateUser(string username, string password)
        {
            ISocketService socket = new SocketServiceImpl();
            User user = socket.ValidateUser(username, password);
            return user;
        }

        /// <summary>
        /// Confirm order loading.
        /// </summary>
        /// <param name="id">Order id</param>
        /// <returns>Nothing.</returns>
        public async Task ConfirmOrder(int id)
        {
            System.Diagnostics.Debug.WriteLine("ClientWebServiceConfirm");
            HandleOrder handleOrders = new HandleOrder(null);
            handleOrders.LoadTruckOrder(id);
        }
        
        /// <summary>
        /// Receive items into the warehouse.
        /// </summary>
        /// <param name="id">id of item to receive</param>
        /// <param name="count">Count of item to receive</param>
        /// <returns>Nothing.</returns>
        public async Task ReceiveItem(int id, int count)
        {
            System.Diagnostics.Debug.WriteLine("ClientWebServiceConfirm");
            HandleItems items = new HandleItems();
            items.ReturnItems(id, count);
        }

        /// <summary>
        /// Adds a new item to database.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        /// <returns>Nothing.</returns>
        public async Task AddNewItem(Item item)
        {
            HandleItems items = new HandleItems();
            items.AddNewItem(item);
        }

        public async Task EditItem(Item item)
        {
            HandleItems items = new HandleItems();
            items.EditItem(item);
        }

        public async Task RemoveItem(int id)
        {
            HandleItems items = new HandleItems();
            items.RemoveItem(id);
        }
    }
}
