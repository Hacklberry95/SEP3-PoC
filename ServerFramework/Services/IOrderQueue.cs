using System;

namespace ServerFramework.Services
{
    [Obsolete]
    public interface IOrderQueue
    {
        void Clear();
        void RemoveOrder(int rderId);
        //void Enqueue(Order order);
        //or
        void Enque(int OrderId);
        void EnqueueHighpriority(int orderId);
        //or
        //void EnqueueHighpriority(Order order);
        int Dequeue();
        int Peek(int pos);
        //int Contains(Order order);
        //or
        int Contains(int OrderId);
    }
}