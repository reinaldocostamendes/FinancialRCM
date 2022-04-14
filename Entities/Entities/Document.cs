using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTimeOffset Date { get; set; }
        public DocumentType DocumentType { get; set; }
        public Operation Operation { get; set; }
        public bool Payed { get; set; }
        public DateTimeOffset PaymentDate { get; set; } 
        public string Description { get; set; } 
        public decimal Total { get; set; }

        public string Observation { get; set; } 

    }
}
