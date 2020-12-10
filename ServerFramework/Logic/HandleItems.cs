using System.Linq;
using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Data;

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
        public void AddNewItem()
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                //Database upload comes here
            }
        }

        /// <summary>
        /// This method is to edit a present item in the DB.
        /// </summary>
        /// <param name="id">Item ID.</param>
        public void EditItem(string id)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                //Database upload comes here
            }
        }

        /// <summary>
        /// Removes an item by ID from the DB.
        /// </summary>
        /// <param name="id">Item ID.</param>
        public void RemoveItem(string id)
        {
            if (user.Roles.OfType<InboundManager>().Any())
            {
                //Database upload comes here
            }
        }

        /// <summary>
        /// This method would move the given amount of damaged items to another table in the DB.
        /// </summary>
        /// <param name="id">Item ID.</param>
        public void MarkItemAsDamaged(string id)
        {
            
        }

        /// <summary>
        /// This method will handle the returned orders, which can be broken down to items.
        /// </summary>
        /// <param name="order">Order ID.</param>
        public void ReturnItems(Order order)
        {
            
        }
    }
}