using Entities.Entities;
using Entities.Enums;
using NUnit.Framework;
using Project_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectc_Unit_Test
{
    public class OrderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNotNull()
        {
            var order = new Order()
            {};
            Assert.IsNotNull(order);
            Assert.Pass();
        }
        [Test]
        public void TestInvalidOrder()
        {
            var order = new Order()
            { };
            var result = OrderHelper.InvalidOrder(order);
            Assert.IsTrue(result);
            Assert.Pass();
        }
        [Test]
        public void TestValidOrder()
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Code = 245,
                Date = DateTime.Now,
                DeliveryDate = DateTime.Now,
                Client = Guid.NewGuid(),
                ClientDescription = "Teste client",
                ClientEmail = "client@client.com",
                ClientPhone = "913344555",
                Status = OrderStatus.RECEIVED,
                Street = "4555 Street",
                StreetNumber = "45",
                ProductsValues = 2900,
                Discount = 190,
                CostValue =800,
                TotalValue =1500
            };
            var result = OrderHelper.ValidOrder(order);
            Assert.IsTrue(result);
            Assert.Pass();
        }
    }
}
