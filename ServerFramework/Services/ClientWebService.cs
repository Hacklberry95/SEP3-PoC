using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerFramework.Authorization;
using ServerFramework.Data;

namespace ServerFramework.Services
{
    interface ClientWebService
    {
        public Task ConfirmOrder(int id);
        public Task ConfirmOrder(Order order);
        public Task ReceiveItem(Item item);
        public Task ReceiveItem(int id);
        public Task<User> ValidateUser(string username, string password);
    }
}
