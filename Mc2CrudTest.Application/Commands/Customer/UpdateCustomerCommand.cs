using Mc2CrudTest.Application.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.Commands.Customer
{
    public record UpdateCustomerCommand(UpdateCustomerRequest Request) : IRequest<UpdateCustomerResponse>;
}
