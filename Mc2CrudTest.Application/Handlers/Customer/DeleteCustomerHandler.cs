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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public DeleteCustomerHandler(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = await _customerService.GetByIdAsync(request.Request.Id);
            if (customerEntity == null) { return new DeleteCustomerResponse { IsSucceed = false }; }

            await _customerService.DeleteAndSaveAsync(customerEntity);

            return new DeleteCustomerResponse { IsSucceed = true };
        }
    }
}
