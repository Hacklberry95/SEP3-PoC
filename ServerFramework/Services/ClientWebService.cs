using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientFramework.Data;

namespace ServerFramework.Services
{
    interface ClientWebService
    {
        public Task ConfirmOrder(int id);
        public Task ConfirmOrder(Order order);
    }
}
