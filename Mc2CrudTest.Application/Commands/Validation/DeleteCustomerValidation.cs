using FluentValidation;
using Mc2CrudTest.Application.Commands.Customer;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.Commands.Validation
{
    public class DeleteCustomerValidation : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerValidation()
        {
            RuleFor(customer => customer.Request.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Id should greater than 0");
            
        }
    }

}
