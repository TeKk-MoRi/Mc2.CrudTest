using Mc2CrudTest.Application.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.Queries.Customer
{
    public record GetCustomerByIdQuery(GetCustomerByIdRequest Request) : IRequest<GetCustomerByIdResponse>;
}
