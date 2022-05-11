using Entities.Entities;
using Entities.Validadors;
using System;

namespace Project_Helper
{
    public static class CashBookHelper
    {
        public static bool InvalidCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            return !result.IsValid;
        }
        public static bool ValidCashBook(CashBook cashbook)
        {
            var validator = new CashBookValidator();
            var result = validator.Validate(cashbook);
            return result.IsValid;
        }
    }
}
