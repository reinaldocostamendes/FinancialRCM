﻿using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Validadors
{
    public class CashBookValidator : AbstractValidator<CashBook>
    {
        public CashBookValidator()
        {
            RuleFor(c => c.Id).NotNull().WithMessage("Id is requirid");
            RuleFor(c => c.OriginId).NotNull().WithMessage("Origin Id is requirid");
            RuleFor(c => c.Origin).NotNull().WithMessage("Origin is requirid");
            RuleFor(c => c.Description).NotNull().WithMessage("Description is requirid");
            RuleFor(c => c.Type).NotNull().WithMessage("Type is requirid");
            RuleFor(c => c.Value).NotNull().WithMessage("Value is requirid");
        }
    }
}
