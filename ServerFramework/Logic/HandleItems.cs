using System.Collections.Generic;
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

        public Item GetItem(string id)
        {
            return null;
        }

        /// <summary>
        /// This method would move the given amount of damaged items to another table in the DB.
        /// </summary>
        /// <param name="id">Item ID.</param>
        public void MarkItemAsDamaged(string id)
        {
            //stock--, damaged++
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