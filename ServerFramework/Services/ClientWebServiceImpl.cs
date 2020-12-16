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
            HandleOrder handleOrders = new HandleOrder();
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

        public async Task<Item> GetItem(int id)
        {
            HandleItems items = new HandleItems();
            return items.GetItem(id);
        }

        public async Task MarkItemAsDamaged(int id, int count)
        {
            HandleItems items = new HandleItems();
            items.MarkItemAsDamaged(id, count);
        }

        public async Task AllocatePutaway(Item item, string id)
        {
            HandleLocations items = new HandleLocations();
            items.AllocatePutaway(item, id);
        }

        public async Task CreateLocation(string id)
        {
            HandleLocations items = new HandleLocations();
            items.CreateLocation(id);
        }

        public async Task UpdateLocation(Location item)
        {
            HandleLocations items = new HandleLocations();
            items.UpdateLocation(item);
        }

        public async Task DeleteLocation(string id)
        {
            HandleLocations items = new HandleLocations();
            items.DeleteLocation(id);
        }

        public async Task<Location> GetLocation(string id)
        {
            HandleLocations items = new HandleLocations();
            return items.GetLocation(id);
        }

        public async Task<List<string>> ReplenishLocation(string id)
        {
            HandleLocations loc = new HandleLocations();
            return loc.ReplenishLocation(id);
        }

        public async Task AddUser(User user)
        {
            HandleUsers items = new HandleUsers();
            items.AddUser(user);
        }

        public async Task UpdateUser(User user)
        {
            HandleUsers items = new HandleUsers();
            items.UpdateUser(user);
        }

        public async Task DeleteUser(string username)
        {
            HandleUsers items = new HandleUsers();
            items.RemoveUser(username);
        }

        public async Task<User> GetUser(string username)
        {
            HandleUsers items = new HandleUsers();
            return items.GetUser(username);
        }

        public async Task<Order> TakeNewOrder()
        {
            HandleOrder order = new HandleOrder();
            return order.TakeNewOrder();
        }

        public async Task FinalizePicking(int id)
        {
            HandleOrder order = new HandleOrder();
            order.FinalizePicking(id);
        }

        public async Task CancelOrder(int id)
        {
            HandleOrder order = new HandleOrder();
            order.CancelOrder(id);
        }

        public async Task QueueNewOrder(Order order, bool isHigh)
        {
            HandleOrder handler = new HandleOrder();
            handler.QueueNewOrder(order, isHigh);
        }

        public async Task DeleteOrder(int id)
        {
            HandleOrder handler = new HandleOrder();
            handler.DeleteOrder(id);
        }

        public async Task ClearOrderQueue()
        {
            HandleOrder handler = new HandleOrder();
            handler.ClearOrderQueue();
        }

        public async Task<int> CheckOrderPosition(int id)
        {
            HandleOrder handler = new HandleOrder();
            return handler.CheckOrderPosition(id);
        }

        public async Task CutFromOrder(int itemId, int orderId)
        {
            HandleOrder handler = new HandleOrder();
            handler.CutFromOrder(itemId, orderId);
        }

    }
}