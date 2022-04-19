using System;

namespace Application.DTOs
{
    public class DocumentDTO
    {
        public string Number { get; set; }  
        public DateTime Date { get; set; }
        public int DocumentType { get; set; }
        public int Operation { get; set; }
        public bool Payed { get; set; }
        public DateTime PayementDate { get; set; }
        public string Description { get; set; }
        public decimal Total { get; set; }
        public string Observation { get; set; }
    }
}
