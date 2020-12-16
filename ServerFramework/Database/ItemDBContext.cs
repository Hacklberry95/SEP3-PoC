using ServerFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerFramework.Database
{
    [Obsolete]
    /// <summary>
    /// Class that creates,reads, updates and deletes items
    /// </summary>
    public class ItemDBContext
    {
        /// <summary>
        /// Adds an item to the database
        /// </summary>
        /// <param name="item">Item to be added to the database</param>
        public void AddItem(Item item)
        {
            
        }
        public void RemoveItem(int id)
        {

        }

        public Item GetItem(int id)
        {
            return null;
        }

        public void UpdateItem(Item item)
        {

        }

    }
}
