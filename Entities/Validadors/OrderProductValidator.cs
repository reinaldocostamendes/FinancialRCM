﻿using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validadors
{
    public class OrderProductValidator: AbstractValidator<OrderProducts>
    {
        public OrderProductValidator()
        {
            RuleFor(o => o.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(o => o.OrderId).NotNull().WithMessage("Order Id is requirid");
            RuleFor(o => o.ProductId).NotNull().WithMessage("Product Id is requirid");
            RuleFor(o => o.ProductDescription).NotNull().WithMessage("Product Description is requirid");
            RuleFor(o => o.ProductCategory).NotNull().WithMessage("IProduct Category is requirid");
            RuleFor(o => o.Quantity).NotNull().WithMessage("Quantity is requirid");
            RuleFor(o => o.Value).NotNull().WithMessage("Value is requirid");
            RuleFor(o => o.Total).NotNull().WithMessage("Total is requirid");
        }
    }
}
