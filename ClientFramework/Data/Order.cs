using System.Collections.Generic;

namespace ClientFramework.Data
{
    /// <summary>
    /// This class stores the orders
    /// </summary>
    public class Order
    {
        private int id;
        private int orderState;
        private List<Item> items;
        private List<Location> locations;
        public int Id
        {
            get => id;
            set => id = value;
        }
        public int OrderState
        {
            get => orderState;
            set => orderState = value;
        }
        public List<Item> Items
        {
            get => items;
            set => items = value;
        }
        public List<Location> Locations
        {
            get => locations;
            set => locations = value;
        }

        /// <summary>
        /// Constructor for the Order class
        /// </summary>
        /// <param name="items"></param>
        public Order(List<Item> items)
        {
            this.items = items;
            orderState = 0;
        }

        /// <summary>
        /// Finishes the setup of the Order class. WARNING: call immediately after server gets the ID for the Order added to the database.
        /// </summary>
        /// <param name="id"></param>
        public void InitOrder(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChangeOrderState()
        {
            
        }
    }
}