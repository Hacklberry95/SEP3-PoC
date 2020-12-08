﻿using ServerFramework.Authorization;
using ServerFramework.Authorization.AuthRoles;
using ServerFramework.Data;
using ServerFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerFramework.Logic
{
    /// <summary>
    /// Main logic class for handling orders. Roles accessing: Picker, Picking Manager, Troubleshooter, Loader.
    /// </summary>
    public class HandleOrder
    {
        private Order order;
        private User user;
        private OrderQueue queue;

        public HandleOrder(User user)
        {
            this.user = user;
            queue = null; //write queue getter
        }

        public void LoadOrderToField(int id)
        {
            //set current order
        }

        public Order TakeNewOrder()
        {
            if (user.Roles.OfType<Picker>().Any())
            {
                int id = queue.Dequeue();
                if (id == -1)
                {
                    return null;
                }
                else
                {
                    Order pick = new Order(new List<Item>(), new List<int>());
                    //get full order, send to client
                    pick.ChangeOrderState();
                    return pick;
                }
            }
            else return null;
        }

        public void FinalizePicking(int id)
        {
            if (user.Roles.OfType<Picker>().Any())
            {
                LoadOrderToField(id);
                List<int> containers = new List<int>();
                List<int> containersCount = new List<int>();
                //read containers from client, then free up client order
                order.ChangeOrderState();
            }
        }

        public void CancelOrder(int id)
        {
            queue.RemoveOrder(id);
            //delete order from database
        }

        public void HandleCancelledOrder(int id)
        {
            LoadOrderToField(id);
            //figure out how to do this
        }

        public void LoadTruckOrder(int id)
        {
            LoadOrderToField(id);
            order.ChangeOrderState();
            //post orderstate to database, update it
        }

        public void QueueNewOrder(Order order, bool isHigh)
        {
            if (isHigh) 
                queue.EnqueueHighpriority(order.Id);
            else queue.Enque(order.Id);
        }

        public void DeleteOrder(int id)
        { 
            //delete order from DB
        }

        public void ClearOrderQueue()
        {
            queue.Clear();
        }

        public int CheckOrderPosition(int id)
        {
            return queue.Contains(id);
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