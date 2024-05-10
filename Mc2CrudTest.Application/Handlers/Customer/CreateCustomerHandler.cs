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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CreateCustomerHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Entity.Customer customerEntity = _mapper.Map<Entity.Customer>(request.Request);

            var res = await _customerService.AddAndSaveAsync(customerEntity);

            return new CreateCustomerResponse { IsSucceed = true, Result = res.Id };
        }
    }
}
