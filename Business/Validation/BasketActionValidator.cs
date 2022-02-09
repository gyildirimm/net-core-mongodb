using Domain.DTOs.Basket;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class BasketActionValidator : AbstractValidator<BasketActionDto>
    {
        public BasketActionValidator()
        {
            RuleFor(r => r.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(r => r.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
