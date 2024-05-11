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
            RuleFor(customer => customer.Request.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

            RuleFor(customer => customer.Request.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

            RuleFor(customer => customer.Request.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required")
                .Must(BeValidDateOfBirth).WithMessage("Invalid date of birth");

            RuleFor(customer => customer.Request.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address format")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters");

            RuleFor(customer => customer.Request.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Must(BeValidPhoneNumber).WithMessage("Invalid phone number format");

            RuleFor(customer => customer.Request.BankAccountNumber)
                .NotEmpty().WithMessage("Bank account number is required")
                .Matches(@"^[0-9]{1,20}$").WithMessage("Invalid bank account number format");
        }

        private bool BeValidDateOfBirth(DateTime dateOfBirth)
        {
            // Add custom logic to validate date of birth if needed
            // For example, ensure date of birth is not in the future
            return dateOfBirth <= DateTime.Today;
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
