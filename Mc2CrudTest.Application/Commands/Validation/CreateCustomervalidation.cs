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
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidation()
        {
            RuleFor(customer => customer.Request.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Must(BeValidPhoneNumber).WithMessage("Invalid phone number format");
        }

        private bool BeValidPhoneNumber(string phoneNumber)
        {
            string countryCode = "US";

            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();

            try
            {
                PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, countryCode);

                var res = phoneNumberUtil.IsValidNumberForRegion(number, countryCode) &&
                       phoneNumberUtil.GetNumberType(number) == PhoneNumberType.FIXED_LINE_OR_MOBILE;

                return res;
            }
            catch (NumberParseException)
            {
                return false; // Invalid phone number format
            }
        }
    }
}
