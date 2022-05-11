using Application.Contarcts;
using Application.DTOs;

namespace Order_API.API.Contracts
{
    public class OrderErrorMessage : ErrorMessage<OrderDTO>
    {
        public OrderErrorMessage(string code, string message, OrderDTO contract) : base(code, message, contract)
        {
        }
    }
}
