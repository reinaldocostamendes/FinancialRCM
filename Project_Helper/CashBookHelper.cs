using Entities.Entities;
using Entities.Validadors;
using System;

namespace Project_Helper
{
    public static class CashBookHelper
    {
        public static bool InvalidCashBookMan(CashBook cashbook)
        {
            if (cashbook == null) { return true; } else
            {
                if((cashbook.Id.Equals("") ||cashbook.Value.Equals("")||
                    cashbook.Equals(""))||(((int)cashbook.Origin >=1&& (int)cashbook.Origin.Value <= 4)
                    &&cashbook.OriginId.Equals("")))
                {
                    return true;
                }
            };
            return false;
        }
        public static bool InvalidCashBookValue(CashBook cashBook)
        {
            if((cashBook.Type==Entities.Enums.CashBookType.RECEIVEMENT && cashBook.Value<0) ||
                (cashBook.Type == Entities.Enums.CashBookType.PAYMENT && cashBook.Value > 0))
                return true;
            return false;
        }
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
