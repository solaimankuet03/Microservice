using FluentValidation;
using OrderApi.Models.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Validators.V1
{
    public class OrderModelValidator : AbstractValidator<OrderModel>
    {
        public OrderModelValidator()
        {
            RuleFor(x => x.CustomerFullName)
                .NotNull()
                .WithMessage("The customer name must be at least 2 character long");
            RuleFor(x => x.CustomerFullName)
                .MinimumLength(2).WithMessage("The customer name must be at least 2 character long");
        }
    }
}
