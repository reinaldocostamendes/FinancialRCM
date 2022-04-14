using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validadors
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(o => o.Code).NotNull().WithMessage("Code is requirid");
            RuleFor(o => o.Date).NotNull().WithMessage("Date is requirid");
            RuleFor(o => o.DeliveryDate).NotNull().WithMessage("Delivery Date is requirid");
            RuleFor(o => o.Client).NotNull().WithMessage("Custumer is requirid");
            RuleFor(o => o.ClientDescription).NotNull().WithMessage("Custumer Description is requirid");
            RuleFor(o => o.ClientEmail).NotNull().WithMessage("Custumer emáil  is requirid").EmailAddress().WithMessage("Email format not Valid");
            RuleFor(o => o.ClientPhone).NotNull().WithMessage("custumer phone is requirid");
            RuleFor(o => o.Status).NotNull().WithMessage("Status is requirid");
            RuleFor(o => o.ProductsValues).NotNull().WithMessage("Products Values is requirid");
            RuleFor(o => o.CostValue).NotNull().WithMessage("Cost Value is requirid");
            RuleFor(o => o.TotalValue).NotNull().WithMessage("Total Value is requirid");
        }
    }
}
