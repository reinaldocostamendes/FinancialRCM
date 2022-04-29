using Entities.Entities;
using Entities.Validadors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Helper
{
    public static class DocumentHelper
    {
        public static bool InvalidDocumentMan(Document document)
        {
            if (document == null) return true;
            if(document.Number.Equals("")||document.Date.Equals("") ||document.DocumentType.Equals("") ||
                document.Operation.Equals("") ||document.Payed.Equals("") ||document.PaymentDate.Equals("") 
                ||document.Description.Equals("") ||document.Total.Equals(""))
                return true;
            return false;
        }
        public static bool InvalidDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            return !result.IsValid;
        }
        public static bool ValidDocument(Document document)
        {
            var validator = new DocumentValidator();
            var result = validator.Validate(document);
            return result.IsValid;
        }
    }
}
