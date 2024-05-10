using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.Handlers.Customer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        public CreateCustomerHandler()
        {
                
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
