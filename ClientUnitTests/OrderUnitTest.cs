using System;
using NUnit.Framework;
using ClientFramework.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClientUnitTests
{
    public class Tests
    {
        public Order order;
        
        [SetUp]
        public void Setup()
        {
            //order = new Order();
        }

        [Test]
        public void Test1()
        {
            //Assert.IsNotNull(order.Id());
        }

        [Test]
        public void Test2()
        {
            //Assert.IsNotNull(order.OrderState());
        }

        [Test]
        public void Test3()
        {
            //order.setOrderId(3);
            //Assert.AreEqual(order.getOrderId(), 3);
        }
        

        [Test]
        public void Test5()
        {

            //order.setOrderState(3);
            //Assert.AreEqual(order.getOrderState(), 3);
        }
    }
}