using AutoMapper;
using Mc2.CrudTest.Service.Core.Customer;
using Mc2CrudTest.Application.Commands.Customer;
using Mc2CrudTest.Application.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Mc2.CrudTest.Domain.Models;

namespace Mc2CrudTest.Application.Handlers.Customer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public UpdateCustomerHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Entity.Customer customerEntity = _mapper.Map<Entity.Customer>(request.Request);

            var res = await _customerService.UpdateAndSaveAsync(customerEntity);

            return new UpdateCustomerResponse { IsSucceed = true, Result = res };
        }
    }
}
