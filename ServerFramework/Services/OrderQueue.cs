using System.Collections.Generic;
using ServerFramework.Data;

namespace ServerFramework.Services
{
    public class OrderQueue : IOrderQueue
    {
        private List<int> nQueue;
        private List<int> hQueue;

        public OrderQueue()
        {
            nQueue = new List<int>();
            hQueue = new List<int>();
        }

        public void Clear()
        {
            nQueue = new List<int>();
            hQueue = new List<int>();
        }

        public void RemoveOrder(int orderId)
        {
            if (hQueue.Contains(orderId))
            {
                int dex = hQueue.IndexOf(orderId);
            }
        }

        public void Enque(int orderId)
        {
            nQueue.Add(orderId);
        }

        public void EnqueueHighpriority(int orderId)
        {
            hQueue.Add(orderId);
        }

        public int Dequeue()
        {
            if (hQueue.Count>0)
            {
                int res = hQueue[0];
                int[] eee = new int[hQueue.Count];
                hQueue.CopyTo(eee,1);
                List<int> tmp1 = new List<int>(eee);
                hQueue = tmp1;
                return res;
            }
            else
            {
                int res = nQueue[0];
                int[] eee = new int[nQueue.Count];
                nQueue.CopyTo(eee,1);
                List<int> tmp1 = new List<int>(eee);
                nQueue = tmp1;
                return res; 
            }
        
        }

        public int Peek(int pos)
        {
            if (pos <= hQueue.Count-1)
            {
                return hQueue[pos];
            }
            else
            {
                return nQueue[pos-hQueue.Count];
            }
            
        }

        public int Contains(int OrderId)
        {
            if (hQueue.Contains(OrderId))
            {
                return hQueue.IndexOf(OrderId);
            }
            else if(nQueue.Contains(OrderId))
            {
                return nQueue.IndexOf(OrderId);
            }
        }
    }