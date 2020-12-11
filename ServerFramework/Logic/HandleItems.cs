using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Data;
using ServerFramework.Services;

namespace ServerFramework.Logic
{
    /// <summary>
    /// This class takes care of the handling of the items.
    /// </summary>
    public class HandleItems
    {
        private Item item;
        private Order order;
        private User user;

        /// <summary>
        /// Adds new item in the DB.
        /// </summary>
        /// <param name="item">The item to be added to the DB.</param>
        public void AddNewItem(Item item)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<Item>(item);
                socket.AddNewItem(json);
            }
        }

        /// <summary>
        /// This method is to edit a present item in the DB.
        /// </summary>
        /// <param name="item">Item object.</param>
        public void EditItem(Item item)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<Item>(item);
                socket.EditItem(json);
            }
        }

        /// <summary>
        /// Removes an item by ID from the DB.
        /// </summary>
        /// <param name="item">Item object.</param>
        public void RemoveItem(Item item)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<Item>(item);
                socket.RemoveItem(json);
            }
        }

        /// <summary>
        /// Get method for item.
        /// </summary>
        /// <param name="id">Item ID.</param>
        /// <returns>An Item object.</returns>
        public Item GetItem(string id)
        {
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<string>(id);
            Item item = socket.GetItem(json);
            return item;
        }

        /// <summary>
        /// This method would move the given amount of damaged items to another table in the DB.
        /// </summary>
        /// <param name="id">Item ID.</param>
        public void MarkItemAsDamaged(string id)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                SocketServiceImpl socket = new SocketServiceImpl();
                string json = JsonSerializer.Serialize<string>(id);
                socket.MarkItemAsDamaged(json);
            }
        }

        /// <summary>
        /// This method will handle the returned orders, which can be broken down to items.
        /// </summary>
        /// <param name="itemIDs">The list of items to return.</param>
        /// <param name="itemCounts">The amount of items to return per any type.</param>
        public void ReturnItems(List<int> itemIDs, List<int> itemCounts)
        {
            //foreach, iterate, add back to list
        }
    }
}