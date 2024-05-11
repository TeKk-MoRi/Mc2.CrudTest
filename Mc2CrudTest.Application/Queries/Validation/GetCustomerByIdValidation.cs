using FluentValidation;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.Queries.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.Queries.Validation
{
    public class GetCustomerByIdValidation : AbstractValidator<GetCustomerByIdQuery>
    {
        public GetCustomerByIdValidation()
        {
            RuleFor(customer => customer.Request.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id should greater than 0");

        }
    }
}
