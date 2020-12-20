﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Models.V1;
using FluentValidation;

namespace CustomerApi.Validators.V1
{
    public class CreateCustomerModelValidator : AbstractValidator<CreateCustomerModel>
    {
        public CreateCustomerModelValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("The first name must be at least 2 character long");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("The first name must be at least 2 character long");

            RuleFor(x => x.LastName).NotNull().WithMessage("The last name must be at least 2 character long");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("The last name must be at least 2 character long");

            RuleFor(x => x.DateOfBirth).InclusiveBetween(DateTime.Now.AddYears(-150).Date, DateTime.Now).WithMessage("The birthday must not be longer ago than 150 years and can not be in the future");
            RuleFor(x => x.Age).InclusiveBetween(0, 150).WithMessage("The minimum age is 0 and the maximum age is 150 years");
        }
    }
}
