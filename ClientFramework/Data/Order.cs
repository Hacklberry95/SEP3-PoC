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
        /// <param name="items">The list of items in the order.</param>
        public Order(List<Item> items)
        {
            this.items = items;
            orderState = 0;
        }

        /// <summary>
        /// Finishes the setup of the Order class. WARNING: call immediately after server gets the ID for the Order added to the database.
        /// </summary>
        /// <param name="id">The ID retrieved from the database.</param>
        public void InitOrder(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Method to change order state. Enabling changes depends on authorization roles and current order state.
        /// Possible order states:
        /// 0 - order created
        /// 1 - order in queue
        /// 2 - order assigned
        /// 3 - order loading
        /// 4 - order complete
        /// </summary>
        public void ChangeOrderState()
        {
            //Don't forget to create role checking method.
        }
    }
}