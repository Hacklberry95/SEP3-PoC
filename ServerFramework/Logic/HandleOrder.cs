﻿using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Data;
using ServerFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerFramework.Logic
{
    /// <summary>
    /// Main logic class for handling orders. Roles accessing: Picker, Picking Manager, Troubleshooter, Loader.
    /// </summary>
    public class HandleOrder
    {
        private Order order;

        public HandleOrder()
        {
            
        }

        public void LoadOrderToField(int id)
        {
            SocketServiceImpl socket = new SocketServiceImpl();
            order = socket.GetOrder(id);
        }

        public Order TakeNewOrder()
        {
            int id = OrderQueue.Dequeue();
            if (id == -1)
            {
                return null;
            }
            else
            {
                Order pick = new Order(new List<Item>(), new List<int>());
                SocketServiceImpl socket = new SocketServiceImpl();
                pick = socket.GetOrder(id);
                pick.ChangeOrderState();
                return pick;
            }
        }

        public void FinalizePicking(int id)
        {
            LoadOrderToField(id);
            List<int> containers = new List<int>();
            List<int> containersCount = new List<int>();
            //read containers from client, then free up client order
            SocketServiceImpl socket = new SocketServiceImpl();
            order.ChangeOrderState();
            socket.FinalizePicking(JsonSerializer.Serialize(id, Int32.MaxValue.GetType()));
        }

        public void CancelOrder(int id)
        {
            OrderQueue.RemoveOrder(id);
            DeleteOrder(id);
        }

        public void LoadTruckOrder(int id)
        {
            LoadOrderToField(id);
            order.ChangeOrderState();
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<int>(id);
            socket.LoadTruckOrder(json);
        }

        public void QueueNewOrder(Order order, bool isHigh)
        {
            if (isHigh)
                OrderQueue.EnqueueHighpriority(order.Id);
            else OrderQueue.Enque(order.Id);
        }

        public void DeleteOrder(int id)
        { 
            SocketServiceImpl socket = new SocketServiceImpl();
            string json = JsonSerializer.Serialize<int>(id);
            socket.DeleteOrder(json);
        }

        public void ClearOrderQueue()
        {
            OrderQueue.Clear();
        }

        public int CheckOrderPosition(int id)
        {
            return OrderQueue.Contains(id);
        }

        public void CutFromOrder(int itemId, int orderId)
        {
            LoadOrderToField(orderId);
            for (int i = 0; i < order.Items.Count; i++)
            {
                if (order.Items[i].Id == itemId)
                {
                    order.Items.RemoveAt(i);
                    order.ItemCounts.RemoveAt(i);
                }
            }
        }
    }
}
