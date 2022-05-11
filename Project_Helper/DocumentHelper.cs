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
