namespace ClientFramework.Data
{
    public class Order
    {
        private int orderId;
        private int orderState;

        public Order()
        {
            orderId = -1;
            orderState = 0;
        }

        public Order(int orderId)
        {
            this.orderId = orderId;
            orderState = 0;
        }

        public void setOrderState(int i)
        {
            orderState = i;
        }

        public int getOrderState()
        {
            return orderState;
        }

        public void setOrderId(int id)
        {
            orderId = id;
        }

        public int getOrderId()
        {
            return orderId;
        }
    }
}