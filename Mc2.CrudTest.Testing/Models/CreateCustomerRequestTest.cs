using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.DTOs.Customer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Testing.Models
{
    public class CreateCustomerRequestTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new CreateCustomerCommand(new CreateCustomerRequest
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            DateOfBirth = new DateTime(1990, 1, 1),
                            Email = "john.doe@example.com",
                            PhoneNumber = "+14155552671", // Valid mobile number
                            BankAccountNumber = "12345678901234567890" // Valid bank account number
                        }
                    )};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class CreateCustomerRequestInvalidNoTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new CreateCustomerCommand(new CreateCustomerRequest
                        {
                            FirstName = "John",
                            LastName = "Doe",
                            DateOfBirth = new DateTime(1990, 1, 1),
                            Email = "john.doe@example.com",
                            PhoneNumber = "123", // Valid mobile number
                            BankAccountNumber = "12345678901234567890" // Valid bank account number
                        }
                    )};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
