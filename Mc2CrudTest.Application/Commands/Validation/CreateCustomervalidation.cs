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
    public class CreateCustomervalidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomervalidation()
        {
            RuleFor(customer => customer.Request.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Must(BeValidPhoneNumber).WithMessage("Invalid phone number format");

            // Add other validation rules for other properties of the Customer class
        }

        private bool BeValidPhoneNumber(string phoneNumber)
        {
            // Replace "US" with the appropriate country code for your application
            string countryCode = "US";

            // Instantiate PhoneNumberUtil
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();

            try
            {
                // Parse the phone number
                PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, countryCode);

                // Check if the number is valid for the specified country code and if it's a mobile number
                return phoneNumberUtil.IsValidNumberForRegion(number, countryCode) &&
                       phoneNumberUtil.GetNumberType(number) == PhoneNumberType.MOBILE;
            }
            catch (NumberParseException)
            {
                return false; // Invalid phone number format
            }
        }
    }
}
