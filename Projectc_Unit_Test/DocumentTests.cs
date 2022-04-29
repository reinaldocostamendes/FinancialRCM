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
    public class DocumentTests
        
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestNotNull()
        {
            var d = new Document()
            { };
            Assert.IsNotNull(d);
            Assert.Pass();
        }
        [Test]
        public void TestInvalidDocument()
        {
            var d = new Document()
            {};
            var result = DocumentHelper.InvalidDocument(d);
            Assert.IsTrue(result);
            Assert.Pass();
        }
        [Test]
        public void TestValidDocument()
        {
            var d = new Document()
            { 
            Id = Guid.NewGuid(),
            Number =    "32323",
            Date = DateTime.Now,    
            DocumentType = DocumentType.RECEIPT,
            Operation = Operation.Input,
            Payed = true,
            PaymentDate = DateTime.Now,
            Description = "Document for tests",
            Total = 200,
            Observation = "For tests"
            };
            var result = DocumentHelper.ValidDocument(d);
            Assert.IsTrue(result);
            Assert.Pass();
        }
    }
}
