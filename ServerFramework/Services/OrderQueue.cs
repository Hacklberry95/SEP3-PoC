using System.Collections.Generic;
using ServerFramework.Data;

namespace ServerFramework.Services
{
    /// <summary>
    /// Class for the queue that holds the orders. Initializes a high and a normal priority queue.
    /// </summary>
    public class OrderQueue
    {
        private static List<int> nQueue;
        private static List<int> hQueue;

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
        public static void Clear()
        {
            nQueue = new List<int>();
            hQueue = new List<int>();
        }

        /// <summary>
        /// This method removes a given order by the order ID.
        /// </summary>
        /// <param name="orderId">ID of the order</param>
        public static void RemoveOrder(int orderId)
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
        public static void Enque(int orderId)
        {
            nQueue.Add(orderId);
        }

        /// <summary>
        /// Adds a new order by the ID into the high priority queue.
        /// </summary>
        /// <param name="orderId">ID of the order.</param>
        public static void EnqueueHighpriority(int orderId)
        {
            hQueue.Add(orderId);
        }

        /// <summary>
        /// This method returns the order which is first in the queue.
        /// </summary>
        /// <returns>First order's id or -1.</returns>
        public static int Dequeue()
        {
            if (hQueue.Count > 0)
            {
                int res = hQueue[0];
                hQueue.Remove(res);
                return res;
            }
            else if (nQueue.Count > 0)
            {
                int res = nQueue[0];
                nQueue.Remove(res);
                return res;
            }
            else return -1;
        }

        /// <summary>
        /// This method returns the position of the given order's position in the queue.
        /// </summary>
        /// <param name="pos">Position</param>
        /// <returns>Position in queue.</returns>
        public static int Peek(int pos)
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
        /// This method returns the index of the given order in the queue.
        /// </summary>
        /// <param name="OrderId">The ID of the order.</param>
        /// <returns>-1 or the position of the order in the queue.</returns>
        public static int Contains(int OrderId)
        {
            if (hQueue.Contains(OrderId))
            {
                return hQueue.IndexOf(OrderId);
            }
            else if (nQueue.Contains(OrderId))
            {
                return (nQueue.IndexOf(OrderId) + hQueue.Count);
            }
            else return -1;
        }
    }
}