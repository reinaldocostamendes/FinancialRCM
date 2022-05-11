using AutoMock;
using Domain.Interfaces;
using Domain.Services;
using Entities.Entities;
using Entities.Enums;
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
    public class DocumentTests

    {
        private readonly AutoMocker _mocker;

        public DocumentTests()
        {
            _mocker = new AutoMocker();
        }

        [Fact]
        public void TestNotNull()
        {
            var d = new Document()
            { };
            Assert.NotNull(d);
            // Assert.Pass();
        }

        [Fact]
        public void TestInvalidDocument()
        {
            var d = new Document()
            { };
            var result = DocumentHelper.InvalidDocument(d);
            Assert.True(result);
            //  Assert.Pass();
        }

        [Fact(DisplayName = "Add Document Successfull")]
        [Trait("Type", "Document 1 AutoMoq test")]
        public async void Add_Document_Successfull()
        {
            var d = new Document()
            {
                Id = Guid.NewGuid(),
                Number = "32323",
                Date = DateTime.Now,
                DocumentType = DocumentType.RECEIPT,
                Operation = Operation.Input,
                Payed = true,
                PaymentDate = DateTime.Now,
                Description = "Document for tests",
                Total = 200,
                Observation = "For tests"
            };
            var cashbookRepository = _mocker.GetMock<IDocumentRepository>();
            var _cashBooService = _mocker.CreateInstance<DocumentService>();
            await _cashBooService.AddDocument(d);
            cashbookRepository.Verify(x => x.AddDocument(It.IsAny<Document>()), Times.Once);
        }

        [Fact(DisplayName = "GetAll Document Successfull")]
        [Trait("Type", "Document All AutoMoq test")]
        public async void GetAll_Document_Returns()
        {
            var cashbookRepository = _mocker.GetMock<IDocumentRepository>();
            var _cashBooService = _mocker.CreateInstance<DocumentService>();
            var pgP = new Entities.PageParam.PageParameters() { PageIndex = 1, PageSize = 5 };
            var docs = await _cashBooService.GetAllDocuments(pgP);
            cashbookRepository.Verify(r => r.GetAllDocuments(pgP), Times.Once);
            Assert.NotNull(docs);
            Assert.True(docs.Count() > 0);
            Assert.True(docs.Any());
        }
    }
}