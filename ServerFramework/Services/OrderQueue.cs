using System.Collections.Generic;
using ServerFramework.Data;

namespace ServerFramework.Services
{
    /// <summary>
    /// Class for the queue that holds the orders. Initializes a high and a normal priority queue.
    /// </summary>
    public class OrderQueue : IOrderQueue
    {
        private List<int> nQueue;
        private List<int> hQueue;

        /// <summary>
        /// Constructor for the Order Queue class.
        /// </summary>
        public OrderQueue()
        {
            nQueue = new List<int>();
            hQueue = new List<int>();
        }

        /// <summary>
        /// Clears the queue, deletes all the orders and initializes two new queues.
        /// </summary>
        public void Clear()
        {
            nQueue = new List<int>();
            hQueue = new List<int>();
        }

        /// <summary>
        /// This method removes a given order by the order ID.
        /// </summary>
        /// <param name="orderId">ID of the order</param>
        public void RemoveOrder(int orderId)
        {
            if (hQueue.Contains(orderId))
            {
                hQueue.Remove(orderId);
            } 
            else if (nQueue.Contains(orderId))
            {
                nQueue.Remove(orderId);
            }
        }

        /// <summary>
        /// Adds a new order by the ID into the normal priority queue.
        /// </summary>
        /// <param name="orderId">ID of the order.</param>
        public void Enque(int orderId)
        {
            nQueue.Add(orderId);
        }

        /// <summary>
        /// Adds a new order by the ID into the high priority queue.
        /// </summary>
        /// <param name="orderId">ID of the order.</param>
        public void EnqueueHighpriority(int orderId)
        {
            hQueue.Add(orderId);
        }

        /// <summary>
        /// This method returns the order which is first in the queue.
        /// </summary>
        /// <returns>First.</returns>
        public int Dequeue()
        {
            if (hQueue.Count > 0)
            {
                int res = hQueue[0];
                int[] eee = new int[hQueue.Count];
                hQueue.CopyTo(eee, 1);
                List<int> tmp1 = new List<int>(eee);
                hQueue = tmp1;
                return res;
            }
            else
            {
                int res = nQueue[0];
                int[] eee = new int[nQueue.Count];
                nQueue.CopyTo(eee, 1);
                List<int> tmp1 = new List<int>(eee);
                nQueue = tmp1;
                return res;
            }

        }

        /// <summary>
        /// This method returns the position of the given order's position in the queue.
        /// </summary>
        /// <param name="pos">Position</param>
        /// <returns>Position in queue.</returns>
        public int Peek(int pos)
        {
            if (pos <= hQueue.Count - 1)
            {
                return hQueue[pos];
            }
            else
            {
                return nQueue[pos - hQueue.Count];
            }

        }

        /// <summary>
        /// This method is to returns the index of the given order in the queue.
        /// </summary>
        /// <param name="OrderId">The ID of the order.</param>
        /// <returns>-1</returns>
        public int Contains(int OrderId)
        {
            if (hQueue.Contains(OrderId))
            {
                return hQueue.IndexOf(OrderId);
            }
            else if (nQueue.Contains(OrderId))
            {
                return nQueue.IndexOf(OrderId);
            }

            return -1;
        }
    }
}