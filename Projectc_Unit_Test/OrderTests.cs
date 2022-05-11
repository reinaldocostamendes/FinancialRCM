using AutoMock;
using Domain.Interfaces;
using Domain.Services;
using Entities.Entities;
using Entities.Enums;
using Entities.PageParam;
using Moq;
using Moq.AutoMock;
using Project_Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Projectc_Unit_Test
{
    public class OrderTests
    {
        private readonly AutoMocker _mocker;

        public OrderTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public void TestNotNull()
        {
            var order = new Order()
            { };
            Assert.NotNull(order);
            //  Assert.Pass();
        }

        [Fact]
        public void TestInvalidOrder()
        {
            var order = new Order()
            { };
            var result = OrderHelper.InvalidOrder(order);
            Assert.True(result);
            //  Assert.Pass();
        }

        [Fact]
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
                CostValue = 800,
                TotalValue = 1500
            };
            var result = OrderHelper.ValidOrder(order);
            Assert.True(result);
            //  Assert.Pass();
        }

        [Fact(DisplayName = "Add Order Successfull")]
        [Trait("Type", "Order 1 AutoMoq test")]
        public async void Add_Valid_Order_Success()
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
                CostValue = 800,
                TotalValue = 1500
            };
            var cashbookRepository = _mocker.GetMock<IOrderRepository>();
            var _cashBooService = _mocker.CreateInstance<OrderService>();
            await _cashBooService.AddOrder(order);
            cashbookRepository.Verify(x => x.AddOrder(It.IsAny<Order>()), Times.Once);
        }

        [Fact(DisplayName = "GetAll Order Successfull")]
        [Trait("Type", "Order 1 AutoMoq test")]
        public async void GetAll_Order_Returns()
        {
            var cashbookRepository = _mocker.GetMock<IOrderRepository>();
            var _cashBooService = _mocker.CreateInstance<OrderService>();
            var pgP = new PageParameters() { PageIndex = 1, PageSize = 5 };
            var orders = await _cashBooService.GetAllOrders(pgP);
            cashbookRepository.Verify(x => x.GetAllOrders(pgP), Times.Once);
            Assert.NotNull(orders);
            Assert.True(orders.Count() > 0);
            Assert.True(orders.Any());
        }
    }
}