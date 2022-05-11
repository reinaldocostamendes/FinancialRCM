using Application.Applications;
using AutoMock;
using Domain.Interfaces;
using Domain.Services;
using Entities.Entities;
using Entities.Enums;
using Infrastruture.Repository;
using Moq;
using Moq.AutoMock;
using Project_Helper;
using System;
using System.Linq;
using Xunit;

namespace Projectc_Unit_Test
{
    public class CasBookTests
    {
        private readonly AutoMocker _mocker;

        public CasBookTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact(DisplayName = "Add CashBook Successfull")]
        [Trait("Type", "CashBook 1 AutoMoq test")]
        public async void Add_CashBook_SuccessFull()
        {
            var cashBook = new CashBook()
            {
                Id = Guid.NewGuid(),
                Origin = CashBookOrigin.DOCUMENT,
                OriginId = Guid.NewGuid(),
                Description = "For test valid cashbook",
                Type = CashBookType.PAYMENT,
                Value = -200
            };
            var cashbookRepository = _mocker.GetMock<ICashBookRepository>();
            var _cashBooService = _mocker.CreateInstance<CashBookService>();
            await _cashBooService.AddCashBook(cashBook);
            cashbookRepository.Verify(x => x.AddCashBook(It.IsAny<CashBook>()), Times.Once);
        }

        [Fact]
        public void TestNotNull()
        {
            var cashBook = new CashBook()
            {
            };
            Assert.NotNull(cashBook);
            // Assert.True();
        }

        [Fact(DisplayName = "Add Empty CashBook")]
        [Trait("Type", "CashBook 1 AutoMoq test empty")]
        public async void TestInvalid()
        {
            var cashBook = new CashBook()
            {
            };
            var cashbookRepository = _mocker.GetMock<ICashBookRepository>();
            var _cashBooService = _mocker.CreateInstance<CashBookService>();
            await _cashBooService.AddCashBook(cashBook);
            cashbookRepository.Verify(x => x.AddCashBook(It.IsNotNull<CashBook>()), Times.Once);
        }

        [Fact(DisplayName = "GetAll CashBook")]
        [Trait("Type", "CashBook All AutoMoq test")]
        public async void Get_All_CashBook_Must_Be_Returns()
        {
            var cashbookRepository = _mocker.GetMock<ICashBookRepository>();
            var _cashBooService = _mocker.CreateInstance<CashBookService>();
            var pgP = new Entities.PageParam.PageParameters() { PageIndex = 1, PageSize = 5 };
            var csb = await _cashBooService.GetAllCashBook(pgP);
            cashbookRepository.Verify(r => r.GetAllCashBook(pgP), Times.Once);
            Assert.NotNull(csb);
            Assert.True(csb.Count() > 0);
            Assert.True(csb.Any());
        }

        [Fact(DisplayName = "Add CashBook Invalid")]
        [Trait("Type", "CashBook 1 AutoMoq test invalid")]
        public async void Add_Invalid_CashBook()
        {
            var cashBook = new CashBook()
            {
                Id = Guid.NewGuid(),
                Origin = CashBookOrigin.DOCUMENT,
                OriginId = Guid.NewGuid(),
                Description = "For test valid cashbook",
                Type = CashBookType.PAYMENT,
                Value = 200
            };
            var cashbookRepository = _mocker.GetMock<ICashBookRepository>();
            var _cashBooService = _mocker.CreateInstance<CashBookService>();
            await _cashBooService.AddCashBook(cashBook);
            cashbookRepository.Verify(x => x.AddCashBook(It.IsAny<CashBook>()), Times.Once);
        }
    }
}