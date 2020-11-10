using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerFramework.Services
{
    interface DataWebService
    {
        Task ConfirmOrder(int orderId);
    }
}
