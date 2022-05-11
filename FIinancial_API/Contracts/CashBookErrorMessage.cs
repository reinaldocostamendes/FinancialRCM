using Application.Contarcts;
using Application.DTOs;
using Application.ViewModel;

namespace CashBook_Error.API.Contracts
{
    public class CashBookErrorMessage : ErrorMessage<CashBookDTO>
    {
        public CashBookErrorMessage(string code, string message, CashBookDTO contract) : base(code, message, contract)
        {
        }
    }
}
