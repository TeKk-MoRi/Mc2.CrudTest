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
    public class DeleteCustomerRequestTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new DeleteCustomerCommand(new DeleteCustomerRequest
                        {
                            Id = 3
                        }
                    )};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class DeleteCustomerRequestInvalidNoTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new DeleteCustomerCommand(new DeleteCustomerRequest
                        {
                            Id = 0
                        }
                    )};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
