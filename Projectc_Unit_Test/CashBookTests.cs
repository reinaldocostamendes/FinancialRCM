using Entities.Entities;
using Entities.Enums;
using NUnit.Framework;
using Project_Helper;
using System;

namespace Projectc_Unit_Test
{
    public class CasBookTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNotNull()
        {
            var cashBook = new CashBook()
            {

            };
            Assert.IsNotNull(cashBook); 
            Assert.Pass();
        }
        [Test]
        public void TestInvalid()
        {
            var cashBook = new CashBook()
            {

            };
            var result = CashBookHelper.InvalidCashBook(cashBook);
            Assert.IsTrue(result);
            Assert.Pass();
        }
        [Test]
        public void TestValid()
        {
            var cashBook = new CashBook()
            {
                Id = Guid.NewGuid(),
                Origin = CashBookOrigin.DOCUMENT,
                OriginId= Guid.NewGuid(),
                Description = "For test valid cashbook",
                Type =  CashBookType.PAYMENT,
                Value =     -200

            };
            var result = CashBookHelper.ValidCashBook(cashBook);
            Assert.IsTrue(result);
            Assert.Pass();
        }
    
    }
}