using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.DTOs.Customer;
using Mc2CrudTest.Application.Queries.Customer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Testing.Models
{
    public class GetCustomerByIdRequestTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new GetCustomerByIdQuery(new GetCustomerByIdRequest
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

    public class GetCustomerByIdRequestInvalidIdTest : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                    new GetCustomerByIdQuery(new GetCustomerByIdRequest
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
