using Application.DTOs;
using FIinancial_API.ViewModels;
using FluentValidation;

namespace FIinancial_API.ViewModelValidators
{
    public class CashBookDTOValidator: AbstractValidator<CashBookDTO>
    {
        public CashBookDTOValidator()
        {

        }
    }
}
